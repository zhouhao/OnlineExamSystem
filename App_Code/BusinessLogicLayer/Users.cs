using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Examination.DataAccessLayer;
using Examination.DataAccessHelper;

namespace Examination.BusinessLogicLayer
{
    //用户类
    public class Users
    {
        #region 私有成员
        private string _userID;                                               //用户编号
        private string _userPwd;                                         //用户密码
        private string _userName;                                             //用户姓名 
        private int _roleid;		                     //用户角色
        private string _rolename;
        private ArrayList _duties = new ArrayList();	//用户所有的权限

        #endregion 私有成员

        #region 属性

        public string UserID
        {
            set
            {
                this._userID = value;
            }
            get
            {
                return this._userID;
            }
        }
        public string UserPwd
        {
            set
            {
                this._userPwd = value;
            }
            get
            {
                return this._userPwd;
            }
        }
      
        public string UserName
        {
            set
            {
                this._userName = value;
            }
            get
            {
                return this._userName;
            }
        }
        
        public int RoleId
        {
            set
            {
                this._roleid = value;
            }
            get
            {
                return this._roleid;
            }
        }
        public string RoleName
        {
            set
            {
                this._rolename = value;
            }
            get
            {
                return this._rolename;
            }
        }
        public ArrayList Duties
        {
            set
            {
                this._duties = value;
            }
            get
            {
                return this._duties;
            }
        }
        #endregion 属性

        #region 方法

        //根据用户 UserID 初始化该用户
        //输入：
        //      XUserID - 用户编号；
        //输出：
        //      用户存在：返回True；
        //      用户不在：返回False；
        public bool LoadData(string XUserID)
        {
            SqlParameter[] Params = new SqlParameter[1];
            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 50, XUserID);                  //用户编号            

            DataSet ds = DB.GetDataSet("Proc_UsersDetail", Params);            
            ds.CaseSensitive = false;
            DataRow DR;
            if (ds.Tables[0].Rows.Count > 0)
            {
                DR= ds.Tables[0].Rows[0];
                this._userID = GetSafeData.ValidateDataRow_S(DR, "UserID");                         //用户编号              
                this._userName = GetSafeData.ValidateDataRow_S(DR, "UserName");                     //用户姓名 
                this._userPwd = GetSafeData.ValidateDataRow_S(DR, "UserPwd");                   //用户密码
                this._roleid = GetSafeData.ValidateDataRow_N(DR, "RoleId");                     //用户权限 
                this._rolename = GetSafeData.ValidateDataRow_S(DR, "RoleName");                     //用户权限 

                //获取权限集合
                string colName = "";
                for (int i = 0; i < DR.ItemArray.Length; i++)
                {
                    colName = DR.Table.Columns[i].ColumnName;
                    if (colName.StartsWith("HasDuty_") && GetSafeData.ValidateDataRow_N(DR, colName) == 1)
                    {
                        this._duties.Add(DR.Table.Columns[i].ColumnName.Substring(8));	//去掉前缀“HasDuty_”
                    }
                }
                return true;
            }
            else
            {
                return false;
            }           
        }

        //根据UserID判断该用户是否存在
        //输入：
        //      XUserID - 用户编号；        
        //输出：
        //      用户存在：返回True；
        //      用户不在：返回False；
        public bool CheckUser(string XUserID)
        {
            SqlParameter[] Params = new SqlParameter[1];
            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 50, XUserID);                  //教工姓名            
            
            SqlDataReader DR = DB.RunProcGetReader("Proc_UsersDetail", Params);           
            if (!DR.Read())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
      

        //根据UserID和UserPassword判断密码是否正确
        //输入：
        //      XUserID - 用户编号；        
        //输出：
        //      用户存在：返回True；
        //      用户不在：返回False；
        public bool CheckPassword(string XUserID)
        {
            SqlParameter[] Params = new SqlParameter[1];
            DataBase DB = new DataBase();
            Params[0] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 50, XUserID);                  //编号            

