﻿using System;
using System.Collections.Generic;
using System.Text;
using GPStudio.Tools.ReaderMe.Module.Config;

namespace GPStudio.Tools.ReaderMe.Module.book
{
    /// <summary>
    /// 书籍
    /// </summary>
    public class Book
    {
        /// <summary>
        /// 获取或设置书籍ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置书名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置书签列表
        /// </summary>
        public List<Bookmark> Bookmarks { get; set; }
    }
}