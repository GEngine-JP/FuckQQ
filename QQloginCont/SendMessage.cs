using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml;
using System.IO;
using System.Text;

namespace QQloginCont
{
	/// <summary>
	/// SendMessage 的摘要说明。
	/// </summary>
	public class SendMessage
	{
		private string ToIpName="";
		private string MSG="";
		private string IpEndPoint="";
		public SendMessage()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private bool result=true;
		/// <summary>
		/// 获取发送消息的结果
		/// </summary>
		public bool Result
		{
			get
			{
				return(result);
			}
		}
		private string msg;
		/// <summary>
		/// 需要发送的消息
		/// </summary>
		public string Msg
		{
			get
			{
				return(msg);
			}
			set
			{
				msg=value;
			}
		}
		private string ToWho;
		/// <summary>
		/// 目标用户
		/// </summary>
		public string ToDistUser
		{
			set
			{
				ToWho=value;
			}
		}
		public void send()
		{
			Thread th=new Thread(new ThreadStart(MessageSend));
			th.Start();
		}
		/// <summary>
		/// 向指定用户发送消息
		/// </summary>
		/// <param name="msg">要发送的消息内容</param>
		/// <param name="ToWho">要发送消息的目标用户</param>
		/// <returns>返回发送结果是成功还是失败</returns>
		private void MessageSend()
		{
			try
			{
				string TOIpNumber="";
				CheckOutNum NAN=new CheckOutNum(ToWho);
				this.ToIpName=NAN.QQname;
				this.MSG=msg;
				TOIpNumber=NAN.QQnumber;
				XmlDataDocument Xml=new XmlDataDocument();
				Xml.Load("online.dat");
				XmlNode root=Xml.SelectSingleNode("root");
				for(int i=0;i<root.ChildNodes.Count;i++)
				{
					if(root.ChildNodes[i].ChildNodes[0].InnerText.Trim()==TOIpNumber.Trim())
					{
						this.IpEndPoint=root.ChildNodes[i].ChildNodes[1].InnerText.Trim();
						break;
					}
				}
				CheckOutIpPoint IEP=new CheckOutIpPoint(IpEndPoint);
				TcpClient Send=new TcpClient();
				Send.Connect(IEP.IpAdd,5281);
				Stream stm=Send.GetStream();
				UTF8Encoding asen = new UTF8Encoding();
				byte[] ba = asen.GetBytes("2;"+ShareDate.ThisUser.Trim()+";"+MSG);//参数格式为（标识；原用户；消息内容）
				stm.Write(ba, 0, ba.Length);
				Send.Close();
				result=true;
			}
			catch
			{
				result=false;
			}
		}
	}
}
