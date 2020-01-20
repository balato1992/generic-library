using GenericLogger.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLogger
{
    public class GLoggerManager
    {
        private GLoggerModel _MessageModel { get; set; }
        private GLoggerModel _DebugModel { get; set; }

        private Dictionary<string, int> DictErrorCount { get; set; }

        public GLoggerManager(Func<object, string> serializer, Func<string, Type, object> deserializer, GLoggerSettings messageSetting, GLoggerSettings debugSetting)
        {
            if (messageSetting.FolderPath == debugSetting.FolderPath)
            {
                messageSetting.FolderPath += "1";
                debugSetting.FolderPath += "2";
            }

            _MessageModel = new GLoggerModel(serializer, deserializer, messageSetting, _SaveOverCount);
            _DebugModel = new GLoggerModel(serializer, deserializer, debugSetting, _SaveOverCount);

            DictErrorCount = new Dictionary<string, int>();
        }

        /// <summary>
        /// return "User Convert, User Write, Debug Convert, Debug Write"
        /// </summary>
        /// <returns></returns>
        public Tuple<Action, Action, Action, Action> SetManualAndGetFunc()
        {
            _MessageModel.UseManualLog = true;
            _DebugModel.UseManualLog = true;

            return new Tuple<Action, Action, Action, Action>(_MessageModel.Data_Convert, _MessageModel.Data_Write, _DebugModel.Data_Convert, _DebugModel.Data_Write);
        }

        public SubLogger CreateSubLogger(string tag)
        {

            SubLogger subLogger = new SubLogger(tag, tag, _MessageModel.Data_Put, _DebugModel.Data_Put);
            subLogger.AddedEvent += (LogInfo obj) =>
            {
                if (obj.LogType == LogTypes.Error)
                {
                    string tagName = obj.Tag;

                    if (!DictErrorCount.ContainsKey(tagName))
                    {
                        DictErrorCount.Add(tagName, 0);
                    }
                    DictErrorCount[tagName] += 1;
                }
            };

            return subLogger;
        }

        public Dictionary<string, string> GetErrorCount()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (var entry in DictErrorCount)
            {
                dict.Add(entry.Key, entry.Value.ToString());
            }

            return dict;
        }

        private void _SaveOverCount(int overCount, int currentCount)
        {
            LogInfo li = new LogInfo(DateTime.Now, LogTypes.Error, "Global.", $"Please check computer status, Log pool has over {overCount} data, current: {currentCount}");
            _MessageModel.Data_WriteAtOnce(li);
        }
    }
}
