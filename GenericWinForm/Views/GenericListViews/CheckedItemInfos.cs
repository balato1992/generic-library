using GenericModel.Structures;
using System.Collections.Generic;
using System.Linq;

namespace GenericWinForm.Views.GenericListViews
{
    public class CheckedItemInfos
    {
        private SortedDictionary<string, GenericListViewItem> m_AllItemsInfos;

        public CheckedItemInfos()
        {
            m_AllItemsInfos = new SortedDictionary<string, GenericListViewItem>(new StringHelper.NaturalStringComparer());
        }

        public void Set(GenericListViewItem iglvi)
        {
            string key = iglvi.Key;
            GenericListViewItem value = iglvi;

            if (!m_AllItemsInfos.ContainsKey(key))
            {
                m_AllItemsInfos.Add(key, value);
            }
            else
            {
                m_AllItemsInfos[key] = value;
            }
        }

        public void Set(List<GenericListViewItem> listGlvi)
        {
            foreach (GenericListViewItem glvi in listGlvi)
            {
                Set(glvi);
            }
        }

        public void Set(string key, bool isChecked)
        {
            if (!m_AllItemsInfos.ContainsKey(key))
            {
                m_AllItemsInfos.Add(key, new GenericListViewItem(key, isChecked));
            }
            else
            {
                m_AllItemsInfos[key].IsChecked = isChecked;
            }
        }

        public void Set(List<string> keys, bool isChecked)
        {
            foreach (string key in keys)
            {
                Set(key, isChecked);
            }
        }

        public void SetItem(string key, List<string> items)
        {
            if (m_AllItemsInfos != null && m_AllItemsInfos.ContainsKey(key))
            {
                m_AllItemsInfos[key].Items = items;
            }
        }

        public void SetItem(string key, int index, string value)
        {
            if (m_AllItemsInfos != null && m_AllItemsInfos.ContainsKey(key))
            {
                int lackIndexCount = index - (m_AllItemsInfos[key].Items.Count - 1);

                for (int i = 0; i < lackIndexCount; i++)
                {
                    m_AllItemsInfos[key].Items.Add(string.Empty);
                }
                m_AllItemsInfos[key].Items[index] = value;
            }
        }

        public void Clear()
        {
            m_AllItemsInfos.Clear();
        }

        public List<GenericListViewItem> GetList(string searchText = null)
        {
            List<GenericListViewItem> listItems = null;
            if (!string.IsNullOrEmpty(searchText))
            {
                listItems = m_AllItemsInfos.Where(o => o.Key.IndexOf(searchText) >= 0).Select(o => o.Value).ToList();
            }
            else
            {
                listItems = m_AllItemsInfos.Select(o => o.Value).ToList();
            }

            return listItems;
        }

        public List<GenericListViewItem> GetCheckedList(List<string> listSearchKeys = null)
        {
            List<GenericListViewItem> listCheckItems = null;

            if (listSearchKeys != null)
            {
                listCheckItems = m_AllItemsInfos.Where(o => listSearchKeys.Contains(o.Key) && o.Value.IsChecked == true).Select(o => o.Value).ToList();
            }
            else
            {
                listCheckItems = m_AllItemsInfos.Where(o => o.Value.IsChecked == true).Select(o => o.Value).ToList();
            }

            return listCheckItems;
        }
    }
}