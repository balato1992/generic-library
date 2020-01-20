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

        private GLoggerSettings _Setting { get; set; }
        private GLoggerFileController _LoggerFileController { get; set; }
        private GLoggerPool _LoggerPool { get; set; }

        public GLoggerModel(Func<object, string> serializer, Func<string, Type, object> deserializer) : this(serializer, deserializer, new GLoggerSettings())
        {
        }
        public GLoggerModel(Func<object, string> serializer, Func<string, Type, object> deserializer, GLoggerSettings settings)
        {
            _Setting = settings;
            _LoggerFileController = new GLoggerFileController(serializer, deserializer);
        }
        public GLoggerModel(Func<object, string> serializer, Func<string, Type, object> deserializer, GLoggerSettings settings, LogOverCount overCountLog)
        {
            _Setting = settings;
            _LoggerFileController = new GLoggerFileController(serializer, deserializer);
            _LoggerPool = new GLoggerPool(settings.BackupFilePath, overCountLog);
        }

        #region pool
        public bool UseManualLog
        {
            get { return _LoggerPool.UseManualLog; }
            set { _LoggerPool.UseManualLog = value; }
        }
        public int OverCount
        {
            get { return _LoggerPool.OverCount; }
            set { _LoggerPool.OverCount = value; }
        }
        public void Data_Put(LogInfo li)
        {
            _LoggerPool.Put(li);
        }

        public void Data_Convert()
        {
            _LoggerPool.Convert(_LoggerFileController, _Setting, AddEventHandler);
        }
        public void Data_Write()
        {
            _LoggerPool.Write(_LoggerFileController);
        }
        public void Data_WriteAtOnce(LogInfo li, Action<Exception, string> catchAction = null)
        {
            _LoggerPool.WriteAtOnce(_LoggerFileController, _Setting, AddEventHandler, li, catchAction);
        }
        #endregion pool

        public List<string> GetSubNames()
        {
            return _LoggerFileController.GetFolderSubNames(_Setting.FolderPath, new LogInfoFilter())
                .ConvertAll(o => Path.GetFileNameWithoutExtension(o))
                .Distinct()
                .ToList();
        }

        public List<LogInfo> LoadFile(DateTime? dtStart = null, DateTime? dtEnd = null, List<LogTypes> logTypes = null, string subName = null, int maxCount = 100000)
        {
            try
            {
                List<LogInfo> dataInFolder =
                    _LoggerFileController.ReadFromFolder(_Setting.FolderPath, _Setting.FileEncryptionKey, _Setting.FileEncryptionIV,
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