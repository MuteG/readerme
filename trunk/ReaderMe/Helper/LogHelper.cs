using System;
using System.Diagnostics;
using System.IO;

namespace GPSoft.Tools.ReaderMe.Helper
{
    public enum LogInstance
    {
        LITxtLog = 0,
        LIEventLog = 1
    }

    public enum LogType
    {
        LTDetail = 0,
        LTProcStart = 1,
        LTProcStop = 2,
        LTError = 3,
        LTDB = 4
    }

    public interface ILogHelper
    {
        void WriteLog(LogType logType, string message, string source, string logName);

        void WriteLog(LogType logType, string message, string source);

        void WriteLog(LogType logType, string message);
    }

    public class LogHelper
    {
        private ILogHelper log;
        private LogInstance ins;

        public LogInstance InstanceType
        {
            get { return this.ins; }
        }

        private LogHelper() { }

        public LogHelper(LogInstance li)
        {
            ins = li;
            switch (li)
            {
                case LogInstance.LITxtLog:
                    {
                        log = new TxtLogHelper();
                        break;
                    }
                case LogInstance.LIEventLog:
                    {
                        log = new EventLogHelper();
                        break;
                    }
            }
        }

        public void WriteLog(LogType logType, string message, string source, string logName)
        {
            log.WriteLog(logType, message, source, logName);
        }

        public void WriteLog(LogType logType, string message, string source)
        {
            log.WriteLog(logType, message, source);
        }

        public void WriteLog(LogType logType, string message)
        {
            log.WriteLog(logType, message);
        }
    }

    public class TxtLogHelper : ILogHelper
    {
        #region 写文本日志（ログを書きます）
        /// <summary>
        /// 写日志（ログを書きます）
        /// </summary>
        /// <param name="logType">日志类型（ログのタイプ）、LogType参照</param>
        /// <param name="message">日志信息（ログの情報）</param>
        /// /// <param name="logPath">日志路径（ログのパス）</param>
        /// <param name="logName">日志文件名（ログの名）</param>
        public void WriteLog(LogType logType, string message, string logPath, string logName)
        {
            string logMsg = DateTime.Now.ToString("HH:mm:ss fff\t");
            string logFile = Path.Combine(logPath, logName);  // logPath + "\\" + logName;  //2008-09-05 修改
            //如果路径不存在，建立目录
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            //如果文件不存在，建立文件
            if (!File.Exists(logFile))
            {
                File.Create(logFile).Close();
            }

            switch (logType)
            {
                case LogType.LTDetail:
                    {
                        logMsg += "■\t";
                        break;
                    }
                case LogType.LTError:
                    {
                        logMsg += "◆\t";
                        break;
                    }
                case LogType.LTProcStart:
                    {
                        logMsg += "▼\t";
                        break;
                    }
                case LogType.LTProcStop:
                    {
                        logMsg += "▲\t";
                        break;
                    }
                case LogType.LTDB:
                    {
                        logMsg += "□\t";
                        break;
                    }
                default:
                    break;
            }
            logMsg += message;

            try
            {
                WriteToFile(logFile, logMsg);
            }
            catch
            {
                // do nothing
            }
        }

        /// <summary>
        /// 写日志（ログを書きます）
        /// </summary>
        /// <param name="logType">日志类型（ログのタイプ）、LogType参照</param>
        /// <param name="message">日志信息（ログの情報）</param>
        /// /// <param name="logPath">日志路径（ログのパス）</param>
        public void WriteLog(LogType logType, string message, string logPath)
        {
            WriteLog(logType, message, logPath, DateTime.Now.ToString("yyyy-MM-dd.LOG"));
        }

        /// <summary>
        /// 写日志（ログを書きます）
        /// </summary>
        /// <param name="logType">日志类型（ログのタイプ）、LogType参照</param>
        /// <param name="sMessage">日志信息（ログの情報）</param>
        public void WriteLog(LogType logType, string message)
        {
            WriteLog(logType, message, AppDomain.CurrentDomain.BaseDirectory + "\\LOG");
        }

        /// <summary>
        /// 把信息写到指定文件的尾部
        /// </summary>
        /// <param name="fileName">文件完整路径</param>
        /// <param name="msg">信息文本</param>
        public void WriteToFile(string fileName, string msg)
        {
            StreamWriter swWriter = new StreamWriter(new FileStream(fileName, FileMode.Append));
            swWriter.WriteLine(msg);
            swWriter.Close();
        }
        #endregion
    }

    public class EventLogHelper : ILogHelper
    {
        #region 写系统日志
        /// <summary>
        /// 写系统日志
        /// </summary>
        /// <param name="logType">日志内容的类型，参照LogType</param>
        /// <param name="message">日志信息</param>
        /// <param name="source">日志源</param>
        /// <param name="logName">日志名</param>
        public void WriteLog(LogType logType, string message, string source, string logName)
        {
            try
            {
                if (!EventLog.SourceExists(source))
                {
                    EventLog.CreateEventSource(source, logName);
                }
                //日志初始化
                EventLog log = new EventLog();
                log.Source = source;
                //判断日志类型
                EventLogEntryType elet;
                switch (logType)
                {
                    case LogType.LTError:
                        {
                            elet = EventLogEntryType.Error;
                            break;
                        }
                    default:
                        {
                            elet = EventLogEntryType.Information;
                            break;
                        }
                }
                //写日志
                log.WriteEntry(message, elet);
            }
            catch
            {
                // do nothing
            }
        }

        /// <summary>
        /// 写系统日志
        /// </summary>
        /// <param name="logType">日志内容的类型，参照LogType</param>
        /// <param name="message">日志信息</param>
        /// <param name="source">日志源</param>
        public void WriteLog(LogType logType, string message, string source)
        {
            string logName = source + "EventLog";
            WriteLog(logType, message, source, logName);
        }

        /// <summary>
        /// 写系统日志
        /// </summary>
        /// <param name="logType">日志内容的类型，参照LogType</param>
        /// <param name="message">日志信息</param>
        public void WriteLog(LogType logType, string message)
        {
            string source = Process.GetCurrentProcess().ProcessName;
            WriteLog(logType, message, source);
        }
        #endregion
    }
}
