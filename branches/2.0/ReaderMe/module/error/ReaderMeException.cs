﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GPSoft.Tools.ReaderMe.module.error
{
    [Serializable]
    public class ReaderMeException : Exception
    {
        private string errorCode;

        public ReaderMeException(string errorCode)
        {
            this.errorCode = errorCode;
        }

        /// <summary>
        /// 获取异常信息
        /// </summary>
        public override string Message
        {
            get
            {
                return base.Message;
            }
        }

        private string GetMessage()
        {
            return ExceptionMessageManager.GetMessage(this.errorCode);
        }
    }
}