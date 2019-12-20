namespace GenericModel.File
{
    public class TextLoggers
    {
        // common situation, write data in initial path
        private static TextLoggerHelper _Logger = new TextLoggerHelper(0);
        private static TextLoggerHelper _Debugger = new TextLoggerHelper("debug", 1);
        private static TextLoggerHelper _DeepDebugger = new TextLoggerHelper("deepDebug", 2);
        private static TextLoggerHelper _Warning = new TextLoggerHelper("MessageDD", 2);

        public static TextLoggerHelper Logger { get { return _Logger; } }
        public static TextLoggerHelper Debugger { get { return _Debugger; } }
        public static TextLoggerHelper DeepDebugger { get { return _DeepDebugger; } }
        public static TextLoggerHelper Warning { get { return _Warning; } }

        // give a file name, write data and cover target file
        public static void WriteCover(string log, string fileName)
        {
            new TextLoggerHelper(fileName, 0).WriteCover(log);
        }
        public static void WriteCoverDebugger(string log, string fileName)
        {
            new TextLoggerHelper(fileName, 1).WriteCover(log);
        }
        public static void WriteCoverDeepDebugger(string log, string fileName)
        {
            new TextLoggerHelper(fileName, 2).WriteCover(log);
        }
    }
}
