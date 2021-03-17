using System;
using System.Windows.Forms;

namespace ReaderMe.Forms
{
    public partial class FormInputDialog : Form
    {
        public FormInputDialog()
        {
            InitializeComponent();
        }

        private void FormInputDialog_Load(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        public string MyShowDialog(string info)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(info))
            {
                info = "请输入";
            }
            this.lblInfoMessage.Text = info;
            if (this.ShowDialog() == DialogResult.OK)
            {
                result = tbxInput.Text.Trim();
            }
            else
            {
                result = string.Empty;
            }
            return result;
        }

        private void FormInputDialog_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        this.DialogResult = DialogResult.OK;
                        Close();
                        break;
                    }
                case Keys.Escape:
                    {
                        this.DialogResult = DialogResult.Cancel;
                        Close();
                        break;
                    }
            }
        }
    }
}
