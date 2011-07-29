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
        }

        public void LoadState()
        {
            // 窗体属性设置
            this.frmCurrent.Width = CommonFunc.Config.Width;
            this.frmCurrent.Height = CommonFunc.Config.Height;
            this.frmCurrent.Top = CommonFunc.Config.Top;
            this.frmCurrent.Left = CommonFunc.Config.Left;
            this.frmCurrent.Opacity = (double)CommonFunc.Config.Opacity / 100;
        }

        public void SaveState()
        {
            CommonFunc.Config.Width = this.frmCurrent.Width;
            CommonFunc.Config.Height = this.frmCurrent.Height;
            CommonFunc.Config.Top = this.frmCurrent.Top;
            CommonFunc.Config.Left = this.frmCurrent.Left;
        }
    }
}
