using GenericLogger.DataStructures;
using GenericModel.Other;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenericLogger
{
    public class GLoggerModel
    {
        public event Action<LogInfo> AddEventHandler;

        public GLoggerSettings Setting { get; set; }
        private GLoggerFileController _LoggerFileController { get; set; }
        private Func<object, string> _Serializer { get; set; }
        private Func<string, Type, object> _Deserializer { get; set; }

        public GLoggerModel(Func<object, string> serializer, Func<string, Type, object> deserializer)
        {
            Setting = new GLoggerSettings();
            _LoggerFileController = new GLoggerFileController();
            _Serializer = serializer;
            _Deserializer = deserializer;
        }

        //public void Set(LogInfo ld)
        //{
        //    _LoggerFileController.WriteToFile(_Serializer, Setting.FolderPath, ld, Setting.FileEncryption, Setting.FileEncryptionKey, Setting.FileEncryptionIV);

        //    AddEventHandler?.Invoke(ld);
        //}

        public Dictionary<string, List<string>> ConvertToPoolItems(IEnumerable<LogInfo> lis, Action<Exception, string> catchAction = null)
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

            return _LoggerFileController.CreatePoolItems(lis, Setting.FolderPath,
                _Serializer, Setting.FileEncryption, Setting.FileEncryptionKey, Setting.FileEncryptionIV, catchAction);
        }
        public void SaveFromPoolItems(Dictionary<string, List<string>> data)
        {
            _LoggerFileController.WritePoolItems(data);
        }

        public List<string> GetSubNames()
        {
            return _LoggerFileController.GetFolderSubNames(Setting.FolderPath, new LogInfoFilter())
                .ConvertAll(o => Path.GetFileNameWithoutExtension(o))
                .Distinct()
                .ToList();
        }

        public List<LogInfo> LoadFile(DateTime? dtStart = null, DateTime? dtEnd = null, List<LogTypes> logTypes = null, string subName = null, int maxCount = 100000)
        {
            try
            {
                List<LogInfo> dataInFolder =
                    _LoggerFileController.ReadFromFolder(Setting.FolderPath, _Deserializer,
                    (string strSerializeInfo) =>
                    {
                        return CryptographyHelper.DecryptAES256(strSerializeInfo, Setting.FileEncryptionKey, Setting.FileEncryptionIV);
                    },
                    new LogInfoFilter(dtStart, dtEnd, logTypes, subName), maxCount);

                return dataInFolder;
            }
            catch (Exception ex)
            {
                throw new Exception("Load from folder error!", ex);
            }
        }
    }
}