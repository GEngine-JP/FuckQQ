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
	/// MessageServer 的摘要说明。
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
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 初始化服务
		/// </summary>
		/// <param name="uid">当前用户ｉｄ</param>
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
				//服务接收处理
				Socket QS;
				QS = qTcpListener.AcceptSocket();
				Byte[] Stream = new Byte[1024];
				QS.Receive(Stream);
				string save = System.Text.Encoding.UTF8.GetString(Stream);
				CheckOutDate(save);
				switch (parameter[0])
				{
					case "1"://该用户上线
						TrafficMsg.PostMessage(ShareDate.MainFormHand,500,1,0);
						Login.SendMsgToGetOnlineInf();//获取新的在线用户列表
						System.Threading.Thread ShowOnline=new Thread(new ThreadStart(ShowInfWin));
						ShowOnline.Start();
						break;
					case "2"://接收到来自用户的消息;格式为（标识；源用户；消息内容）
						TrafficMsg.PostMessage(ShareDate.MainFormHand,500,2,0);//发送播放声音提示消息
						System.Threading.Thread SM=new Thread(new ThreadStart(ShowMsg));
						SM.Start();//创建聊天窗口
						break;
					default://发送错误参数
						break;
				}
				QS.Close();
			}
		}
		private void ShowInfWin()
		{
			Online showInf=new Online("用户："+parameter[1]+"上线啦！\n请使用图标右键刷新资料！");
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
			msg+="：("+UserInf.GetTime()+")\n　   "+parameter[2].Trim();
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
				TrafficMsg.PostMessage(hand,500,MsgId,0);//向目标窗口发送消息
			}
			else
			{
				TrafficMsg.PostMessage(ShareDate.MainFormHand,501,int.Parse(parameter[1]),MsgId);//闪烁图标
			}
		}
		private void CheckOutDate(string str)
		{
			for(int i=0;i<3;i++)
			{
				parameter[i]="";
			}
			int j = 0;//参数指针
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
