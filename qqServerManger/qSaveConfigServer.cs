using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace qqServerManger
{
    /// <summary>
    /// 服务器信息保存类
    /// </summary>
    public class qSaveConfigServer
    {
        public static bool SaveConfigServer(string ipadd, string port)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                string ConfigFileUrl = "config/ipConfig.dat";
                str.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?><root><server>");
                str.Append("<ip>" + ipadd + "</ip>");
                str.Append("<port>" + port + "</port>");
                str.Append("</server></root>");
                StreamWriter save = new StreamWriter(ConfigFileUrl);
                save.Write(str.ToString());
                save.Close();
                return (true);
            }
            catch
            {
                return (false);
            }
        }

        public static bool SaveConfigDate(string ip, string database, string uid, string pwd)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                string FileUrl = "config/dataConfig.dat";
                str.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?><root><server>");
                str.Append("<ip>" + ip + "</ip>");
                str.Append("<database>" + database + "</database>");
                str.Append("<uid>" + uid + "</uid>");
                str.Append("<pwd>" + pwd + "</pwd>");
                str.Append("</server></root>");
                StreamWriter save = new StreamWriter(FileUrl);
                save.Write(str.ToString());
                save.Close();
                return (true);
            }
            catch
            {
                return (false);
            }
        }

        public static string GetValueByNode(string XmlFile, string NodePath)
        {
            if (File.Exists(XmlFile))
            {
                XmlDocument SerInf = new XmlDocument();
                SerInf.Load(XmlFile);
                XmlNode FirstNode = SerInf.SelectSingleNode(NodePath).FirstChild;
                return (FirstNode.InnerText);
            }
            else
            {
                return ("-1");
            }
        }
    }
}
