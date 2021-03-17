using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ReaderMe.Common;

namespace ReaderMe.Module
{
    public class Configuration
    {
        private static Configuration _instance;

        private Configuration()
        {
            _fileInfoList = new List<FileInformation>();
            _readOnly = true;
            _backColor = Color.White.ToArgb();
            _width = 166;
            _height = 166;
            Rectangle screenArea = Screen.PrimaryScreen.WorkingArea;
            _top = (screenArea.Height - _height) / 2;
            _left = (screenArea.Width - _width) / 2;
            _miniWidth = 150;
            _miniTop = 0;
            _miniLeft = 0;
            _opacity = 20;
            _normalAutoScrollInterval = Constants.DEFAULT_AUTOSCROLL_INTERVAL;
            _normalAutoScrollRows = Constants.DEFAULT_AUTOSCROLL_ROWS;
            _miniAutoScrollInterval = Constants.DEFAULT_AUTOSCROLL_INTERVAL;
            _miniAutoScrollRows = 1;
            _wordWrap = 1;
            _fontName = "NSimSun";
            _fontSize = 12;
        }

        public static Configuration GetInstance()
        {
            if (null == _instance)
            {
                _instance = new Configuration();
                _instance.Reload();
            }

            return _instance;
        }

        #region 变量声明
        private readonly List<FileInformation> _fileInfoList;
        private bool _readOnly;
        private int _backColor;
        private int _width, _height, _top, _left, _opacity;
        private int _miniWidth, _miniTop, _miniLeft;
        private int _normalAutoScrollInterval;
        private int _normalAutoScrollRows;
        private int _miniAutoScrollInterval;
        private int _miniAutoScrollRows;
        private int _wordWrap;
        private int _fontSize;
        private string _fontName;
        #endregion

        #region 属性

        /// <summary>
        /// 获取或者设置文本文件信息记录列表
        /// </summary>
        public List<FileInformation> FileInfoList
        {
            get { return _fileInfoList; }
        }

