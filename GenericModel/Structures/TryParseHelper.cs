using System;
using System.ComponentModel;

namespace GenericModel.Structures
{
    public class ConverterHelper
    {
        public static T Parse<T>(object obj, T defaultValue)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (obj != null && converter != null)
                {
                    // Cast ConvertFromString(string text) : object to (T)
                    return (T)converter.ConvertFrom(obj);
                }
            }
            catch
            {
            }
            return defaultValue;
        }

        public static T ParseFromString<T>(string obj, T defaultValue)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    // Cast ConvertFromString(string text) : object to (T)
                    return (T)converter.ConvertFromString(obj);
                }
            }
            catch
            {
            }
            return defaultValue;
        }
    }
}
