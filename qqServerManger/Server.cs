using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace qqServerManger
{
    /// <summary>
    /// qq���������幦����
    /// </summary>
    public class Server
    {
        private Thread qSerTh;
        private bool ServerRun = true;
        private TcpListener qTcpListener = null;
        private string[] parameter = new string[3];//������յĲ���
        IPEndPoint qSerIpendPoint;
        public bool IniServer(string ip, string port)
        {
            try
            {
                int ipPort=Int32.Parse(port);
                IPAddress ipAdd=IPAddress.Parse(ip);
                qSerIpendPoint = new IPEndPoint(ipAdd, ipPort);
                return (true);
            }
            catch
            {
                return (false);
            }
        }
        public bool StartServer()
        {
            try
            {
                qTcpListener = new TcpListener(qSerIpendPoint);
                qTcpListener.Start();
                qSerTh = new Thread(new ThreadStart(QQServerIng));
                ServerRun = true;
                qSerTh.Start();
                return (true);
            }
            catch
            {
                return (false);
            }
        }
        public bool StopServer()
        {
            try
            {
                ServerRun = false;
                qTcpListener.Stop();
                qSerTh.Abort();
                return (true);
            }
            catch
            {
                return (false);
            }
        }
        private void QQServerIng()
        {
            try
            {
                while (ServerRun)
                {
                    Socket QS;
                    QS = qTcpListener.AcceptSocket();
                    string RemoteEndPoint = QS.RemoteEndPoint.ToString();
                    Byte[] Stream = new Byte[1024];
                    QS.Receive(Stream);
                    string save = System.Text.Encoding.UTF8.GetString(Stream);
                    string Sendmsg = "";
                    CheckOutDate(save);
                    switch (parameter[0])
                    {
                        case "1"://��֤�û���½��Ϣ
                            if (opDate.qUserLogin(parameter[1], parameter[2]))
                            {
                                Sendmsg = "1";
                                XmlOperate.AddOnlineUser(parameter[1], RemoteEndPoint);
                            }
                            else
                            {
                                Sendmsg = "0";
                            }
                            SendMsg(QS, Sendmsg);
                            break;
                        case "2"://���ͺ��ѷ�����������
                            XmlOperate friend = new XmlOperate();
                            string FileUrl = "";
                            while ((FileUrl = friend.MakeFriendXml(parameter[1])) == "-1")
                            { }
                            SendFile(QS, FileUrl);
                            XmlFileOp.DelThisFile(FileUrl);
                            break;
                        case "3"://����Ⱥ����������
                            break;
                        case "4"://���Ͳ��ҽ��
                            break;
                        case "5"://ע���û�
                            break;
                        case "6"://���������û��б�
                            SendFile(QS, "onlineinf\\onLine.xml");
                            break;
						case "7"://��Ӻ��� ��Ϣ��ʽΪ�����ͺţ�����ӵ���ߣ����Ѻ���
                            Sendmsg = opDate.AddFriend(parameter[1].Trim(), parameter[2].Trim());
                            SendMsg(QS, Sendmsg);
                            break;
                        default://���ʹ������
                            break;
                    }
                    QS.Close();
                }
            }
            catch { }
        }

        private void SendMsg(Socket So, string msg)
        {
            UTF8Encoding SendByte = new UTF8Encoding();
            So.Send((SendByte.GetBytes(msg)));
        }

        private void SendFile(Socket So, string FileUrl)
        {
            So.SendFile(FileUrl);
        }

        private void CheckOutDate(string str)
        {
            for (int i = 0; i < 3; i++)
            {
                parameter[i] = "";
            }
            int j = 0;//����ָ��
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ';')
                {
                    if (str[i] == '\0')
                    {
                        break;
                    }
                    parameter[j] += str[i].ToString().Trim();
                }
                else
                {
                    j++;
                }
            }
        }
    }
}
