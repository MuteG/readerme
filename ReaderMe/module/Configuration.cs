using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using GPStudio.Tools.ReaderMe.common;
using GPStudio.Tools.ReaderMe.Helper;
using System.Windows.Forms;

namespace GPStudio.Tools.ReaderMe.Module
{
    public class Configuration
    {
        private static Configuration _ConfigInstance = null;

        public Configuration()
        {
        }

        private Configuration(string filePath)
        {
            m_Xml = new XMLHelper(filePath);
            ReadConig();
        }

        public static Configuration GetInstance()
        {
            if (null == _ConfigInstance)
            {
                _ConfigInstance = new Configuration();
                _ConfigInstance.Reload();
            }
            return _ConfigInstance;
        }

        #region 变量声明

        private XMLHelper m_Xml;
        private List<FileInformation> m_FileInfoList;

        private string m_LogPath = string.Empty;
        private string m_FontName;

        private int m_Width, m_Height, m_Top, m_Left, m_opacity;
        private int m_MiniWidth, m_MiniTop, m_MiniLeft;
        private int m_IsDebug;
        private int m_FontSize;
        private int m_WordWrap;
        private int m_NormalAutoScrollInterval;
        private int m_BackColor;

        #endregion

        #region 属性

        /// <summary>
        /// 获取或者设置文本文件信息记录列表
        /// </summary>
        public List<FileInformation> FileInfoList
        {
            get { return m_FileInfoList; }
            set
            {
                m_FileInfoList = value;
                m_Xml.SetAllNodeValues(Constants.XPATH, value, "MD5");
            }
        }

        private int m_ReadOnly = 1;
        /// <summary>
        /// 获取或者设置文件是否只读
        /// </summary>
        public bool ReadOnly
        {
            get { return m_ReadOnly == 1; }
            set
            {
                m_ReadOnly = value ? 1 : 0;
                m_Xml.WriteInteger("ReadOnly", m_ReadOnly);
            }
        }

        /// <summary>
        /// 获取日志路径
        /// </summary>
        public string LogPath
        {
            get { return m_LogPath; }
        }
        /// <summary>
        /// 获取或者设置阅读窗口背景色
        /// </summary>
        public int BackColor
        {
            get { return m_BackColor; }
            set
            {
                m_BackColor = value;
                m_Xml.WriteInteger("BackColor", value);
            }
        }

        /// <summary>
        /// 获取或者设置主窗体宽度
        /// </summary>
        public int Width
        {
            get { return m_Width; }
            set
            {
                m_Width = value;
                m_Xml.WriteInteger("Width", value);
            }
        }

        /// <summary>
        /// 获取或者设置主窗体高度
        /// </summary>
        public int Height
        {
            get { return m_Height; }
            set
            {
                m_Height = value;
                m_Xml.WriteInteger("Height", value);
            }
        }

        /// <summary>
        /// 获取或者设置主窗体左上角Y坐标
        /// </summary>
        public int Top
        {
            get { return m_Top; }
            set
            {
                m_Top = value;
                m_Xml.WriteInteger("Top", value);
            }
        }

        /// <summary>
        /// 获取或者设置主窗体左上角X坐标
        /// </summary>
        public int Left
        {
            get { return m_Left; }
            set
            {
                m_Left = value;
                m_Xml.WriteInteger("Left", value);
            }
        }

        /// <summary>
        /// 获取或者设置迷你窗体宽度
        /// </summary>
        public int MiniWidth
        {
            get { return m_MiniWidth; }
            set
            {
                m_MiniWidth = value;
                m_Xml.WriteInteger("MiniWidth", value);
            }
        }

        /// <summary>
        /// 获取或者设置迷你窗体左上角Y坐标
        /// </summary>
        public int MiniTop
        {
            get { return m_MiniTop; }
            set
            {
                m_MiniTop = value;
                m_Xml.WriteInteger("MiniTop", value);
            }
        }

        /// <summary>
        /// 获取或者设置迷你窗体左上角X坐标
        /// </summary>
        public int MiniLeft
        {
            get { return m_MiniLeft; }
            set
            {
                m_MiniLeft = value;
                m_Xml.WriteInteger("MiniLeft", value);
            }
        }

        /// <summary>
        /// 获取或者设置透明度
        /// </summary>
        public int Opacity
        {
            get { return m_opacity; }
            set
            {
                m_opacity = value;
                if (m_opacity > 100)
                {
                    m_opacity = 100;
                }
                else if (m_opacity < 0)
                {
                    m_opacity = 0;
                }
                m_Xml.WriteInteger("Opacity", m_opacity);
            }
        }

        /// <summary>
        /// 获取是否是调试状态
        /// </summary>
        public int IsDebug
        {
            get { return m_IsDebug; }
        }

