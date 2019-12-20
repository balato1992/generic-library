using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericModel.Structures
{
    public static class NumberHelper
    {
        /// <summary>
        /// If 'value' is greater than 'upperBound' than get max below 'upperBound', or get 'value'
        /// </summary>
        /// <param name="value"></param>
        /// <param name="upperBound"></param>
        /// <returns></returns>
        public static int LimitToUpperBound(int value, decimal upperBound)
        {
            if (value > upperBound)
            {
                return (int)Math.Floor(upperBound);
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// If 'value' is less than 'lowerBound' than get min above 'lowerBound', or get 'value'
        /// </summary>
        /// <param name="value"></param>
        /// <param name="lowerBound"></param>
        /// <returns></returns>
        public static int LimitToLowerBound(int value, decimal lowerBound)
        {
            if (value < lowerBound)
            {
                return (int)Math.Ceiling(lowerBound);
            }
            else
            {
                return value;
            }
        }
    }
}
