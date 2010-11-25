using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ReaderMe.Common;

namespace ReaderMe.Forms
{
    public partial class FormConfigOpenHistory : Form
    {
        public FormConfigOpenHistory()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SetAllRecordCheck(true);
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            SetAllRecordCheck(false);
        }

        private void SetAllRecordCheck(bool isChecked)
        {
            for (int i = 0; i < lsvOpenHistory.Items.Count; i++)
            {
                lsvOpenHistory.Items[i].Checked = isChecked;
            }
        }

        private void FormConfigOpenHistory_Load(object sender, EventArgs e)
        {
            SetListView();
        }

        private void SetListView()
        {
            lsvOpenHistory.Items.Clear();
            for (int i = 0; i < CommonFunc.config.FileInfoList.Count; i++)
            {
                FileInformation fileInfo = CommonFunc.config.FileInfoList[i];
                ListViewItem item = lsvOpenHistory.Items.Add("");
                item.SubItems.Add(Path.GetFileNameWithoutExtension(fileInfo.Path));
                item.SubItems.Add(File.Exists(fileInfo.Path) ? "存在" : "不存在");
                item.SubItems.Add(fileInfo.Path);
                item.SubItems.Add(fileInfo.MD5);
                item.SubItems.Add(CommonFunc.DictEncodingToMenu[fileInfo.Encode]);
                item.SubItems.Add(fileInfo.UpdateTime);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("此操作不可恢复，是否确认删除？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                return;
            }
            List<FileInformation> list = new List<FileInformation>();
            for (int i = 0; i < lsvOpenHistory.CheckedIndices.Count; i++)
            {
                list.Add(CommonFunc.config.FileInfoList[lsvOpenHistory.CheckedIndices[i]]);
            }
            for (int i = 0; i < list.Count; i++)
            {
                CommonFunc.config.RemoveFile(list[i]);
            }
            SetListView();
            list.Clear();
        }

        private void mnuItemOpenFolder_Click(object sender, EventArgs e)
        {
            if (lsvOpenHistory.SelectedIndices.Count > 0)
            {
                FileInformation file = CommonFunc.config.FileInfoList[lsvOpenHistory.SelectedIndices[0]];
                System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(file.Path));
                System.Diagnostics.Process.Start("explorer.exe", "/select," + file.Path);
            }
        }

        private void mnuItemFileRename_Click(object sender, EventArgs e)
        {
            if (lsvOpenHistory.SelectedIndices.Count > 0)
            {
                string newFileName = new FormInputDialog().MyShowDialog("请输入文件名");
                if (!string.IsNullOrEmpty(newFileName))
                {
                    FileInformation file = new FileInformation(CommonFunc.config.FileInfoList[lsvOpenHistory.SelectedIndices[0]]);
                    newFileName = Path.Combine(Path.GetDirectoryName(file.Path),
                                        Path.GetFileNameWithoutExtension(newFileName) + Path.GetExtension(file.Path));
                    GYP.Helper.FileHelper.FileHelper.RenameFileSafely(file.Path, newFileName);
                    file.Path = newFileName;
                    CommonFunc.config.RemoveFile(lsvOpenHistory.SelectedIndices[0]);
                    CommonFunc.config.AddFile(file);
                    SetListView();
                }
            }
        }

        private void mnuItemSelectAllNotExistFile_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvOpenHistory.Items.Count; i++)
            {
                ListViewItem item = lsvOpenHistory.Items[i];
                if (item.SubItems[2].Text.Equals("不存在"))
                {
                    item.Checked = true;
                }
            }
        }
    }
}