        /// <summary>
        /// 获取或者设置通常模式下自动滚动的时间间隔（秒）
        /// </summary>
        public int NormalAutoScrollInterval
        {
            get { return m_NormalAutoScrollInterval; }
            set
            {
                m_NormalAutoScrollInterval = value;
                m_Xml.WriteInteger("NormalAutoScrollInterval", m_NormalAutoScrollInterval);
            }
        }

        private int m_NormalAutoScrollRows;
        /// <summary>
        /// 获取或者设置通常模式下自动滚动的距离（行数）
        /// </summary>
        public int NormalAutoScrollRows
        {
            get { return m_NormalAutoScrollRows; }
            set
            {
                m_NormalAutoScrollRows = value;
                m_Xml.WriteInteger("NormalAutoScrollRows", m_NormalAutoScrollRows);
            }
        }

        private int m_MiniAutoScrollInterval;
        /// <summary>
        /// 获取或者设置迷你模式下自动滚动的时间间隔（秒）
        /// </summary>
        public int MiniAutoScrollInterval
        {
            get { return m_MiniAutoScrollInterval; }
            set
            {
                m_MiniAutoScrollInterval = value;
                m_Xml.WriteInteger("MiniAutoScrollInterval", m_MiniAutoScrollInterval);
            }
        }

        private int m_MiniAutoScrollRows = 1;
        /// <summary>
        /// 获取或者设置迷你模式下自动滚动的距离（行数）
        /// </summary>
        public int MiniAutoScrollRows
        {
            get { return m_MiniAutoScrollRows; }
            set
            {
                m_MiniAutoScrollRows = value;
                m_Xml.WriteInteger("MiniAutoScrollRows", m_MiniAutoScrollRows);
            }
        }

        /// <summary>
        /// 获取或者设置是否自动换行
        /// </summary>
        public int WordWrap
        {
            get { return m_WordWrap; }
            set
            {
                m_WordWrap = value;
                m_Xml.WriteInteger("WordWrap", m_WordWrap);
            }
        }

        /// <summary>
        /// 获取或者设置文字大小
        /// </summary>
        public int FontSize
        {
            get { return m_FontSize; }
            set
            {
                m_FontSize = value;
                m_Xml.WriteInteger("FontSize", m_FontSize);
            }
        }

        /// <summary>
        /// 获取或者设置文字字体
        /// </summary>
        public string FontName
        {
            get { return m_FontName; }
            set
            {
                m_FontName = value;
                m_Xml.WriteString("FontName", m_FontName);
            }
        }

        #endregion

        #region 功能函数

        /// <summary>
        /// 读取窗体大小、位置值
        /// </summary>
        /// <param name="param">记载数值的变量</param>
        /// <param name="nodeName">节点名</param>
        /// <param name="defaultValue">默认值</param>
        private void ReadWindowSize(out int param, string nodeName, int defaultValue)
        {
            param = m_Xml.ReadInteger(nodeName, 0);
            if (0 == param)
            {
                param = defaultValue;
                m_Xml.WriteInteger(nodeName, param);
            }
        }

        /// <summary>
        /// 从配置文件中读取配置信息
        /// </summary>
        private void ReadConig() //从文件中读取设置信息
        {
            //日志路径
            m_LogPath = m_Xml.ReadString("LogPath", "");
            if (m_LogPath.Equals(""))
            {
                m_LogPath = Directory.GetCurrentDirectory() + "\\LOG";
                m_Xml.WriteString("LogPath", m_LogPath);
            }
            ReadWindowSize(out m_Width, "Width", 166);
            ReadWindowSize(out m_Height, "Height", 166);
            Rectangle screenArea = Screen.PrimaryScreen.WorkingArea;
            ReadWindowSize(out m_Top, "Top", (screenArea.Height - m_Height) / 2);
            ReadWindowSize(out m_Left, "Left", (screenArea.Width - m_Width) / 2);
            ReadWindowSize(out m_MiniWidth, "MiniWidth", 150);
            ReadWindowSize(out m_MiniTop, "MiniTop", 0);
            ReadWindowSize(out m_MiniLeft, "MiniLeft", 0);

            m_opacity = m_Xml.ReadInteger("Opacity", 0);
            if (0 >= m_opacity)
            {
                m_opacity = 20;
                m_Xml.WriteInteger("Opacity", m_opacity);
            }
            else if(m_opacity > 100)
            {
                m_opacity = 100;
                m_Xml.WriteInteger("Opacity", m_opacity);
            }
            m_IsDebug = m_Xml.ReadInteger("IsDebug", 0);
            if ((m_IsDebug != 0) && (m_IsDebug != 1))
            {
                m_IsDebug = 1;
                m_Xml.WriteInteger("IsDebug", m_IsDebug);
            }
            m_WordWrap = m_Xml.ReadInteger("WordWrap", 0);
            if ((m_WordWrap != 0) && (m_WordWrap != 1))
            {
                m_WordWrap = 0;
                m_Xml.WriteInteger("WordWrap", m_WordWrap);
            }
            m_NormalAutoScrollInterval = m_Xml.ReadInteger("NormalAutoScrollInterval", Constants.DEFAULT_AUTOSCROLL_INTERVAL);
            m_NormalAutoScrollRows = m_Xml.ReadInteger("NormalAutoScrollRows", Constants.DEFAULT_AUTOSCROLL_ROWS);
            m_MiniAutoScrollInterval = m_Xml.ReadInteger("MiniAutoScrollInterval", Constants.DEFAULT_AUTOSCROLL_INTERVAL);
            m_MiniAutoScrollRows = m_Xml.ReadInteger("MiniAutoScrollRows", Constants.DEFAULT_AUTOSCROLL_ROWS);
            m_FontName = m_Xml.ReadString("FontName", "NSimSun");
            m_FontSize = m_Xml.ReadInteger("FontSize", 12);
            m_ReadOnly = m_Xml.ReadInteger("ReadOnly", 1);
            m_BackColor = m_Xml.ReadInteger("BackColor", Color.White.ToArgb());
            m_FileInfoList =  m_Xml.GetAllNodeValues<FileInformation>(Constants.XPATH);
        }

