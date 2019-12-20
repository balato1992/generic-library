using GenericModel.Other;
using System;
using System.Diagnostics;

namespace GenericModel.File
{
    public class TextLoggerHelper
    {
        // 0: simple log (simple message about program flow, exception message, and input data when exception)
        // 1: data log (program flow method name, small data)
        // 2: all log (big data, exception detail)
        private static int _UserLevel = 0;
        public static int UserLevel
        {
            get
            {
                return _UserLevel;
            }
            set
            {
                _UserLevel = value;
            }
        }

        #region member variable
        private int _LogLevel = 0;

        private string _FolderPath = AppDomain.CurrentDomain.BaseDirectory + "GOL";
        private string _PostfixName = null;

        private string _FileName_day
        {
            get
            {
                string fileName = GetFileName("yyyy_MM_dd");

                return fileName;
            }
        }

        private string _FileName_second
        {
            get
            {
                string fileName = GetFileName("yyyyMMdd_HHmmss");

                return fileName;
            }
        }
        #endregion member variable


        #region private function
        /// <summary>
        /// Insert current time in front of log
        /// </summary>
        private string InsertTime(string log)
        {
            return string.Format("{0}: {1}", DateTimeConverter.Convert(DateTime.Now), log);
        }

        private string GetFileName(string dateTimeFormat)
        {
            string fileName = DateTime.Now.ToString(dateTimeFormat);

            if (_PostfixName != null)
            {
                fileName += "_" + _PostfixName + ".log";
            }
            else
            {
                fileName += ".log";
            }

            return fileName;
        }
        #endregion private function


        #region constructor
        public TextLoggerHelper(int logLevel)
        {
            this._LogLevel = logLevel;
        }

        public TextLoggerHelper(string postfixName, int logLevel) : this(logLevel)
        {
            this._PostfixName = postfixName;
        }
        #endregion constructor


        public void WriteLine(string log)
        {
            if (_LogLevel <= UserLevel)
            {
                FileHelper.WriteLine(log, _FolderPath + "\\" + _FileName_day);
            }
        }

        public void WriteCover(string log)
        {
            if (_LogLevel <= UserLevel)
            {
                FileHelper.WriteLineCover(log, _FolderPath + "\\" + _FileName_second);
            }
        }

        public void WriteLineWithTime(string log)
        {
            this.WriteLine(this.InsertTime(log));
        }

        public void WriteLineWithTime(Exception exception)
        {
            string prefix = "";
            while (exception != null)
            {
                this.WriteLineWithTime("");
                this.WriteLineWithTime(prefix + " Exception: " + exception.Message);

                var stackTrace = new System.Diagnostics.StackTrace(exception, true);
                string stackIndent = "";
                for (int i = 0; i < stackTrace.FrameCount; i++)
                {
                    // Note that at this level, there are four
                    // stack frames, one for each method invocation.
                    StackFrame sf = stackTrace.GetFrame(i);
                    this.WriteLineWithTime(prefix + stackIndent + " Method: " + sf.GetMethod());
                    this.WriteLineWithTime(prefix + stackIndent + " File: " + sf.GetFileName());
                    this.WriteLineWithTime(prefix + stackIndent + " Line Number: " + sf.GetFileLineNumber());
                    stackIndent += "  ";
                }

                prefix += "   ";
                exception = exception.InnerException;
            }
        }

        public void WriteLineWithTime(Exception exception, string tag)
        {
            this.WriteLine("");
            this.WriteLineWithTime("---" + tag + "---");

            this.WriteLineWithTime(exception);

            string endDash = "------";
            for (int i = 0; i < tag.Length; i++)
            {
                endDash += "-";
            }
            this.WriteLineWithTime(endDash);
        }

    }
}
