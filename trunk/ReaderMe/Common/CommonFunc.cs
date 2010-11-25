/*
 *********************************************************************
 * 程序名称 : ReaderMe
 * 类名称   : CommonFunc
 * 说明     : 公共函数
 * 作者     : 高云鹏
 * 作成日期 : 2008-10-27
 * 修改履历 :
 * 日期         修改者  程序版本    类型    理由
 * 2008-10-27   高云鹏  1.0.0.0     新规    首次记录
 * 2010-01-14   高云鹏  1.0.0.31    修改    精简模式时，不在任务栏上显示
 *********************************************************************
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using GYP.Helper.HotKey;
using GYP.Helper.LogHelper;
using ReaderMe.Model;

namespace ReaderMe.Common
{
    public class CommonFunc
    {
        #region 公有变量

        public static Configurations config = Configurations.GetInstance();

        #endregion

        #region 私有变量

        private static FileInformation _ActiveFile;
        private static RichTextBox _RichTextBox;
        private static FindStatus _FindStatus;
        private static Timer timer = new Timer();
        private static Hotkey hotKey = new Hotkey();
        private static LogHelper log = new LogHelper(LogInstance.LITxtLog);  //日志文件对象

        private static bool _AutoScroll;
        private static bool _IsMiniStatus;

        private static Dictionary<string, int> _DictHotKey = new Dictionary<string, int>();
        private static Dictionary<string, string> _DictMenuToEncoding = new Dictionary<string, string>();
        private static Dictionary<string, string> _DictEncodingToMenu = new Dictionary<string, string>(); 

        #endregion

        #region 属性

        /// <summary>
        /// 设置或者获取当前正在阅读中的文件
        /// </summary>
        public static FileInformation ActiveFile
        {
            get { return CommonFunc._ActiveFile; }
            set { CommonFunc._ActiveFile = value; }
        }

        /// <summary>
        /// 设置或者获取当前窗口中的RichTextBox对象
        /// </summary>
        public static RichTextBox RichTextBox
        {
            get { return CommonFunc._RichTextBox; }
            set { CommonFunc._RichTextBox = value; }
        }

        /// <summary>
        /// 设置或者获取查询状态类的实例
        /// </summary>
        public static FindStatus FindStatus
        {
            get
            {
                if (null == _FindStatus)
                {
                    _FindStatus = new FindStatus();
                    _FindStatus.StartIndex = _RichTextBox.SelectionStart;
                    _FindStatus.EndIndex = _RichTextBox.Text.Length - 1;
                }
                return _FindStatus;
            }
            set { _FindStatus = value; }
        }

        /// <summary>
        /// 设置或者获取是否为自动滚动状态
        /// </summary>
        public static bool AutoScroll
        {
            get { return CommonFunc._AutoScroll; }
            set { CommonFunc._AutoScroll = value; }
        }

        /// <summary>
        /// 设置或者获取是否是迷你模式
        /// </summary>
        public static bool IsMiniStatus
        {
            get { return CommonFunc._IsMiniStatus; }
            set { CommonFunc._IsMiniStatus = value; }
        }

        /// <summary>
        /// 获取热键控制类实例
        /// </summary>
        public static Hotkey HotKey
        {
            get { return CommonFunc.hotKey; }
        }

        /// <summary>
        /// 获取Timer实例
        /// </summary>
        public static Timer Timer
        {
            get { return CommonFunc.timer; }
        }

        /// <summary>
        /// 获取热键字典
        /// </summary>
        public static Dictionary<string, int> DictHotKey
        {
            get { return CommonFunc._DictHotKey; }
        }

        /// <summary>
        /// 获取菜单对应编码字典
        /// </summary>
        public static Dictionary<string, string> DictMenuToEncoding
        {
            get { return CommonFunc._DictMenuToEncoding; }
        }

        /// <summary>
        /// 获取编码对应菜单字典
        /// </summary>
        public static Dictionary<string, string> DictEncodingToMenu
        {
            get { return CommonFunc._DictEncodingToMenu; }
        } 

        #endregion

        #region WinAPI引用

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(
            IntPtr hWnd,    // handle to destination window
            int Msg,        // message
            int wParam,     // first message parameter
            int lParam      // second message parameter
            );

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture(); 

        #endregion

        public static void ScrollDown(IntPtr richTextBoxHandle)
        {
            SendMessage(richTextBoxHandle, Consts.WIN_MESSAGE_WS_VSCROLL, Consts.WIN_PARAM_SB_LINEDOWN, 0x0);
        }

        public static void ScrollUp(IntPtr richTextBoxHandle)
        {
            SendMessage(richTextBoxHandle, Consts.WIN_MESSAGE_WS_VSCROLL, Consts.WIN_PARAM_SB_LINEUP, 0x0);
        }

        public static void ScrollLeft(IntPtr richTextBoxHandle)
        {
            SendMessage(richTextBoxHandle, Consts.WIN_MESSAGE_WS_VSCROLL, Consts.WIN_PARAM_SB_LINELEFT, 0x0);
        }

        public static void ScrollRight(IntPtr richTextBoxHandle)
        {
            SendMessage(richTextBoxHandle, Consts.WIN_MESSAGE_WS_VSCROLL, Consts.WIN_PARAM_SB_LINERIGHT, 0x0);
        }

        /// <summary>
        /// 利用WinAPI移动指定窗口
        /// </summary>
        /// <param name="formHandle">窗口句柄</param>
        public static void MoveWindow(IntPtr formHandle)
        {
            ReleaseCapture();
            SendMessage(formHandle, 
                Consts.WIN_MESSAGE_WM_SYSCOMMAND,
                Consts.WIN_PARAM_HTCAPTION + Consts.WIN_PARAM_SC_MOVE,
                0x0);
        }

        /// <summary>
        /// 利用WinAPI改变指定窗口大小
        /// </summary>
        /// <param name="formHandle">窗口句柄</param>
        public static void ResizeWindow(IntPtr formHandle)
        {
            ReleaseCapture();
            SendMessage(formHandle,
                Consts.WIN_MESSAGE_WM_SYSCOMMAND,
                //Consts.WIN_PARAM_HTCAPTION | Consts.WIN_PARAM_SC_SIZE,
                0xF002,
                0x0);
        }

        private CommonFunc() { }

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            _DictEncodingToMenu.Add(Consts.ENCODE_BIG_UNICODE, Consts.ENCODE_MENU_BIG_UNICODE);
            _DictEncodingToMenu.Add(Consts.ENCODE_UNICODE, Consts.ENCODE_MENU_UNICODE);
            _DictEncodingToMenu.Add(Consts.ENCODE_UTF8, Consts.ENCODE_MENU_UTF8);
            _DictEncodingToMenu.Add(Consts.ENCODE_GB2312, Consts.ENCODE_MENU_GB2312);
            _DictEncodingToMenu.Add(Consts.ENCODE_SHIFT_JIS, Consts.ENCODE_MENU_SHIFT_JIS);

            _DictMenuToEncoding.Add(Consts.ENCODE_MENU_BIG_UNICODE, Consts.ENCODE_BIG_UNICODE);
            _DictMenuToEncoding.Add(Consts.ENCODE_MENU_UNICODE, Consts.ENCODE_UNICODE);
            _DictMenuToEncoding.Add(Consts.ENCODE_MENU_UTF8, Consts.ENCODE_UTF8);
            _DictMenuToEncoding.Add(Consts.ENCODE_MENU_GB2312, Consts.ENCODE_GB2312);
            _DictMenuToEncoding.Add(Consts.ENCODE_MENU_SHIFT_JIS, Consts.ENCODE_SHIFT_JIS);

            // 系统热键
            //hotKey.HWnd = _RichTextBox.FindForm().Handle;
            //_DictHotKey.Add(Consts.HASH_KEY_HOT_KEY_HIDE, hotKey.RegisterHotKey(Keys.D1, Hotkey.KeyFlags.MOD_ALT));
            //_DictHotKey.Add(Consts.HASH_KEY_HOT_KEY_SHOW, hotKey.RegisterHotKey(Keys.D2, Hotkey.KeyFlags.MOD_ALT));
            //_DictHotKey.Add(Consts.HASH_KEY_HOT_KEY_UP, hotKey.RegisterHotKey(Keys.Up, Hotkey.KeyFlags.MOD_ALT));
            //_DictHotKey.Add(Consts.HASH_KEY_HOT_KEY_DOWN, hotKey.RegisterHotKey(Keys.Down, Hotkey.KeyFlags.MOD_ALT));
            //_DictHotKey.Add(Consts.HASH_KEY_HOT_KEY_LEFT, hotKey.RegisterHotKey(Keys.Left, Hotkey.KeyFlags.MOD_ALT));
            //_DictHotKey.Add(Consts.HASH_KEY_HOT_KEY_RIGHT, hotKey.RegisterHotKey(Keys.Right, Hotkey.KeyFlags.MOD_ALT));
            ReRegisterHotKey();
            hotKey.OnHotkey += new HotkeyEventHandler(hotKey_OnHotkey);

            // 自动滚动
            timer.Interval = config.AutoScrollInterval * 1000;
            timer.Tick += new System.EventHandler(timer1_Tick);

            _IsMiniStatus = false;
        }

        public static void ReRegisterHotKey()
        {
            _DictHotKey.Clear();
            hotKey.HWnd = _RichTextBox.FindForm().Handle;
            _DictHotKey.Add(Consts.HASH_KEY_HOT_KEY_HIDE, hotKey.RegisterHotKey(Keys.D1, Hotkey.KeyFlags.MOD_ALT));
            _DictHotKey.Add(Consts.HASH_KEY_HOT_KEY_SHOW, hotKey.RegisterHotKey(Keys.D2, Hotkey.KeyFlags.MOD_ALT));
            _DictHotKey.Add(Consts.HASH_KEY_HOT_KEY_UP, hotKey.RegisterHotKey(Keys.Up, Hotkey.KeyFlags.MOD_ALT));
            _DictHotKey.Add(Consts.HASH_KEY_HOT_KEY_DOWN, hotKey.RegisterHotKey(Keys.Down, Hotkey.KeyFlags.MOD_ALT));
            _DictHotKey.Add(Consts.HASH_KEY_HOT_KEY_LEFT, hotKey.RegisterHotKey(Keys.Left, Hotkey.KeyFlags.MOD_ALT));
            _DictHotKey.Add(Consts.HASH_KEY_HOT_KEY_RIGHT, hotKey.RegisterHotKey(Keys.Right, Hotkey.KeyFlags.MOD_ALT));
        }

        private static void timer1_Tick(object sender, EventArgs e)
        {
            CommonFunc.ScrollDown(_RichTextBox.Handle);
        }

        // 系统热键响应
        private static void hotKey_OnHotkey(int HotKeyID)
        {
            if (HotKeyID == _DictHotKey[Consts.HASH_KEY_HOT_KEY_HIDE])
            {
                if (!_IsMiniStatus)
                {
                    if (CommonFunc.AutoScroll && timer.Enabled)
                    {
                        timer.Stop();
                    }
                    _RichTextBox.FindForm().Hide();
                }
                else
                {
                    _RichTextBox.FindForm().Opacity = 0;
                }
            }
            else if (HotKeyID == _DictHotKey[Consts.HASH_KEY_HOT_KEY_SHOW])
            {
                if (!_IsMiniStatus)
                {
                    _RichTextBox.FindForm().Show();
                    if (CommonFunc.AutoScroll && !timer.Enabled)
                    {
                        timer.Start();
                    }
                }
                else
                {
                    _RichTextBox.FindForm().Opacity = (double)CommonFunc.config.Opacity / 100;
                    _RichTextBox.FindForm().Activate();
                }
            }
            else if (HotKeyID == _DictHotKey[Consts.HASH_KEY_HOT_KEY_UP])
            {
                CommonFunc.ScrollUp(_RichTextBox.Handle);
            }
            else if (HotKeyID == _DictHotKey[Consts.HASH_KEY_HOT_KEY_DOWN])
            {
                CommonFunc.ScrollDown(_RichTextBox.Handle);
            }
            else if (HotKeyID == _DictHotKey[Consts.HASH_KEY_HOT_KEY_LEFT])
            {
                CommonFunc.ScrollLeft(_RichTextBox.Handle);
            }
            else if (HotKeyID == _DictHotKey[Consts.HASH_KEY_HOT_KEY_RIGHT])
            {
                CommonFunc.ScrollRight(_RichTextBox.Handle);
            }
        }

        public static FileInformation CheckFileMD5(FileInformation newFile, List<FileInformation> existFiles)
        {
            FileInformation result = null;
            for (int i = 0; i < existFiles.Count; i++)
            {
                if (newFile.MD5.Equals(existFiles[i].MD5))
                {
                    result = existFiles[i];
                    break;
                }
            }
            return result;
        }

        #region 获得文件编码格式

        /// <summary>
        /// 获得指定文件的编码
        /// </summary>
        /// <param name="fileName">文件完整路径</param>
        /// <returns>文件的编码</returns>
        public static Encoding GetEncoding(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            System.Text.Encoding r = GetEncoding(fs);
            fs.Close();
            return r;
        }

        /// <summary>
        /// 获得指定文件流的编码
        /// </summary>
        /// <param name="fs">文件流</param>
        /// <returns>文件流的编码</returns>
        public static Encoding GetEncoding(FileStream fs)
        {
            /*byte[] Unicode=new byte[]{0xFF,0xFE};
            byte[] UnicodeBIG=new byte[]{0xFE,0xFF};
            byte[] UTF8=new byte[]{0xEF,0xBB,0xBF};*/

            BinaryReader r = new BinaryReader(fs, System.Text.Encoding.Default);
            byte[] ss;
            if (fs.Length >= 3)
            {
                ss = r.ReadBytes(3);
            }
            else if (fs.Length == 2)
            {
                ss = r.ReadBytes(2);
            }
            else
            {
                return Encoding.Default;
            }
            r.Close();
            //编码类型 Coding=编码类型.ASCII;
            if (ss[0] >= 0xEF)
            {
                if (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF)
                {
                    return Encoding.UTF8;
                }
                else if (ss[0] == 0xFE && ss[1] == 0xFF)
                {
                    return Encoding.BigEndianUnicode;
                }
                else if (ss[0] == 0xFF && ss[1] == 0xFE)
                {
                    return Encoding.Unicode;
                }
                else
                {
                    return Encoding.Default;
                }
            }
            else
            {
                return Encoding.Default;
            }
        }

        #endregion

        #region 字符串查找

        /// <summary>
        /// 查找匹配到的下一个字符串
        /// </summary>
        public static void FindRichTextBoxString()
        {
            if (!string.IsNullOrEmpty(FindStatus.SelectedString))
            {
                if (_FindStatus.Reverse)
                {
                    _FindStatus.StartIndex = 0;
                    _FindStatus.EndIndex = _RichTextBox.SelectionStart;
                }
                else
                {
                    _FindStatus.StartIndex = 0 == _RichTextBox.SelectionLength ? _RichTextBox.SelectionStart : _RichTextBox.SelectionStart + _RichTextBox.SelectionLength;
                    _FindStatus.EndIndex = _RichTextBox.Text.Length;
                }

                if (_FindStatus.StartIndex != _FindStatus.EndIndex)
                {
                    _RichTextBox.Find(_FindStatus.SelectedString, _FindStatus.StartIndex, _FindStatus.EndIndex, _FindStatus.BoxFinds);
                }
                _RichTextBox.FindForm().Activate();
            }
        }

        /// <summary>
        /// 统计所有匹配的字符串个数
        /// </summary>
        /// <returns></returns>
        public static int FindRichTextBoxStringCount()
        {
            return HighLightAllFindedString(System.Drawing.Color.White);
        }

        /// <summary>
        /// 高亮显示所有匹配的字符串
        /// </summary>
        public static void HighLightAllFindedString()
        {
            HighLightAllFindedString(System.Drawing.Color.LimeGreen);
        }

        /// <summary>
        /// 取消所有高亮的字符串
        /// </summary>
        public static void ClearAllHighLightString()
        {
            HighLightAllFindedString(System.Drawing.Color.White);
        }

        /// <summary>
        /// 利用指定颜色高亮显示查找到的所有匹配的字符串
        /// </summary>
        /// <param name="color">高亮颜色</param>
        /// <returns>匹配到的字符串个数</returns>
        private static int HighLightAllFindedString(System.Drawing.Color color)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(FindStatus.SelectedString))
            {
                int startIndex = 0;
                int endIndex = _RichTextBox.Text.Length;
                while (-1 != _RichTextBox.Find(_FindStatus.SelectedString, startIndex, endIndex, _FindStatus.BoxFinds))
                {
                    if (_FindStatus.Reverse)
                    {
                        endIndex = _RichTextBox.SelectionStart;
                    }
                    else
                    {
                        startIndex = _RichTextBox.SelectionStart + _RichTextBox.SelectionLength;
                    }
                    result++;
                    _RichTextBox.SelectionBackColor = color;
                    if (startIndex == endIndex)
                    {
                        break;
                    }
                }
                _RichTextBox.SelectionStart = FindStatus.StartIndex;
                _RichTextBox.SelectionLength = 0;
                _RichTextBox.ScrollToCaret();
            }
            return result;
        } 

        #endregion

        #region  写日志

        /// <summary>
        /// 写日志（只有Debug状态或者发生异常的时候才写日志）
        /// </summary>
        /// <param name="logType">日志类型，LogType参照</param>
        /// <param name="message">日志内容</param>
        public static void WriteLog(LogType logType, string message)
        {
            bool isDebug = (LogType.LTError == logType) || ((null != config) && (1 == config.IsDebug));
            if (isDebug)
            {
                switch (log.InstanceType)
                {
                    case LogInstance.LITxtLog:
                        {
                            if ((null != config) && (config.LogPath.Equals("")))
                            {
                                log.WriteLog(logType, message);
                            }
                            else
                            {
                                log.WriteLog(logType, message, CommonFunc.config.LogPath);
                            }
                            break;
                        }
                    case LogInstance.LIEventLog:
                        {
                            log.WriteLog(logType, message);
                            break;
                        }
                }
            }
        }
        #endregion
    }
}
