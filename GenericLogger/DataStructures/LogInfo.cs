using GenericModel.File;
using GenericModel.Other;
using System;

namespace GenericLogger.DataStructures
{
    public class LogInfo
    {
        #region properties

        // log time
        public DateTime Time { get; set; }

        // message type
        public LogTypes LogType { get; set; }

        // message type
        public string Tag { get; set; }

        // message to read
        public string Message { get; set; }

        // append item, should be able to be serialize by NewtonsoftJson
        public object AdditionalItem { get; set; }


        private string _SubName { get; set; }
        public string SubName
        {
            get { return _SubName; }
            set
            {
                _SubName = (value != null) ? FileHelper.MakeValidFileName(value) : null;
            }
        }

        #endregion properties

        public LogInfo()
            : this(DateTime.Now, LogTypes.Info, string.Empty, string.Empty, null, null)
        { }

        public LogInfo(LogTypes type, string tag, string message, object appendObj = null, string subName = null)
            : this(DateTime.Now, type, tag, message, appendObj, subName)
        { }

        public LogInfo(DateTime dt, LogTypes type, string tag, string message, object appendObj = null, string subName = null)
        {
            this.Time = dt;
            this.LogType = type;
            this.Tag = tag;
            this.Message = message;
            this.AdditionalItem = appendObj;
            this.SubName = subName;
        }

        public LogInfo(LogInfo obj)
            : this(obj.Time, obj.LogType, obj.Tag, obj.Message, obj.AdditionalItem, obj.SubName)
        { }

        public static LogInfo CreateSampleData()
        {
            LogInfo ld = new LogInfo();

            ld.Time = RandomHelper.GetDateTime(DateTime.Now);
            ld.LogType = RandomHelper.GetEnum<LogTypes>();
            ld.Tag = "Tag" + RandomHelper.StaticRandom.Next(100);
            ld.Message = "Message" + RandomHelper.StaticRandom.Next(100);
            ld.AdditionalItem = "Item" + RandomHelper.StaticRandom.Next(100);

            return ld;
        }
    }
}