using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericModel.Structures
{
    public static class IntHelper
    {
        public static int ToNumber(string str, int defaultValue)
        {
            int number = int.MinValue;
            if (!int.TryParse(str, out number))
            {
                number = defaultValue;
            }

            return number;
        }
    }
}