        /// <summary>
        /// 从文件中重新读取设置的值
        /// </summary>
        public void Reload()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string file = Path.Combine(folder, "ReaderMe.xml");
            ObjectXMLSerializer<Configuration>.Load(ref _ConfigInstance, file);
        }

        /// <summary>
        /// 配置文件中是否存在当前文本文件的信息
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>如果存在返回true，否则返回false</returns>
        public bool ExistFile(string filePath)
        {
            bool result = false;
            FileInformation file = new FileInformation(filePath);
            result = ExistFile(file);
            return result;
        }

        /// <summary>
        /// 配置文件中是否存在当前文本文件的信息
        /// </summary>
        /// <param name="file">文件信息对象</param>
        /// <returns>如果存在返回true，否则返回false</returns>
        public bool ExistFile(FileInformation file)
        {
            bool result = false;
            result = (null != GetFile(file));
            return result;
        }

        /// <summary>
        /// 获得与当前文件信息相符的信息对象
        /// </summary>
        /// <param name="file">作为标准的当前文件信息对象</param>
        /// <returns>返回相符的信息对象，如果不存在则返回null</returns>
        public FileInformation GetFile(FileInformation file)
        {
            FileInformation result = null;
            for (int i = 0; i < m_FileInfoList.Count; i++)
            {
                if (file.Path.Equals(m_FileInfoList[i].Path) && file.MD5.Equals(m_FileInfoList[i].MD5))
                {
                    result = m_FileInfoList[i];
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 获得路径相同的文件信息对象
        /// </summary>
        /// <param name="file">作为标准的当前文件信息对象</param>
        /// <returns>回相符的信息对象，如果不存在则返回null</returns>
        public List<FileInformation> GetFileOnlyWithPath(FileInformation file)
        {
            List<FileInformation> result = new List<FileInformation>();
            for (int i = 0; i < m_FileInfoList.Count; i++)
            {
                if (file.Path.Equals(m_FileInfoList[i].Path))
                {
                    result.Add(FileInfoList[i]);
                }
            }
            return result;
        }

        /// <summary>
        /// 向配置文件中加入一个新的文件信息记录
        /// </summary>
        /// <param name="file">要添加的文件信息记录</param>
        public void AddFile(FileInformation file)
        {
            FileInformation existFile = GetFile(file);
            if (null != existFile)
            {
                existFile.BookMark = file.BookMark;
            }
            else
            {
                this.m_FileInfoList.Add(file);
            }
            m_Xml.SetAllNodeValues(Constants.XPATH, m_FileInfoList, "MD5");
        }

        /// <summary>
        /// 从现有文件信息记录中删除一条记录
        /// </summary>
        /// <param name="file">要删除的文件信息记录</param>
        public void RemoveFile(FileInformation file)
        {
            this.m_FileInfoList.Remove(file);
            m_Xml.RemoveNode(Constants.XPATH, file, "MD5");
        }
        
        /// <summary>
        /// 删除指定索引的文件信息对象（索引从0开始）
        /// </summary>
        /// <param name="index">索引值（索引从0开始）</param>
        public void RemoveFile(int index)
        {
            FileInformation file = new FileInformation(m_FileInfoList[index]);
            this.m_FileInfoList.RemoveAt(index);
            m_Xml.RemoveNode(Constants.XPATH, file, "MD5");
        }

 
	#endregion
    }
}