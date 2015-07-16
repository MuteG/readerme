using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GPStudio.Tools.ReaderMe.common;
using GPStudio.Tools.ReaderMe.Helper;
using GPStudio.Tools.ReaderMe.module;

namespace GPStudio.Tools.ReaderMe.Forms
{
    public partial class FormOpenHistory : Form
    {
        public FormOpenHistory()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
            for (int i = 0; i < CommonFunc.Config.FileInfoList.Count; i++)
            {
                FileInformation fileInfo = CommonFunc.Config.FileInfoList[i];
                ListViewItem item = lsvOpenHistory.Items.Add("");
                item.SubItems.Add(Path.GetFileNameWithoutExtension(fileInfo.Path));
                item.SubItems.Add(File.Exists(fileInfo.Path) ? "存在" : "不存在");
                item.ToolTipText = string.Format("MD5 ：{0}\n编码：{1}\n日期：{2}\n路径：{3}",
                    fileInfo.MD5, CommonFunc.DictEncodingToMenu[fileInfo.Encode], fileInfo.UpdateTime, fileInfo.Path);
            }
            lsvOpenHistory.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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
                list.Add(CommonFunc.Config.FileInfoList[lsvOpenHistory.CheckedIndices[i]]);
            }
            for (int i = 0; i < list.Count; i++)
            {
                CommonFunc.Config.RemoveFile(list[i]);
            }
            SetListView();
            list.Clear();
        }

        private void mnuItemOpenFolder_Click(object sender, EventArgs e)
        {
            if (lsvOpenHistory.SelectedIndices.Count > 0)
            {
                FileInformation file = CommonFunc.Config.FileInfoList[lsvOpenHistory.SelectedIndices[0]];
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
                    FileInformation file = new FileInformation(CommonFunc.Config.FileInfoList[lsvOpenHistory.SelectedIndices[0]]);
                    newFileName = Path.Combine(Path.GetDirectoryName(file.Path),
                                        Path.GetFileNameWithoutExtension(newFileName) + Path.GetExtension(file.Path));
                    FileHelper.RenameFileSafely(file.Path, newFileName);
                    file.Path = newFileName;
                    CommonFunc.Config.RemoveFile(lsvOpenHistory.SelectedIndices[0]);
                    CommonFunc.Config.AddFile(file);
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

        private void cbxCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            SetAllRecordCheck(cbxCheckAll.Checked);
        }
    }
}
