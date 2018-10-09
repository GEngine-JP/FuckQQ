using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace qqServerManger
{
    /// <summary>
    /// 验证用户提交数据合法性类
    /// </summary>
    public class regx
    {
        /// <summary>
        /// 验证该字符串是否是合法的ip地址
        /// </summary>
        /// <param name="ip">需要验证的字符串</param>
        /// <returns>合法为true,非法为false</returns>
        public static bool isIpaddres(string ip)
        {
            Regex reg = new Regex("(((2[0-4]\\d)|(25[0-5]))|(1\\d{2})|([1-9]\\d)|(\\d))[.](((2[0-4]\\d)|(25[0-5]))|(1\\d{2})|([1-9]\\d)|(\\d))[.](((2[0-4]\\d)|(25[0-5]))|(1\\d{2})|([1-9]\\d)|(\\d))[.](((2[0-4]\\d)|(25[0-5]))|(1\\d{2})|([1-9]\\d)|(\\d))");
            if (reg.IsMatch(ip, 0))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        /// <summary>
        /// 验证该字符串是否是空值
        /// </summary>
        /// <param name="check">需要验证的字符串</param>
        /// <returns>验证结果：空为true，非空为：false</returns>
        public static bool isNull(string check)
        {
            if (check.Trim() == "" || check == "")
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        /// <summary>
        /// 验证该字符串是否是合法的QQ号码
        /// </summary>
        /// <param name="QNumber">需要验证的字符串</param>
        /// <returns>验证结果：是为true，不是为false</returns>
        public static bool IsThisQQNumber(string QNumber)
        {
            Regex reg = new Regex("\\d{8}");
            if (reg.IsMatch(QNumber, 0))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        /// <summary>
        /// 验证该字符串是否为数字
        /// </summary>
        /// <param name="Number">需要验证的字符串</param>
        /// <returns>验证结果：是为true，不是为false</returns>
        public static bool IsThisNumber(string Number)
        {
            Regex reg=new Regex("[1-9]\\d*");
            if(reg.IsMatch(Number,0))
            {
                return(true);
            }
            else
            {
                return(false);
            }
        }
    }
}
