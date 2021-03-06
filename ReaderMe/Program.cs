﻿using System;
using System.Threading;
using System.Windows.Forms;
using GPSoft.Tools.ReaderMe.Forms;

namespace GPSoft.Tools.ReaderMe
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool canCreateNew;
            //限制单例运行
            Mutex m = new Mutex(true, "ReaderMeByGYP", out canCreateNew);
            if (canCreateNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //CommonFunc.config = Configurations.GetInstance();
                Application.Run(new FormMain());
                m.ReleaseMutex();    //必须
            }
            else
            {
                MessageBox.Show("程序正在运行中。",
                    "警告",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}