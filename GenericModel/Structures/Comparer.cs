using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GenericModel.Structures
{
    public class GenericComparer<T> : IComparer<T>
    {
        private static StringHelper.NaturalStringComparer _NaturalStringComparer = new StringHelper.NaturalStringComparer();

        public int Compare(T x, T y)
        {
            if (x == null)
            {
                return (y == null) ? 0 : -1; //nulls are equal
            }

            if (y == null)
            {
                return 1; //first has value, second doesn't
            }

            if (x is IComparable)
            {
                return ((IComparable)x).CompareTo(y);
            }

            if (x.Equals(y))
            {
                return 0; //both are the same
            }

            int result = _NaturalStringComparer.Compare(x.ToString(), y.ToString());
            //not comparable, compare ToString
            return result;
        }
    }

}
