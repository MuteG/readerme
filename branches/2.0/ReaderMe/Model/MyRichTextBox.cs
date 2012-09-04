namespace GPSoft.Tools.ReaderMe.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// 自定义富文本框
    /// </summary>
    public partial class MyRichTextBox : UserControl
    {
        private AbstractFile _File;
        /// <summary>
        /// 获取或设置与此富文本框关联的文件对象
        /// </summary>
        public AbstractFile File
        {
            get { return _File; }
            set
            {
                _File = value;
                _File.Load();
                vScrollBar.Maximum = _File.Length;
            }
        }

        public MyRichTextBox()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(MyRichTextBox_MouseWheel);
            this.Paint += new PaintEventHandler(MyRichTextBox_Paint);
        }

        private void MyRichTextBox_Paint(object sender, PaintEventArgs e)
        {
            if (null != _File)
            {
                using (Graphics g = e.Graphics)
                {
                    g.DrawString(_File.Text, this.Font, new SolidBrush(this.ForeColor), new RectangleF(0f, 0f, this.Width, this.Height));
                }
            }
        }

        private void MyRichTextBox_MouseWheel(object sender, MouseEventArgs e)
        {
            Console.WriteLine("a");
            
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (null != _File)
            {
                this.File.Position = e.NewValue;
                Refresh();
            }
        }


    }
}
