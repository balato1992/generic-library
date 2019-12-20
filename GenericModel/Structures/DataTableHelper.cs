using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GenericModel.Structures
{
    public static class DataTableHelper
    {
        public static List<string> GetUniqueDataListByHeader(DataTable dt, string header)
        {
            // if it does not exist header, return null
            if (!dt.Columns.Contains(header))
                return null;

            // Get all data in the column
            List<string> tmpList = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                string data = row[header].ToString();

                // remove empty string data
                if (data != "")
                {
                    tmpList.Add(data);
                }
            }


            // Return unique data
            return tmpList.Distinct().ToList();
        }

        public static string GetColumnDataToString(DataTable dt, string header, string separator)
        {
            string dataString = null;

            if (dt.Columns.Contains(header))
            {
                dataString = "";

                foreach (DataRow dr in dt.Rows)
                {
                    dataString += dr[header] + separator;
                }
            }

            return dataString;
        }

        public static List<string> GetColumnToList(DataTable dt, string targetColumnName, Dictionary<string, List<string>> selectedConditions)
        {
            string dtSelectQuery = "";


            bool firstTime = true;
            foreach (var item in selectedConditions)
            {
                string key = item.Key;
                List<string> values = item.Value;

                if (!firstTime)
                {
                    dtSelectQuery += "AND";
                }
                else
                {
                    firstTime = false;
                }

                dtSelectQuery += "(";
                if (values == null)
                {
                    dtSelectQuery += "1=1";
                }
                else if (values.Count > 0)
                {
                    bool firstOrCondition = true;
                    foreach (string value in values)
                    {
                        if (!firstOrCondition)
                        {
                            dtSelectQuery += "OR";
                        }
                        else
                        {
                            firstOrCondition = false;
                        }

                        dtSelectQuery += string.Format(" {0} = '{1}' ", key, value);
                    }
                }
                else
                {
                    dtSelectQuery += "1=0";
                }
                dtSelectQuery += ")";



            }


            DataTable filteredDT = dt.Select(dtSelectQuery).CopyToDataTable();

            return filteredDT.AsEnumerable().Select(x => x[targetColumnName].ToString()).ToList();
        }


        public static string FindColumnValueByKey(DataTable dt, object searchKey, string columnName)
        {
            if (dt.PrimaryKey == null || dt.PrimaryKey.Count() == 0)
            {
                return null;
            }
            if (!dt.Columns.Contains(columnName))
            {
                return null;
            }


            DataRow dr = dt.Rows.Find(searchKey);

            if (dr == null)
            {
                return null;
            }


            return dr[columnName].ToString();

        }


        public static string ToDebugString(DataTable dt)
        {
            string str = "";
            str += "\r\n";
            str += "------ColumnName----------";
            str += "\r\n";

            foreach (DataColumn column in dt.Columns)
            {
                str += column.ColumnName + " | ";
                str += "\r\n";
            }

            str += "\r\n";
            str += "------DataType----------";
            str += "\r\n";
            foreach (DataColumn column in dt.Columns)
            {
                str += column.DataType + " | ";
                str += "\r\n";
            }

            str += "\r\n";
            str += "--------VALUE--------";
            str += "\r\n";
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    str += row[column] + " | ";
                    str += "\r\n";
                }
                str += "\r\n";
            }
            str += "----------------";
            str += "\r\n";

            return str;
        }

        public static string ToCsvString(DataTable dt)
        {
            string str = "";

            foreach (DataColumn dc in dt.Columns)
            {
                if (dt.Columns.IndexOf(dc) != 0)
                {
                    str += ",";
                }
                str += dc.ColumnName;
            }

            str += "\r\n";

            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dt.Columns.IndexOf(dc) != 0)
                    {
                        str += ",";
                    }
                    str += dr[dc].ToString();
                }
                str += "\r\n";
            }

            return str;
        }


        public static bool NullOrDBNull(object obj)
        {
            if (obj == DBNull.Value || obj == null)
            {
                return true;
            }

            return false;
        }

    }
}
