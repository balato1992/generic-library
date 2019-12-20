using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenericModel.Structures;
using System.Collections;

namespace GenericWinForm.Views
{
    public partial class GenericNumericList : UserControl
    {
        public GenericNumericList()
        {
            InitializeComponent();

            MaxValue = decimal.MaxValue;
            MinValue = decimal.MinValue;
            DefaultValue = decimal.Zero;
            AlwaysDescending = false;
        }

        [Description("The max value of the list")]
        public decimal MaxValue { get; set; }

        [Description("The min value of the list")]
        public decimal MinValue { get; set; }

        [Description("The default value of the list")]
        public decimal DefaultValue { get; set; }

        [Description("If is always sort by descending")]
        public bool AlwaysDescending { get; set; }



        public List<decimal> GetValues()
        {
            List<decimal> list = new List<decimal>();

            foreach (DataGridViewRow row in pDataGridView.Rows)
            {
                decimal iNewInteger;
                if (decimal.TryParse(row.Cells[dgvtbc_Value.Name].Value.ToString(), out iNewInteger))
                {
                    list.Add(iNewInteger);
                }

            }

            return list;
        }

        public void SetValues(List<decimal> listValues)
        {
            pDataGridView.Rows.Clear();

            foreach (var value in listValues)
            {
                pDataGridView.Rows.Add(Convert.ToString(value));
            }
        }

        private void pDataGridView_DescendingSort()
        {
            pDataGridView.Sort(new DgvStringSortComparer(ListSortDirection.Descending));
        }

        private void pDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv == null)
            {
                return;
            }

            // Don't try to validate the 'new row' until finished 
            // editing since there
            // is not any point in validating its initial value.
            if (dgv.Rows[e.RowIndex].IsNewRow)
            {
                return;
            }

            dgv.Rows[e.RowIndex].ErrorText = string.Empty;
            decimal iNewInteger;

            string inputValue = e.FormattedValue.ToString();
            if (inputValue.Equals(string.Empty) || !decimal.TryParse(inputValue, out iNewInteger))
            {
                e.Cancel = true;
                dgv.Rows[e.RowIndex].ErrorText = "Value must be a valid number";

                return;
            }

            if (iNewInteger > MaxValue || iNewInteger < MinValue)
            {
                e.Cancel = true;
                dgv.Rows[e.RowIndex].ErrorText = string.Format("Value must be lower than '{0}' and greater than '{1}'", MaxValue, MinValue);

                return;
            }
        }

        private void pDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            pDataGridView_DescendingSort();
        }

        private void pDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            pDataGridView_DescendingSort();
        }



        private void btn_Add_Click(object sender, EventArgs e)
        {
            pDataGridView.Rows.Add(Convert.ToString(DefaultValue));

            if (AlwaysDescending)
            {
                pDataGridView_DescendingSort();
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (pDataGridView.Rows.Count == 1)
            {
                return;
            }

            if (pDataGridView.SelectedRows.Count > 0)
            {
                pDataGridView.Rows.Remove(pDataGridView.SelectedRows[0]);
            }

            if (AlwaysDescending)
            {
                pDataGridView_DescendingSort();
            }
        }
        
    }


    // Implements the manual sorting of items by columns.
    public class DgvStringSortComparer : IComparer
    {
        private int col;
        private ListSortDirection _Direction;

        public DgvStringSortComparer(ListSortDirection direction)
        {
            col = 0;
            _Direction = direction;
        }


        public DgvStringSortComparer(int columnIndex)
        {
            col = columnIndex;
        }

        public virtual int Compare(object x, object y)
        {
            try
            {
                string strX = ((DataGridViewRow)x).Cells[col].Value.ToString();
                string strY = ((DataGridViewRow)y).Cells[col].Value.ToString();

                decimal dX = Convert.ToDecimal(strX);
                decimal dY = Convert.ToDecimal(strY);

                if(_Direction== ListSortDirection.Ascending)
                {
                    return dX.CompareTo(dY); //sort ascending
                }
                else
                {
                    return -dX.CompareTo(dY); //sort descending
                }
            }
            catch
            {
                return 0;
            }
        }
    };

}
