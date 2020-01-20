using GenericLogger.DataStructures;
using GenericModel.File;
using GenericModel.Other;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace GenericLogger
{
    internal class GLoggerFileController
    {
        private static string _DateFormat = "yyyy-MM-dd_HH";

        #region locker
        private ConcurrentDictionary<string, LockerItem> _Lockers { get; set; } = new ConcurrentDictionary<string, LockerItem>();
        private int _LockerClearCount { get; set; } = 0;
        private void _ClearLockerTime()
        {
            if (_LockerClearCount++ < 1000)
            {
                return;
            }
            _LockerClearCount = 0;

            List<string> removeKeys = new List<string>();

            foreach (var entry in _Lockers)
            {
                if (DateTime.Now.Subtract(entry.Value.Time).TotalMinutes >= 15)
                {
                    removeKeys.Add(entry.Key);
                }
            }

            LockerItem tmp = null;
            foreach (string key in removeKeys)
            {
                _Lockers.TryRemove(key, out tmp);
            }
        }
        private object _GetLocker(string path)
        {
            LockerItem item = _Lockers.GetOrAdd(path, new LockerItem(new object(), DateTime.MinValue));

            item.Time = DateTime.Now;
            return item.Locker;
        }
        #endregion locker

        private Func<object, string> _Serializer { get; set; }
        private Func<string, Type, object> _Deserializer { get; set; }

        internal GLoggerFileController(Func<object, string> serializer, Func<string, Type, object> deserializer)
        {
            _Serializer = serializer;
            _Deserializer = deserializer;
        }


        public Dictionary<string, List<string>> CreatePoolItems(string folderPath, bool isEncryption, string encryptionKey, string encryptionIV,
            IEnumerable<LogInfo> lis, Action<Exception, string> catchAction)
        {
            Dictionary<string, List<string>> pool = new Dictionary<string, List<string>>();

            foreach (LogInfo li in lis)
            {
                try
                {
                    string filePath = GetPath(folderPath, li.Time, li.SubName);
                    string serializeObj = GetSerializeObj(_Serializer, li, isEncryption, encryptionKey, encryptionIV);

                    if (!pool.ContainsKey(filePath))
                    {
                        pool.Add(filePath, new List<string>());
                    }
                    pool[filePath].Add(serializeObj);
                }
                catch (Exception ex)
                {
                    string message = li == null ? "" : $"Time: {li.Time}, LogType: {li.LogType}, Tag: {li.Tag}, Message: {li.Message}";

                    catchAction?.Invoke(ex, message);
                }
            }

            return pool;
        }
        public void WritePoolItems(Dictionary<string, List<string>> pool)
        {
            foreach (var entry in pool)
            {
                string filePath = entry.Key;
                List<string> data = entry.Value;

                _ClearLockerTime();
                lock (_GetLocker(filePath))
                {
                    FilePathHelper.CreateFileAndFolder(filePath);
                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                        foreach (string datum in data)
                        {
                            sw.WriteLine(datum);
                        }
                    }
                }
            }
        }

        public static string GetSerializeObj(Func<object, string> serializer, LogInfo ld,
            bool isEncryption, string encryptionKey, string encryptionIV)
        {
            if (ld.LogType == LogTypes.Debug)
            {
                isEncryption = true;
            }

            string serializeInfoObj = serializer(ld);
            if (isEncryption)
            {
                serializeInfoObj = CryptographyHelper.EncryptAES256(serializeInfoObj, encryptionKey, encryptionIV);
            }

            string serializeObj = serializer(new LogData(isEncryption, serializeInfoObj));

            return serializeObj;
        }
        public static string GetPath(string folderPath, DateTime dt, string subName)
        {
            string strTime = dt.ToString(_DateFormat);
            string filePath = null;
            if (string.IsNullOrWhiteSpace(subName))
            {
                filePath = Path.Combine(folderPath, strTime + ".log");
            }
            else
            {
                filePath = Path.Combine(folderPath, strTime, subName + ".log");
            }

            return filePath;
        }

        public List<LogInfo> ReadFromFolder(string folderPath, string encryptionKey, string encryptionIV, LogInfoFilter logInfoFilter, int maxCount)
        {
            if (!Directory.Exists(folderPath))
            {
                return new List<LogInfo>();
            }

            List<string> availableFileNames = new List<string>();
            string[] fileEntries = Directory.GetFiles(folderPath);
            foreach (string path in fileEntries)
            {
                string fileNameWithout = Path.GetFileNameWithoutExtension(path);

                if (File.Exists(path)
                    && Path.GetExtension(path).ToLower() == ".log"
                    && IsAvailableTimeFormat(fileNameWithout, logInfoFilter)
                    && logInfoFilter.IsPassSubName(fileNameWithout))
                {
                    availableFileNames.Add(path);
                }
            }

            List<string> subNames = GetFolderSubNames(folderPath, logInfoFilter);

            availableFileNames.AddRange(subNames);

            List<LogInfo> listLogData = new List<LogInfo>();
            foreach (string fileName in availableFileNames)
            {
                List<LogInfo> dataInFile = _ReadFromFile(fileName, _Deserializer,
                    (string strSerializeInfo) =>
                    {
                        return CryptographyHelper.DecryptAES256(strSerializeInfo, encryptionKey, encryptionIV);
                    }, logInfoFilter, maxCount - listLogData.Count);
                listLogData.AddRange(dataInFile);

                if (listLogData.Count > maxCount)
                {
                    break;
                }
            }
            listLogData = listLogData.OrderBy(o => o.Time).ToList();

            return listLogData;
        }

        public List<string> GetFolderSubNames(string folderPath, LogInfoFilter logInfoFilter)
        {
            List<string> availableFileNames = new List<string>();

            string[] directoryEntries = Directory.GetDirectories(folderPath);
            foreach (string path in directoryEntries)
            {
                if (Directory.Exists(path) && IsAvailableTimeFormat(Path.GetFileName(path), logInfoFilter))
                {
                    string[] directoryFileEntries = Directory.GetFiles(path);
                    foreach (string filePath in directoryFileEntries)
                    {
                        if (File.Exists(filePath)
                            && Path.GetExtension(filePath).ToLower() == ".log"
                            && logInfoFilter.IsPassSubName(Path.GetFileNameWithoutExtension(filePath)))
                        {
                            availableFileNames.Add(filePath);
                        }
                    }
                }
            }

            return availableFileNames;
        }

        private List<LogInfo> _ReadFromFile(string filePath, Func<string, Type, object> deserializer, Func<string, string> decrypt,
            LogInfoFilter logInfoFilter, int maxCount)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }

            List<LogInfo> listLogData = new List<LogInfo>();

            // Read the file and display it line by line.
            lock (_GetLocker(filePath))
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    try
                    {
                        LogInfo logInfo = _GetLogData(line, deserializer, decrypt);

                        if (logInfo != null
                            && logInfoFilter.IsPassTime(logInfo.Time)
                            && logInfoFilter.IsPassLogTypes(logInfo.LogType)
                            && logInfoFilter.IsPassSubName(logInfo.SubName))
                        {
                            listLogData.Add(logInfo);
                        }

                        if (listLogData.Count > maxCount)
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        listLogData.Add(new LogInfo(LogTypes.Error, "Deserialize", ex.Message));
                        listLogData.Add(new LogInfo(LogTypes.ErrorDebug, "Deserialize", ex.Message, line));
                        listLogData.Add(new LogInfo(LogTypes.ErrorDebug, "Deserialize", ex.Message, ex));
                    }
                }
            }

            return listLogData;
        }

        private LogInfo _GetLogData(string line, Func<string, Type, object> deserializer, Func<string, string> decrypt)
        {
            try
            {
                LogData deserializeObj = deserializer?.Invoke(line, typeof(LogData)) as LogData;

                if (deserializeObj != null)
                {
                    string strSerializeInfo = deserializeObj.SerializeInfo;
                    if (deserializeObj.Encryption)
                    {
                        strSerializeInfo = decrypt?.Invoke(strSerializeInfo);
                    }

                    try
                    {
                        return deserializer?.Invoke(strSerializeInfo, typeof(LogInfo)) as LogInfo;
                    }
                    catch
                    {
                        throw new Exception("Error information format");
                    }
                }

                return null;
            }
            catch
            {
                throw new Exception("Error format");
            }
        }

        private static bool IsAvailableTimeFormat(string name, LogInfoFilter logInfoFilter)
        {
            DateTime timeFileName = DateTime.MinValue;

            return (DateTime.TryParseExact(name, _DateFormat, null, DateTimeStyles.None, out timeFileName)
                && logInfoFilter.IsPassTime(timeFileName, _DateFormat));
        }
    }

    internal class LockerItem
    {
        internal object Locker { get; set; }
        internal DateTime Time { get; set; }

        internal LockerItem(object locker, DateTime time)
        {
            Locker = locker;
            Time = time;
        }
    }
}