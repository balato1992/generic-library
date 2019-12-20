using GenericLogger.DataStructures;
using GenericModel.File;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace GenericLogger
{
    public class GLoggerPool
    {
        private string _BackupFullPath { get; set; }
        private LogOverCount _OverCountLog { get; set; }
        private GLoggerModel _Model { get; set; }
        private ConcurrentQueue<LogInfo> _Pool { get; set; }
        private ConcurrentQueue<Dictionary<string, List<string>>> _ConvertedData { get; set; }

        #region 
        private object _LockError { get; set; }
        private DateTime _LastErrorTime { get; set; }
        #endregion

        public GLoggerPool(string fullpath, LogOverCount overCountLog)
        {
            if (!FilePathHelper.CheckVaild(fullpath))
            {
                throw new Exception("GLoggerPool Error: fullpath not valid");
            }

            _BackupFullPath = fullpath;
            _OverCountLog = overCountLog;
            _Pool = new ConcurrentQueue<LogInfo>();
            _ConvertedData = new ConcurrentQueue<Dictionary<string, List<string>>>();
            _LockError = new object();
            _LastErrorTime = DateTime.MinValue;
        }

        public void SetModel(GLoggerModel model)
        {
            _Model = model;
        }

        private static readonly int _OverCount = 100 * 1000;
        public void Put(LogInfo li)
        {
            if (_Model != null)
            {
                _Pool.Enqueue(li);

                if (_Pool.Count > _OverCount)
                {
                    lock (_LockError)
                    {
                        if ((DateTime.Now - _LastErrorTime).TotalMinutes > 5)
                        {
                            _OverCountLog?.Invoke(_OverCount, _Pool.Count);

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
        public void ConvertData()
        {
            List<LogInfo> lis = new List<LogInfo>();
            LogInfo li;
            while (_Pool.TryDequeue(out li) && lis.Count < 100 * 1000)
            {
                lis.Add(li);
            }

            Dictionary<string, List<string>> item = _Model.ConvertToPoolItems(lis);
            _ConvertedData.Enqueue(item);
        }
        public void Save()
        {
            Dictionary<string, List<string>> item;
            while (_ConvertedData.TryDequeue(out item))
            {
                _Model.SaveFromPoolItems(item);
            }
        }
    }


    public delegate void LogOverCount(int overCount, int currentCount);
}
