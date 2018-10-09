using System;
using System.Collections;

namespace QQloginCont
{
	/// <summary>
	/// 用于窗体间的数据共享
	/// </summary>
	public class ShareDate
	{
		private static ArrayList winhand=new ArrayList();
		/// <summary>
		/// 用户保存当前聊天窗口的窗口句柄
		/// </summary>
		public static ArrayList WinHand
		{
			get
			{
				return(winhand);
			}
			set
			{
				winhand=value;
			}
		}
		private static ArrayList winname=new ArrayList();
		/// <summary>
		/// 用户保存当前存在的窗体名称，便于检索，和WinHand一一对应
		/// </summary>
		public static ArrayList WinName
		{
			get
			{
				return(winname);
			}
			set
			{
				winname=value;
			}
		}
		private static ArrayList msg=new ArrayList();
		/// <summary>
		/// 用于保存当前收到的消息！
		/// </summary>
		public static ArrayList Msg
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
		private static string thisuser;
		/// <summary>
		/// 用于保存当前登陆用户号码
		/// </summary>
		public static string ThisUser
		{
			get
			{
				return(thisuser);
			}
			set
			{
				thisuser=value;
			}
		}
		private static ArrayList qqnumber=new ArrayList();
		/// <summary>
		/// 保存当前用户的好友信息（号码）
		/// </summary>
		public static ArrayList QQNumber
		{
			get
			{
				return(qqnumber);
			}
			set
			{
				qqnumber=value;
			}
		}
		private static ArrayList qqname=new ArrayList();
		/// <summary>
		/// 保存当前用户的好友信息（昵称）
		/// </summary>
		public static ArrayList QQName
		{
			get
			{
				return(qqname);
			}
			set
			{
				qqname=value;
			}
		}
		private static int mainformhand;
		/// <summary>
		/// 保存主窗体的句柄
		/// </summary>
		public static int MainFormHand
		{
			get
			{
				return(mainformhand);
			}
			set
			{
				mainformhand=value;
			}
		}
		public ShareDate()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
	}
}
