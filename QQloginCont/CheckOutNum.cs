using System;

namespace QQloginCont
{
	/// <summary>
	/// CheckOutNum 的摘要说明。
	/// </summary>
	public class CheckOutNum
	{
		private string[] parmer =new string[2]{"",""};
		/// <summary>
		/// 获取传进来的值的QQ昵称
		/// </summary>
		public string QQname
		{
			get
			{
				return(parmer[0]);
			}
		}
		/// <summary>
		/// 获取传进来的值的QQ号码
		/// </summary>
		public string QQnumber
		{
			get
			{
				return(parmer[1]);
			}
		}
		public CheckOutNum(string NameAndNum)
		{
			for(int i=0;i<2;i++)
			{
				parmer[i]="";
			}
			int j=0;
			for(int i=0;i<NameAndNum.Length;i++)
			{
				if(NameAndNum[i]=='(')
				{
					j=1;
					continue;
				}
				if(NameAndNum[i]==')')
				{
					break;
				}
				parmer[j]+=NameAndNum[i].ToString().Trim();
			}
		}
	}
}
