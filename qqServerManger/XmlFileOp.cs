using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace qqServerManger
{
    /// <summary>
    /// 提供对xml文件的操作！对整个文件操作！
    /// </summary>
    public class XmlFileOp
    {
        /// <summary>
        /// 删除指定的文件
        /// </summary>
        /// <param name="FileUrl">需要删除的文件路径</param>
        /// <returns></returns>
        public static bool DelThisFile(string FileUrl)
        {
            try
            {
                File.Delete(FileUrl);
                return (true);
            }
            catch
            {
                return (false);
            }
        }
    }
}