            SqlDataReader DR = DB.RunProcGetReader("Proc_UsersDetail", Params);
            if (!DR.Read())
            {
                return false;
            }
            else
            {
                this._userPwd = DR["UserPwd"].ToString();                
                return true;
            }
        }
        
        //修改用户的密码
        //输入：
        //      XUserID - 用户编号；
        //输出：
        //      修改成功：返回True；
        //      修改失败：返回False；
        public bool ModifyPassword(string XUserID)
        {
            SqlParameter[] Params = new SqlParameter[2];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 20, XUserID);               //用户编号 
            Params[1] = DB.MakeInParam("@UserPwd", SqlDbType.VarChar, 64, UserPwd);    //用户密码 

            int Count = -1;
            Count = DB.RunProc("Proc_UserPwdModify", Params);
            if (Count > 0)
                return true;
            else return false;
        }

        //向Users表中添加用户信息(采用存储过程)
        //输出：
        //      插入成功：返回True；
        //      插入失败：返回False；
        public bool InsertByProc()
        {
            SqlParameter[] Params = new SqlParameter[4];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 50, UserID);               //用户编号
            Params[1] = DB.MakeInParam("@UserName", SqlDbType.VarChar, 50, UserName);           //用户姓名
            Params[2] = DB.MakeInParam("@UserPwd", SqlDbType.VarChar,64, UserPwd);    //用户密码
            Params[3] = DB.MakeInParam("@RoleId", SqlDbType.Int, 4,RoleId);    //角色
           
            int Count = -1;
            Count = DB.RunProc("Proc_UsersAdd", Params);
            if (Count > 0)
                return true;
            else return false;
        }
        //更新用户的信息
        public bool UpdateByProc(string XUserID)
        {
            SqlParameter[] Params = new SqlParameter[3];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 50, XUserID);               //用户编号           
            Params[1] = DB.MakeInParam("@UserName", SqlDbType.VarChar, 50, UserName);           //用户姓名               
            Params[2] = DB.MakeInParam("@RoleId", SqlDbType.Int, 4, RoleId);                    //角色
            //Params[3] = DB.MakeInParam("@UserPwd", SqlDbType.NVarChar, 64, UserPwd);           //角色
         
            int Count = -1;
            Count = DB.RunProc("Proc_UsersModify1", Params);
            if (Count > 0)
                return true;
            else return false;
        }

        //删除用户
        //输入：
        //      XUserID - 用户编号；
        //输出：
        //      删除成功：返回True；
        //      删除失败：返回False；
        public bool DeleteByProc(string XUserID)
        {
            SqlParameter[] Params = new SqlParameter[1];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 50, XUserID);               //用户编号          
            
            int Count = -1;
            Count = DB.RunProc("Proc_UsersDelete", Params);
            if (Count > 0)
                return true;
            else return false;
        }
        //删除与某用户相关的所有信息
        //输入：
        //      XUserID - 用户编号；
        //输出：
        //      删除成功：返回True；
        //      删除失败：返回False；
        public bool DeleteAllByProc(string XUserID)
        {
            SqlParameter[] Params = new SqlParameter[1];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 50, XUserID);               //用户编号          

            int Count = -1;
            Count = DB.RunProc("Proc_UsersAllDelete", Params);
            if (Count > 0)
                return true;
            else return false;
        }
        //查询用户
        //查询所用用户
        //不需要参数
        public DataSet QueryUsers()
        {
            DataBase DB = new DataBase();
            string sql = "SELECT [Users].[UserID],[Users].[UserName],[Role].[RoleName]FROM [Users],[Role] WHERE [Users].[RoleId]=[Role].[RoleId] and [Users].[UserID]!='admin'";
            return DB.GetDataSetSql(sql);//DB.GetDataSet("Proc_UsersList");
            
        }
      
        /// 查询用户        
        public static DataTable QueryUsers(Hashtable queryItems)
        {
            string where = SQLString.GetConditionClause(queryItems);
            string sql = "Select * From [Users],[Role] " + where;

            if (where == "")
                sql += " Where";
            else
                sql += " And";

            sql +=" [Users].RoleId=[Role].RoleId";

            DataBase DB = new DataBase();
            return DB.GetDataTable(sql);
        }
        //判断是否已经考试
        public bool IsTest(string UserID, int PaperID)
        {
            SqlParameter[] Params = new SqlParameter[2];

            DataBase DB = new DataBase();
            string strsql = "SELECT * FROM UserAnswertb WHERE UserID=@UserID AND PaperID=@PaperID";
            Params[0] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 20, UserID);
            Params[1] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, PaperID);

            SqlDataReader DR = DB.RunStrGetReader(strsql, Params);
            if (!DR.Read())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //判断是不是管理员在问范围页面
        public bool IsAdmin(string UserID)
        {
            this.LoadData(UserID);
            if (RoleId !=5)
                return true;
            else
                return false;
        }
        #endregion 方法
    }
}