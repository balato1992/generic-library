using System;
using System.Globalization;

namespace GenericModel.Other
{
    public static class DateTimeConverter
    {
        public readonly static string DateTimeFormat = "yyyy/MM/dd HH:mm:ss";
        
        public static DateTime Convert(string datetime)
        {
            return DateTime.ParseExact(datetime, DateTimeFormat, CultureInfo.InvariantCulture);
        }

        public static string Convert(DateTime datetime)
        {
            return datetime.ToString(DateTimeFormat);
        }
    }
}
