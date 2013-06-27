using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using GPSoft.Tools.ReaderMe.common;
using GPSoft.Tools.ReaderMe.module;

namespace GPSoft.Tools.ReaderMe.Controller
{
    public sealed class RichTextBoxController
    {
        private RichTextBox rtbCurrent;

        /// <summary>
        /// 读取当前阅读进度
        /// </summary>
        public string WordCountText
        {
            get
            {
                return GetWordCountText();
            }
        }

        public RichTextBoxController(RichTextBox richTextBox)
        {
            this.rtbCurrent = richTextBox;
        }

        public void LoadState()
        {
            // 文本区域设置
            this.rtbCurrent.BackColor = Color.FromArgb(CommonFunc.Config.BackColor);
            // 字体
            this.rtbCurrent.Font = new Font(CommonFunc.Config.FontName, CommonFunc.Config.FontSize);
            // 支持拖放打开文件
            this.rtbCurrent.AllowDrop = true;

            this.rtbCurrent.WordWrap = 1 == CommonFunc.Config.WordWrap;
            this.rtbCurrent.ReadOnly = CommonFunc.Config.ReadOnly;
        }

        public void SaveState()
        {
            CommonFunc.Config.FontName = this.rtbCurrent.Font.Name;
            CommonFunc.Config.FontSize = (int)this.rtbCurrent.Font.Size;
            CommonFunc.Config.WordWrap = this.rtbCurrent.WordWrap ? 1 : 0;
            CommonFunc.Config.ReadOnly = this.rtbCurrent.ReadOnly;
        }

        private string GetWordCountText()
        {
            int currentIndex = this.rtbCurrent.GetCharIndexFromPosition(new Point(0, 0));
            currentIndex = Math.Max(currentIndex, this.rtbCurrent.SelectionStart);
            return string.Format("{0}/{1}({2:#0.00}%)", currentIndex, this.rtbCurrent.TextLength,
                this.rtbCurrent.TextLength == 0 ? 0d : currentIndex * 100d / this.rtbCurrent.TextLength);
        }

        /// <summary>
        /// 打开一个文件，并将文件添加到配置文件中去
        /// </summary>
        /// <param name="filePath">文件完整路径</param>
        public void OpenFile(string filePath)
        {
            try
            {
                //System.IO.StreamReader reader = new System.IO.StreamReader(filePath);
                //TODO 提高读取和显示的效率，考虑两种办法：1、使用流；2、将整个txt缓存起来，通过指针遍历
                //TODO 有必要的话，考虑限制可以打开txt的最大大小
                //TODO 提供大文件分割功能
                FileInformation newFile = new FileInformation(filePath);
                // 获得历史记录中所有与当前文件路径相同的记录集
                List<FileInformation> existFiles = CommonFunc.Config.GetFileOnlyWithPath(newFile);
                // 获得已经获得的记录集中与当前文件MD5相同的记录
                FileInformation existFile = CommonFunc.CheckFileMD5(newFile, existFiles);
                if (existFiles.Count > 0)
                {
                    if (null == existFile)
                    {
                        StringBuilder message = new StringBuilder();
                        message.AppendLine("正在打开的文件与历史记录中的信息不符，是覆盖历史记录？");
                        message.AppendLine("如果选择“是”，将覆盖历史记录。");
                        message.AppendLine("如果选择“否”，将生成一条新记录。");
                        message.AppendLine("如果选择“取消”，将停止打开文件。");
                        DialogResult dr = MessageBox.Show(message.ToString(), "文件已改变", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        switch (dr)
                        {
                            case DialogResult.No:
                                CommonFunc.ActiveFile = newFile;
                                break;
                            case DialogResult.Yes:
                                foreach (FileInformation info in existFiles)
                                {
                                    info.MD5 = newFile.MD5;
                                }
                                CommonFunc.ActiveFile = existFiles[0];
                                CommonFunc.ActiveFile.UpdateTime = newFile.UpdateTime;
                                break;
                            default:
                                return;
                                break;
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
                        && File.Exists(filePath)
                        && MessageBox.Show("打开新文件前，是否在当位置作书签？", "确认",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        CommonFunc.ActiveFile.BookMark = this.rtbCurrent.GetCharIndexFromPosition(this.rtbCurrent.PointToClient(Cursor.Position));
                        CommonFunc.ActiveFile.UpdateTime = DateTime.Now.ToString(Constants.FORMAT_FILEINFO_UPDATETIME);
                        CommonFunc.Config.AddFile(CommonFunc.ActiveFile);
                    }
                    CommonFunc.ActiveFile = newFile;
                }
                CommonFunc.Config.AddFile(CommonFunc.ActiveFile);
            }
            catch
            {
                MessageBox.Show("打开文件时发生了错误。", "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ShowFileText()
        {
            if (null != CommonFunc.ActiveFile)
            {
                this.rtbCurrent.Text = File.ReadAllText(CommonFunc.ActiveFile.Path, Encoding.GetEncoding(CommonFunc.ActiveFile.Encode));
                this.rtbCurrent.SelectionStart = (0 == CommonFunc.ActiveFile.BookMark) ? 0 : CommonFunc.ActiveFile.BookMark - 2;
                this.rtbCurrent.ScrollToCaret();
                this.rtbCurrent.Font = new Font(CommonFunc.Config.FontName, CommonFunc.Config.FontSize);
            }
        }

        /// <summary>
        /// 保存文本
        /// </summary>
        public void SaveFile()
        {
            if (null != CommonFunc.ActiveFile)
            {
                StreamWriter sr = new StreamWriter(CommonFunc.ActiveFile.Path, false, Encoding.GetEncoding(CommonFunc.ActiveFile.Encode));
                sr.Write(this.rtbCurrent.Text);
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
        public void SaveAsFile()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.Filter = "文本文件|*.txt|所有文件|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (null == CommonFunc.ActiveFile)
                    {
                        CommonFunc.ActiveFile = new FileInformation();
                        CommonFunc.ActiveFile.Path = saveFileDialog.FileName;
                        SaveFile();
                        CommonFunc.ActiveFile = new FileInformation(saveFileDialog.FileName);
                    }
                    else
                    {
                        CommonFunc.ActiveFile.Path = saveFileDialog.FileName;
                        SaveFile();
                    }
                    CommonFunc.Config.AddFile(CommonFunc.ActiveFile);
                }
            }
        }

        /// <summary>
        /// 跳转到书签位置
        /// </summary>
        public void JumpToBookMark()
        {
            if (null != CommonFunc.ActiveFile)
            {
                this.rtbCurrent.SelectionStart = CommonFunc.ActiveFile.BookMark;
                this.rtbCurrent.SelectionLength = 0;
                this.rtbCurrent.ScrollToCaret();
            }
        }
    }
}
