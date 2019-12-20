using GenericWinForm.Model;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GenericWinForm.Views
{
    /// <summary>
    /// TabControl that can have background color and invisible border (margin: 0).
    /// </summary>
    public partial class GenericTabControl : TabControl
    {
        private const int TCM_ADJUSTRECT = 0x1328;

        protected override void WndProc(ref Message m)
        {
            //Hide the tab headers at run-time
            if (m.Msg == TCM_ADJUSTRECT)
            {

                RECT rect = (RECT)(m.GetLParam(typeof(RECT)));
                rect.Left = this.Left + this.Margin.Left - 4;
                rect.Right = this.Right - this.Margin.Right + 4;

                rect.Top = this.Top + this.Margin.Top - 5;
                rect.Bottom = this.Bottom - this.Margin.Bottom + 4;
                Marshal.StructureToPtr(rect, m.LParam, true);
                //m.Result = (IntPtr)1;
                //return;
            }
            //else
            // call the base class implementation
            base.WndProc(ref m);
        }

        private struct RECT
        {
            public int Left, Top, Right, Bottom;
        }


        public GenericTabControl() : base()
        {
            this.ParentChanged += customTabControl_ParentChanged;
        }

        public void HideHeader()
        {
            TabControlHelper.HideHeader(this);
        }

        /// <summary>
        /// Use this function when some controls won't initialize in tabcontrol.
        /// </summary>
        public void ToggleAllTabs()
        {
            TabControlHelper.ToggleAllTabs(this);
        }

        private void customTabControl_ParentChanged(object sender, System.EventArgs e)
        {
            if (this.Parent != null)
            {
                OnParentBackColorChanged(e);
            }
        }

        protected override void OnParentBackColorChanged(System.EventArgs e)
        {
            base.OnParentBackColorChanged(e);

            if (this.Parent != null)
            {
                foreach (TabPage tp in this.TabPages)
                {
                    tp.BackColor = this.Parent.BackColor;
                }
            }
        }
    }
}
