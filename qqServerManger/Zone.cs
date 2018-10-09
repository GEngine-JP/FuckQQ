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
            /// 获取该用户是否有空间，只读
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
            /// 获取或设置qq空间的名称
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
                        zonename = "没有命名";
                    }
                }
            }
            private string zonestyle = "";
            /// <summary>
            /// 获取或设置qq空间的样式
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
                        zonestyle = "默认";
                    }
                }
            }
            private string zonebgsound = "";
            /// <summary>
            /// 获取或设置qq空间的背景音乐
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
            /// 获取或设置qq空间的描述信息
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
                        zonedes = "没有描述信息";
                    }
                }
            }
            private string zonebgimg = "";
            /// <summary>
            /// 获取或设置qq空间的背景图片
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
            /// 执行ZONE命令
            /// </summary>
            /// <param name="model">GET:获取空间的信息，SET:设置空间的信息，NEW添加新空间</param>
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
            /// 获取文章标题,只读
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
            /// 获取发表时间,只读
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
            /// 获取文章内容
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
            /// 浏览次数
            /// </summary>
            public string BrowseCount
            {
                get
                {
                    return (browsecount);
                }
            }
            /// <summary>
            /// 获取最新的文章列表
            /// </summary>
            /// <param name="ModelId">模块名称</param>
            /// <param name="UserId">用户名称</param>
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
            /// 通过模块名称获取文章列表
            /// </summary>
            /// <param name="ModelId">模块id</param>
            /// <param name="UserId">用户id</param>
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
