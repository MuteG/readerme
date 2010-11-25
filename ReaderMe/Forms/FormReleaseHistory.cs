using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ReaderMe.Forms
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
