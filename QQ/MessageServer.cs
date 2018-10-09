using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using QQloginCont;
using System.ComponentModel;
using System.Windows.Forms;

namespace QQ
{
	/// <summary>
	/// MessageServer ��ժҪ˵����
	/// </summary>
	public class MessageServer
	{
		private bool run;
		private TcpListener qTcpListener = null;
		private Thread ServerTh;
		private string[] parameter=new string[3]{"","",""};
		public Control Co;
		public MessageServer()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ��ʼ������
		/// </summary>
		/// <param name="uid">��ǰ�û����</param>
		/// <returns></returns>
		public bool IniServer(string uid)
		{
			string IpEnd=UserInf.GetMySerInf(uid);
			if(IpEnd!="-1")
			{
				CheckOutIpPoint check=new CheckOutIpPoint(IpEnd);
				IPAddress Ad=IPAddress.Parse(check.IpAdd);
				IPEndPoint server=new IPEndPoint(Ad,5281);
				qTcpListener=new TcpListener(server);
				qTcpListener.Start();
				ServerTh=new Thread(new ThreadStart(ServerIng));
				run=true;
				ServerTh.Start();
				ServerTh.IsBackground=true;
				return(true);
			}
			else
			{
				return(false);
			}
		}
		public void DisposeServer()
		{
			run=false;
			qTcpListener.Stop();
			ServerTh.Abort();
		}
		private void ServerIng()
		{
			while (run)
			{
				//������մ���
				Socket QS;
				QS = qTcpListener.AcceptSocket();
				Byte[] Stream = new Byte[1024];
				QS.Receive(Stream);
				string save = System.Text.Encoding.UTF8.GetString(Stream);
				CheckOutDate(save);
				switch (parameter[0])
				{
					case "1"://���û�����
						TrafficMsg.PostMessage(ShareDate.MainFormHand,500,1,0);
						Login.SendMsgToGetOnlineInf();//��ȡ�µ������û��б�
						System.Threading.Thread ShowOnline=new Thread(new ThreadStart(ShowInfWin));
						ShowOnline.Start();
						break;
					case "2"://���յ������û�����Ϣ;��ʽΪ����ʶ��Դ�û�����Ϣ���ݣ�
						TrafficMsg.PostMessage(ShareDate.MainFormHand,500,2,0);//���Ͳ���������ʾ��Ϣ
						System.Threading.Thread SM=new Thread(new ThreadStart(ShowMsg));
						SM.Start();//�������촰��
						break;
					default://���ʹ������
						break;
				}
				QS.Close();
			}
		}
		private void ShowInfWin()
		{
			Online showInf=new Online("�û���"+parameter[1]+"��������\n��ʹ��ͼ���Ҽ�ˢ�����ϣ�");
			ISynchronizeInvoke synchronizer;   
			synchronizer = showInf;   
			MethodInvoker invoker = new MethodInvoker(showInf.Show);   
			Co.Invoke(invoker,null);
			showInf.Show(); 
		}
		private void ShowMsg()
		{
			bool isHaveWin=false;
			int MsgId=0;
			int hand=0;
			string msg="";
			string FriendName=UserInf.GetUserNameByUserNumber(parameter[1].Trim());
			if(FriendName.Trim()=="")
			{
				msg+=parameter[1].Trim();
			}
			else
			{
				msg+=FriendName;
			}
			msg+="��("+UserInf.GetTime()+")\n��   "+parameter[2].Trim();
			for(int i=0;i<ShareDate.WinName.Count;i++)
			{
				if(parameter[1].Trim()==ShareDate.WinName[i].ToString().Trim())
				{
					hand=int.Parse(ShareDate.WinHand[i].ToString());
					isHaveWin=true;
					break;
				}
			}
			MsgId=ShareDate.Msg.Add(msg);
			if(isHaveWin)
			{
				TrafficMsg.PostMessage(hand,500,MsgId,0);//��Ŀ�괰�ڷ�����Ϣ
			}
			else
			{
				TrafficMsg.PostMessage(ShareDate.MainFormHand,501,int.Parse(parameter[1]),MsgId);//��˸ͼ��
			}
		}
		private void CheckOutDate(string str)
		{
			for(int i=0;i<3;i++)
			{
				parameter[i]="";
			}
			int j = 0;//����ָ��
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] != ';')
				{
					if (str[i] == '\0')
					{
						break;
					}
					parameter[j] += str[i].ToString().Trim();
				}
				else
				{
					j++;
				}
			}
		}
	}
}
