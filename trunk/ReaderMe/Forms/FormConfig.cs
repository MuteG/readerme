using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ReaderMe.Common;

namespace ReaderMe.Forms
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            CommonFunc.config.Opacity = int.Parse(numOpacity.Value.ToString("##"));
            CommonFunc.config.AutoScrollInterval = int.Parse(tbxAutoScrollInterval.Text.Trim());
            this.Opacity = (double)CommonFunc.config.Opacity / 100;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            this.Opacity = (double)CommonFunc.config.Opacity / 100;
            numOpacity.Value = CommonFunc.config.Opacity;
            tbxAutoScrollInterval.Text = CommonFunc.config.AutoScrollInterval.ToString();
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
