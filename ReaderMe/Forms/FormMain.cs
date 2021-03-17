using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ReaderMe.Common;
using ReaderMe.Controller;
using ReaderMe.Module;

namespace ReaderMe.Forms
{
    public partial class FormMain : Form
    {
        private FormStateController formStateController;
        private RichTextBoxController richTextBoxController;

        public FormMain()
        {
            InitializeComponent();
            formStateController = new FormStateController(this);
            richTextBoxController = new RichTextBoxController(rtbText);
        }

        #region 系统函数

        #region 窗体事件

        // 窗体初始化
        private void FormMain_Load(object sender, EventArgs e)
        {
            CommonFunc.RichTextBox = rtbText;
            CommonFunc.Init();
            // 窗体属性设置
            this.formStateController.LoadState();
            // 富文本框属性设置
            this.richTextBoxController.LoadState();

            rtbText.DragDrop += new DragEventHandler(FormMain_DragDrop);
            rtbText.DragEnter += new DragEventHandler(FormMain_DragEnter);
            rtbText.SelectionChanged += new EventHandler(rtbText_SelectionChanged);

            // 自动换行
            mnuItemWordWrap.Checked = rtbText.WordWrap;
            mnuItemReadOnly.Checked = rtbText.ReadOnly;

            SetMenuOpenHistory();
            SetMenuEncoding();
        }

        private void rtbText_SelectionChanged(object sender, EventArgs e)
        {
            tsslWordCount.Text = this.richTextBoxController.WordCountText;
        }

        /// <summary>
        /// 动态生成“打开历史”菜单
        /// </summary>
        private void SetMenuOpenHistory()
        {
            TimeWatcher watcher = new TimeWatcher();
            watcher.Start();
            mnuItemOpenHistory.DropDownItems.Clear();
            for (int i = 0; i < CommonFunc.Config.FileInfoList.Count; i++)
            {
                ToolStripItem item = mnuItemOpenHistory.DropDownItems.Add(Path.GetFileNameWithoutExtension(CommonFunc.Config.FileInfoList[i].Path));
                item.Click += new EventHandler(item_Click);
            }
            watcher.Stop();
        }

        // “打开历史”菜单下的文件列表中的项的点击事件
        private void item_Click(object sender, EventArgs e)
        {
            int index = mnuItemOpenHistory.DropDownItems.IndexOf((ToolStripItem)sender);
            FileInformation file = CommonFunc.Config.FileInfoList[index];
            if (File.Exists(file.Path))
            {
                CommonFunc.ActiveFile = file;
                ShowFileText();
            }
            else
            {
                CommonFunc.Config.RemoveFile(file);
                mnuItemOpenHistory.DropDownItems.Remove((ToolStripItem)sender);
                MessageBox.Show("此文件不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                CommonFunc.ActiveFile.BookMark = rtbText.SelectionStart;
            }
            SaveStatus();
            // 注销热键
            CommonFunc.HotKey.UnregisterHotKeys();
        }

        /// <summary>
        /// 保存当前状态
        /// </summary>
        private void SaveStatus()
        {
            if (CommonFunc.ActiveFile != null)
            {
                CommonFunc.ActiveFile.UpdateTime = DateTime.Now.ToString(Constants.FORMAT_FILEINFO_UPDATETIME);
                CommonFunc.Config.AddFile(CommonFunc.ActiveFile);
            }
            this.formStateController.SaveState();
            this.richTextBoxController.SaveState();
        }

        // 窗体拖放事件
        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            string filePath = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            string fileExt = Path.GetExtension(filePath).ToUpper();
            if (!fileExt.Equals(Constants.EXT_TEXT_TXT))
            {
                if (MessageBox.Show("您正在打开的文件可能不是文本文件，是否打开？", "警告",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
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
                            richTextBoxController.SaveFile();
                            break;
                        }
                    case Keys.V:
                        {
                            if (Clipboard.ContainsText())
                            {
                               //rtbText.Paste();
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
                            CommonFunc.Config.Opacity += 5;
                            this.Opacity = (double)CommonFunc.Config.Opacity / 100;
                            break;
                        }
                    case Keys.Down:
                        {
                            e.Handled = true;
                            CommonFunc.Config.Opacity -= 5;
                            this.Opacity = (double)CommonFunc.Config.Opacity / 100;
                            break;
                        }
                    case Keys.B:
                        {
                            CommonFunc.AutoScroll = !CommonFunc.AutoScroll;
                            CommonFunc.Timer.Interval = CommonFunc.Config.NormalAutoScrollInterval * 1000;
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
                    case Keys.Space:
                        if (mnuItemReadOnly.Checked)
                        {
                            CommonFunc.SendMessage(rtbText.Handle, Constants.WIN_MESSAGE_WS_VSCROLL, Constants.WIN_PARAM_SB_PAGEDOWN, 0x0);
                            e.Handled = true;
                            e.SuppressKeyPress = false;
                        }
                        break;
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
            richTextBoxController.SaveFile();
        }

        // 主菜单“另存为”
        private void mnuItemSaveAs_Click(object sender, EventArgs e)
        {
            SaveAsFile();
        }

        // 主菜单“关闭当前文件”
        private void mnuItemCloseActiveFile_Click(object sender, EventArgs e)
        {
            richTextBoxController.SaveFile();
            CommonFunc.ActiveFile = null;
            rtbText.Clear();
            ShowStatusBarText();
        }

        // 主菜单“退出”
        private void mnuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                CommonFunc.Config.FontName = fontDialog1.Font.Name;
                CommonFunc.Config.FontSize = (int)fontDialog1.Font.Size;
            }
        }

        // 主菜单“自动换行”
        private void mnuItemWordWrap_Click(object sender, EventArgs e)
        {
            rtbText.WordWrap = mnuItemWordWrap.Checked;
            CommonFunc.Config.WordWrap = mnuItemWordWrap.Checked ? 1 : 0;
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
            this.richTextBoxController.JumpToBookMark();
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
                        if (null != CommonFunc.ActiveFile)
                        {
                            if (CommonFunc.GetEncoding(CommonFunc.ActiveFile.Path) == Encoding.Default &&
                                (item.Text.Equals(Constants.ENCODE_MENU_GB2312) ||
                                item.Text.Equals(Constants.ENCODE_MENU_SHIFT_JIS)))
                            {
                                CommonFunc.ActiveFile.Encode = CommonFunc.DictMenuToEncoding[item.Text];
                                ShowFileText();
                            }
                        }
                    }
                }
                CheckedMenuItemByName(CommonFunc.ActiveFile.Encode);
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
            //this.MinimumSize = new Size(80, CommonFunc.Config.FontSize + 2);
            //this.Height = CommonFunc.Config.FontSize + 2;
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
                this.Opacity = (double)CommonFunc.Config.Opacity / 100;
                CommonFunc.Timer.Interval = CommonFunc.Config.NormalAutoScrollInterval * 1000;
                this.rtbText.BackColor = Color.FromArgb(CommonFunc.Config.BackColor);
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

        private Point formLocation;
        private Point textLocation;
        private Size formSize;
        private Size textSize;

        /// <summary>
        /// 切换精简模式
        /// </summary>
        private void ChangeSimpleMode()
        {
            this.Hide();
            if (this.FormBorderStyle == FormBorderStyle.Sizable)
            {
                this.rtbText.Anchor = AnchorStyles.Left | AnchorStyles.Top;

                this.formLocation = this.Location;
                this.textLocation = this.rtbText.Location;
                this.formSize = this.Size;
                this.textSize = this.rtbText.Size;

                Point location = this.PointToScreen(textLocation);
                Size size = this.rtbText.Size;

                this.FormBorderStyle = FormBorderStyle.None;
                this.statusStrip1.Hide();
                this.menuStrip1.Hide();

                this.Size = size;
                this.Location = location;
                this.rtbText.Location = new Point(0, 0);

                mnuItemPopSimpleMode.Checked = true;
                this.ShowInTaskbar = false;

                this.rtbText.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.statusStrip1.Show();
                this.menuStrip1.Show();

                this.Size = formSize;
                this.Location = formLocation;
                this.rtbText.Location = this.textLocation;
                this.rtbText.Size = this.textSize;

                mnuItemPopSimpleMode.Checked = false;
                this.ShowInTaskbar = true;
            }
            CommonFunc.ReRegisterHotKey();
            this.Show();
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
            this.richTextBoxController.JumpToBookMark();
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
                this.richTextBoxController.ShowFileText();
                ShowStatusBarText();
            }
        }