        /// <summary>
        /// 获取或者设置文件是否只读
        /// </summary>
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                Save();
            }
        }

        /// <summary>
        /// 获取或者设置阅读窗口背景色
        /// </summary>
        public int BackColor
        {
            get { return _backColor; }
            set
            {
                _backColor = value;
                Save();
            }
        }

        /// <summary>
        /// 获取或者设置主窗体宽度
        /// </summary>
        public int Width
        {
            get { return _width; }
            set
            {
                _width = value;
                Save();
            }
        }

        /// <summary>
        /// 获取或者设置主窗体高度
        /// </summary>
        public int Height
        {
            get { return _height; }
            set
            {
                _height = value;
                Save();
            }
        }

        /// <summary>
        /// 获取或者设置主窗体左上角Y坐标
        /// </summary>
        public int Top
        {
            get { return _top; }
            set
            {
                _top = value;
                Save();
            }
        }

        /// <summary>
        /// 获取或者设置主窗体左上角X坐标
        /// </summary>
        public int Left
        {
            get { return _left; }
            set
            {
                _left = value;
                Save();
            }
        }

        /// <summary>
        /// 获取或者设置迷你窗体宽度
        /// </summary>
        public int MiniWidth
        {
            get { return _miniWidth; }
            set
            {
                _miniWidth = value;
                Save();
            }
        }

        /// <summary>
        /// 获取或者设置迷你窗体左上角Y坐标
        /// </summary>
        public int MiniTop
        {
            get { return _miniTop; }
            set
            {
                _miniTop = value;
                Save();
            }
        }

        /// <summary>
        /// 获取或者设置迷你窗体左上角X坐标
        /// </summary>
        public int MiniLeft
        {
            get { return _miniLeft; }
            set
            {
                _miniLeft = value;
                Save();
            }
        }

        /// <summary>
        /// 获取或者设置透明度
        /// </summary>
        public int Opacity
        {
            get { return _opacity; }
            set
            {
                _opacity = value;
                if (_opacity > 100)
                {
                    _opacity = 100;
                }
                else if (_opacity <= 0)
                {
                    _opacity = 20;
                }

                Save();
            }
        }

        /// <summary>
        /// 获取或者设置通常模式下自动滚动的时间间隔（秒）
        /// </summary>
        public int NormalAutoScrollInterval
        {
            get { return _normalAutoScrollInterval; }
            set
            {
                _normalAutoScrollInterval = value;
                Save();
            }
        }

        /// <summary>
        /// 获取或者设置通常模式下自动滚动的距离（行数）
        /// </summary>
        public int NormalAutoScrollRows
        {
            get { return _normalAutoScrollRows; }
            set
            {
                _normalAutoScrollRows = value;
                Save();
            }
        }

        /// <summary>
        /// 获取或者设置迷你模式下自动滚动的时间间隔（秒）
        /// </summary>
        public int MiniAutoScrollInterval
        {
            get { return _miniAutoScrollInterval; }
            set
            {
                _miniAutoScrollInterval = value;
                Save();
            }
        }

        /// <summary>
        /// 获取或者设置迷你模式下自动滚动的距离（行数）
        /// </summary>
        public int MiniAutoScrollRows
        {
            get { return _miniAutoScrollRows; }
            set
            {
                _miniAutoScrollRows = value;
                Save();
            }
        }

        /// <summary>
        /// 获取或者设置是否自动换行
        /// </summary>
        public int WordWrap
        {
            get { return _wordWrap; }
            set
            {
                _wordWrap = value;
                Save();
            }
        }

        /// <summary>
        /// 获取或者设置文字大小
        /// </summary>
        public int FontSize
        {
            get { return _fontSize; }
            set
            {
                _fontSize = value;
                Save();
            }
        }

        /// <summary>
        /// 获取或者设置文字字体
        /// </summary>
        public string FontName
        {
            get { return _fontName; }
            set
            {
                _fontName = value;
                Save();
            }
        }

        private string ConfigFile
        {
            get
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                return Path.Combine(folder, @"ReaderMe\Config.xml");
            }
        }

        #endregion

        #region 功能函数
        /// <summary>
        /// 从文件中重新读取设置的值
        /// </summary>
        private void Reload()
        {
            ObjectXmlSerializer<Configuration>.Load(ref _instance, ConfigFile);
        }

        private void Save()
        {
            ObjectXmlSerializer<Configuration>.Save(_instance, ConfigFile);
        }

        /// <summary>
        /// 获得与当前文件信息相符的信息对象
        /// </summary>
        /// <param name="file">作为标准的当前文件信息对象</param>
        /// <returns>返回相符的信息对象，如果不存在则返回null</returns>
        public FileInformation GetFile(FileInformation file)
        {
            FileInformation result = null;
            for (int i = 0; i < _fileInfoList.Count; i++)
            {
                if (file.Path.Equals(_fileInfoList[i].Path) && file.MD5.Equals(_fileInfoList[i].MD5))
                {
                    result = _fileInfoList[i];
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
            for (int i = 0; i < _fileInfoList.Count; i++)
            {
                if (file.Path.Equals(_fileInfoList[i].Path))
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
                _fileInfoList.Add(file);
            }

            Save();
        }

        /// <summary>
        /// 从现有文件信息记录中删除一条记录
        /// </summary>
        /// <param name="file">要删除的文件信息记录</param>
        public void RemoveFile(FileInformation file)
        {
            _fileInfoList.Remove(file);
            Save();
        }

        /// <summary>
        /// 删除指定索引的文件信息对象（索引从0开始）
        /// </summary>
        /// <param name="index">索引值（索引从0开始）</param>
        public void RemoveFile(int index)
        {
            _fileInfoList.RemoveAt(index);
            Save();
        }
        #endregion
    }
}