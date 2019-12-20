using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GenericWinForm.Views.GenericListViews
{
    /// <summary>
    /// Avoiding the item being checked when multiselect the rows.
    /// <para>Reference: https://stackoverflow.com/questions/2017170/c-sharp-listview-with-checkboxes-automatic-checkbox-checked-when-multi-select-r</para>
    /// </summary>
    public partial class n_ListView : ListView
    {
        private bool mouseDown = false;

        public n_ListView() : base()
        {
            InitializeComponent();

            SetupListView();
        }

        public n_ListView(IContainer container) : base()
        {
            container.Add(this);

            InitializeComponent();

            SetupListView();
        }

        private void SetupListView()
        {
            this.ItemCheck += new ItemCheckEventHandler(listView_ItemCheck);
            this.MouseDown += new MouseEventHandler(listView_MouseDown);
            this.MouseUp += new MouseEventHandler(listView_MouseUp);
            this.MouseLeave += new EventHandler(listView_MouseLeave);
        }

        private void listView_MouseLeave(object sender, EventArgs e)
        {
            mouseDown = false;
        }

        private void listView_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void listView_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void listView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (mouseDown)
            {
                e.NewValue = e.CurrentValue;
            }
            else
            {
                this.ItemCheck -= new ItemCheckEventHandler(listView_ItemCheck);

                bool bIsInSeletedItems = this.SelectedIndices.Contains(e.Index);

                if (bIsInSeletedItems)
                {
                    foreach (ListViewItem lvi in this.SelectedItems)
                    {
                        if (e.NewValue == CheckState.Checked)
                        {
                            lvi.Checked = true;
                        }
                        else
                        {
                            lvi.Checked = false;
                        }
                    }
                }
                //e.NewValue = e.CurrentValue;
                this.ItemCheck += new ItemCheckEventHandler(listView_ItemCheck);
            }
        }
    }
}