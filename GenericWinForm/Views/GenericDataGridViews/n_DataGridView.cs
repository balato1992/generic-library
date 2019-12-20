using GenericModel.Structures;
using GenericWinForm.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GenericWinForm.Views.GenericDataGridViews
{
    public partial class n_DataGridView : DataGridView
    {
        public n_DataGridView()
        {
            InitializeComponent();

            Initialize();
        }

        public n_DataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            this.AutoGenerateColumns = false;
        }

        public T AddColumn<T>(
            string strDataPropertyNameAndName,
            string strHeaderText,
            DataGridViewAutoSizeColumnMode AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet,
            bool readOnly = false,
            bool visible = true) where T : DataGridViewColumn, new()
        {
            T dgvc = DataGridViewHelper.CreateColumn<T>(
                strDataPropertyNameAndName,
                strHeaderText,
                AutoSizeMode,
                readOnly,
                visible);

            this.Columns.Add(dgvc);

            return dgvc;
        }

        public void ClearColumns()
        {
            this.Columns.Clear();
        }

        public void SetDataSource(SortableBindingList<object> dataSource)
        {
            this.DataSource = dataSource;
        }

        public SortableBindingList<object> GetDataSource()
        {
            SortableBindingList<object> listRows = this.DataSource as SortableBindingList<object>;

            return listRows;
        }

        public object GetRowObject(int rowIndex)
        {
            SortableBindingList<object> listRows = this.DataSource as SortableBindingList<object>;
            if (listRows == null)
            {
                return null;
            }

            if (rowIndex >= 0 && rowIndex < listRows.Count)
            {
                return listRows[rowIndex];
            }

            return null;
        }

        public T GetRowObject<T>(int rowIndex) where T : class
        {
            object obj = GetRowObject(rowIndex);

            T classObj = obj as T;
            return classObj;
        }

        public List<object> GetAllItems()
        {
            SortableBindingList<object> listObjs = GetDataSource();

            List<object> rtnListObjs = listObjs.ToList();

            return rtnListObjs;
        }

        public List<T> GetAllItems<T>() where T : class
        {
            List<object> listObjs = GetAllItems();

            List<T> rtnListObjs = listObjs.ConvertAll(o => o as T);

            return rtnListObjs;
        }
    }
}
