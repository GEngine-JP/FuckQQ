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
	/// SendMessage ��ժҪ˵����
	/// </summary>
	public class SendMessage
	{
		private string ToIpName="";
		private string MSG="";
		private string IpEndPoint="";
		public SendMessage()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		private bool result=true;
		/// <summary>
		/// ��ȡ������Ϣ�Ľ��
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
		/// ��Ҫ���͵���Ϣ
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
		/// Ŀ���û�
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
		/// ��ָ���û�������Ϣ
		/// </summary>
		/// <param name="msg">Ҫ���͵���Ϣ����</param>
		/// <param name="ToWho">Ҫ������Ϣ��Ŀ���û�</param>
		/// <returns>���ط��ͽ���ǳɹ�����ʧ��</returns>
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
				byte[] ba = asen.GetBytes("2;"+ShareDate.ThisUser.Trim()+";"+MSG);//������ʽΪ����ʶ��ԭ�û�����Ϣ���ݣ�
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
