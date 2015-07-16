/*
 *********************************************************************
 * 程序 : 
 * 类名 : Dice
 * 说明 : 骰子
 * 作者 : 高云鹏
 * 作成 : 2011/12/16 16:38:24 
 * 履历 :
 * 
 *********************************************************************
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace GPStudio.Tools.ReaderMe.Helper
{
    /// <summary>
    /// 骰子
    /// </summary>
    public class Dice
    {
        /// <summary>
        /// 获取或设置去掉几个最大值
        /// </summary>
        public static int ExceptMaxCount { set; get; }

        /// <summary>
        /// 获取或设置去掉几个最小值
        /// </summary>
        public static int ExceptMinCount { set; get; }

        /// <summary>
        /// 获取或设置加值
        /// </summary>
        public static int Bonus { set; get; }

        /// <summary>
        /// 获取或设置减值
        /// </summary>
        public static int Penalty { set; get; }

        /// <summary>
        /// 投掷骰子
        /// </summary>
        /// <param name="count">骰子数量</param>
        /// <param name="number">单个骰子的最大点数</param>
        /// <returns>返回投掷结果总和</returns>
        public static int Throw(int count, int number)
        {
            int result = 0;
            List<int> valueList = new List<int>();
            for (int i = 0; i < count; i++)
            {
                Random random = new Random(Guid.NewGuid().GetHashCode());
                valueList.Add(random.Next(1, number + 1));
            }
            valueList.Sort();
            for (int i = 0; i < valueList.Count - ExceptMaxCount - ExceptMinCount; i++)
            {
                result += valueList[i + ExceptMinCount];
            }
            result += Bonus;
            result -= Penalty;
            return result;
        }
    }
}
