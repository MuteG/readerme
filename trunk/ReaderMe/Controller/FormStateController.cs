using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using GPSoft.Tools.ReaderMe.Common;

namespace GPSoft.Tools.ReaderMe.Controller
{
    public sealed class FormStateController
    {
        private Form frmCurrent;

        public FormStateController(Form form)
        {
            this.frmCurrent = form;
            form.ResizeEnd += new EventHandler(form_ResizeEnd);
            form.LocationChanged += new EventHandler(form_LocationChanged);
        }

        private void form_LocationChanged(object sender, EventArgs e)
        {
            SaveState();
        }

        private void form_ResizeEnd(object sender, EventArgs e)
        {
            SaveState();
        }

        public void LoadState()
        {
            // 窗体属性设置
            int top, left;
            top = CommonFunc.Config.Top;
            left = CommonFunc.Config.Left;
            Rectangle screenArea = Screen.FromHandle(this.frmCurrent.Handle).WorkingArea;

            this.frmCurrent.Width = CommonFunc.Config.Width > screenArea.Width ? screenArea.Width : CommonFunc.Config.Width;
            this.frmCurrent.Height = CommonFunc.Config.Height > screenArea.Height ? screenArea.Height : CommonFunc.Config.Height;

            if (top < 0)
            {
                top = 0;
            }
            else if (top > screenArea.Height - this.frmCurrent.Height)
            {
                top = screenArea.Height - this.frmCurrent.Height;
            }

            if (left < 0)
            {
                left = 0;
            }
            else if (left > screenArea.Width - this.frmCurrent.Width)
            {
                left = screenArea.Width - this.frmCurrent.Width;
            }
            this.frmCurrent.Top = top;
            this.frmCurrent.Left = left;

            this.frmCurrent.Opacity = (double)CommonFunc.Config.Opacity / 100;
        }

        public void SaveState()
        {
            if (this.frmCurrent.WindowState == FormWindowState.Normal)
            {
                CommonFunc.Config.Width = this.frmCurrent.Width;
                CommonFunc.Config.Height = this.frmCurrent.Height;
                CommonFunc.Config.Top = this.frmCurrent.Top;
                CommonFunc.Config.Left = this.frmCurrent.Left;
            }
        }
    }
}
