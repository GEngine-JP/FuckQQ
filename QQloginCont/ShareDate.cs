using System;
using System.Collections;

namespace QQloginCont
{
	/// <summary>
	/// ���ڴ��������ݹ���
	/// </summary>
	public class ShareDate
	{
		private static ArrayList winhand=new ArrayList();
		/// <summary>
		/// �û����浱ǰ���촰�ڵĴ��ھ��
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
		/// �û����浱ǰ���ڵĴ������ƣ����ڼ�������WinHandһһ��Ӧ
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
		/// ���ڱ��浱ǰ�յ�����Ϣ��
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
		/// ���ڱ��浱ǰ��½�û�����
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
		/// ���浱ǰ�û��ĺ�����Ϣ�����룩
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
		/// ���浱ǰ�û��ĺ�����Ϣ���ǳƣ�
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
		/// ����������ľ��
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
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
	}
}
