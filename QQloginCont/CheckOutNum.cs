using System;

namespace QQloginCont
{
	/// <summary>
	/// CheckOutNum ��ժҪ˵����
	/// </summary>
	public class CheckOutNum
	{
		private string[] parmer =new string[2]{"",""};
		/// <summary>
		/// ��ȡ��������ֵ��QQ�ǳ�
		/// </summary>
		public string QQname
		{
			get
			{
				return(parmer[0]);
			}
		}
		/// <summary>
		/// ��ȡ��������ֵ��QQ����
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
