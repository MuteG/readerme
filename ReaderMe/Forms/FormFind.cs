using System;
using System.Windows.Forms;
using GPStudio.Tools.ReaderMe.common;

namespace GPStudio.Tools.ReaderMe.Forms
{
    public partial class FormFind : Form
    {
        private static FormFind _FormFind = null;

        private FormFind()
        {
            InitializeComponent();
        }

        public static FormFind GetInstance()
        {
            if ((null == _FormFind) ||(_FormFind.IsDisposed))
            {
                _FormFind = new FormFind();
            }
            return _FormFind;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            CommonFunc.FindStatus.MatchCase = cbxCase.Checked;
            CommonFunc.FindStatus.BoxFinds = GetRichTextBoxFinds();
            CommonFunc.FindStatus.SelectedString = tbxFindWord.Text.Trim();
            CommonFunc.FindStatus.WholeWord = cbxWholeWord.Checked;
            CommonFunc.FindStatus.Reverse = rbtnUp.Checked;
            CommonFunc.FindRichTextBoxString();
        }

        private RichTextBoxFinds GetRichTextBoxFinds()
        {
            RichTextBoxFinds result = RichTextBoxFinds.None;
            // 区分大小写
            if (cbxCase.Checked)
            {
                result = RichTextBoxFinds.MatchCase;
            }
            // 全字对应
            if (cbxWholeWord.Checked)
            {
                if (RichTextBoxFinds.None == result)
                {
                    result = RichTextBoxFinds.WholeWord;
                }
                else
                {
                    result = result & RichTextBoxFinds.WholeWord;
                }
            }
            // 反向查找
            if (rbtnUp.Checked)
            {
                if (RichTextBoxFinds.None == result)
                {
                    result = RichTextBoxFinds.Reverse;
                }
                else
                {
                    result = result & RichTextBoxFinds.Reverse;
                }
            }
            return result;
        }

        public void FormFind_Load(object sender, EventArgs e)
        {
            tbxFindWord.Text = CommonFunc.FindStatus.SelectedString;
            cbxCase.Checked = CommonFunc.FindStatus.MatchCase;
            cbxWholeWord.Checked = CommonFunc.FindStatus.WholeWord;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CommonFunc.ClearAllHighLightString();
        }

        private void btnFindCount_Click(object sender, EventArgs e)
        {
            CommonFunc.FindStatus.SelectedString = tbxFindWord.Text.Trim();
            MessageBox.Show("统计总数：" + CommonFunc.FindRichTextBoxStringCount().ToString());
        }

        private void btnFindAll_Click(object sender, EventArgs e)
        {
            CommonFunc.FindStatus.SelectedString = tbxFindWord.Text.Trim();
            CommonFunc.HighLightAllFindedString();
        }
    }
}