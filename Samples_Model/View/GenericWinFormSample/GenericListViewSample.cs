using GenericWinForm.Views.GenericListViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MyModelSample.View.GenericWinFormSample
{
    public partial class GenericListViewSample : Form
    {
        public GenericListViewSample()
        {
            InitializeComponent();

            cb_CheckBoxes.Checked = pGenericListView.CheckBoxes;

            pGenericListView.ItemChecked += pGenericListView_ItemChecked;
            pGenericListView.AllSelected += pGenericListView_AllSelected;
            pGenericListView.SelectedIndexChanged += PGenericListView_SelectedIndexChanged;
        }

        #region pGenericListView

        private GenericListViewItem pGenericListView_CreateItem(string strText)
        {
            List<string> listResult = GetTexts_Split(strText);

            if (listResult != null && listResult.Count > 0)
            {
                GenericListViewItem glvi = new GenericListViewItem(listResult[0]);
                glvi.Items.AddRange(listResult.GetRange(1, listResult.Count - 1));

                return glvi;
            }

            return null;
        }

        private void pGenericListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            rtb_eventMessage.AppendText("\n");
            rtb_eventMessage.AppendText("ItemChecked: " + e.Item.Index + ", " + e.Item.Checked);
        }

        private void pGenericListView_AllSelected(object sender, EventArgs e)
        {
            rtb_eventMessage.AppendText("\n");
            rtb_eventMessage.AppendText("AllSelected");
        }

        private void PGenericListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtb_eventMessage.AppendText("\n");
            rtb_eventMessage.AppendText("SelectedIndexChanged");
        }

        #endregion pGenericListView

        #region control

        private List<string> rtb_GetTexts(RichTextBox rtb)
        {
            List<string> texts = new List<string>();

            for (int i = 0; i < rtb.Lines.Count(); i++)
            {
                if (rtb.Lines[i] != string.Empty)
                {
                    texts.Add(rtb.Lines[i]);
                }
            }

            return texts;
        }

        private List<string> GetTexts_Split(string strText)
        {
            List<string> splits = strText.Split(',').ToList();

            splits.ForEach(o => o = o.Trim());

            return splits;
        }

        private void rtb_SetTexts(RichTextBox rtb, List<string> listString)
        {
            rtb.Lines = listString.ToArray();
        }

        #endregion control

        #region events

        private void btn_InitialList_Click(object sender, EventArgs e)
        {
            List<string> texts = rtb_GetTexts(rtb_List1);

            List<GenericListViewItem> listGlvi = new List<GenericListViewItem>();
            foreach (string strText in texts)
            {
                var glvi = pGenericListView_CreateItem(strText);

                listGlvi.Add(glvi);
            }

            pGenericListView.InitialItems(listGlvi);
        }

        #region Set Items

        private void btn_SetItems_Click(object sender, EventArgs e)
        {
            List<string> texts = rtb_GetTexts(rtb_List1);

            Dictionary<string, List<string>> dictItemValues = new Dictionary<string, List<string>>();
            foreach (string strText in texts)
            {
                var glvi = pGenericListView_CreateItem(strText);

                if (!dictItemValues.ContainsKey(glvi.Key))
                {
                    dictItemValues.Add(glvi.Key, glvi.Items);
                }
            }

            pGenericListView.ChangeItemValue(dictItemValues);
        }

        private void btn_ChangeItemValue_Click(object sender, EventArgs e)
        {
            List<string> texts = rtb_GetTexts(rtb_List1);

            foreach (string strText in texts)
            {
                var glvi = pGenericListView_CreateItem(strText);

                for (int i = 0; i < glvi.Items.Count; i++)
                {
                    pGenericListView.ChangeItemValue(glvi.Key, i, glvi.Items[i]);
                }
            }
        }

        private void btn_CheckItems_Click(object sender, EventArgs e)
        {
            List<string> texts = rtb_GetTexts(rtb_List1);

            List<string> keys = texts.ConvertAll(o => pGenericListView_CreateItem(o).Key);

            pGenericListView.CheckInView(keys, true);
        }

        private void btn_UncheckItems_Click(object sender, EventArgs e)
        {
            List<string> texts = rtb_GetTexts(rtb_List1);

            List<string> keys = texts.ConvertAll(o => pGenericListView_CreateItem(o).Key);

            pGenericListView.CheckInView(keys, false);
        }

        private void btn_SetColumns_Click(object sender, EventArgs e)
        {
            List<string> texts = rtb_GetTexts(rtb_List2);

            pGenericListView.InitialColumns(texts);
        }

        #endregion Set Items

        #region Get Items

        private void btn_ViewItems_Click(object sender, EventArgs e)
        {
            rtb_SetTexts(rtb_List3, pGenericListView.ItemNames.ToList().ConvertAll(o => o.Key));
        }

        private void btn_ViewCheckedItems_Click(object sender, EventArgs e)
        {
            rtb_SetTexts(rtb_List3, pGenericListView.CheckedItemNames.ToList().ConvertAll(o => o.Key));
        }

        private void btn_SelectedItems_Click(object sender, EventArgs e)
        {
            rtb_SetTexts(rtb_List3, pGenericListView.SelectedItemNames.ToList().ConvertAll(o => o.Key));
        }

        #endregion Get Items

        private void btn_AutoResizeColumns_Click(object sender, EventArgs e)
        {
            pGenericListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void cb_CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb != null)
            {
                pGenericListView.CheckBoxes = cb.Checked;
            }
        }

        private void cb_HideUncheckedItems_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb != null)
            {
                pGenericListView.HideUncheckedItems = cb.Checked;
            }
        }

        #endregion events
    }
}