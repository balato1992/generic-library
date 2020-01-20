using GenericLogger.DataStructures;
using GenericModel.File;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace GenericLogger
{
    internal class GLoggerPool
    {
        private string _BackupFullPath { get; set; }
        private LogOverCount _OverCountLog { get; set; }

        private ConcurrentQueue<LogInfo> _Data { get; set; }
        private ConcurrentQueue<Dictionary<string, List<string>>> _ConvertedData { get; set; }

        #region 
        private object _LockError { get; set; }
        private DateTime _LastErrorTime { get; set; }
        #endregion
        internal bool UseManualLog { get; set; }
        internal int OverCount { get; set; }

        internal GLoggerPool(string fullpath, LogOverCount overCountLog)
        {
            if (!FilePathHelper.CheckVaild(fullpath))
            {
                throw new Exception("GLoggerPool Error: fullpath not valid");
            }

            _BackupFullPath = fullpath;
            _OverCountLog = overCountLog;

            _Data = new ConcurrentQueue<LogInfo>();
            _ConvertedData = new ConcurrentQueue<Dictionary<string, List<string>>>();
            _LockError = new object();
            _LastErrorTime = DateTime.MinValue;

            UseManualLog = true;
            OverCount = 100 * 1000;
        }

        internal void Put(LogInfo li)
        {
            if (UseManualLog)
            {
                _Data.Enqueue(li);

                if (_Data.Count > OverCount)
                {
                    lock (_LockError)
                    {
                        if ((DateTime.Now - _LastErrorTime).TotalMinutes > 5)
                        {
                            _OverCountLog?.Invoke(OverCount, _Data.Count);

                            _LastErrorTime = DateTime.Now;
                        }
                    }
                }
            }
            else
            {
                string filePath = _BackupFullPath;

                FileHelper.WriteLine(string.Format("{0} - {1}, {2}: {3} | {4}", DateTime.Now, li.LogType, li.Tag, li.Message, li.AdditionalItem), filePath);
                if (li.AdditionalItem != null)
                {
                    FileHelper.WriteLine(string.Format("obj: {0}", li.AdditionalItem), filePath);
                }
            }
        }

        internal void Convert(GLoggerFileController fileController, GLoggerSettings setting, Action<LogInfo> AddEventHandler, Action<Exception, string> catchAction = null)
        {
            List<LogInfo> lis = new List<LogInfo>();
            while (_Data.TryDequeue(out LogInfo li) && lis.Count < 100 * 1000)
            {
                lis.Add(li);
            }

            Dictionary<string, List<string>> dict = _Convert(fileController, setting, AddEventHandler, lis, catchAction);

            _ConvertedData.Enqueue(dict);
        }

        private static Dictionary<string, List<string>> _Convert(GLoggerFileController fileController, GLoggerSettings setting,
            Action<LogInfo> AddEventHandler, List<LogInfo> lis, Action<Exception, string> catchAction = null)
        {
            if (catchAction == null)
            {
                catchAction = (Exception ex, string msg) =>
                {
                    throw ex;
                };
            }

            foreach (LogInfo li in lis)
            {
                try
                {
                    AddEventHandler?.Invoke(li);
                }
                catch (Exception ex)
                {
                    catchAction?.Invoke(ex, "in AddEventHandler");
                }
            }

            Dictionary<string, List<string>> dict = fileController.CreatePoolItems(
                setting.FolderPath, setting.FileEncryption, setting.FileEncryptionKey, setting.FileEncryptionIV,
                lis, catchAction);

            return dict;
        }

        internal void Write(GLoggerFileController fileController)
        {
            while (_ConvertedData.TryDequeue(out Dictionary<string, List<string>> dict))
            {
                fileController.WritePoolItems(dict);
            }
        }
        internal void WriteAtOnce(GLoggerFileController fileController, GLoggerSettings setting, Action<LogInfo> AddEventHandler, LogInfo li, Action<Exception, string> catchAction = null)
        {
            Dictionary<string, List<string>> dict = _Convert(fileController, setting, AddEventHandler, new List<LogInfo>() { li }, catchAction);
            fileController.WritePoolItems(dict);
        }
    }

    public delegate void LogOverCount(int overCount, int currentCount);
}
