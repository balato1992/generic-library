using GenericLogger.DataStructures;
using System.Windows.Media;

namespace GenericLoggerViewerWpf.Views
{
    internal static class LogTypesExtensions
    {
        public static SolidColorBrush GetLogRowColor(this LogTypes type)
        {
            switch (type)
            {
                case LogTypes.Error:
                    return new SolidColorBrush(Color.FromRgb(255, 235, 235));

                case LogTypes.Warn:
                    return new SolidColorBrush(Color.FromRgb(255, 255, 200));

                case LogTypes.Info:
                    return new SolidColorBrush(Color.FromRgb(235, 245, 255));

                case LogTypes.Debug:
                    return new SolidColorBrush(Color.FromRgb(0xAB, 0x47, 0xBC));

                case LogTypes.ErrorDebug:
                    return new SolidColorBrush(Color.FromRgb(0xFF, 0x77, 0x77));

                default:
                    return Brushes.Transparent;
            }
        }

        public static SolidColorBrush GetLogRowForeColor(this LogTypes type)
        {
            switch (type)
            {
                case LogTypes.Error:
                    return new SolidColorBrush(Color.FromRgb(255, 15, 59));
                case LogTypes.Info:
                    return new SolidColorBrush(Color.FromRgb(0, 83, 255));
                case LogTypes.Debug:
                    return new SolidColorBrush(Color.FromRgb(255, 255, 255));
                case LogTypes.Warn:
                case LogTypes.ErrorDebug:
                    return new SolidColorBrush(Color.FromRgb(0, 0, 0));
                default:
                    return Brushes.Black;
            }
        }
    }
}
