using GenericLogger.DataStructures;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace GenericLoggerViewerWpf.Views
{
    public class LogInfoForView : LogInfo
    {
        public string StrTime => Time.ToString("yyyy-MM-dd HH:mm:ss.fff");

        public LogInfoForView(LogInfo info) : base(info)
        {
        }

        public Brush RowForeColor => LogType.GetLogRowForeColor();
        public Brush RowColor => LogType.GetLogRowColor();
        public Visibility HasAppend => (AdditionalItem != null) ? Visibility.Visible : Visibility.Hidden;

        public static List<LogInfoForView> ConvertTo(List<LogInfo> list)
        {
            return list.ConvertAll(o => new LogInfoForView(o)).ToList();
        }
    }
}
