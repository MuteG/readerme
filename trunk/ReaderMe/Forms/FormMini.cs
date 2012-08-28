using System;
using System.Drawing;
using System.Windows.Forms;
using GPSoft.Tools.ReaderMe.Common;
using GPSoft.Tools.ReaderMe.Helper;

namespace GPSoft.Tools.ReaderMe.Forms
{
    public partial class FormMini : Form
    {
        private int _BookMark = 0;

        public int BookMark
        {
            get
            {
                return _BookMark;
            }
            set
            {
                _BookMark = value;
                if (CommonFunc.ActiveFile != null && richTextBox1.TextLength > 0 && richTextBox1.SelectionStart != _BookMark)
                {
                    richTextBox1.SelectionStart = _BookMark;
                }
            }
        }

        public FormMini()
        {
            InitializeComponent();
            this.Width = CommonFunc.Config.MiniWidth;
            this.Top = CommonFunc.Config.MiniTop;
            this.Left = CommonFunc.Config.MiniLeft;
            this.Opacity = (double)CommonFunc.Config.Opacity / 100;
            this.BackColor = Color.FromArgb(CommonFunc.Config.BackColor);
        }

        public string RichText
        {
            set
            {
                this.richTextBox1.Text = value;
                this.Refresh();
            }
        }

        private void FormMini_MouseDown(object sender, MouseEventArgs e)
        {
            CommonFunc.MoveWindow(this.Handle);
        }

        private void mnuItemReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void mnuItemTop_Click(object sender, EventArgs e)
        {
            mnuItemTop.Checked = !mnuItemTop.Checked;
            this.TopMost = mnuItemTop.Checked;
        }

        private void FormMini_Load(object sender, EventArgs e)
        {
            CommonFunc.HotKey.HWnd = this.Handle;
            CommonFunc.RichTextBox = richTextBox1;
            richTextBox1.Font = new Font(CommonFunc.Config.FontName, CommonFunc.Config.FontSize);
            lblText.Font = new Font(CommonFunc.Config.FontName, CommonFunc.Config.FontSize);
            this.Height = (int)this.CreateGraphics().MeasureString("例", richTextBox1.Font).Height;// CommonFunc.config.FontSize + 6;
            //richTextBox1.Height = CommonFunc.config.FontSize;

            richTextBox1.MouseWheel += new MouseEventHandler(richTextBox1_MouseWheel);
            CommonFunc.HotKey.OnHotkey += new HotkeyEventHandler(HotKey_OnHotkey);
        }

        private void HotKey_OnHotkey(int HotKeyID)
        {
            int lineIndex = richTextBox1.GetLineFromCharIndex(_BookMark);
            if (HotKeyID == CommonFunc.DictHotKey[Constants.HASH_KEY_HOT_KEY_UP] ||
                (HotKeyID == CommonFunc.DictHotKey[Constants.HASH_KEY_HOT_KEY_LEFT]))
            {
                ScrollRichText(true);
            }
            else if ((HotKeyID == CommonFunc.DictHotKey[Constants.HASH_KEY_HOT_KEY_DOWN]) ||
                (HotKeyID == CommonFunc.DictHotKey[Constants.HASH_KEY_HOT_KEY_RIGHT]))
            {
                ScrollRichText(false);
            }
            else if (HotKeyID == CommonFunc.DictHotKey[Constants.HASH_KEY_HOT_KEY_SHOW])
            {
                lblText.BackColor = System.Drawing.Color.Black;
                lblText.ForeColor = System.Drawing.Color.White;
                lblText.Refresh();
                System.Threading.Thread.Sleep(200);
                lblText.BackColor = System.Drawing.Color.Transparent;
                lblText.ForeColor = System.Drawing.Color.Black;
                lblText.Refresh();
            }
        }

        void richTextBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (null == CommonFunc.ActiveFile)
            {
                return;
            }
            int lineIndex = richTextBox1.GetLineFromCharIndex(_BookMark);
            ScrollRichText(e.Delta > 0);
        }

        private void ScrollRichText(bool isUp)
        {
            if (null == CommonFunc.ActiveFile)
            {
                return;
            }

            int lineIndex = richTextBox1.GetLineFromCharIndex(_BookMark);
            if (isUp)
            {
                if (0 < lineIndex)
                {
                    lineIndex--;
                }
            }
            else
            {
                int maxLineIndex = richTextBox1.GetLineFromCharIndex(richTextBox1.TextLength - 1);
                if (lineIndex < maxLineIndex)
                {
                    lineIndex++;
                }
            }
            BookMark = richTextBox1.GetFirstCharIndexFromLine(lineIndex);
        }

        public int MyShowDialog()
        {
            int result = 0;
            this.ShowDialog();
            // 保存状态
            CommonFunc.Config.MiniLeft = this.Left;
            CommonFunc.Config.MiniTop = this.Top;
            CommonFunc.Config.MiniWidth = this.Width;
            result = _BookMark;
            return result;
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            this.BookMark = richTextBox1.SelectionStart;

            int endIndex = richTextBox1.TextLength - 1;
            int maxLineIndex = richTextBox1.GetLineFromCharIndex(endIndex);
            int activeLineIndex = richTextBox1.GetLineFromCharIndex(_BookMark);
            int activeLineFirstCharIndex = richTextBox1.GetFirstCharIndexFromLine(activeLineIndex);
            if (activeLineIndex < maxLineIndex)
            {
                endIndex = richTextBox1.GetFirstCharIndexFromLine(activeLineIndex + 1);
            }
            lblText.Text = richTextBox1.Text.Substring(activeLineFirstCharIndex, endIndex - activeLineFirstCharIndex);
        }

        private void mnuItemShowInTask_CheckedChanged(object sender, EventArgs e)
        {
            if (mnuItemShowInTask.Checked)
            {
                this.ShowInTaskbar = true;
            }
            else
            {
                this.ShowInTaskbar = false;
            }
        }

        private void mnuItemBookMark_Click(object sender, EventArgs e)
        {
            if (CommonFunc.ActiveFile != null)
            {
                CommonFunc.ActiveFile.BookMark = richTextBox1.SelectionStart;
                CommonFunc.Config.AddFile(CommonFunc.ActiveFile);
            }
        }

        private void FormMini_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && !e.Alt && !e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.B:
                        {
                            CommonFunc.AutoScroll = !CommonFunc.AutoScroll;
                            CommonFunc.Timer.Interval = CommonFunc.Config.MiniAutoScrollInterval * 1000;
                            CommonFunc.Timer.Enabled = CommonFunc.AutoScroll;
                            break;
                        }
                    case Keys.Up:
                        {
                            e.Handled = true;
                            CommonFunc.Config.Opacity += 5;
                            this.Opacity = (double)CommonFunc.Config.Opacity / 100;
                            break;
                        }
                    case Keys.Down:
                        {
                            e.Handled = true;
                            CommonFunc.Config.Opacity -= 5;
                            this.Opacity = (double)CommonFunc.Config.Opacity / 100;
                            break;
                        }
                }
            }
        }

        private void mnuItemShowInTask_Click(object sender, EventArgs e)
        {

        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            CommonFunc.ResizeWindow(this.Handle);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        private void richTextBox1_SizeChanged(object sender, EventArgs e)
        {
            BookMark = BookMark;
        }
    }
}