        /// <summary>
        /// 显示状态信息
        /// </summary>
        private void ShowStatusBarText()
        {
            if (null != CommonFunc.ActiveFile)
            {
                this.Text = Path.GetFileNameWithoutExtension(CommonFunc.ActiveFile.Path) + " - ReaderMe";
                tsslWordCount.Text = this.richTextBoxController.WordCountText;
                CheckedMenuItemByName(CommonFunc.ActiveFile.Encode);
            }
            else
            {
                this.Text = "ReaderMe";
                tsslWordCount.Text = "0";
                CheckedMenuItemByName(string.Empty);
            }
        }

        /// <summary>
        /// 另存为文本
        /// </summary>
        private void SaveAsFile()
        {
            this.richTextBoxController.SaveAsFile();
            SetMenuOpenHistory();
            ShowStatusBarText();
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
        /// 打开一个文件，并将文件添加到配置文件中去
        /// </summary>
        /// <param name="filePath">文件完整路径</param>
        private void OpenFile(string filePath)
        {
            this.richTextBoxController.OpenFile(filePath);
            SetMenuOpenHistory();
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
                    newFile.Encode = CommonFunc.ActiveFile.Encode;
                    // 获得历史记录中所有与当前文件路径相同的记录集
                    List<FileInformation> existFiles = CommonFunc.Config.GetFileOnlyWithPath(newFile);
                    for (int i = 0; i < existFiles.Count; i++)
                    {
                        CommonFunc.Config.RemoveFile(existFiles[i]);
                        //existFiles[i].MD5 = newFile.MD5;
                    }
                    //CommonFunc.ActiveFile = existFiles[0];
                    //CommonFunc.ActiveFile.UpdateTime = newFile.UpdateTime;
                    CommonFunc.ActiveFile = newFile;
                    CommonFunc.Config.AddFile(CommonFunc.ActiveFile);

                    //OpenFile(CommonFunc.ActiveFile.Path);
                    ShowFileText();
                }
                catch (Exception ex)
                {
                    //
                }
            }
        }

        private void mnuItemReadOnly_Click(object sender, EventArgs e)
        {
            rtbText.ReadOnly = mnuItemReadOnly.Checked;
            CommonFunc.Config.ReadOnly = mnuItemReadOnly.Checked;
        }

        private void menuItemTopMost_Click(object sender, EventArgs e)
        {
            menuItemTopMost.Checked = !menuItemTopMost.Checked;
            this.TopMost = menuItemTopMost.Checked;
        }
    }
}