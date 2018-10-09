using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;

namespace qqServerManger
{
    /// <summary>
    /// sql数据库链接信息获取类
    /// </summary>
    public class SqlConnectionTest
    {
        private static string constr = "";
        public static string ConStr
        {
            set 
            {
                if (value != "")
                {
                    constr = value;
                }
            }
        }
        public static bool ConnectionTest(string Server, string Database, string Uid, string Pwd)
        {
            try
            {
                string strCon = "Database=" + Database + ";Server=" + Server + ";uid=" + Uid + ";pwd=" + Pwd + ";";
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                con.Close();
                return (true);
            }
            catch
            {
                return (false);
            }
        }

        public static string GetConnString()
        {
            try
            {
                string XmlUrl = "config\\dataConfig.dat";
                if (File.Exists(XmlUrl))
                {
                    string Server, Database, Uid, Pwd, ConnStr;
                    Server = qSaveConfigServer.GetValueByNode(XmlUrl, "//root//server//ip");
                    Database = qSaveConfigServer.GetValueByNode(XmlUrl, "//root//server//database");
                    Uid = qSaveConfigServer.GetValueByNode(XmlUrl, "//root//server//uid");
                    Pwd = qSaveConfigServer.GetValueByNode(XmlUrl, "//root//server//pwd");
                    if (Server == "-1" || Database == "-1" || Uid == "-1" || Pwd == "-1")
                    {
                        return ("-1");
                    }
                    else
                    {
                        ConnStr = "Database=" + Database + ";Server=" + Server + ";uid=" + Uid + ";pwd=" + Pwd + ";";
                        return (ConnStr);
                    }
                }
                else
                {
                    return (constr);
                }
            }
            catch
            {
                return ("-1");
            }
        }

        public static SqlConnection GetConnection()
        {
            string ConStr = GetConnString();
            if (ConStr != "-1")
            {
                SqlConnection con = new SqlConnection(ConStr);
                return (con);
            }
            else
            {
                return (null);
            }
        }
    }
}
