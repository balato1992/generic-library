using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace GenericModel.Structures
{
    public static class EnumHelper
    {
        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }

        public static string GetCustomDescription(object objEnum)
        {
            var fi = objEnum.GetType().GetField(objEnum.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : objEnum.ToString();
        }

        public static string Description(this Enum value)
        {
            return GetCustomDescription(value);
        }

        // reference: https://stackoverflow.com/questions/11361635/foreach-on-enum-types-in-template
        public static IEnumerable<T> ListAll<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Generic argument type must be an Enum.");
            }

            foreach (T value in Enum.GetValues(typeof(T)))
            {
                yield return value;
            }
        }

        public static T Find<T>(string str, T defaultValue = default(T)) where T : struct, IConvertible
        {
            foreach (T value in ListAll<T>())
            {
                if (str == value.ToString())
                {
                    return value;
                }
            }
            return defaultValue;
        }
    }
}
