using System;
using System.Text.RegularExpressions;

namespace QQloginCont
{
	/// <summary>
	/// Regx ��ժҪ˵����
	/// </summary>
	public class Regx
	{
		public Regx()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ��֤�����Ƿ�Ϊ��
		/// </summary>
		/// <param name="str">����֤����</param>
		/// <returns></returns>
		public static bool isNull(string str)
		{
			if(str.Trim()==""||str=="")
			{
				return(false);
			}
			else
			{
				return(true);
			}
		}
		public static bool isNumber(string number)
		{
			Regex check=new Regex("\\d{8}");
			if(check.IsMatch(number,0))
			{
				return(true);
			}
			else
			{
				return(false);
			}
		}
		public static string CheckUserNumber(string number)
		{
			string temp="";
			if(number.Length!=8)
			{
				for(int i=0;i<8-number.Length;i++)
				{
					temp+="0";
				}
				temp+=number;
			}
			else
			{
				temp=number;
			}
			return(temp);
		}
	}
}
