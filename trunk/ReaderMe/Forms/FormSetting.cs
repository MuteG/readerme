using System;
using System.Drawing;
using System.Windows.Forms;
using GPSoft.Tools.ReaderMe.Common;

namespace GPSoft.Tools.ReaderMe.Forms
{
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            CommonFunc.Config.Opacity = int.Parse(numOpacity.Value.ToString("##"));
            CommonFunc.Config.NormalAutoScrollInterval = int.Parse(tbxNormalScrollInterval.Text.Trim());
            CommonFunc.Config.NormalAutoScrollRows = int.Parse(tbxNormalScrollRows.Text.Trim());
            CommonFunc.Config.MiniAutoScrollInterval = int.Parse(tbxMiniScrollInterval.Text.Trim());
            CommonFunc.Config.MiniAutoScrollRows = int.Parse(tbxMiniScrollRows.Text.Trim());
            this.Opacity = (double)CommonFunc.Config.Opacity / 100;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            this.Opacity = (double)CommonFunc.Config.Opacity / 100;
            numOpacity.Value = CommonFunc.Config.Opacity;
            tbxNormalScrollInterval.Text = CommonFunc.Config.NormalAutoScrollInterval.ToString();
            tbxNormalScrollRows.Text = CommonFunc.Config.NormalAutoScrollRows.ToString();
            tbxMiniScrollInterval.Text = CommonFunc.Config.MiniAutoScrollInterval.ToString();
            tbxMiniScrollRows.Text = CommonFunc.Config.MiniAutoScrollRows.ToString();
            pbxBackColor.BackColor = Color.FromArgb(CommonFunc.Config.BackColor);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void numOpacity_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        CommonFunc.Config.Opacity = int.Parse(numOpacity.Value.ToString("##"));
                        this.Opacity = (double)CommonFunc.Config.Opacity / 100;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                    }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
            {
                e.Handled = true;
            }
        }

        private void pbxBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pbxBackColor.BackColor = colorDialog1.Color;
                CommonFunc.Config.BackColor = colorDialog1.Color.ToArgb();
            }
        }
    }
}
