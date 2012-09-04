﻿namespace GPSoft.Tools.ReaderMe.Common
{
    /***************************************
     * 错误编号规则
     * 编号长度为8位
     * [错误级别2位] + [错误类型2位] + [错误编号4位]
     * 
     * 级别：
     * 0：无错误
     * 1：业务可继续（警告）
     * 2：业务不可继续，但保证数据完整性（严重）
     * 3：业务不可继续，数据可能受损（致命）
     * 
     * 类型：
     * 0：无错误
     * 1：程序配置错误
     * 2：文件系统错误
     * 3：网络异常
     * 4：数据库错误
     * 5：UI异常
     * 6：业务逻辑异常
     * 7：数据受损
     * 
     * 编号：
     * 0：缺省
     ***************************************/

    /// <summary>
    /// 错误号一览
    /// </summary>
    public sealed class ErrorCode
    {
        /// <summary>
        /// 缺省值，没有任何错误
        /// </summary>
        public const string NONE = "00000000";
    }
}
