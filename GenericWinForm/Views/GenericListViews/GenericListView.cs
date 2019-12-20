using GenericWinForm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GenericWinForm.Views.GenericListViews
{
    public partial class GenericListView : UserControl
    {
        //private Font m_Font = DefaultFont;
        private CheckedItemInfos m_AllItemsInfos;

        #region Browsable Property

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public string SelectAllText { get { return cb_SelectAll.Text; } set { cb_SelectAll.Text = value; } }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public bool CheckBoxes
        {
            get
            {
                return lv_Main.CheckBoxes;
            }
            set
            {
                if (lv_Main.CheckBoxes != value)
                {
                    lv_Main.CheckBoxes = value;

                    if (CheckBoxesChanged != null)
                    {
                        CheckBoxesChanged(this, null);
                    }
                }
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public bool HideUncheckedItems
        {
            get
            {
                return _HideUncheckedItems;
            }
            set
            {
                _HideUncheckedItems = value;
                gstb_Search_SearchTextChanged(gstb_Search, null);
            }
        }

        private bool _HideUncheckedItems { get; set; }

        #endregion Browsable Property

        #region Get Property

        public List<GenericListViewItem> ItemNames { get { return m_AllItemsInfos.GetList(); } }
        public List<GenericListViewItem> SelectedItemNames { get { return lv_Main_GetSelectedItems(); } }
        public List<GenericListViewItem> CheckedItemNames { get { return m_AllItemsInfos.GetCheckedList(); } }

        #endregion Get Property

        #region EventHandler

        public event ItemCheckedEventHandler ItemChecked;

        public event EventHandler AllSelected;

        public event EventHandler SelectedIndexChanged { add { lv_Main.SelectedIndexChanged += value; } remove { lv_Main.SelectedIndexChanged -= value; } }

        private event EventHandler CheckBoxesChanged;

        #endregion EventHandler

        public GenericListView()
        {
            InitializeComponent();

            FontChanged += GenericListView_ChangeSize;
            CheckBoxesChanged += GenericListView_CheckBoxesChanged;

            gstb_Search.ClearText();
            m_AllItemsInfos = new CheckedItemInfos();

            HideUncheckedItems = false;
        }

        public void InitialItems(List<string> items)
        {
            InitialItems(items.ConvertAll(o => new GenericListViewItem(o)));
        }

        public void InitialItems(List<GenericListViewItem> items)
        {
            gstb_Search.ClearText();

            if (items == null)
            {
                items = new List<GenericListViewItem>();
            }
            items = items.Distinct().ToList();

            m_AllItemsInfos.Clear();
            m_AllItemsInfos.Set(items);

            // items is initial with unchecked
            lv_Main_ResetItems(m_AllItemsInfos.GetList());
        }

        /// <summary>
        /// If 'listColumnNames' is null or empty, listView will be 'List', else is 'Details'
        /// </summary>
        /// <param name="listColumnNames"></param>
        public void InitialColumns(List<string> listColumnNames = null)
        {
            lv_Main_InitialColumns(listColumnNames);
        }

        public void CheckInView(List<string> items, bool checkedState)
        {
            lv_Main_Select(items, checkedState);
        }

        public void ChangeItemValue(Dictionary<string, List<string>> dictItemValues)
        {
            foreach (var item in dictItemValues)
            {
                m_AllItemsInfos.SetItem(item.Key, item.Value);
            }

            lv_Main_SetSubItems(m_AllItemsInfos.GetList());
        }

        public void ChangeItemValue(string key, int index, string value)
        {
            m_AllItemsInfos.SetItem(key, index, value);

            lv_Main_SetSubItems(m_AllItemsInfos.GetList());
        }

        public void AutoResizeColumns(ColumnHeaderAutoResizeStyle headerAutoResize)
        {
            lv_Main_AutoResizeColumns(headerAutoResize);
        }

        #region control

        #region lv_Main columns

        private void lv_Main_InitialColumns(List<string> listColumnNames = null)
        {
            lv_Main.Columns.Clear();

            if (listColumnNames == null || listColumnNames.Count == 0)
            {
                lv_Main.View = View.List;
                return;
            }

            lv_Main.View = View.Details;
            foreach (string strColumnName in listColumnNames)
            {
                lv_Main.Columns.Add(lv_Main_CreateColumnHeader(strColumnName));
            }
            lv_Main.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private ColumnHeader lv_Main_CreateColumnHeader(string text)
        {
            ColumnHeader columnHeaher = new ColumnHeader();
            columnHeaher.Text = text;
            columnHeaher.Width = -2;
            columnHeaher.TextAlign = HorizontalAlignment.Center;

            return columnHeaher;
        }

        private void lv_Main_AutoResizeColumns(ColumnHeaderAutoResizeStyle headerAutoResize)
        {
            lv_Main.AutoResizeColumns(headerAutoResize);
        }

        #endregion lv_Main columns

        #region lv_Main items

        private ListViewItem lv_Main_CreateItem(GenericListViewItem glvi)
        {
            List<string> items = new List<string>() { glvi.Key };
            items.AddRange(glvi.Items);

            var lvi = new ListViewItem(items.ToArray());
            lvi.Checked = glvi.IsChecked;
            lvi.Tag = glvi.Data;

            return lvi;
        }

        private void lv_Main_SetSubItems(List<GenericListViewItem> itemNames)
        {
            for (int i = 0; i < lv_Main.Items.Count; i++)
            {
                ListViewItem item = lv_Main.Items[i];

                GenericListViewItem glvi = itemNames.Find(o => o.Key == item.Text);

                if (glvi != null)
                {
                    lv_Main_SetSubItemValue(item, glvi.Items);
                }
            }
        }

        private void lv_Main_SetSubItemValue(ListViewItem item, List<string> itemValues)
        {
            for (int j = 0; j < itemValues.Count; j++)
            {
                string value = itemValues[j];

                if (item.SubItems.Count > j + 1)
                {
                    item.SubItems[j + 1].Text = value;
                }
                else
                {
                    item.SubItems.Add(value);
                }
            }
        }

        private void lv_Main_ResetItems(List<GenericListViewItem> itemNames)
        {
            if (HideUncheckedItems)
            {
                itemNames = itemNames.FindAll(o => o.IsChecked == true).ToList();
            }

            ListViewItem[] arrLvi = itemNames.ConvertAll(o => lv_Main_CreateItem(o)).ToArray();

            // Prevent the control from repainting
            lv_Main.BeginUpdate();

            lv_Main.Items.Clear();
            lv_Main.ItemChecked -= new ItemCheckedEventHandler(lv_Main_ItemChecked);
            lv_Main.Items.AddRange(arrLvi);
            lv_Main.Sort();

            bool isSelectAll = lv_Main_CheckCheckedAll();
            cb_SelectAll_CheckedWithoutEvent(isSelectAll);
            lv_Main.ItemChecked += new ItemCheckedEventHandler(lv_Main_ItemChecked);

            // Turn display back on.
            lv_Main.EndUpdate();
        }

        private void lv_Main_Select(List<string> items, bool checkedState)
        {
            foreach (ListViewItem lvi in lv_Main.Items)
            {
                if (items.Contains(lvi.Text))
                {
                    lvi.Checked = checkedState;
                }
            }
        }

        private void lv_Main_SelectAllWithoutEvent(bool checkedState)
        {
            lv_Main.ItemChecked -= new ItemCheckedEventHandler(lv_Main_ItemChecked);
            foreach (ListViewItem lvi in lv_Main.Items)
            {
                lvi.Checked = checkedState;
                m_AllItemsInfos.Set(lvi.Text, lvi.Checked);
            }
            lv_Main.ItemChecked += new ItemCheckedEventHandler(lv_Main_ItemChecked);
        }

        private bool lv_Main_CheckCheckedAll()
        {
            bool isSelectAll = true;
            foreach (ListViewItem lvi in lv_Main.Items)
            {
                if (!lvi.Checked)
                {
                    isSelectAll = false;
                    break;
                }
            }

            return isSelectAll;
        }

        private List<GenericListViewItem> lv_Main_GetSelectedItems()
        {
            List<string> listSeletedItemTexts = new List<string>();
            foreach (ListViewItem lvi in lv_Main.SelectedItems)
            {
                listSeletedItemTexts.Add(lvi.Text);
            }

            List<GenericListViewItem> listSelectedItems =
                m_AllItemsInfos.GetList().Where(o => listSeletedItemTexts.Contains(o.Key)).ToList();

            return listSelectedItems;
        }

        #endregion lv_Main items

        private void cb_SelectAll_CheckedWithoutEvent(bool isSelectAll)
        {
            cb_SelectAll.CheckedChanged -= new EventHandler(cb_SelectAll_CheckedChanged);
            cb_SelectAll.Checked = isSelectAll;
            cb_SelectAll.CheckedChanged += new EventHandler(cb_SelectAll_CheckedChanged);
        }

        #endregion control

        #region events

        private void lv_Main_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            m_AllItemsInfos.Set(e.Item.Text, e.Item.Checked);

            bool isSelectAll = lv_Main_CheckCheckedAll();

            cb_SelectAll_CheckedWithoutEvent(isSelectAll);

            if (this.ItemChecked != null)
            {
                this.ItemChecked(this, e);
            }
        }

        private void cb_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            lv_Main_SelectAllWithoutEvent(cb_SelectAll.Checked);

            if (this.AllSelected != null)
            {
                this.AllSelected(this, e);
            }
        }

        private void gstb_Search_SearchTextChanged(object sender, EventArgs e)
        {
            GenericSearchTextBox tb = sender as GenericSearchTextBox;

            if (tb == null)
            {
                return;
            }

            if (m_AllItemsInfos != null)
            {
                lv_Main_ResetItems(m_AllItemsInfos.GetList(tb.LastSearchText));
            }
        }

        #region GenericListView

        private void GenericListView_ChangeSize(object sender, EventArgs e)
        {
            tlp_Main.RowStyles[0].Height = ControlHelper.GetSizeWithMargin(gstb_Search).Height;
            if (lv_Main.CheckBoxes)
            {
                tlp_Main.RowStyles[2].Height = 20;
            }
            else
            {
                tlp_Main.RowStyles[2].Height = 0;
            }
        }

        private void GenericListView_CheckBoxesChanged(object sender, EventArgs e)
        {
            bool bIsCheckBoxes = lv_Main.CheckBoxes;

            GenericListView_ChangeSize(null, null);

            cb_SelectAll.Enabled = bIsCheckBoxes;
            cb_SelectAll.Visible = bIsCheckBoxes;
        }

        #endregion GenericListView

        #endregion events
    }
}