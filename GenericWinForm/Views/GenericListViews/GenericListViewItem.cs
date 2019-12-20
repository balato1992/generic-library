using GenericModel.Structures;
using System;
using System.Collections.Generic;

namespace GenericWinForm.Views.GenericListViews
{
    public class GenericListViewItem : IComparable<GenericListViewItem>
    {
        private static StringHelper.NaturalStringComparer _Comparer = new StringHelper.NaturalStringComparer();

        public string Key { get; }
        public bool IsChecked { get; set; }
        public List<string> Items { get; set; }
        public object Data { get; set; }

        public GenericListViewItem(string key = "", bool isChecked = false)
        {
            Key = key;
            IsChecked = isChecked;
            Items = new List<string>();
            Data = null;
        }

        public int CompareTo(GenericListViewItem other)
        {
            return _Comparer.Compare(this.Key, other.Key);
        }

        public override bool Equals(object obj)
        {
            var item = obj as GenericListViewItem;

            if (item == null)
            {
                return false;
            }

            return this.Key.Equals(item.Key);
        }

        public override int GetHashCode()
        {
            return this.Key.GetHashCode();
        }
    }
}