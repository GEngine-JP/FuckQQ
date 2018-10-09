using System;
using System.Text.RegularExpressions;

namespace QQloginCont
{
	/// <summary>
	/// Regx 的摘要说明。
	/// </summary>
	public class Regx
	{
		public Regx()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 验证数据是否为空
		/// </summary>
		/// <param name="str">代验证数据</param>
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
