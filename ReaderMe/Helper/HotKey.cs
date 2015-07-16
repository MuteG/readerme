using System;
using System.Runtime.InteropServices;

namespace GPStudio.Tools.ReaderMe.Helper
{
    public delegate void HotkeyEventHandler(int HotKeyID);

    public class Hotkey : System.Windows.Forms.IMessageFilter
    {
        //存储定义的热键的ID
        System.Collections.Hashtable keyIDs = new System.Collections.Hashtable();
        //存放调用该类的窗体的句柄
        private IntPtr hWnd;

        public IntPtr HWnd
        {
            get { return hWnd; }
            set
            {
                hWnd = value;
                //在类中监窗体的消息
                System.Windows.Forms.Application.AddMessageFilter(this);
            }
        }

        //热键的事件
        public event HotkeyEventHandler OnHotkey;

        //组合键枚举
        public enum KeyFlags
        {
            MOD_ALT = 0x1,
            MOD_CONTROL = 0x2,
            MOD_SHIFT = 0x4,
            MOD_WIN = 0x8
        }
        //注册热键API
        [DllImport("user32.dll")]
        public static extern UInt32 RegisterHotKey(IntPtr hWnd, UInt32 id, UInt32 fsModifiers, UInt32 vk);
        //删除热键API
        [DllImport("user32.dll")]
        public static extern UInt32 UnregisterHotKey(IntPtr hWnd, UInt32 id);
        //填加全局原子表API,获取得到一个唯一标识的原子
        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalAddAtom(String lpString);
        //释放全局原子表API
        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalDeleteAtom(UInt32 nAtom);

        /**/
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hWnd">调用该类的窗体的句柄</param>
        public Hotkey(IntPtr hWnd)
        {
            this.HWnd = hWnd;
        }

        public Hotkey()
        {
        }

        /**/
        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="Key">常规键</param>
        /// <param name="keyflags">功能键</param>
        /// <returns>热键ID</returns>
        public int RegisterHotKey(System.Windows.Forms.Keys Key, KeyFlags keyflags)
        {
            UInt32 hotkeyid = GlobalAddAtom(System.Guid.NewGuid().ToString());
            RegisterHotKey((IntPtr)hWnd, hotkeyid, (UInt32)keyflags, (UInt32)Key);
            keyIDs.Add(hotkeyid, hotkeyid);
            return (int)hotkeyid;
        }

        /// <summary>
        /// 释放全部热键
        /// </summary>
        public bool UnregisterHotKeys()
        {
            try
            {
                foreach (UInt32 key in keyIDs.Values)
                {
                    UnregisterHotKey(hWnd, key);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /**/
        /// <summary>
        /// 释放指定热键
        /// </summary>
        /// <param name="key">热键ID</param>
        public bool UnregisterHotKeys(UInt32 key)
        {
            try
            {
                UnregisterHotKey(hWnd, key);
                GlobalDeleteAtom(key);
                keyIDs.Remove(key);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        /**/
        /// <summary>
        /// 监视热键
        /// </summary>
        /// <param name="m">窗体消息</param>
        /// <returns></returns>
        public bool PreFilterMessage(ref System.Windows.Forms.Message m)
        {
            //如果m.Msg的值为0x0312那么表示用户按下了热键
            if (m.Msg == 0x312)
            {
                //是否有对应的事件函数
                if (OnHotkey != null)
                {
                    //在热键集合中查找当前按键
                    foreach (UInt32 key in keyIDs.Values)
                    {
                        if ((UInt32)m.WParam == key)
                        {
                            //执行事件函数
                            OnHotkey((int)m.WParam);
                            return true;
                        }
                    }
                    //m.Msg = 0x0;
                    //m.Result = IntPtr.Zero;
                    
                }
            }
            
            return false;
        }
    }
}