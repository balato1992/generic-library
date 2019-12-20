using GenericModel.Structures;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GenericWinForm.Views
{
    /// <summary>
    /// Label with placeholder if text is empty.
    /// </summary>
    public partial class GenericSearchTextBox : TextBox
    {
        public event EventHandler SearchTextChanged;
        public string LastSearchText { get; set; }

        public GenericSearchTextBox()
        {
            Initialize();
        }

        public GenericSearchTextBox(IContainer container)
        {
            container.Add(this);

            Initialize();
        }

        public void ClearText()
        {
            this.ForeColor = Color.Gray;
            this.Text = "Enter text here...";
        }


        private void Initialize()
        {
            InitializeComponent();
            this.Enter += tb_Search_Enter;
            this.Leave += tb_Search_Leave;
            this.TextChanged += tb_Search_TextChanged;

            LastSearchText = string.Empty;
            ClearText();
        }

        #region events
        private void tb_Search_Enter(object sender, EventArgs e)
        {
            if (this.ForeColor == Color.Gray)
            {
                this.ForeColor = Color.Black;
                this.Text = "";
            }
        }

        private void tb_Search_Leave(object sender, EventArgs e)
        {
            if (StringHelper.IsNullOrWhiteSpace(this.Text))
            {
                ClearText();
            }
        }

        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;

            // only trigger search when fore color is black
            if (tb == null || tb != this || tb.ForeColor != Color.Black)
            {
                return;
            }

            // record last search text
            LastSearchText = tb.Text;

            if (SearchTextChanged != null)
            {
                SearchTextChanged(sender, e);
            }
        }
        #endregion events
    }
}
