using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common
{
    /// <summary>
    /// 经验转换成等级和当前经验
    /// </summary>
    public class Experience
    {
        private int[] rule = { 30, 120, 480, 1920, 7680, 30720, 122880, 491520 };
        public int[] getRule
        {
            get { return rule; }
        }
        public int current { get; set; }
        public int level { get; set; }
        public Experience(int exp)
        {
            for (int i = 0; i < rule.Length; i++)
            {
                if (i == rule.Length - 1)
                {
                    level = i + 2;
                }
                if (exp < rule[i])
                {
                    level = i + 1;
                    break;
                }
                exp = exp - rule[i];
            }
            current = exp;
        }
    }
}