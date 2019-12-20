using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GenericModel.Structures
{
    public static class StringHelper
    {
        public static string NullToEmpty(string str)
        {
            return !string.IsNullOrEmpty(str) ? str : "";
        }

        // reference: http://stackoverflow.com/questions/10251133/net-string-isnullorwhitespace-implementation
        public static bool IsNullOrWhiteSpace(String value)
        {
            if (value == null) return true;

            for (int i = 0; i < value.Length; i++)
            {
                if (!Char.IsWhiteSpace(value[i])) return false;
            }

            return true;
        }

        // reference: https://stackoverflow.com/questions/248603/natural-sort-order-in-c-sharp
        // keys.OrderBy(i => i, new StringHelper.NaturalStringComparer());
        #region sorted strings
        /*
            1
            2
            10
            12abc
            123ab
            a1
            a1a1
            a1a2
            a1b1
            a1b2
            a2
            a2a1
            a2a2
            a2b1
            a2b2
            a10
            A1
            A2
            A10
            abc12
            abc123
            b1
            b1a1
            b1a2
            b1b1
            b1b2
            b2
            b2a1
            b2a2
            b2b1
            b2b2
            b10
         */
        #endregion sorted strings
        public class NaturalStringComparer : IComparer<string>
        {
            private static readonly Regex _re = new Regex(@"(?<=\D)(?=\d)|(?<=\d)(?=\D)", RegexOptions.Compiled);

            public int Compare(string x, string y)
            {
                //x = x.ToLower();
                //y = y.ToLower();
                if (string.Compare(x, 0, y, 0, Math.Min(x.Length, y.Length)) == 0)
                {
                    if (x.Length == y.Length) return 0;
                    return x.Length < y.Length ? -1 : 1;
                }
                var a = _re.Split(x);
                var b = _re.Split(y);
                int i = 0;
                while (true)
                {
                    int r = PartCompare(a[i], b[i]);
                    if (r != 0) return r;
                    ++i;
                }
            }

            private static int PartCompare(string x, string y)
            {
                int a, b;
                if (int.TryParse(x, out a) && int.TryParse(y, out b))
                    return a.CompareTo(b);
                return x.CompareTo(y);
            }
        }

    }
}
