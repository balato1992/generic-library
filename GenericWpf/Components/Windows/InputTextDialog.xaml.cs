using System;
using System.Windows;
using System.Windows.Controls;

namespace GenericWpf.Components.Windows
{
    public partial class InputTextDialog : Window
    {
        public event Func<string, string> MakeValidInput;

        public string TextOk
        {
            get { return btnOk.Content as string; }
            set { btnOk.Content = value; }
        }
        public string TextCancel
        {
            get { return btnCancel.Content as string; }
            set { btnCancel.Content = value; }
        }

        public InputTextDialog(string title, string text, string defaultContent = "")
        {
            InitializeComponent();
            Title = title;
            lblQuestion.Content = text;
            textInput.Text = defaultContent;
        }
        public string Input
        {
            get { return textInput.Text; }
        }

        #region events
        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            textInput.SelectAll();
            textInput.Focus();
        }

        private void textContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (MakeValidInput != null)
            {
                textInput.Text = MakeValidInput(textInput.Text);
            }
        }
        #endregion events
    }
}
