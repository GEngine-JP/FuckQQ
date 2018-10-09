using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace QQloginCont
{
	/// <summary>
	/// UserInf 的摘要说明。
	/// </summary>
	public class UserInf
	{
		private bool checkresult=false;
		private string usernumber="0";
		private static string QQuser="QQuser.dat";
		private static string UidTemp;//保存临时参数
		/// <summary>
		/// 提供各种检查结果
		/// </summary>
		public bool CheckResult
		{
			get
			{
				return(checkresult);
			}
		}
		/// <summary>
		/// 设置或获取当先用户的ＱＱ号码
		/// </summary>
		public string UserNumber
		{
			get
			{
				return(usernumber);
			}
			set
			{
				if(Regx.isNumber(value))
				{
					usernumber=value;
				}
			}
		}
		public UserInf()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 验证该用户在本机器上是否登陆过
		/// </summary>
		/// <returns></returns>
		private bool HaveUser()
		{
			if(!Directory.Exists("\\"+usernumber))
			{
				return(true);
			}
			else
			{
				return(false);
			}
		}
		/// <summary>
		/// 创建该用户在本地的目录
		/// </summary>
		/// <returns></returns>
		public void CreateUserDir(string fatherUrl)
		{
			try
			{
				Directory.CreateDirectory(fatherUrl+"\\"+usernumber);
				checkresult=true;
			}
			catch
			{
				checkresult=false;
			}
		}
		/// <summary>
		/// 检查本地是否有用户好友信息
		/// </summary>
		/// <returns></returns>
		public void isHaveFriendInf()
		{
			if(HaveUser())
			{
				if(File.Exists("\\"+usernumber+"\\FriendInf.dat"))
				{
					checkresult=true;
				}
				else
				{
					checkresult=false;
				}
			}
			else
			{
				checkresult=false;
			}
		}
		public void CreateFile(string fatherUrl)
		{
			File.Create(fatherUrl+"\\"+usernumber+"\\FriendInf.dat",1).Close();
		}
		public void CreateOnlineFile(string fatherUrl)
		{
			File.Create(fatherUrl+"\\SerInf\\OnlineInf.dat",1).Close();
		}
		public static void DelFile(string FileUrl)
		{
			File.Delete(FileUrl);
		}
		public static void AddUser(string Uid,string Pwd,bool RememberMe)
		{
			if(!File.Exists(QQuser))
			{
				File.Create(QQuser,1).Close();
				StreamWriter WriteInf=new StreamWriter(QQuser);
				StringBuilder str=new StringBuilder();
				str.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
				str.Append("<root>");
				str.Append("</root>");
				WriteInf.Write(str.ToString());
				WriteInf.Close();
				AddNode(Uid,Pwd,RememberMe);
			}
			else
			{
				AddNode(Uid,Pwd,RememberMe);
			}
		}
		private static void AddNode(string sUid,string sPwd,bool RememberMe)
		{		
			bool isAdd=true;
			XmlDataDocument UserDate=new XmlDataDocument();
			UserDate.Load(QQuser);
			XmlNode root=UserDate.SelectSingleNode("root");
			for(int i=0;i<root.ChildNodes.Count;i++)
			{
				if(root.ChildNodes[i].Attributes["user"].Value.Trim()==sUid)
				{
					//更新用户消息
					if(RememberMe)
					{
						root.ChildNodes[i].ChildNodes[0].InnerText=sPwd;
					}
					else
					{
						root.ChildNodes[i].ChildNodes[0].InnerText="";
					}
					UserDate.Save(QQuser);
					isAdd=false;
					break;
				}
			}
			if(isAdd)
			{
				XmlNode NodeAtt=UserDate.CreateNode(XmlNodeType.Attribute,"user",null);
				XmlElement user=UserDate.CreateElement("user");
				XmlElement pwd=UserDate.CreateElement("pwd");
				user.Attributes.SetNamedItem(NodeAtt);
				user.Attributes["user"].Value=sUid;
				if(RememberMe)
				{
					pwd.InnerText=sPwd;
				}
				else
				{
					pwd.InnerText="";
				}
				user.AppendChild(pwd);
				root.AppendChild(user);
				UserDate.Save(QQuser);
			}
		}
		public static DataTable GetUserInf()
		{
			if(File.Exists(QQuser))
			{
				DataTable QuserInf=new DataTable();
				XmlDataDocument UserDate=new XmlDataDocument();
				UserDate.Load(QQuser);
				XmlNode root=UserDate.SelectSingleNode("root");
				if(!root.HasChildNodes)
				{
					return(null);
				}
				else
				{
					QuserInf.Columns.Add("user",System.Type.GetType("System.String"));
					QuserInf.Columns.Add("pwd",System.Type.GetType("System.String"));
					DataRow dr=null;
					for(int i=0;i<root.ChildNodes.Count;i++)
					{
						dr=QuserInf.NewRow();
						dr["user"]=root.ChildNodes[i].Attributes["user"].Value;
						dr["pwd"]=root.ChildNodes[i].ChildNodes[0].InnerText.Trim();
						QuserInf.Rows.Add(dr);
					}
					return(QuserInf);
				}
			}
			else
			{
				return(null);
			}
		}
		public static bool iniOnlineInf()
		{
			try
			{
				if(!File.Exists("online.dat"))
				{
					File.Create("online.dat").Close();
				}
				else
				{
					File.Delete("online.dat");
					File.Create("online.dat").Close();
				}
				return(true);
			}
			catch
			{
				return(false);
			}
		}
		public static string GetMySerInf(string uid)
		{
			string RetValue="-1";
			if(File.Exists("online.dat"))
			{
				XmlDataDocument onlineInf=new XmlDataDocument();
				onlineInf.Load("online.dat");
				XmlNode root=onlineInf.SelectSingleNode("root");
				for(int i=0;i<root.ChildNodes.Count;i++)
				{
					if(uid.Trim()==root.ChildNodes[i].ChildNodes[0].InnerText.Trim())
					{
						RetValue=root.ChildNodes[i].ChildNodes[1].InnerText.Trim();
						break;
					}
					else
					{
						continue;
					}
				}
				return(RetValue);
			}
			else
			{
				return(RetValue);
			}
		}
		public static void TellMyFriendIOnLine(string uid)
		{
			UidTemp=uid;
			Thread th=new Thread(new ThreadStart(TellIng));
			th.Start();
		}
		private static void TellIng()
		{
			try
			{
				string onlineInf="online.dat";
				XmlDataDocument Xml=new XmlDataDocument();
				Xml.Load(onlineInf);
				XmlNode root=Xml.SelectSingleNode("root");
				for(int i=0;i<root.ChildNodes.Count;i++)
				{
					if(root.ChildNodes[i].ChildNodes[0].InnerText.Trim()!=UidTemp.Trim())
					{
						TcpClient tcpclnt = new TcpClient();
						string IpEndPoint=root.ChildNodes[i].ChildNodes[1].InnerText;
						CheckOutIpPoint check=new CheckOutIpPoint(IpEndPoint);
						tcpclnt.Connect(check.IpAdd,5281);
						Stream stm = tcpclnt.GetStream();
						UTF8Encoding asen = new UTF8Encoding();
						byte[] ba = asen.GetBytes("1;" + UidTemp);
						stm.Write(ba, 0, ba.Length);
						tcpclnt.Close();
					}
				}
			}
			catch
			{}
		}
		public static string GetUserNameByUserNumber(string UserNumber)
		{
			string UserName="";
			for(int i=0;i<ShareDate.QQNumber.Count;i++)
			{
				if(ShareDate.QQNumber[i].ToString().Trim()==UserNumber.Trim())
				{
					UserName=ShareDate.QQName[i].ToString();
					break;
				}
			}
			return(UserName);
		}
		public static string GetTime()
		{
			return(DateTime.Now.Hour.ToString()+":"+DateTime.Now.Minute.ToString()+":"+DateTime.Now.Second);
		}
	}
}
