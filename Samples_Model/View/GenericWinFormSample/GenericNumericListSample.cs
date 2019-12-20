using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MyModelSample.View.GenericWinFormSample
{
    public partial class GenericNumericListSample : Form
    {
        public GenericNumericListSample()
        {
            InitializeComponent();

            //nud_MaxValue.Value = pGenericNumericList.MaxValue;
            //nud_MinValue.Value = pGenericNumericList.MinValue;
            //nud_DefaultValue.Value = pGenericNumericList.DefaultValue;
            cb_AlwaysDescending.Checked = pGenericNumericList.AlwaysDescending;
        }

        private void nud_MaxValue_ValueChanged(object sender, EventArgs e)
        {
            pGenericNumericList.MaxValue = nud_MaxValue.Value;
        }

        private void nud_MinValue_ValueChanged(object sender, EventArgs e)
        {
            pGenericNumericList.MinValue = nud_MinValue.Value;
        }

        private void nud_DefaultValue_ValueChanged(object sender, EventArgs e)
        {
            pGenericNumericList.DefaultValue = nud_DefaultValue.Value;
        }

        private void cb_AlwaysDescending_CheckedChanged(object sender, EventArgs e)
        {
            pGenericNumericList.AlwaysDescending = cb_AlwaysDescending.Checked;
        }

        private void btn_GetValue_Click(object sender, EventArgs e)
        {
            var listValues = pGenericNumericList.GetValues();

            pRichTextBox.Text = "";
            foreach (var Value in listValues)
            {
                pRichTextBox.AppendText(Value + "\r\n");
            }
        }

        private List<decimal> rtb_GetTexts(RichTextBox rtb)
        {
            List<decimal> texts = new List<decimal>();

            for (int i = 0; i < rtb.Lines.Count(); i++)
            {
                decimal value;
                string strValue = rtb.Lines[i];
                if (strValue != string.Empty && decimal.TryParse(strValue, out value))
                {
                    texts.Add(value);
                }
            }

            return texts;
        }

        private void btn_SetValue_Click(object sender, EventArgs e)
        {
            var listValues = rtb_GetTexts(pRichTextBox);

            pGenericNumericList.SetValues(listValues);
        }
    }
}