using GenericLogger.DataStructures;
using GenericModel.Other;
using System;

namespace GenericLogger
{
    public class SubLogger
    {
        private string _Tag { get; set; }
        private string _SubName { get; set; }
        private Action<LogInfo> _LogUser { get; set; }
        private Action<LogInfo> _LogDebug { get; set; }

        public event Action<LogInfo> AddedEvent;

        public SubLogger(string tag, string subName, Action<LogInfo> logUser, Action<LogInfo> logDebug)
        {
            _Tag = tag;
            _SubName = subName;

            _LogUser = logUser;
            _LogDebug = logDebug;
        }

        public void Log(string postfix, LogTypes type, string msg, object obj = null)
        {
            string tag = _Tag + ((string.IsNullOrWhiteSpace(postfix)) ? "" : $"_{postfix}");

            LogInfo li = new LogInfo(DateTime.Now, type, tag, msg, obj, _SubName);
            switch (li.LogType)
            {
                default:
                case LogTypes.Debug:
                case LogTypes.ErrorDebug:
                case LogTypes.Detail:
                    _LogDebug?.Invoke(li);
                    break;

                case LogTypes.Info:
                case LogTypes.Warn:
                case LogTypes.Error:
                    _LogUser?.Invoke(li);
                    break;
            }

            AddedEvent?.Invoke(li);
        }

        public void Log(LogTypes type, string msg, object obj = null)
        {
            Log(null, type, msg, obj);
        }
        
        public void LogInfo(string msg)
        {
            Log(LogTypes.Info, msg);
        }

        public void LogFullError(string postfix, Exception ex, string msgPrefix = null)
        {
            Log(postfix, LogTypes.Error, msgPrefix + ExceptionHelper.GetExceptionAllMessage(ex));
            Log(postfix, LogTypes.ErrorDebug, msgPrefix + ExceptionHelper.GetExceptionAllMessage(ex), ex);
        }

        public void LogFullError(Exception ex)
        {
            LogFullError(null, ex);
        }
    }
}
