using System;
using System.Collections.Generic;
using System.Globalization;

namespace GenericLogger.DataStructures
{
    internal class LogInfoFilter
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public List<LogTypes> ListLogTypes { get; set; }
        public string SubName { get; set; }

        internal LogInfoFilter(DateTime? dtStart = null, DateTime? dtEnd = null, List<LogTypes> logTypes = null, string subName = null)
        {
            Start = dtStart;
            End = dtEnd;
            ListLogTypes = logTypes;
            SubName = subName;
        }

        public bool IsPassTime(DateTime target, string format = null)
        {
            return _DateTimeInRange(Start, End, target, format);
        }
        public bool IsPassLogTypes(LogTypes logType)
        {
            return (ListLogTypes == null || ListLogTypes.Contains(logType));
        }
        public bool IsPassSubName(string subName)
        {
            if (string.IsNullOrWhiteSpace(SubName))
            {
                return true;
            }
            else if (SubName != null && subName !=null)
            {
                return SubName.ToLower() == subName.ToLower();
            }
            else
            {
                return false;
            }
        }



        #region filter
        private static bool _DateTimeInRange(DateTime? start, DateTime? end, DateTime target, string format = null)
        {
            return _OnlyDateCompare(start, target, format) <= 0 && _OnlyDateCompare(end, target, format) >= 0;
        }
        private static int _OnlyDateCompare(DateTime? inputA, DateTime b, string format = null)
        {
            if (inputA == null)
            {
                return 0;
            }

            DateTime a = inputA.Value;
            if (!string.IsNullOrWhiteSpace(format))
            {
                a = _GetFormatDateTime(a, format);
                b = _GetFormatDateTime(b, format);
            }

            return a.CompareTo(b);
        }
        private static DateTime _GetFormatDateTime(DateTime dt, string format)
        {
            string dtFormat = dt.ToString(format);

            DateTime parseTime = DateTime.MinValue;
            if (DateTime.TryParseExact(dtFormat, format, null, DateTimeStyles.None, out parseTime))
            {
                return parseTime;
            }

            return dt;
        }
        #endregion filter

    }
}
