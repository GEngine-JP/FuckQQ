using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace qqServerManger
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public class opDate
    {
        /// <summary>
        /// 用户登陆验证
        /// </summary>
        /// <param name="uid">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>成功：true,失败：false</returns>
        public static bool qUserLogin(string uid, string pwd)
        {
            if (uid == "-1" || pwd == "-1")
            {
                return (false);
            }
            else
            {
                string sql = string.Format("select * from UserInf where cQQNum='{0}' and vcQuserPwd='{1}'", uid, pwd);
                SqlConnection Conn = SqlConnectionTest.GetConnection();
                if (Conn != null)
                {
                    Conn.Open();
                    SqlCommand Com = new SqlCommand(sql, Conn);
                    SqlDataReader dr;
                    dr = Com.ExecuteReader();
                    if (dr.Read())
                    {
                        Com.Dispose();
                        Conn.Close();
                        return (true);
                    }
                    else
                    {
                        Com.Dispose();
                        Conn.Close();
                        return (false);
                    }
                }
                else
                {
                    return (false);
                }
            }
        }
        /// <summary>
        /// 通过用户ｉｄ获取好友列表
        /// </summary>
        /// <param name="uid">用户ｉｄ</param>
        /// <returns></returns>
        public static DataSet GetFriendLsit(string uid)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlDataAdapter da = new SqlDataAdapter("GetFriendLsit", Con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter cQQNum = da.SelectCommand.Parameters.Add("@cQQNum", SqlDbType.Char, 8);
            cQQNum.Direction = ParameterDirection.Input;
            cQQNum.Value = uid;
            da.Fill(ds);
            da.Dispose();
            Con.Close();
            return (ds);
        }
        /// <summary>
        /// 根据用户id获取该用户的好友分组消息
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="model">查询模式</param>
        /// <returns></returns>
        public static DataSet GetGroupInfByUserId(string uid,int model)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlDataAdapter da = new SqlDataAdapter("GetGroupInf", Con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter cQQNum = da.SelectCommand.Parameters.Add("@UserId", SqlDbType.Char, 8);
            SqlParameter Model = da.SelectCommand.Parameters.Add("@Model", SqlDbType.Int);
            cQQNum.Direction = ParameterDirection.Input;
            Model.Value = model;
            cQQNum.Value = uid;
            da.Fill(ds);
            da.Dispose();
            Con.Close();
            return (ds);
        }
        /// <summary>
        /// 通过用户号码获取用户名称
        /// </summary>
        /// <param name="number">用户号码</param>
        /// <returns></returns>
        public static string GetUserNameByNumber(string number)
        {
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlCommand cmd = new SqlCommand("GetUserNameByNumber",Con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter UserNumber = cmd.Parameters.Add("@UserNumber", SqlDbType.Char, 8);
            UserNumber.Direction = ParameterDirection.Input;
            UserNumber.Value = number;
            return (cmd.ExecuteScalar().ToString());
        }
        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="uid">用户名称</param>
        /// <param name="pwd">用户密码</param>
        /// <returns>返回用户的ｑｑ号码</returns>
        public static string AddNewUser(string uid,string pwd)
        {
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlCommand cmd = new SqlCommand("RegUser", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter UserName = cmd.Parameters.Add("@UserName", SqlDbType.Char, 10);
            SqlParameter UserPwd = cmd.Parameters.Add("@UserPwd", SqlDbType.Char, 50);
            SqlParameter UserNumber = cmd.Parameters.Add("@UserNumber", SqlDbType.Char, 8);
            UserName.Direction = ParameterDirection.Input;
            UserPwd.Direction = ParameterDirection.Input;
            UserNumber.Direction = ParameterDirection.Output;
            UserName.Value = uid;
            UserPwd.Value = pwd;
            cmd.ExecuteNonQuery();
            return (UserNumber.Value.ToString());
        }
        /// <summary>
        /// 通过用户名查询用户
        /// </summary>
        /// <param name="Name">需要查询的用户名</param>
        /// <returns></returns>
        public static DataSet SelectUserByName(string Name)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SelectUserByName", Con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter UserName = da.SelectCommand.Parameters.Add("@UserName", SqlDbType.Char, 10);
            UserName.Direction = ParameterDirection.Input;
            UserName.Value = Name;
            da.Fill(ds);
            da.Dispose();
            Con.Close();
            return (ds);
        }
        /// <summary>
        /// 通过用户号码查询用户
        /// </summary>
        /// <param name="Num">需要查询的用户号码</param>
        /// <returns></returns>
        public static DataSet SelectUserByNum(string Num)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SelectUserByNum", Con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter UserNum = da.SelectCommand.Parameters.Add("@UserNum", SqlDbType.Char, 8);
            UserNum.Direction = ParameterDirection.Input;
            UserNum.Value = Num;
            da.Fill(ds);
            da.Dispose();
            Con.Close();
            return (ds);
        }
        /// <summary>
        /// 添加好友
        /// </summary>
        /// <param name="Ow">该好友拥有者号码</param>
        /// <param name="FNumber">需要添加的好友</param>
        /// <returns>返回添加结果</returns>
        public static string AddFriend(string Ow, string FNumber)
        {
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlCommand cmd = new SqlCommand("AddFriend", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter Owner = cmd.Parameters.Add("@Owner", SqlDbType.Char, 8);
            SqlParameter FriendNumber = cmd.Parameters.Add("@FriendNumber", SqlDbType.Char, 8);
            SqlParameter GroupId = cmd.Parameters.Add("@GroupId", SqlDbType.Int);
            SqlParameter result = cmd.Parameters.Add("@result", SqlDbType.Int);
            Owner.Direction = ParameterDirection.Input;
            FriendNumber.Direction = ParameterDirection.Input;
            GroupId.Direction = ParameterDirection.Input;
            result.Direction = ParameterDirection.Output;
            Owner.Value = Ow;
            FriendNumber.Value = FNumber;
            GroupId.Value = "-1";
            cmd.ExecuteNonQuery();
            Con.Close();
            return (result.Value.ToString());
        }
        /// <summary>
        /// 添加新用户分组
        /// </summary>
        /// <param name="Owner">分组拥有者</param>
        /// <param name="groupname">分组名称</param>
        /// <returns></returns>
        public static string AddNewGroup(string Owner,string groupname)
        {
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlCommand cmd = new SqlCommand("AddNewGroup", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter GroupOwner = cmd.Parameters.Add("@GroupOwner", SqlDbType.Char, 8);
            SqlParameter GroupName = cmd.Parameters.Add("@GroupName", SqlDbType.Char, 8);
            SqlParameter Result = cmd.Parameters.Add("@Result", SqlDbType.Int);
            GroupName.Direction = ParameterDirection.Input;
            GroupOwner.Direction = ParameterDirection.Input;
            Result.Direction = ParameterDirection.Output;
            GroupName.Value = groupname;
            GroupOwner.Value = Owner;
            cmd.ExecuteNonQuery();
            Con.Close();
            if (Result.Value.ToString().Trim() == "-1")
            {
                return ("该分组名称已经存在！");
            }
            else if (Result.Value.ToString().Trim() == "1")
            {
                return ("恭喜！添加分组成功！");
            }
            else
            {
                return ("未知错误！");
            }
        }
        /// <summary>
        /// 更新用户分组名称
        /// </summary>
        /// <param name="NewName">新名称</param>
        /// <param name="uid">用户</param>
        /// <returns></returns>
        public static string UpDateGroupInf(string NewName, string uid,string groupid)
        {
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlCommand cmd = new SqlCommand("UpDateGroupInf", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter newName = cmd.Parameters.Add("@newName", SqlDbType.Char, 10);
            SqlParameter User = cmd.Parameters.Add("@User", SqlDbType.Char, 8);
            SqlParameter GroupId = cmd.Parameters.Add("@GroupId", SqlDbType.Int);
            SqlParameter Result = cmd.Parameters.Add("@Result", SqlDbType.Int);
            newName.Direction = ParameterDirection.Input;
            User.Direction = ParameterDirection.Input;
            GroupId.Direction = ParameterDirection.Input;
            Result.Direction = ParameterDirection.Output;
            newName.Value = NewName;
            User.Value = uid;
            GroupId.Value = groupid;
            cmd.ExecuteNonQuery();
            Con.Close();
            switch (Result.Value.ToString().Trim())
            {
                case "0":
                    return ("该分组名称已经存在！不能修改为此名称！");
                case "1":
                    return ("修改名称成功！");
                case "2":
                    return ("不能修改默认分组\"我的好友\"的名称！");
                default:
                    return ("未知错误！");
            }
        }
        /// <summary>
        /// 删除用户分组
        /// </summary>
        /// <param name="groupId">分组号</param>
        /// <returns></returns>
        public static bool DelGroup(string groupId)
        {
            try
            {
                SqlConnection Con = SqlConnectionTest.GetConnection();
                Con.Open();
                SqlCommand cmd = new SqlCommand("DelGroupName", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter GroupId = cmd.Parameters.Add("@GroupId", SqlDbType.Int);
                GroupId.Direction = ParameterDirection.Input;
                GroupId.Value = groupId;
                cmd.ExecuteNonQuery();
                Con.Close();
                return (true);
            }
            catch
            {
                return (false);
            }
        }
        /// <summary>
        /// 根据分组id返回该分组的所有好友列表
        /// </summary>
        /// <param name="groupId">分组id</param>
        /// <returns></returns>
        public static DataSet GetFriendByGroupId(string groupId)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlDataAdapter da = new SqlDataAdapter("GetFriendByGroupId", Con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter GroupId = da.SelectCommand.Parameters.Add("@GroupId", SqlDbType.Int);
            GroupId.Direction = ParameterDirection.Input;
            GroupId.Value = groupId;
            da.Fill(ds);
            da.Dispose();
            Con.Close();
            return (ds);
        }
        /// <summary>
        /// 根据用户id获取所有默认分组的好友名单
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        public static DataSet GetDefaultGroupFriend(string uid)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlDataAdapter da = new SqlDataAdapter("GetFriendListDefault", Con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter UserId = da.SelectCommand.Parameters.Add("@UserId", SqlDbType.Char,8);
            UserId.Direction = ParameterDirection.Input;
            UserId.Value = uid;
            da.Fill(ds);
            da.Dispose();
            Con.Close();
            return (ds);
        }
        /// <summary>
        /// 更改好友所属于分组
        /// </summary>
        /// <param name="friendId">好友id</param>
        /// <param name="DesGroup">目的分组id</param>
        /// <returns></returns>
        public static bool ChangeFriGroup(string friendId, string DesGroup)
        {
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlCommand cmd = new SqlCommand("ChangeFriGroup", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter FriendId = cmd.Parameters.Add("@FriendId", SqlDbType.Int);
            SqlParameter DestiGroup = cmd.Parameters.Add("@DestiGroup", SqlDbType.Int);
            FriendId.Direction = ParameterDirection.Input;
            DestiGroup.Direction = ParameterDirection.Input;
            FriendId.Value = friendId.Trim();
            DestiGroup.Value = DesGroup.Trim();
            cmd.ExecuteNonQuery();
            Con.Close();
            return (true);
        }
        /// <summary>
        /// 删除指定好友
        /// </summary>
        /// <param name="friendId">好友id</param>
        /// <returns></returns>
        public static bool DelThisFriend(string friendId)
        {
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlCommand cmd = new SqlCommand("DelThisFriend", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter FriendId = cmd.Parameters.Add("@FriendId", SqlDbType.Int);
            FriendId.Direction = ParameterDirection.Input;
            FriendId.Value = friendId.Trim();
            cmd.ExecuteNonQuery();
            Con.Close();
            return (true);
        }
        /// <summary>
        /// 返回所有用户
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAllUser()
        {
            DataSet ds = new DataSet();
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from GetAllUser", Con);
            da.Fill(ds);
            da.Dispose();
            Con.Close();
            return (ds);
        }
        /// <summary>
        /// 根据id获取空间资料
        /// </summary>
        /// <param name="Owner">id</param>
        /// <returns></returns>
        public static DataSet GetZoneInf(string owner)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlDataAdapter da = new SqlDataAdapter("GetZoneInf", Con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter Owner = da.SelectCommand.Parameters.Add("@Owner", SqlDbType.Char, 8);
            Owner.Direction = ParameterDirection.Input;
            Owner.Value = owner;
            da.Fill(ds);
            da.Dispose();
            Con.Close();
            return (ds);
        }
        /// <summary>
        /// 执行空间命令
        /// </summary>
        /// <param name="sql">sql命令</param>
        /// <returns></returns>
        public static bool doZoneCommand(string sql)
        {
            try
            {
                SqlConnection Con = SqlConnectionTest.GetConnection();
                Con.Open();
                SqlCommand cmd = new SqlCommand(sql, Con);
                cmd.ExecuteNonQuery();
                return (true);
            }
            catch
            {
                return (false);
            }
        }
        /// <summary>
        /// 获取系统中的所有样式
        /// </summary>
        /// <returns></returns>
        public static DataSet GetStyleList()
        {
            string sql = "select * from viGetStyleList";
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, Con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Con.Close();
            da.Dispose();
            return (ds);
        }
        /// <summary>
        /// 根据用户名获取所有模块列表
        /// </summary>
        /// <param name="uid">用户名</param>
        /// <returns></returns>
        public static DataSet GetModelList(string uid)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlDataAdapter da = new SqlDataAdapter("GetModelList", Con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter ZoneOwner = da.SelectCommand.Parameters.Add("@ZoneOwner", SqlDbType.Char, 8);
            ZoneOwner.Direction = ParameterDirection.Input;
            ZoneOwner.Value = uid;
            da.Fill(ds);
            Con.Close();
            da.Dispose();
            return (ds);
        }
        /// <summary>
        /// 创建新的模块
        /// </summary>
        /// <param name="modelname">模块名称</param>
        /// <param name="user">所有者</param>
        /// <returns></returns>
        public static string MakeNewModel(string modelname, string user)
        {
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlCommand cmd = new SqlCommand("MakeNewModel", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter ModelName = cmd.Parameters.Add("@ModelName", SqlDbType.VarChar, 20);
            SqlParameter ModelOwner = cmd.Parameters.Add("@ModelOwner", SqlDbType.Char, 8);
            SqlParameter Result = cmd.Parameters.Add("@Result", SqlDbType.Int);
            ModelName.Direction = ParameterDirection.Input;
            ModelOwner.Direction = ParameterDirection.Input;
            Result.Direction = ParameterDirection.Output;
            ModelName.Value = modelname;
            ModelOwner.Value = user;
            cmd.ExecuteNonQuery();
            Con.Close();
            switch (Result.Value.ToString().Trim())
            {
                case "0":
                    return ("该模块名称已经存在！");
                case "1":
                    return ("添加模块成功！");
                default:
                    return ("未知错误！");
            }
        }
        /// <summary>
        /// 重命名模块
        /// </summary>
        /// <param name="modelid">模块id</param>
        /// <param name="modelname">新名称</param>
        /// <returns></returns>
        public static bool ReNameModel(string modelid, string modelname)
        {
            try
            {
                SqlConnection Con = SqlConnectionTest.GetConnection();
                Con.Open();
                SqlCommand cmd = new SqlCommand("ReNameModel", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter ModelId = cmd.Parameters.Add("@ModelId", SqlDbType.Int);
                SqlParameter ModelName = cmd.Parameters.Add("@ModelName", SqlDbType.VarChar, 20);
                ModelId.Direction = ParameterDirection.Input;
                ModelName.Direction = ParameterDirection.Input;
                ModelId.Value = Convert.ToInt32(modelid);
                ModelName.Value = modelname;
                cmd.ExecuteNonQuery();
                Con.Close();
                return (true);
            }
            catch
            {
                return (false);
            }
        }
        /// <summary>
        /// 发布新的日志
        /// </summary>
        /// <param name="cArtName">日志名称</param>
        /// <param name="tArtContent">日志内容</param>
        /// <param name="iModeId">模块id</param>
        /// <returns></returns>
        public static bool AddNewArt(string cArtName, string tArtContent, string iModeId)
        {
            try
            {
                SqlConnection Con = SqlConnectionTest.GetConnection();
                Con.Open();
                SqlCommand cmd = new SqlCommand("AddNewArt", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter ModeId = cmd.Parameters.Add("@ModeId", SqlDbType.Int);
                SqlParameter ArtName = cmd.Parameters.Add("@ArtName", SqlDbType.VarChar, 20);
                SqlParameter ArtContent = cmd.Parameters.Add("@ArtContent", SqlDbType.Text);
                SqlParameter PubTime = cmd.Parameters.Add("@PubTime", SqlDbType.Char, 10);
                ModeId.Direction = ParameterDirection.Input;
                ArtName.Direction = ParameterDirection.Input;
                ArtContent.Direction = ParameterDirection.Input;
                PubTime.Direction = ParameterDirection.Input;
                ModeId.Value = iModeId;
                ArtName.Value = cArtName;
                ArtContent.Value = tArtContent;
                PubTime.Value = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                cmd.ExecuteNonQuery();
                Con.Close();
                return (true);
            }
            catch
            {
                return (false);
            }
        }
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="SelectModel">查询模式</param>
        /// <param name="modeid">模块名称</param>
        /// <param name="modeowner">模块所有者</param>
        /// <returns></returns>
        public static DataSet GetArtList(string SelectModel,string modeid, string modeowner)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlDataAdapter da = new SqlDataAdapter("GetArtList", Con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter Model = da.SelectCommand.Parameters.Add("@Model", SqlDbType.Int);
            SqlParameter ModeId = da.SelectCommand.Parameters.Add("@ModeId", SqlDbType.Int);
            SqlParameter ModeOwner = da.SelectCommand.Parameters.Add("@ModeOwner", SqlDbType.Char, 8);
            Model.Direction = ParameterDirection.Input;
            ModeId.Direction = ParameterDirection.Input;
            ModeOwner.Direction = ParameterDirection.Input;
            Model.Value = Convert.ToInt32(SelectModel);
            ModeId.Value = Convert.ToInt32(modeid);
            ModeOwner.Value = modeowner;
            da.Fill(ds);
            da.Dispose();
            Con.Close();
            return (ds);
        }
        /// <summary>
        /// 获取文章的具体信息
        /// </summary>
        /// <param name="Id">文章id</param>
        /// <returns></returns>
        public static SqlDataReader ReadArtById(string Id)
        {
            SqlDataReader dr;
            SqlConnection Con = SqlConnectionTest.GetConnection();
            Con.Open();
            SqlCommand cmd = new SqlCommand("ReadArt", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter ArtId = cmd.Parameters.Add("@ArtId", SqlDbType.Int);
            ArtId.Direction = ParameterDirection.Input;
            ArtId.Value = Convert.ToInt32(Id);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return (dr);
            }
            else
            {
                return (null);
            }
            cmd.Dispose();
            Con.Close();
        }
    }
}
