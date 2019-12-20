using System.Collections.Generic;
using System.Data;

namespace GenericModel.Structures
{
    public static class DictionaryHelper
    {
        public static void RenameKey<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey fromKey, TKey toKey)
        {
            TValue value = dic[fromKey];
            dic.Remove(fromKey);
            dic[toKey] = value;
        }

        public static Dictionary<string, DataTable> Copy(Dictionary<string, DataTable> dict)
        {
            Dictionary<string, DataTable> rtnDict = new Dictionary<string, DataTable>();
            foreach (var item in dict)
            {
                rtnDict.Add(item.Key, item.Value.Copy());
            }

            return rtnDict;
        }

        public static Dictionary<string, List<string>> Copy(Dictionary<string, List<string>> dict)
        {
            Dictionary<string, List<string>> rtnDict = new Dictionary<string, List<string>>();
            foreach (var item in dict)
            {
                rtnDict.Add(item.Key, new List<string>(item.Value));
            }

            return rtnDict;
        }
    }
}
