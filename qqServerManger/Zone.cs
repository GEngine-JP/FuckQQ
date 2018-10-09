using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace qqServerManger
{
    namespace Zone
    {
        public class ZoneInf
        {
            private string ZoneUser = "";
            private bool haszone = false;
            /// <summary>
            /// ��ȡ���û��Ƿ��пռ䣬ֻ��
            /// </summary>
            public bool HasZone
            {
                get
                {
                    return (haszone);
                }
            }
            private string zonename = "";
            /// <summary>
            /// ��ȡ������qq�ռ������
            /// </summary>
            public string ZoneName
            {
                get
                {
                    return (zonename);
                }
                set
                {
                    if (value.Trim() != "")
                    {
                        zonename = value;
                    }
                    else
                    {
                        zonename = "û������";
                    }
                }
            }
            private string zonestyle = "";
            /// <summary>
            /// ��ȡ������qq�ռ����ʽ
            /// </summary>
            public string ZoneStyle
            {
                get
                {
                    return (zonestyle);
                }
                set
                {
                    if (value.Trim() != "")
                    {
                        zonestyle = value;
                    }
                    else
                    {
                        zonestyle = "Ĭ��";
                    }
                }
            }
            private string zonebgsound = "";
            /// <summary>
            /// ��ȡ������qq�ռ�ı�������
            /// </summary>
            public string ZoneBgSound
            {
                get
                {
                    return (zonebgsound);
                }
                set
                {
                    if (value.Trim() != "")
                    {
                        zonebgsound = value;
                    }
                    else
                    {
                        zonebgsound = "0";
                    }
                }
            }
            private string zonedes = "";
            /// <summary>
            /// ��ȡ������qq�ռ��������Ϣ
            /// </summary>
            public string ZoneDes
            {
                get
                {
                    return (zonedes);
                }
                set
                {
                    if (value.Trim() != "")
                    {
                        zonedes = value;
                    }
                    else
                    {
                        zonedes = "û��������Ϣ";
                    }
                }
            }
            private string zonebgimg = "";
            /// <summary>
            /// ��ȡ������qq�ռ�ı���ͼƬ
            /// </summary>
            public string ZoneBgImg
            {
                get
                {
                    return (zonebgimg);
                }
                set
                {
                    if (value.Trim() != "")
                    {
                        zonebgimg = value;
                    }
                    else
                    {
                        zonebgimg = "0";
                    }
                }
            }
            public ZoneInf(string uid)
            {
                ZoneUser = uid;
            }
            /// <summary>
            /// ִ��ZONE����
            /// </summary>
            /// <param name="model">GET:��ȡ�ռ����Ϣ��SET:���ÿռ����Ϣ��NEW����¿ռ�</param>
            public bool doZoneCommand(string model)
            {
                switch (model.Trim())
                { 
                    case "GET":
                        GetZoneInf();
                        break;
                    case "SET":
                        SetZoneInf();
                        break;
                    case "NEW":
                        return (MakeNewZone());
                    default:
                        break;
                }
                return(true);
            }
            private void GetZoneInf()
            {
                DataSet tempDs = new DataSet();
                tempDs = opDate.GetZoneInf(ZoneUser);
                if (tempDs.Tables[0].Rows.Count != 0)
                {
                    haszone = true;
                    zonename = tempDs.Tables[0].Rows[0]["vcZoneName"].ToString();
                    zonestyle = tempDs.Tables[0].Rows[0]["iStyId"].ToString();
                    zonebgsound = tempDs.Tables[0].Rows[0]["vsBgSound"].ToString();
                    zonedes = tempDs.Tables[0].Rows[0]["tZoneDes"].ToString();
                    zonebgimg = tempDs.Tables[0].Rows[0]["vcZoneBgImg"].ToString();
                }
                tempDs.Dispose();
            }
            private void SetZoneInf()
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("update ZoneInf set vcZoneName='");
                sql.Append(zonename + "',vcZoneBgImg='");
                sql.Append(zonebgimg + "',vsBgSound='");
                sql.Append(zonebgsound + "',tZoneDes='");
                sql.Append(zonedes + "',iStyId='");
                sql.Append(zonestyle + "' where cZoneOwner='");
                sql.Append(ZoneUser + "'");
                opDate.doZoneCommand(sql.ToString());
            }
            private bool MakeNewZone()
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("insert into ZoneInf(cZoneOwner,vcZoneName,vcZoneBgImg,vsBgSound,tZoneDes,iStyId) values('");
                sql.Append(ZoneUser + "','" + zonename + "','" + zonebgimg + "','" + zonebgsound + "','" + zonedes + "','" + zonestyle + "')");
                return (opDate.doZoneCommand(sql.ToString()));
            }
        }
        public class Art
        {
            private string artid = "";
            private string artname="";
            /// <summary>
            /// ��ȡ���±���,ֻ��
            /// </summary>
            public string ArtTitle
            {
                get
                {
                    return(artname);
                }
            }
            private string pubtime="";
            /// <summary>
            /// ��ȡ����ʱ��,ֻ��
            /// </summary>
            public string PubTime
            {
                get
                {
                    return(pubtime);
                }
            }
            private string artcontent="";
            /// <summary>
            /// ��ȡ��������
            /// </summary>
            public string ArtContent
            {
                get
                {
                    return(artcontent);
                }
            }
            private string browsecount = "";
            /// <summary>
            /// �������
            /// </summary>
            public string BrowseCount
            {
                get
                {
                    return (browsecount);
                }
            }
            /// <summary>
            /// ��ȡ���µ������б�
            /// </summary>
            /// <param name="ModelId">ģ������</param>
            /// <param name="UserId">�û�����</param>
            /// <returns></returns>
            public static string GetArtListByUser(string UserId)
            {
                StringBuilder str = new StringBuilder();
                DataSet ds=new DataSet();
                ds = opDate.GetArtList("0", "0", UserId);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    str.Append("<div class=\"ArtItem\" onmousemove=\"this.style.backgroundColor='#006699'\" onmouseout=\"this.style.backgroundColor='Transparent'\"><table width=\"100%\" border=\"0\" align=\"left\" cellpadding=\"0\"><tr><td>");
                    str.Append((i + 1).ToString().Trim());
                    str.Append("</td><td><a href='ArtView.aspx?id=");
                    str.Append(ds.Tables[0].Rows[i]["iArtId"].ToString().Trim() + "' target='_blank'>");
                    str.Append(ds.Tables[0].Rows[i]["vcArtName"].ToString().Trim());
                    str.Append("</a></td><td>");
                    str.Append(ds.Tables[0].Rows[i]["cPubTime"].ToString().Trim());
                    str.Append("</td></tr></table></div>");
                    str.Append("");
                }
                return (str.ToString());
            }
            /// <summary>
            /// ͨ��ģ�����ƻ�ȡ�����б�
            /// </summary>
            /// <param name="ModelId">ģ��id</param>
            /// <param name="UserId">�û�id</param>
            /// <returns></returns>
            public static string GetArtListByModel(string ModelId, string UserId)
            {
                StringBuilder str = new StringBuilder();
                DataSet ds = new DataSet();
                ds = opDate.GetArtList("1", ModelId, UserId);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    str.Append("<div class=\"ArtItem\" onmousemove=\"this.style.backgroundColor='#006699'\" onmouseout=\"this.style.backgroundColor='Transparent'\"><table width=\"100%\" border=\"0\" align=\"left\" cellpadding=\"0\"><tr><td>");
                    str.Append((i + 1).ToString().Trim());
                    str.Append("</td><td><a href='ArtView.aspx?id=");
                    str.Append(ds.Tables[0].Rows[i]["iArtId"].ToString().Trim() + "' target='_blank'>");
                    str.Append(ds.Tables[0].Rows[i]["vcArtName"].ToString().Trim());
                    str.Append("</a></td><td>");
                    str.Append(ds.Tables[0].Rows[i]["cPubTime"].ToString().Trim());
                    str.Append("</td></tr></table></div>");
                    str.Append("");
                }
                return (str.ToString());
            }
            public Art(string ArtId)
            {
                artid = ArtId;
                GetArt();
            }
            private void GetArt()
            {
                SqlDataReader dr = opDate.ReadArtById(artid);
                artname = dr["vcArtName"].ToString();
                pubtime = dr["cPubTime"].ToString();
                artcontent = dr["tArtContent"].ToString();
                browsecount = dr["iBrowseCount"].ToString();
            }
        }
    }
}
