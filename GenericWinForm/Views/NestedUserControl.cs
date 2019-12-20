using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenericWinForm.Views
{
    // Deeply nested controls do not resize properly when their parents are resized
    // reference: https://support.microsoft.com/en-us/help/953934/deeply-nested-controls-do-not-resize-properly-when-their-parents-are-r
    public class NestedUserControl : UserControl
    {
        public NestedUserControl() : base()
        {
            base.DoubleBuffered = true;
            this.DoubleBuffered = true;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (this.Handle != null)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    base.OnSizeChanged(e);
                });
            }
        }
    }
}
