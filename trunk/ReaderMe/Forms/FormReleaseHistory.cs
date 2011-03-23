using System;
using System.Windows.Forms;

namespace GP.Tools.ReaderMe.Forms
{
    public partial class FormReleaseHistory : Form
    {
        public FormReleaseHistory()
        {
            InitializeComponent();
        }

        private void FormReleaseHistory_Shown(object sender, EventArgs e)
        {
            tbxIntroduction.Text = Properties.Resources.Introduction;
            tbxReleaseHistory.Text = Properties.Resources.ReleaseHistory;
        }
    }
}
