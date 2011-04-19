using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using GPSoft.Tools.ReaderMe.Common;
using GPSoft.Tools.ReaderMe.Model;

namespace GPSoft.Tools.ReaderMe.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        #region 系统函数

        #region 窗体事件

        // 窗体初始化
        private void FormMain_Load(object sender, EventArgs e)
        {
            TimeWatcher watcher = new TimeWatcher();
            watcher.Start();
            CommonFunc.RichTextBox = rtbText;
            CommonFunc.Init();
            tsslInfo.Text = string.Empty;
            // 窗体属性设置
            this.Width = CommonFunc.config.Width;
            this.Height = CommonFunc.config.Height;
            this.Top = CommonFunc.config.Top;
            this.Left = CommonFunc.config.Left;
            this.Opacity = (double)CommonFunc.config.Opacity / 100;
            // 文本区域设置
            this.rtbText.BackColor = Color.FromArgb(CommonFunc.config.BackColor);
            // 字体
            rtbText.Font = new Font(CommonFunc.config.FontName, CommonFunc.config.FontSize);
            // 支持拖放打开文件
            rtbText.AllowDrop = true;
            rtbText.DragDrop += new DragEventHandler(FormMain_DragDrop);
            rtbText.DragEnter += new DragEventHandler(FormMain_DragEnter);
            //rtbText.VScroll += new EventHandler(rtbText_VScroll);
            //rtbText.HScroll += new EventHandler(rtbText_VScroll);
            rtbText.SelectionChanged += new EventHandler(rtbText_VScroll);

            // 自动换行
            mnuItemWordWrap.Checked = 1 == CommonFunc.config.WordWrap ? true : false;

            SetMenuOpenHistory();
            SetMenuEncoding();
            watcher.Stop();
        }

        private void rtbText_VScroll(object sender, EventArgs e)
        {
            SetWordCountText();
        }

        private void SetWordCountText()
        {
            int currentIndex = rtbText.GetCharIndexFromPosition(new Point(0, 0));
            currentIndex = Math.Max(currentIndex, rtbText.SelectionStart);
            tsslWordCount.Text = string.Format("{0}/{1}({2}%)",
                currentIndex, rtbText.TextLength,
                rtbText.TextLength == 0 ? 0 : (int)currentIndex * 100 / rtbText.TextLength);
        }

        /// <summary>
        /// 动态生成“打开历史”菜单
        /// </summary>
        private void SetMenuOpenHistory()
        {
            TimeWatcher watcher = new TimeWatcher();
            watcher.Start();
            mnuItemOpenHistory.DropDownItems.Clear();
            for (int i = 0; i < CommonFunc.config.FileInfoList.Count; i++)
            {
                ToolStripItem item = mnuItemOpenHistory.DropDownItems.Add(Path.GetFileNameWithoutExtension(CommonFunc.config.FileInfoList[i].Path));
                item.Click += new EventHandler(item_Click);
            }
            watcher.Stop();
        }

        // 动态生成“编码”菜单
        private void SetMenuEncoding()
        {
            TimeWatcher watcher = new TimeWatcher();
            watcher.Start();
            mnuItemEncoding.DropDownItems.Clear();
            foreach (string encode in CommonFunc.DictEncodingToMenu.Values)
            {
                ToolStripItem item = mnuItemEncoding.DropDownItems.Add(encode);
                item.Click += new EventHandler(MenuEncoding_Click);
            }
            watcher.Stop();
        }

        // 窗体关闭
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 保存状态
            if (null != CommonFunc.ActiveFile)
            {
                // 1.0.0.30
                CommonFunc.ActiveFile.BookMark = rtbText.SelectionStart;
            }
            SaveStatus();
            // 注销热键
            CommonFunc.HotKey.UnregisterHotKeys();
        }

        // 窗体拖放事件
        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            string filePath = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            string fileExt = Path.GetExtension(filePath).ToUpper();
            if (!fileExt.Equals(Constants.EXT_TEXT_TXT))
            {
                if (MessageBox.Show("您正在打开的文件可能不是文本文件，是否打开？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return;
                }
            }
            OpenFile(filePath);
            ShowFileText();
        }

        // 拖放时改变鼠标样式
        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        // 窗口热键
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && !e.Alt && !e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.M:
                        {
                            if (null != CommonFunc.ActiveFile)
                            {
                                CommonFunc.ActiveFile.BookMark = rtbText.SelectionStart;
                            }
                            SaveStatus();
                            break;
                        }
                    case Keys.S:
                        {
                            SaveFile();
                            break;
                        }
                    case Keys.V:
                        {
                            if (Clipboard.ContainsText())
                            {
                                rtbText.Paste();
                            }
                            else
                            {
                                e.Handled = true;
                            }
                            break;
                        }
                    case Keys.F:
                        {
                            ShowFormFind();
                            break;
                        }
                    case Keys.Up:
                        {
                            e.Handled = true;
                            CommonFunc.config.Opacity += 5;
                            this.Opacity = (double)CommonFunc.config.Opacity / 100;
                            break;
                        }
                    case Keys.Down:
                        {
                            e.Handled = true;
                            CommonFunc.config.Opacity -= 5;
                            this.Opacity = (double)CommonFunc.config.Opacity / 100;
                            break;
                        }
                    case Keys.B:
                        {
                            CommonFunc.AutoScroll = !CommonFunc.AutoScroll;
                            CommonFunc.Timer.Interval = CommonFunc.config.NormalAutoScrollInterval * 1000;
                            CommonFunc.Timer.Enabled = CommonFunc.AutoScroll;
                            break;
                        }
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        {
                            new FormHelp().ShowDialog();
                            break;
                        }
                    case Keys.F5:
                        {
                            ShowFileText();
                            break;
                        }
                    case Keys.F3:
                        {
                            CommonFunc.FindRichTextBoxString();
                            break;
                        }
                    case Keys.Escape:
                        {
                            if (MessageBox.Show("您确定要退出程序？", "退出程序", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                this.Close();
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        #endregion

        #region 主菜单

        #region 文件

        // 主菜单“打开”
        private void mnuItemOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenFile(openFileDialog1.FileNames[0]);
                ShowFileText();
            }
        }

        // 主菜单“保存”
        private void mnuItemSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        // 主菜单“另存为”
        private void mnuItemSaveAs_Click(object sender, EventArgs e)
        {
            SaveAsFile();
        }

        // 主菜单“关闭当前文件”
        private void mnuItemCloseActiveFile_Click(object sender, EventArgs e)
        {
            SaveFile();
            CommonFunc.ActiveFile = null;
            rtbText.Clear();
            ShowStatusText();
        }

        // 主菜单“退出”
        private void mnuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // “打开历史”菜单下的文件列表中的项的点击事件
        private void item_Click(object sender, EventArgs e)
        {
            int index = mnuItemOpenHistory.DropDownItems.IndexOf((ToolStripItem)sender);
            FileInformation file = CommonFunc.config.FileInfoList[index];
            if (File.Exists(file.Path))
            {
                CommonFunc.ActiveFile = file;
                ShowFileText();
            }
            else
            {
                CommonFunc.config.RemoveFile(file);
                mnuItemOpenHistory.DropDownItems.Remove((ToolStripItem)sender);
                MessageBox.Show("此文件不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region 编辑

        // 主菜单“剪切”
        private void mnuItemCut_Click(object sender, EventArgs e)
        {
            rtbText.Cut();
        }

        // 主菜单“拷贝”
        private void mnuItemCopy_Click(object sender, EventArgs e)
        {
            rtbText.Copy();
        }

        // 主菜单“粘贴”
        private void mnuItemPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                rtbText.Paste();
            }
        }

        // 主菜单“查找”
        private void mnuItemFind_Click(object sender, EventArgs e)
        {
            ShowFormFind();
        }

        // 主菜单“字体”
        private void mnuItemFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = rtbText.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbText.Font = fontDialog1.Font;
                rtbText.Refresh();
                CommonFunc.config.FontName = fontDialog1.Font.Name;
                CommonFunc.config.FontSize = (int)fontDialog1.Font.Size;
            }
        }

        // 主菜单“自动换行”
        private void mnuItemWordWrap_Click(object sender, EventArgs e)
        {
            rtbText.WordWrap = mnuItemWordWrap.Checked;
        }

        // 主菜单"做书签"
        private void mnuItemBookMark_Click(object sender, EventArgs e)
        {
            // 1.0.0.30
            if (null != CommonFunc.ActiveFile)
            {
                CommonFunc.ActiveFile.BookMark = rtbText.SelectionStart;
            }
            SaveStatus();
        }

        // 主菜单“移至书签”
        private void mnuItemJumpToBookMark_Click(object sender, EventArgs e)
        {
            JumpToBookMark();
        }

        // “编码”菜单下的文件列表中的项的点击事件
        private void MenuEncoding_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (!item.Checked)
            {
                for (int i = 0; i < mnuItemEncoding.DropDownItems.Count; i++)
                {
                    if (item.Text.Equals(mnuItemEncoding.DropDownItems[i].Text))
                    {
                        item.Checked = true;
                        if (null != CommonFunc.ActiveFile)
                        {
                            CommonFunc.ActiveFile.Encode = CommonFunc.DictMenuToEncoding[item.Text];
                        }
                    }
                    else
                    {
                        ((ToolStripMenuItem)mnuItemEncoding.DropDownItems[i]).Checked = false;
                    }
                }
                ShowFileText();
            }
        }

        /// <summary>
        /// 根据提供的编码名称，使对应的编码选项选中
        /// </summary>
        /// <param name="encodingName"></param>
        private void CheckedMenuItemByName(string encodingName)
        {
            for (int i = 0; i < mnuItemEncoding.DropDownItems.Count; i++)
            {
                if (!string.IsNullOrEmpty(encodingName) &&
                    CommonFunc.DictEncodingToMenu[encodingName].Equals(mnuItemEncoding.DropDownItems[i].Text))
                {
                    ((ToolStripMenuItem)mnuItemEncoding.DropDownItems[i]).Checked = true;
                }
                else
                {
                    ((ToolStripMenuItem)mnuItemEncoding.DropDownItems[i]).Checked = false;
                }
            }
        }

        #endregion

        #region 选项

        // 主菜单“迷你模式”
        private void mnuItemMini_Click(object sender, EventArgs e)
        {
            this.Hide();
            CommonFunc.IsMiniStatus = true;
            FormMini frmMini = new FormMini();
            frmMini.RichText = rtbText.Text;
            frmMini.BookMark = rtbText.SelectionStart;
            rtbText.SelectionStart = frmMini.MyShowDialog();
            rtbText.ScrollToCaret();
            CommonFunc.RichTextBox = rtbText;
            CommonFunc.IsMiniStatus = false;
            this.Show();
            //this.menuStrip1.Hide();
            //this.statusStrip1.Hide();
            //this.rtbText.Dock = DockStyle.Fill;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.MinimumSize = new Size(80, CommonFunc.config.FontSize + 2);
            //this.Height = CommonFunc.config.FontSize + 2;
        }

        // 主菜单“管理打开历史”
        private void mnuItemConfigOpenHistory_Click(object sender, EventArgs e)
        {
            new FormOpenHistory().ShowDialog();
            SetMenuOpenHistory();
        }

        // 主菜单“设置”
        private void mnuItemConfig_Click(object sender, EventArgs e)
        {
            if (new FormSetting().ShowDialog() == DialogResult.OK)
            {
                this.Opacity = (double)CommonFunc.config.Opacity / 100;
                CommonFunc.Timer.Interval = CommonFunc.config.NormalAutoScrollInterval * 1000;
                this.rtbText.BackColor = Color.FromArgb(CommonFunc.config.BackColor);
            }
        }

        private void mnuItemIntroduction_Click(object sender, EventArgs e)
        {
            FormReleaseHistory frmReleaseHistory = new FormReleaseHistory();
            frmReleaseHistory.ShowDialog();
        }

        private void mnuItemInfo_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void mnuItemHelp_Click_1(object sender, EventArgs e)
        {
            new FormHelp().ShowDialog();
        }

        //主菜单“精简模式”
        private void mnuItemSimpleMode_Click(object sender, EventArgs e)
        {
            ChangeSimpleMode();
        }
        
        #endregion

        #endregion

        #region 右键菜单

        // 右键菜单“剪切”
        private void mnuItemPopCut_Click(object sender, EventArgs e)
        {
            rtbText.Cut();
        }

        // 右键菜单“拷贝”
        private void mnuItemPopCopy_Click(object sender, EventArgs e)
        {
            rtbText.Copy();
        }

        // 右键菜单“粘贴”
        private void mnuItemPopPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                rtbText.Paste();
            }
        }

        // 右键菜单“移至书签”
        private void mnuItemPopJumpToBookMark_Click(object sender, EventArgs e)
        {
            JumpToBookMark();
        }

        // 右键菜单“做书签”
        private void mnuItemPopBookMark_Click(object sender, EventArgs e)
        {
            // 以菜单的左上角坐标，作为当前书签位置的坐标
            Point contextPoint = new Point(contextMenuStrip1.Left, contextMenuStrip1.Top);
            rtbText.SelectionStart = rtbText.GetCharIndexFromPosition(rtbText.PointToClient(contextPoint));
            CommonFunc.ActiveFile.BookMark = rtbText.SelectionStart;
            SaveStatus();
        }
        // 右键菜单“精简模式”
        private void mnuItemPopSimpleMode_Click(object sender, EventArgs e)
        {
            ChangeSimpleMode();
        }

        #endregion

        #endregion

        #region 功能函数

        /// <summary>
        /// 显示文本
        /// </summary>
        private void ShowFileText()
        {
            if (null != CommonFunc.ActiveFile)
            {
                rtbText.Text = File.ReadAllText(CommonFunc.ActiveFile.Path, Encoding.GetEncoding(CommonFunc.ActiveFile.Encode));
                rtbText.SelectionStart = (0 == CommonFunc.ActiveFile.BookMark) ? 0 : CommonFunc.ActiveFile.BookMark - 2;
                rtbText.ScrollToCaret();
                rtbText.Font = new Font(CommonFunc.config.FontName, CommonFunc.config.FontSize);
                ShowStatusText();
            }
        }

        /// <summary>
        /// 显示状态信息
        /// </summary>
        private void ShowStatusText()
        {
            if (null != CommonFunc.ActiveFile)
            {
                tsslEncoding.Text = CommonFunc.ActiveFile.Encode;
                tsslInfo.Text = Path.GetFileNameWithoutExtension(CommonFunc.ActiveFile.Path);
                this.Text = tsslInfo.Text + " - ReaderMe";
                SetWordCountText();
                CheckedMenuItemByName(CommonFunc.ActiveFile.Encode);
            }
            else
            {
                tsslEncoding.Text = "未知";
                tsslInfo.Text = string.Empty;
                this.Text = "ReaderMe";
                tsslWordCount.Text = "0";
                CheckedMenuItemByName(string.Empty);
            }
        }

        /// <summary>
        /// 保存文本
        /// </summary>
        private void SaveFile()
        {
            if (null != CommonFunc.ActiveFile)
            {
                StreamWriter sr = new StreamWriter(CommonFunc.ActiveFile.Path, false, Encoding.GetEncoding(CommonFunc.ActiveFile.Encode));
                sr.Write(rtbText.Text);
                sr.Close();
            }
            else
            {
                SaveAsFile();
            }
        }

        /// <summary>
        /// 另存为文本
        /// </summary>
        private void SaveAsFile()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (null == CommonFunc.ActiveFile)
                {
                    CommonFunc.ActiveFile = new FileInformation();
                    CommonFunc.ActiveFile.Path = saveFileDialog1.FileName;
                    SaveFile();
                    CommonFunc.ActiveFile = new FileInformation(saveFileDialog1.FileName);
                }
                else
                {
                    CommonFunc.ActiveFile = new FileInformation(CommonFunc.ActiveFile);
                    CommonFunc.ActiveFile.Path = saveFileDialog1.FileName;
                    SaveFile();
                }
                CommonFunc.config.AddFile(CommonFunc.ActiveFile);
                SetMenuOpenHistory();
                ShowStatusText();
            }
        }

        /// <summary>
        /// 显示查询窗口
        /// </summary>
        private void ShowFormFind()
        {
            if (null != CommonFunc.ActiveFile || !string.IsNullOrEmpty(this.rtbText.Text))
            {
                CommonFunc.FindStatus.SelectedString = rtbText.SelectedText;
                FormFind form = FormFind.GetInstance();
                form.Show();
                form.FormFind_Load(this, new EventArgs());
            }
        }

        /// <summary>
        /// 跳转到书签位置
        /// </summary>
        private void JumpToBookMark()
        {
            if (null != CommonFunc.ActiveFile)
            {
                rtbText.SelectionStart = CommonFunc.ActiveFile.BookMark;
                rtbText.SelectionLength = 0;
                rtbText.ScrollToCaret();
            }
        }

        /// <summary>
        /// 打开一个文件，并将文件添加到配置文件中去
        /// </summary>
        /// <param name="filePath">文件完整路径</param>
        private void OpenFile(string filePath)
        {
            try
            {
                FileInformation newFile = new FileInformation(filePath);
                // 获得历史记录中所有与当前文件路径相同的记录集
                List<FileInformation> existFiles = CommonFunc.config.GetFileOnlyWithPath(newFile);
                // 获得已经获得的记录集中与当前文件MD5相同的记录
                FileInformation existFile = CommonFunc.CheckFileMD5(newFile, existFiles);
                if (existFiles.Count > 0)
                {
                    if (null == existFile)
                    {
                        DialogResult dr = MessageBox.Show("发现文件已改变，是覆盖当前ReaderMe中的记录？\n" +
                            "此操作将覆盖当前ReaderMe中的记录。\n" +
                                "如果选择“否”，将生成一条新纪录。\n" +
                                "如果选择“取消”，将停止打开文件。", "发现文件已改变",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            for (int i = 0; i < existFiles.Count; i++)
                            {
                                existFiles[i].MD5 = newFile.MD5;
                            }
                            CommonFunc.ActiveFile = existFiles[0];
                            CommonFunc.ActiveFile.UpdateTime = newFile.UpdateTime;
                        }
                        else if (dr == DialogResult.No)
                        {
                            CommonFunc.ActiveFile = newFile;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        CommonFunc.ActiveFile = existFile;
                    }
                }
                else // 新的文件
                {
                    if (CommonFunc.ActiveFile != null
                        && !string.IsNullOrEmpty(filePath)
                        && MessageBox.Show("是否将当前显示内容作为最新书签位置？", "当前阅读",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        CommonFunc.ActiveFile.BookMark = rtbText.GetCharIndexFromPosition(rtbText.PointToClient(Cursor.Position));
                        SaveStatus();
                    }
                    CommonFunc.ActiveFile = newFile;
                }
                CommonFunc.config.AddFile(CommonFunc.ActiveFile);

                SetMenuOpenHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生了错误：\n" + ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 保存当前状态
        /// </summary>
        private void SaveStatus()
        {
            if (CommonFunc.ActiveFile != null)
            {
                CommonFunc.ActiveFile.UpdateTime = DateTime.Now.ToString(Constants.FORMAT_FILEINFO_UPDATETIME);
                //CommonFunc.ActiveFile.BookMark = rtbText.SelectionStart;
                CommonFunc.config.AddFile(CommonFunc.ActiveFile);
            }
            CommonFunc.config.Width = this.Width;
            CommonFunc.config.Height = this.Height;
            CommonFunc.config.Top = this.Top;
            CommonFunc.config.Left = this.Left;
            CommonFunc.config.FontName = rtbText.Font.Name;
            CommonFunc.config.FontSize = (int)rtbText.Font.Size;
            CommonFunc.config.WordWrap = mnuItemWordWrap.Checked ? 1 : 0;
        }

        private Point rtbLocation;
        private Size rtbSize;
        /// <summary>
        /// 切换精简模式
        /// </summary>
        private void ChangeSimpleMode()
        {
            this.Hide();
            if (this.FormBorderStyle == FormBorderStyle.Sizable)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.statusStrip1.Hide();
                this.menuStrip1.Hide();
                this.rtbLocation = this.rtbText.Location;
                this.rtbSize = this.rtbText.Size;
                this.rtbText.Dock = DockStyle.Fill;
                mnuItemPopSimpleMode.Checked = true;
                this.ShowInTaskbar = false;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.rtbText.Size = this.rtbSize;
                this.rtbText.Location = this.rtbLocation;
                this.rtbText.Dock = DockStyle.None;
                this.rtbText.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                mnuItemPopSimpleMode.Checked = false;
                this.ShowInTaskbar = true;
                this.statusStrip1.Show();
                this.menuStrip1.Show();
            }
            CommonFunc.ReRegisterHotKey();
            this.Show();
        }
        
        #endregion

        private void mnuItemSmartClearSpaceLine_Click(object sender, EventArgs e)
        {
            if (CommonFunc.ActiveFile != null)
            {
                try
                {
                    //SaveFile();
                    StringBuilder fileText = new StringBuilder();
                    Encoding encoding = Encoding.GetEncoding(CommonFunc.ActiveFile.Encode);
                    StreamReader reader = new StreamReader(CommonFunc.ActiveFile.Path, encoding);
                    encoding = reader.CurrentEncoding;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line.Trim().Length > 0)
                        {
                            fileText.AppendLine(line);
                        }
                    }
                    reader.Close();

                    StreamWriter writer = new StreamWriter(CommonFunc.ActiveFile.Path, false, encoding);
                    writer.Write(fileText.ToString().TrimEnd());
                    writer.Close();

                    FileInformation newFile = new FileInformation(CommonFunc.ActiveFile.Path);
                    // 获得历史记录中所有与当前文件路径相同的记录集
                    List<FileInformation> existFiles = CommonFunc.config.GetFileOnlyWithPath(newFile);
                    for (int i = 0; i < existFiles.Count; i++)
                    {
                        existFiles[i].MD5 = newFile.MD5;
                    }
                    CommonFunc.ActiveFile = existFiles[0];
                    CommonFunc.ActiveFile.UpdateTime = newFile.UpdateTime;
                    CommonFunc.config.AddFile(CommonFunc.ActiveFile);

                    //OpenFile(CommonFunc.ActiveFile.Path);
                    ShowFileText();
                }
                catch (Exception ex)
                {
                    //
                }
            }
        }
    }
}