using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenericWinForm.Model
{
    public static class TabControlHelper
    {
        public static void HideHeader(TabControl tc)
        {
            if (tc == null)
            {
                return;
            }

            tc.SizeMode = TabSizeMode.Fixed;
            tc.Appearance = TabAppearance.Buttons;
            tc.ItemSize = new System.Drawing.Size(0, 1);
        }

        /// <summary>
        /// Use this function when some controls won't initialize in tabcontrol.
        /// </summary>
        public static void ToggleAllTabs(TabControl tc)
        {
            if (tc == null)
            {
                return;
            }

            foreach (TabPage tp in tc.TabPages)
            {
                tp.Show();
            }
        }
    }
}
