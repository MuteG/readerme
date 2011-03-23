using System;
using System.Diagnostics;

namespace GP.Tools.ReaderMe.Common
{
    /// <summary>
    /// 代码执行时间计时辅助类
    /// </summary>
    public class TimeWatcher
    {
#if DEBUG
        private Stopwatch timeWatcher = new Stopwatch();
#endif
        /// <summary>
        /// 开始计时
        /// </summary>
        public void Start()
        {
#if DEBUG
            timeWatcher.Reset();
            timeWatcher.Start();
#endif
        }
        /// <summary>
        /// 停止计时并向控制台输出经过时间（毫秒）
        /// </summary>
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
        public void Stop(string messageTitle)
        {
#if DEBUG
            timeWatcher.Stop();
            Console.WriteLine(string.Format("{0}:{1}ms",
                string.IsNullOrEmpty(messageTitle) ? new StackFrame(1).GetMethod().Name : messageTitle,
                timeWatcher.ElapsedMilliseconds));
#endif
        }
    }
}
