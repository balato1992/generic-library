using System.Collections.Generic;
using System.Linq;

namespace GenericWinForm.Views.GenericDataGridViews
{
    public class CompleteItemList
    {
        private SortedDictionary<string, object> m_AllItems;

        public CompleteItemList()
        {
            m_AllItems = new SortedDictionary<string, object>();
        }

        public ICheckedItemInfo this[string key]
        {
            get
            {
                return m_AllItems[key] as ICheckedItemInfo;
            }
            set
            {
                m_AllItems[key] = value;
            }
        }

        public void Set<T>(T item) where T : class, ICheckedItemInfo
        {
            string key = item.Key;

            if (!m_AllItems.ContainsKey(key))
            {
                m_AllItems.Add(key, item);
            }
            else
            {
                m_AllItems[key] = item;
            }
        }

        public void Check(string key, bool bIsChecked)
        {
            if (m_AllItems.ContainsKey(key))
            {
                var item = m_AllItems[key] as ICheckedItemInfo;
                if (item != null)
                {
                    item.IsChecked = bIsChecked;
                }
            }
        }

        public void Clear()
        {
            m_AllItems.Clear();
        }

        public List<T> GetItems<T>(string searchText = null) where T : class
        {
            IEnumerable<KeyValuePair<string, object>> listAllItems = m_AllItems.ToList();

            if (!string.IsNullOrEmpty(searchText))
            {
                foreach (var k in listAllItems)
                {
                    var key = k.Key;
                    var kk = key.IndexOf(searchText) >= 0;
                }

                listAllItems = listAllItems.Where(o => o.Key.IndexOf(searchText) >= 0);
            }

            List<T> listItems = listAllItems.Select(o => o.Value as T).ToList();

            return listItems;
        }

        public List<ICheckedItemInfo> GetCheckedItems(List<string> listSearchKeys = null)
        {
            var checkedItems = GetCheckedItems<ICheckedItemInfo>(listSearchKeys);

            return checkedItems;
        }

        /// <summary>
        /// Get checked items in listSearchKeys
        /// </summary>
        /// <param name="listSearchKeys"></param>
        /// <returns></returns>
        public List<T> GetCheckedItems<T>(List<string> listSearchKeys = null) where T : class, ICheckedItemInfo
        {
            List<T> listCheckedItems = new List<T>();

            foreach (var item in m_AllItems)
            {
                string key = item.Key;
                T value = item.Value as T;

                if (value != null && value.IsChecked == true)
                {
                    if (listSearchKeys == null || listSearchKeys.Contains(key))
                    {
                        listCheckedItems.Add(value);
                    }
                }
            }

            return listCheckedItems;
        }
    }


    public interface ICheckedItemInfo
    {
        string Key { get; }
        bool IsChecked { get; set; }
    }
}
