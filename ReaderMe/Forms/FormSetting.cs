using System;
using System.Drawing;
using System.Windows.Forms;
using GP.Tools.ReaderMe.Common;

namespace GP.Tools.ReaderMe.Forms
{
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            CommonFunc.config.Opacity = int.Parse(numOpacity.Value.ToString("##"));
            CommonFunc.config.NormalAutoScrollInterval = int.Parse(tbxNormalScrollInterval.Text.Trim());
            CommonFunc.config.NormalAutoScrollRows = int.Parse(tbxNormalScrollRows.Text.Trim());
            CommonFunc.config.MiniAutoScrollInterval = int.Parse(tbxMiniScrollInterval.Text.Trim());
            CommonFunc.config.MiniAutoScrollRows = int.Parse(tbxMiniScrollRows.Text.Trim());
            this.Opacity = (double)CommonFunc.config.Opacity / 100;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            this.Opacity = (double)CommonFunc.config.Opacity / 100;
            numOpacity.Value = CommonFunc.config.Opacity;
            tbxNormalScrollInterval.Text = CommonFunc.config.NormalAutoScrollInterval.ToString();
            tbxNormalScrollRows.Text = CommonFunc.config.NormalAutoScrollRows.ToString();
            tbxMiniScrollInterval.Text = CommonFunc.config.MiniAutoScrollInterval.ToString();
            tbxMiniScrollRows.Text = CommonFunc.config.MiniAutoScrollRows.ToString();
            pbxBackColor.BackColor = Color.FromArgb(CommonFunc.config.BackColor);
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
                        CommonFunc.config.Opacity = int.Parse(numOpacity.Value.ToString("##"));
                        this.Opacity = (double)CommonFunc.config.Opacity / 100;
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
                CommonFunc.config.BackColor = colorDialog1.Color.ToArgb();
            }
        }
    }
}
