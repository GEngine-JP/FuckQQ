using System;
using System.Xml;
using System.IO;

namespace QQloginCont
{
	/// <summary>
	/// getSerInf ��ժҪ˵����
	/// </summary>
	public class getSerInf
	{
		public getSerInf()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
