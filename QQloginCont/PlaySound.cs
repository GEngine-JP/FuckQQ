using System;
using System.Runtime.InteropServices;

namespace QQloginCont
{
	/// <summary>
	/// PlaySound 的摘要说明。
	/// </summary>
	public class PlaySound
	{
		public PlaySound()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		[DllImport("winmm.dll")]
		private static extern long mciSendString(string strCommand,	string strReturn, int iReturnLength, IntPtr hwndCallback);
		private static void GetWavAndOpen(int SoundId)
		{
			string sFileName;
			switch(SoundId)
			{
				case 1://系统消息
					sFileName="sound\\System.wav";
					break;
				case 2://收到消息
					sFileName="sound\\Msg.wav";
					break;
				case 3://功能切换
					sFileName="sound\\Folder.wav";
					break;
				default:
					sFileName="sound\\Call.wav";
					break;
			}
			string sCommand = "open \"" + sFileName + "\" type mpegvideo alias MediaFile";	//   MediaFile是选择播放文件类型 
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
