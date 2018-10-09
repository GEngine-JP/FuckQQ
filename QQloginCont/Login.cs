using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace QQloginCont
{
	/// <summary>
	/// Login ��ժҪ˵����
	/// </summary>
	public class Login
	{
		public Login()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ��½����������֤���û���������û��Ƿ�Ϊ�Ϸ��û�
		/// </summary>
		/// <param name="uid">�û���</param>
		/// <param name="pwd">����</param>
		/// <returns>��֤���</returns>
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
		/// ����������������Ի�ȡ���û��ĺ����б�
		/// </summary>
		/// <param name="UserNumber">��Ҫ��ȡ�����б���û���</param>
		/// <returns>���ػ�ȡ���</returns>
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
		/// ���ͻ�ȡ���������û��б������
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
		/// �����������������Ӻ���
		/// </summary>
		/// <param name="Owner">����ӵ����</param>
		/// <param name="Friend">���Ѻ���</param>
		/// <returns>��ӽ��</returns>
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
					return("sorry��Ҫ��ӵĺ��Ѳ����ڣ�");
				case "0\0":
					return("��ϲ����Ӻ��ѳɹ�����ˢ��");
				case "1\0":
					return("�Բ��𣡸ú�������ĺ����б��У�");
				default:
					return("δ֪����");
			}
		}
	}
}
