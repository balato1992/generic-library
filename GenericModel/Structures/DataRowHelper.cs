using System;
using System.Data;

namespace GenericModel.Structures
{
    public static class DataRowHelper
    {
        public static object GetRowValue(DataRow dr, string columnName)
        {
            object obj = null;

            if (dr.Table.Columns.Contains(columnName))
            {
                if (!DataTableHelper.NullOrDBNull(dr[columnName]))
                {
                    obj = dr[columnName];
                }
            }

            return obj;
        }
        public static double? ToDouble(DataRow dr, string columnName)
        {
            double? rtnValue = null;

            object obj = GetRowValue(dr, columnName);

            if (obj != null)
            {
                try
                {
                    rtnValue = Convert.ToDouble(obj);
                }
                catch
                {

                }
            }

            return rtnValue;
        }
        public static double ToDouble_Nan(DataRow dr, string columnName)
        {
            return ToDouble(dr, columnName) ?? double.NaN;
        }
        public static int? ToInt(DataRow dr, string columnName)
        {
            Int32? rtnValue = null;

            object obj = GetRowValue(dr, columnName);

            if (obj != null)
            {
                try
                {
                    rtnValue = Convert.ToInt32(obj);
                }
                catch
                {

                }
            }

            return rtnValue;
        }
        public static string ToString(DataRow dr, string columnName)
        {
            string rtnValue = null;

            object obj = GetRowValue(dr, columnName);

            if (obj != null)
            {
                try
                {
                    rtnValue = Convert.ToString(obj);
                }
                catch
                {

                }
            }

            return rtnValue;
        }
        public static DateTime? ToDateTime(DataRow dr, string columnName)
        {
            DateTime? rtnValue = null;

            object obj = GetRowValue(dr, columnName);

            if (obj != null)
            {
                try
                {
                    rtnValue = Convert.ToDateTime(obj);
                }
                catch
                {

                }
            }

            return rtnValue;
        }
        public static DateTime ToDateTime_Min(DataRow dr, string columnName)
        {
            return ToDateTime(dr, columnName) ?? DateTime.MinValue;
        }


        public static T ToEnum<T>(DataRow dr, string columnName) where T : struct, IConvertible
        {
            T rtnValue = default(T);

            object obj = GetRowValue(dr, columnName);

            if (obj != null)
            {
                try
                {
                    rtnValue = EnumHelper.Find<T>(obj.ToString());
                }
                catch
                {

                }
            }

            return rtnValue;

        }
    }
}
