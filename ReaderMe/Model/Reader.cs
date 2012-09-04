/* *************************************************************************
 * Copyright (c)2012 NTT DATA BEEN (China) Information Technology Co.,Ltd.
 * 作成者  ：gaoyunpeng
 * 機能概要：
 * 改訂履歴：
 * 2012/9/3 16:16:25 新規 gaoyunpeng
 * *************************************************************************/
namespace GPSoft.Tools.ReaderMe.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 读者
    /// </summary>
    public class Reader
    {
        /// <summary>
        /// 获取读者的私人书架
        /// </summary>
        public Bookshelf Bookshelf { get; private set; }

        /// <summary>
        /// 获取或设置读者的用户名
        /// </summary>
        public string Name { get; set; }
    }
}
