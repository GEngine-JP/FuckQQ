using System;
using System.Runtime.InteropServices;

namespace QQloginCont
{
	/// <summary>
	/// �����ڲ�ͬ�Ĵ����з�����Ϣ
	/// </summary>
	public class TrafficMsg
	{
		public TrafficMsg()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// �ṩWin32����Ϣ����,���ͺ�ȵ��������Ȼ�󷵻�
		/// </summary>
		/// <param name="hWnd">Ҫ������Ϣ����ľ��</param>
		/// <param name="Msg">��Ҫ���͵�ָ����Ϣ</param>
		/// <param name="wParam">��Ҫ���͵�ָ��������Ϣ</param>
		/// <param name="lParam">��Ҫ���͵�ָ��������Ϣ</param>
		/// <returns></returns>
		[DllImport("User32.dll",EntryPoint="SendMessage")]
		public static extern int SendMessage(int hWnd,int Msg,int wParam,int lParam);
		/// <summary>
		/// �ṩWin32����Ϣ����,���ͺ���������
		/// </summary>
		/// <param name="hWnd">Ҫ������Ϣ����ľ��</param>
		/// <param name="Msg">��Ҫ���͵�ָ����Ϣ</param>
		/// <param name="wParam">��Ҫ���͵�ָ��������Ϣ</param>
		/// <param name="lParam">��Ҫ���͵�ָ��������Ϣ</param>
		/// <returns></returns>
		[DllImport("User32.dll",EntryPoint="PostMessage")]
		public static extern bool PostMessage(int hWnd,int Msg,int wParam,int lParam);
	}
}
