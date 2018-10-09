using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace qqServerManger
{
    /// <summary>
    /// ��֤�û��ύ���ݺϷ�����
    /// </summary>
    public class regx
    {
        /// <summary>
        /// ��֤���ַ����Ƿ��ǺϷ���ip��ַ
        /// </summary>
        /// <param name="ip">��Ҫ��֤���ַ���</param>
        /// <returns>�Ϸ�Ϊtrue,�Ƿ�Ϊfalse</returns>
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
        /// ��֤���ַ����Ƿ��ǿ�ֵ
        /// </summary>
        /// <param name="check">��Ҫ��֤���ַ���</param>
        /// <returns>��֤�������Ϊtrue���ǿ�Ϊ��false</returns>
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
        /// ��֤���ַ����Ƿ��ǺϷ���QQ����
        /// </summary>
        /// <param name="QNumber">��Ҫ��֤���ַ���</param>
        /// <returns>��֤�������Ϊtrue������Ϊfalse</returns>
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
        /// ��֤���ַ����Ƿ�Ϊ����
        /// </summary>
        /// <param name="Number">��Ҫ��֤���ַ���</param>
        /// <returns>��֤�������Ϊtrue������Ϊfalse</returns>
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
