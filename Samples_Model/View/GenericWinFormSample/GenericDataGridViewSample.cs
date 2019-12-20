using GenericModel.Other;
using MyModelSample.View._styles;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyModelSample.View.GenericWinFormSample
{
    public partial class GenericDataGridViewSample : Form
    {
        private List<SampleTestClass> _dataSource { get; set; }

        public GenericDataGridViewSample()
        {
            InitializeComponent();
        }

        private void Valid_CheckKey(List<string> checkedKeys, bool bIsChecked)
        {
            foreach (string key in checkedKeys)
            {
                pGenericDataGridView.Check(key, bIsChecked);
            }
        }

        private void Valid_CheckAll(bool bIsChecked)
        {
            pGenericDataGridView.CheckAll(bIsChecked);
        }

        private void Valid_Search(string strText)
        {
            pGenericDataGridView.SetSearchText(strText);
        }

        #region events

        private void btn_SetColumn_Click(object sender, EventArgs e)
        {
            DataGridViewColumn dgviKey = pGenericDataGridView.AddColumn<DataGridViewTextBoxColumn>
             (ReflectionUtility.GetPropertyName(() => (new SampleTestClass()).Key), "Key");
            dgviKey.Width = 80;

            DataGridViewCheckBoxColumn dgviChecker = pGenericDataGridView.AddColumn<DataGridViewCheckBoxColumn>
                (ReflectionUtility.GetPropertyName(() => (new SampleTestClass()).IsChecked), "");
            dgviChecker.Width = 25;

            DataGridViewColumn dgviString1 = pGenericDataGridView.AddColumn<DataGridViewTextBoxColumn>
                (ReflectionUtility.GetPropertyName(() => (new SampleTestClass()).String1), "String1Header");
            dgviString1.Width = 80;

            DataGridViewColumn dgviString2 = pGenericDataGridView.AddColumn<DataGridViewTextBoxColumn>
                (ReflectionUtility.GetPropertyName(() => (new SampleTestClass()).String2), "String2Header");
            dgviString1.Width = 120;

            DataGridViewColumn dgviString3 = pGenericDataGridView.AddColumn<DataGridViewTextBoxColumn>
                (ReflectionUtility.GetPropertyName(() => (new SampleTestClass()).String3), "String3Header");
            dgviString1.Width = 200;

            pGenericDataGridView.SetChecker(dgviChecker);
        }

        private void btn_ClearColumns_Click(object sender, EventArgs e)
        {
            pGenericDataGridView.ClearColumns();
        }

        private void btn_MakeRandomData_Click(object sender, EventArgs e)
        {
            _dataSource = new List<SampleTestClass>();

            int dataCount = RandomHelper.StaticRandom.Next(5, 10 + 1);
            for (int i = 0; i < dataCount; i++)
            {
                _dataSource.Add(SampleTestClass.MakeRandonData());
            }

            pGenericDataGridView.SetDataSource<SampleTestClass>(null);
            pGenericDataGridView.SetDataSource(_dataSource);
        }

        private void btn_MakeSerialData_Click(object sender, EventArgs e)
        {
            _dataSource = SampleTestClass.MakeSerialList(20);

            pGenericDataGridView.SetDataSource<SampleTestClass>(null);
            pGenericDataGridView.SetDataSource(_dataSource);
        }

        private void btn_GetRowObject_Click(object sender, EventArgs e)
        {
            try
            {
                SampleTestClass realObj = pGenericDataGridView.GetRowObject<SampleTestClass>(Convert.ToInt32(nud_RowIndex.Value));

                pSampleTestClassControl.Data = realObj;
            }
            catch
            {
            }
        }

        private void btn_GetAllItems_Click(object sender, EventArgs e)
        {
            rtb_GetInfo.ResetText();

            var items = pGenericDataGridView.GetAllItems<SampleTestClass>();

            foreach (var item in items)
            {
                rtb_GetInfo.AppendText(item.ToString() + "\r\n");
            }
        }

        private void btn_GetCheckedItems_Click(object sender, EventArgs e)
        {
            rtb_GetInfo.ResetText();

            var items = pGenericDataGridView.GetCheckedItems<SampleTestClass>();

            foreach (var item in items)
            {
                rtb_GetInfo.AppendText(item.ToString() + "\r\n");
            }
        }

        private void btn_UnitTest_Click(object sender, EventArgs e)
        {
            btn_ClearColumns.PerformClick();
            btn_SetColumn.PerformClick();
            btn_MakeSerialData.PerformClick();

            rtb_UnitTestMessage.ResetText();

            Valid_CheckKey(_dataSource.ConvertAll(o => o.Key), true);

            var AllItem = pGenericDataGridView.GetAllItems<SampleTestClass>();
            var CheckedItems = pGenericDataGridView.GetCheckedItems();
            rtb_UnitTestMessage.Text += string.Format("AllItem count: {0}\r\nCheckedItems count: {1}", AllItem.Count, CheckedItems.Count);

            Valid_Search("2");

            AllItem = pGenericDataGridView.GetAllItems<SampleTestClass>();
            CheckedItems = pGenericDataGridView.GetCheckedItems();
            rtb_UnitTestMessage.Text += string.Format("AllItem count: {0}\r\nCheckedItems count: {1}", AllItem.Count, CheckedItems.Count);

            Valid_CheckAll(false);

            AllItem = pGenericDataGridView.GetAllItems<SampleTestClass>();
            CheckedItems = pGenericDataGridView.GetCheckedItems();
            rtb_UnitTestMessage.Text += string.Format("AllItem count: {0}\r\nCheckedItems count: {1}", AllItem.Count, CheckedItems.Count);

            Valid_Search("");

            AllItem = pGenericDataGridView.GetAllItems<SampleTestClass>();
            CheckedItems = pGenericDataGridView.GetCheckedItems();
            rtb_UnitTestMessage.Text += string.Format("AllItem count: {0}\r\nCheckedItems count: {1}", AllItem.Count, CheckedItems.Count);

            //rtb_UnitTestMessage.Text += string.Format("AllItem count: {0}\r\nCheckedItems count: {1}", AllItem.Count, CheckedItems.Count);
        }

        #endregion events
    }
}