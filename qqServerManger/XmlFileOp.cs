using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace qqServerManger
{
    /// <summary>
    /// �ṩ��xml�ļ��Ĳ������������ļ�������
    /// </summary>
    public class XmlFileOp
    {
        /// <summary>
        /// ɾ��ָ�����ļ�
        /// </summary>
        /// <param name="FileUrl">��Ҫɾ�����ļ�·��</param>
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
