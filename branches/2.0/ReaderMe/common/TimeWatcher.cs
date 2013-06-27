using System;
using System.Diagnostics;

namespace GPSoft.Tools.ReaderMe.common
{
    /// <summary>
    /// 代码执行时间计时辅助类
    /// </summary>
    public class TimeWatcher
    {
        private Stopwatch timeWatcher = new Stopwatch();

        /// <summary>
        /// 开始计时
        /// </summary>
        [Conditional("DEBUG")]
        public void Start()
        {
            timeWatcher.Reset();
            timeWatcher.Start();
        }
        /// <summary>
        /// 停止计时并向控制台输出经过时间（毫秒）
        /// </summary>
        [Conditional("DEBUG")]
        public void Stop()
        {
            Stop(string.Empty);
        }
    
        /// <summary>
        /// 停止计时并向控制台输出经过时间（毫秒）
        /// </summary>
        /// <param name="messageTitle">显示在经过时间前面的信息头
        /// <para>如果设置成null或者空值，则信息头为当前函数名</para>
        /// </param>
        [Conditional("DEBUG")]
        public void Stop(string messageTitle)
        {
            timeWatcher.Stop();
            Debug.WriteLine(string.Format("{0}:{1}ms",
                string.IsNullOrEmpty(messageTitle) ? new StackFrame(1).GetMethod().Name : messageTitle,
                timeWatcher.ElapsedMilliseconds));
        }
    }
}
