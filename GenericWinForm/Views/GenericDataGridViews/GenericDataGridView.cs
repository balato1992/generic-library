using GenericWinForm.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using GenericModel.Structures;

namespace GenericWinForm.Views.GenericDataGridViews
{
    public partial class GenericDataGridView : UserControl
    {
        public event DataGridViewCellEventHandler CellValueChanged { add { n_dgv_Main.CellValueChanged += value; } remove { n_dgv_Main.CellValueChanged -= value; } }
        private DataGridViewCheckBoxColumn _dgvi_Checker { get; set; }

        private CompleteItemList _CompleteItemList = new CompleteItemList();

        public GenericDataGridView()
        {
            InitializeComponent();

            _dgvi_Checker = null;
        }

        #region public functions

        #region Checker
        public void SetChecker(DataGridViewCheckBoxColumn checker)
        {
            _dgvi_Checker = checker;
        }

        public bool CheckerExist()
        {
            return (_dgvi_Checker != null && n_dgv_Main.Columns.Contains(_dgvi_Checker));
        }

        public List<ICheckedItemInfo> GetCheckedItems()
        {
            return _CompleteItemList.GetCheckedItems();
        }

        public List<T> GetCheckedItems<T>() where T : class, ICheckedItemInfo
        {
            return _CompleteItemList.GetCheckedItems<T>();
        }

        public void Check(string key, bool bIsChecked)
        {
            _CompleteItemList.Check(key, bIsChecked);
        }
        public void CheckAll(bool bIsChecked)
        {
            n_dgv_Main_CheckAll(bIsChecked);
        }

        #endregion Checker

        public T AddColumn<T>(
            string strDataPropertyNameAndName,
            string strHeaderText,
            DataGridViewAutoSizeColumnMode AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet,
            bool readOnly = false,
            bool visible = true) where T : DataGridViewColumn, new()
        {
            return n_dgv_Main.AddColumn<T>(
               strDataPropertyNameAndName,
               strHeaderText,
               AutoSizeMode,
               readOnly,
               visible);
        }
        public void ClearColumns()
        {
            n_dgv_Main.ClearColumns();
        }
        public void SetDataSource<T>(List<T> data) where T : class, ICheckedItemInfo
        {
            if (data == null)
            {
                _CompleteItemList.Clear();
            }
            else
            {
                foreach (T datum in data)
                {
                    _CompleteItemList.Set(datum);
                }
            }

            n_dgv_Main_ResetData(gstb_Search.LastSearchText);
        }
        public T GetRowObject<T>(int rowIndex) where T : class, ICheckedItemInfo
        {
            return n_dgv_Main.GetRowObject<T>(rowIndex);
        }

        public List<T> GetAllItems<T>() where T : class, ICheckedItemInfo
        {
            return _CompleteItemList.GetItems<T>();
        }

        public List<T> GetAllItemsInView<T>() where T : class, ICheckedItemInfo
        {
            return n_dgv_Main.GetAllItems<T>();
        }

        public void SetSearchText(string searchText)
        {
            gstb_Search.Focus();
            System.Windows.Forms.SendKeys.Send(searchText);
        }

        public void CancelAndEndEdit()
        {
            n_dgv_Main.CancelEdit();
            n_dgv_Main.EndEdit();
        }

        #endregion public functions

        #region private functions
        private void cb_SelectAll_SedCheckedState()
        {
            this.cb_SelectAll.CheckedChanged -= new System.EventHandler(this.cb_SelectAll_CheckedChanged);

            List<ICheckedItemInfo> listCheckedItems = n_dgv_Main.GetAllItems<ICheckedItemInfo>();
            var test = listCheckedItems.Where(o => o.IsChecked == false).ToList().Count();
            bool bIsCheckedAll = listCheckedItems.Where(o => o.IsChecked == false).Count() == 0;
            cb_SelectAll.Checked = bIsCheckedAll;

            this.cb_SelectAll.CheckedChanged += new System.EventHandler(this.cb_SelectAll_CheckedChanged);
        }

        private void n_dgv_Main_ResetData(string searchText)
        {
            if (_CompleteItemList != null)
            {
                n_dgv_Main.SetDataSource(null);
                var listItemsWithText = _CompleteItemList.GetItems<object>(searchText);
                listItemsWithText.Sort(new GenericComparer<object>());
                var sortableList = new SortableBindingList<object>(listItemsWithText, new GenericComparer<object>());
                n_dgv_Main.SetDataSource(sortableList);

                cb_SelectAll_SedCheckedState();
            }
        }
        private void n_dgv_Main_CheckAll(bool bIsChecked)
        {
            for (int i = 0; i < n_dgv_Main.Rows.Count; i++)
            {
                n_dgv_Main[_dgvi_Checker.Index, i].Value = bIsChecked;
            }
        }
        #endregion private functions

        #region events

        /// <summary>
        /// CommitEdit when click or double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Main_CommitEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (CheckerExist() && e.ColumnIndex == _dgvi_Checker.Index)
            {
                n_dgv_Main.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgv_Main_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (CheckerExist() && e.ColumnIndex == _dgvi_Checker.Index)
            {
                cb_SelectAll_SedCheckedState();
            }
        }

        private void cb_SelectAll_CheckedChanged(object sender, System.EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb == null || !CheckerExist())
            {
                return;
            }

            bool bIsChecked = true;
            if (cb.Checked == false)
            {
                List<ICheckedItemInfo> listCheckedItems = n_dgv_Main.GetAllItems<ICheckedItemInfo>();
                if (listCheckedItems.Where(o => o.IsChecked == false).ToList().Count() == 0)
                {
                    bIsChecked = false;
                }
            }

            n_dgv_Main_CheckAll( bIsChecked);
        }

        private void gstb_Search_TextChanged(object sender, System.EventArgs e)
        {
            GenericSearchTextBox tb = sender as GenericSearchTextBox;

            if (tb == null)
            {
                return;
            }

            n_dgv_Main_ResetData(tb.LastSearchText);
        }
        #endregion events

    }
}
