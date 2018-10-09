using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;

namespace qqServerManger
{
    /// <summary>
    /// xml数据操作类
    /// </summary>
    public class XmlOperate
    {
        private DataSet FriendData;
        /// <summary>
        /// 生成好友列表xml文件
        /// </summary>
        /// <param name="UserNum">需要生成列表的用户名</param>
        /// <returns>返回生成的文件路径，"-1"意味着生成文件失败</returns>
        public string MakeFriendXml(string UserNum)
        {
            try
            {
                MakeRootFile(UserNum);
                FriendData = opDate.GetFriendLsit(UserNum);
                XmlNode AddHere = null;
                for (int i = 0; i < FriendData.Tables[0].Rows.Count; i++)
                {
                    XmlDataDocument temp = new XmlDataDocument();
                    temp.Load("temp\\" + UserNum.Trim() + ".xml");
                    XmlElement friend = temp.CreateElement("friend");
                    XmlElement FriendNumber = temp.CreateElement("FriendNumber");
                    XmlElement FriendName = temp.CreateElement("FriendName");
                    string GroupName = FriendData.Tables[0].Rows[i]["cGroupName"].ToString().Trim();
                    XmlNodeList AllGroup = temp.SelectSingleNode("root").ChildNodes;
                    foreach (XmlNode node in AllGroup)
                    {
                        if (node.Attributes["GroupName"].Value.Trim() == GroupName)
                        {
                            AddHere = node;
                            FriendName.InnerText = FriendData.Tables[0].Rows[i]["cUserName"].ToString().Trim();
                            FriendNumber.InnerText = FriendData.Tables[0].Rows[i]["cFriendNum"].ToString().Trim();
                            friend.AppendChild(FriendNumber);
                            friend.AppendChild(FriendName);
                            AddHere.AppendChild(friend);
                            break;
                        }
                    }
                    temp.Save("temp\\" + UserNum.Trim() + ".xml");
                }
                return ("temp\\" + UserNum.Trim() + ".xml");
            }
            catch
            {
                return ("-1");
            }
        }
        public static bool AddOnlineUser(string QQNumber, string IpEndPoint)
        {
            string XmlUrl = "onlineinf\\onLine.xml";
            if (!File.Exists(XmlUrl))
            {
                File.Create(XmlUrl).Close();
                StringBuilder add = new StringBuilder();
                StreamWriter str = new StreamWriter(XmlUrl);
                add.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                add.Append("<root></root>");
                str.Write(add.ToString());
                str.Close();
            }
            XmlDataDocument XmlData = new XmlDataDocument();
            XmlData.Load(XmlUrl);
            XmlNode root = XmlData.SelectSingleNode("root");
            if (!IsThisUserOnline(XmlData, QQNumber,IpEndPoint))
            {
                XmlElement online = XmlData.CreateElement("online");
                XmlElement QQnumber = XmlData.CreateElement("QQnumber");
                XmlElement Ipendpoint = XmlData.CreateElement("IpEndPoint");
                QQnumber.InnerText = QQNumber;
                Ipendpoint.InnerText = IpEndPoint;
                online.AppendChild(QQnumber);
                online.AppendChild(Ipendpoint);
                root.AppendChild(online);
            }
            XmlData.Save(XmlUrl);
            return (true);
        }
        private static bool IsThisUserOnline(XmlDataDocument Xml, string uid, string IpEndPoint)
        {
            XmlNode root = Xml.SelectSingleNode("root");
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {
                if (uid.Trim() == root.ChildNodes[i].ChildNodes[0].InnerText.Trim())
                {
                    root.ChildNodes[i].ChildNodes[1].InnerText = IpEndPoint;
                    return (true);
                }
                else
                {
                    continue;
                }
            }
            return (false);
        }
        private void MakeRootFile(string uid)
        {
            StringBuilder FriendInf = new StringBuilder();
            StreamWriter temp = new StreamWriter("temp\\" + uid.Trim() + ".xml");
            DataSet FriendData = opDate.GetGroupInfByUserId(uid,1);
            FriendInf.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            FriendInf.Append("<root>");
            if (FriendData == null)
            {
                FriendInf.Append("<FriendGroup GroupName=\"没有分组\"></FriendGroup>");
            }
            else
            {
                for (int i = 0; i < FriendData.Tables[0].Rows.Count; i++)
                {
                    FriendInf.Append("<FriendGroup GroupName=\"");
                    FriendInf.Append(FriendData.Tables[0].Rows[i]["cGroupName"].ToString().Trim());
                    FriendInf.Append("\"></FriendGroup>");
                }
            }
            FriendInf.Append("</root>");
            temp.Write(FriendInf.ToString());
            temp.Close();
        }
    }
}
