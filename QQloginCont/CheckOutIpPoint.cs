using System;

namespace QQloginCont
{
	/// <summary>
	/// CheckOutIpPoint 的摘要说明。
	/// </summary>
	public class CheckOutIpPoint
	{
		private string ipadd="";
		private int ipport=0;
		/// <summary>
		/// 返回ｉｐ地址，只读
		/// </summary>
		public string IpAdd
		{
			get
			{
				return(ipadd);
			}
		}
		/// <summary>
		/// 返回端口号，只读
		/// </summary>
		public int Port
		{
			get
			{
				return(ipport);
			}
		}
		public CheckOutIpPoint(string IpEndPoint)
		{
			string ip="";
			string port="";
			bool go=false;
			for(int i=0;i<IpEndPoint.Length;i++)
			{
				if(IpEndPoint[i]==':')
				{
					go=true;
					continue;
				}
				if(!go)
				{
					ip+=IpEndPoint[i].ToString().Trim();
				}
				else
				{
					port+=IpEndPoint[i].ToString().Trim();
				}
			}
			this.ipadd=ip;
			this.ipport=Convert.ToInt32(port)-1;
		}
	}
}
