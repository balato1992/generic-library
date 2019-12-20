using GenericWinForm.Model;
using GenericWinForm.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericWinForm4_5.Views
{
    public class DoSomethingWithLoadingForm
    {
        public delegate void SomeAction();
        public Exception ExceptionDuringLoading = null;

        private bool m_loading = false;
        private bool m_formClosed = false;
        private string m_title = null;
        private string m_displayWord = null;
        private SomeAction m_action = null;

        public DoSomethingWithLoadingForm(string displayWord, Control invokeControl, SomeAction action)
        {
            this.m_title = null;
            this.m_displayWord = displayWord;
            this.m_action = delegate
            {
                invokeControl.InvokeIfRequired(() =>
                {
                    action();
                });
            };
        }

        public DoSomethingWithLoadingForm(string title, string displayWord, Control invokeControl, SomeAction action) : this(displayWord, invokeControl, action)
        {
            this.m_title = title;
        }

        public void Start()
        {
            DoSomething(m_title, m_displayWord, m_action);
        }

        public void DoSomething(string title, string displayWord, SomeAction action)
        {
            try
            {
                m_loading = true;
                m_formClosed = false;

                Task.Run(() =>
                {
                    LoadingDialogForm ldf = null;
                    LoadingDialogForm.SomeAction waitUntilLoad = delegate
                    {
                        while (m_loading) {; }
                        m_formClosed = true;
                    };


                    if (title == null)
                    {
                        ldf = new LoadingDialogForm(displayWord, waitUntilLoad);
                    }
                    else
                    {
                        ldf = new LoadingDialogForm(title, displayWord, waitUntilLoad);
                    }

                    ldf.BringToFront();
                    ldf.Focus();
                    // will false after ShowDislog
                    ldf.TopMost = true;
                    ldf.ShowDialog();
                });

                action();
            }
            catch (Exception ex)
            {
                this.ExceptionDuringLoading = ex;
            }


            while (!m_formClosed)
            {
                m_loading = false;
            }
        }

    }
}
