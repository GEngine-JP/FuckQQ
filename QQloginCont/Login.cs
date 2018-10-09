using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace QQloginCont
{
	/// <summary>
	/// Login 的摘要说明。
	/// </summary>
	public class Login
	{
		public Login()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 登陆到服务器验证该用户名密码的用户是否为合法用户
		/// </summary>
		/// <param name="uid">用户名</param>
		/// <param name="pwd">密码</param>
		/// <returns>验证结果</returns>
		public static bool QLogin(string uid,string pwd)
		{
			string SerInfFile="SerInf\\SerInf.dat";
			string StrIp=getSerInf.ReadXmlNode(SerInfFile,"//root//server//ip");
			string StrPort=getSerInf.ReadXmlNode(SerInfFile,"//root//server//port");
			int port=int.Parse(StrPort);
			TcpClient tcpclnt = new TcpClient();
			tcpclnt.Connect(StrIp,port);
			Stream stm = tcpclnt.GetStream();
			UTF8Encoding asen = new UTF8Encoding();
			byte[] ba = asen.GetBytes("1;" + uid +";"+ pwd);
			stm.Write(ba, 0, ba.Length);
			byte[] bb = new byte[1];
			int k = stm.Read(bb, 0, 1);
			string req = System.Text.Encoding.UTF8.GetString(bb);
			stm.Close();
			tcpclnt.Close();
			if (req.Trim() == "1")
			{
				return(true);
			}
			else
			{
				return(false);
			}
		}
		/// <summary>
		/// 向服务器发送请求以获取该用户的好友列表
		/// </summary>
		/// <param name="UserNumber">需要获取好友列表的用户名</param>
		/// <returns>返回获取结果</returns>
		public static bool SendMsgToGetFriendInf(string UserNumber)
		{
			StreamWriter FriendInf=new StreamWriter(UserNumber+"\\FriendInf.dat");
			string SerInfFile="SerInf\\SerInf.dat";
			string StrIp=getSerInf.ReadXmlNode(SerInfFile,"//root//server//ip");
			string StrPort=getSerInf.ReadXmlNode(SerInfFile,"//root//server//port");
			int port=int.Parse(StrPort);
			TcpClient tcpclnt = new TcpClient();
			tcpclnt.Connect(StrIp,port);
			Stream stm = tcpclnt.GetStream();
			UTF8Encoding asen = new UTF8Encoding();
			byte[] ba = asen.GetBytes("2;" + UserNumber);
			stm.Write(ba, 0, ba.Length);
			byte[] bb = new byte[1024];
			int k = stm.Read(bb, 0, 1024);
			while(k>0)
			{
				string Str=System.Text.UTF8Encoding.UTF8.GetString(bb,0,k);
				Console.WriteLine(Str);
				FriendInf.Write(Str);
				k = stm.Read(bb, 0, 1024);
			}
			FriendInf.Close();
			stm.Close();
			tcpclnt.Close();
			return(true);
		}
		/// <summary>
		/// 发送获取所有在线用户列表的请求
		/// </summary>
		/// <returns></returns>
		public static bool SendMsgToGetOnlineInf()
		{
			while(!UserInf.iniOnlineInf())
			{}
			StreamWriter OnlineInf=new StreamWriter("online.dat");
			string SerInfFile="SerInf\\SerInf.dat";
			string StrIp=getSerInf.ReadXmlNode(SerInfFile,"//root//server//ip");
			string StrPort=getSerInf.ReadXmlNode(SerInfFile,"//root//server//port");
			int port=int.Parse(StrPort);
			TcpClient tcpclnt = new TcpClient();
			tcpclnt.Connect(StrIp,port);
			Stream stm = tcpclnt.GetStream();
			UTF8Encoding asen = new UTF8Encoding();
			byte[] ba = asen.GetBytes("6;");
			stm.Write(ba, 0, ba.Length);
			byte[] bb = new byte[1024];
			int k = stm.Read(bb, 0, 1024);
			while(k>0)
			{
				string Str=System.Text.UTF8Encoding.UTF8.GetString(bb,0,k);
				OnlineInf.Write(Str);
				k = stm.Read(bb, 0, 1024);
			}
			OnlineInf.Close();
			stm.Close();
			tcpclnt.Close();
			return(true);
		}
		/// <summary>
		/// 向服务器发送请求！添加好友
		/// </summary>
		/// <param name="Owner">好友拥有者</param>
		/// <param name="Friend">好友号码</param>
		/// <returns>添加结果</returns>
		public static string AddFriend(string Owner,string Friend)
		{
			string SerInfFile="SerInf\\SerInf.dat";
			string StrIp=getSerInf.ReadXmlNode(SerInfFile,"//root//server//ip");
			string StrPort=getSerInf.ReadXmlNode(SerInfFile,"//root//server//port");
			int port=int.Parse(StrPort);
			TcpClient tcpclnt = new TcpClient();
			tcpclnt.Connect(StrIp,port);
			Stream stm = tcpclnt.GetStream();
			UTF8Encoding asen = new UTF8Encoding();
			byte[] ba = asen.GetBytes("7;" + Owner +";"+ Friend);
			stm.Write(ba, 0, ba.Length);
			byte[] bb = new byte[2];
			int k = stm.Read(bb, 0, 2);
			string req = System.Text.Encoding.UTF8.GetString(bb);
			stm.Close();
			tcpclnt.Close();
			switch(req)
			{
				case "-1":
					return("sorry！要添加的好友不存在！");
				case "0\0":
					return("恭喜！添加好友成功！请刷新");
				case "1\0":
					return("对不起！该好友在你的好友列表中！");
				default:
					return("未知错误！");
			}
		}
	}
}
