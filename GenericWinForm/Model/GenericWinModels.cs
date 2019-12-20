using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace GenericWinForm.Model
{
    public static class ControlHelper
    {
        public static System.Drawing.Size GetSizeWithMargin(Control control)
        {
            int width = control.Margin.Left + control.Width + control.Margin.Right;
            int height = control.Margin.Top + control.Height + control.Margin.Bottom;

            return new System.Drawing.Size(width, height);
        }

    }
    
    public static class Extension
    {
        //非同步委派更新UI
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)//在非當前執行緒內 使用委派
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
