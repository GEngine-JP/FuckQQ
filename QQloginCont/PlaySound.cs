using System;
using System.Runtime.InteropServices;

namespace QQloginCont
{
	/// <summary>
	/// PlaySound ��ժҪ˵����
	/// </summary>
	public class PlaySound
	{
		public PlaySound()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		[DllImport("winmm.dll")]
		private static extern long mciSendString(string strCommand,	string strReturn, int iReturnLength, IntPtr hwndCallback);
		private static void GetWavAndOpen(int SoundId)
		{
			string sFileName;
			switch(SoundId)
			{
				case 1://ϵͳ��Ϣ
					sFileName="sound\\System.wav";
					break;
				case 2://�յ���Ϣ
					sFileName="sound\\Msg.wav";
					break;
				case 3://�����л�
					sFileName="sound\\Folder.wav";
					break;
				default:
					sFileName="sound\\Call.wav";
					break;
			}
			string sCommand = "open \"" + sFileName + "\" type mpegvideo alias MediaFile";	//   MediaFile��ѡ�񲥷��ļ����� 
			string ret = null;
			mciSendString(sCommand, ret, 0, IntPtr.Zero);
		}
		public static void play(int SoundId)
		{
			StopPlay();
			GetWavAndOpen(SoundId);
			string sCommand = "play MediaFile";
			string ret = null;
			mciSendString(sCommand, ret, 0, IntPtr.Zero);
		}
		private static void StopPlay()
		{
			string sCommand = "close MediaFile";
			string ret = null;
			mciSendString(sCommand, ret, 0, IntPtr.Zero);
		}
	}
}
