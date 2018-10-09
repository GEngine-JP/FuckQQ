using System;
using System.Xml;
using System.IO;

namespace QQloginCont
{
	/// <summary>
	/// getSerInf 的摘要说明。
	/// </summary>
	public class getSerInf
	{
		public getSerInf()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static string ReadXmlNode(string XmlFileUrl,string Node)
		{
			if(File.Exists(XmlFileUrl))
			{
				XmlDocument SerInf=new XmlDocument();
				SerInf.Load(XmlFileUrl);
				XmlNode FirstNode=SerInf.SelectSingleNode(Node).FirstChild;
				return(FirstNode.InnerText);
			}
			else
			{
				return("-1");
			}
		}
	}
}
