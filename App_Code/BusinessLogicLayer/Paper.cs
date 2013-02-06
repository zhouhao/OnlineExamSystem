using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Examination.DataAccessLayer;
using Examination.DataAccessHelper;


namespace Examination.BusinessLogicLayer
{
    //用户类
    public class Paper
    {
        #region 私有成员
        private int _paperID;                                               //试卷编号
        private int _courseID;                                              //科目编号 
        private string _paperName;                                          //试卷名称  
        private byte _paperState;                                           //试卷状态
        private string _type;
        private string _userid;
        private string _state;
        private int _needtime;

        #endregion 私有成员

        #region 属性
      
        public int PaperID
        {
            set
            {
                this._paperID = value;
            }
            get
            {
                return this._paperID;
            }
        }
        public int CourseID
        {
            set
            {
                this._courseID = value;
            }
            get
            {
                return this._courseID;
            }
        }
        public string PaperName
        {
            set
            {
                this._paperName = value;
            }
            get
            {
                return this._paperName;
            }
        }        
        public byte PaperState
        {
            set
            {
                this._paperState = value;
            }
            get
            {
                return this._paperState;
            }
        }
        public string Type
        {
            set
            {
                this._type = value;
            }
            get
            {
                return this._type;
            }
        }
        public string UserID
        {
            set
            {
                this._userid = value;
            }
            get
            {
                return this._userid;
            }
        }
        public string state
        {
            set
            {
                this._state = value;
            }
            get
            {
                return this._state;
            }
        }
        public int needtime
        {
            set
            {
                this._needtime = value;
            }
            get
            {
                return this._needtime;
            }
        }
        #endregion 属性

        #region 方法

        //向Paper表中添加试卷信息(采用存储过程)
        //输出：
        //      插入成功：返回True；
        //      插入失败：返回False；
        public bool InsertByProc()
        {
            SqlParameter[] Params = new SqlParameter[3];
            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@CourseID", SqlDbType.Int, 4, CourseID);               //科目编号
            Params[1] = DB.MakeInParam("@PaperName", SqlDbType.VarChar, 200, PaperName);       //试卷名称            
            Params[2] = DB.MakeInParam("@PaperState", SqlDbType.Bit,1, PaperState);            //试卷状态            

            int Count = -1;
            Count = DB.RunProc("Proc_PaperAdd", Params);
            if (Count > 0)
                return true;
            else return false;
        }
        //我是周浩----我是周浩
        //更新试卷是否评阅的状态
        public bool UpdateByProc(string XUserID, int XPaperID, string Xstate)
        {
            SqlParameter[] Params = new SqlParameter[3];

            DataBase DB = new DataBase();
            string strsql = "UPDATE UserAnswertb SET state= @state WHERE UserID = @UserID and PaperID= @PaperID";
            Params[0] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 50, XUserID);
            Params[1] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, XPaperID);
            Params[2] = DB.MakeInParam("@state", SqlDbType.VarChar, 50, Xstate);

            int Count = -1;
            Count = DB.ProcStr(strsql, Params);
            if (Count > 0)
                return true;
            else return false;
        }
        //更新试卷信息
        public bool UpdateByProc(int PID)
        {
            SqlParameter[] Params = new SqlParameter[2];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, PID);                      //试卷编号                       
            Params[1] = DB.MakeInParam("@PaperState", SqlDbType.Bit, 1, PaperState);            //试卷状态

            int Count = -1;
            Count = DB.RunProc("Proc_PaperModify", Params);
            if (Count > 0)
                return true;
            else return false;
        }
       

        //删除题目
        //输入：
        //      TID - 题目编号；
        //输出：
        //      删除成功：返回True；
        //      删除失败：返回False；
        public bool DeleteByProc(int PID)
        {
            SqlParameter[] Params = new SqlParameter[1];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@ID", SqlDbType.Int, 4, PID);               //题目编号          

            int Count = -1;
            Count = DB.RunProc("Proc_PaperDelete", Params);
            if (Count > 0)
                return true;
            else return false;
        }
        //删除指定PID试卷的所有在数据库的信息
        //输入：
        //      TID - 题目编号；
        //输出：
        //      删除成功：返回True；
        //      删除失败：返回False；
        public bool DeleteAllByProc(int PID)
        {
            SqlParameter[] Params = new SqlParameter[1];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@ID", SqlDbType.Int, 4, PID);               //题目编号          

            int Count = -1;
            Count = DB.RunProc("Proc_PaperAllDelete", Params);
            if (Count > 0)
                return true;
            else return false;
        }
        //     删除某位用户的试卷
        public bool DeleteByProc(string userid,int paperid)
        {
            SqlParameter[] Params = new SqlParameter[2];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 50, userid);               //用户ＩＤ          
            Params[1] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperid);               //试卷ＩＤ 

            int Count = -1;
            Count = DB.RunProc("Proc_UserPaperDelete", Params);
            if (Count > 0)
                return true;
            else return false;
        }
     
        //查询所用试卷
        //不需要参数
        public DataSet QueryAllPaper()
        {
            DataBase DB = new DataBase();
            return DB.GetDataSet("Proc_PaperList");
        }

        //查询所用指定用户未考过并且可用的试卷
        //需要参数
        public DataSet QueryExamPaper(string userid)
        {
            DataBase DB = new DataBase();
            string SqlStr = string.Format("SELECT [Paper].[PaperID],[Paper].[PaperName] FROM [Paper] where PaperState=1 and NeedTime!=0 and PaperID not in(SELECT PaperID FROM UserAnswertb WHERE UserID='{0}')",userid);
            return DB.GetDataSetSql(SqlStr);
        }
        public DataSet QueryTestPaper()
        {
            DataBase DB = new DataBase();
            string SqlStr = string.Format("SELECT [Paper].[PaperID],[Paper].[PaperName] FROM [Paper] where PaperState=1 and NeedTime =0");// and PaperID not in(SELECT PaperID FROM UserAnswertb WHERE UserID='{0}')", userid);
            return DB.GetDataSetSql(SqlStr);
        }
        //查询所用可用试卷
        //不需要参数
        public DataSet QueryPaper()
        {
            DataBase DB = new DataBase();
            SqlParameter[] Params = new SqlParameter[1];
            Params[0] = DB.MakeInParam("@PaperState", SqlDbType.Bit, 1, "true");               //题目编号   
            return DB.GetDataSet("Proc_PaperUseList", Params);
        }
        //查询所有用户试卷的试卷
        public DataSet QueryUserPaperList()
        {
            DataBase DB = new DataBase();
            return DB.GetDataSet("Proc_UserPaperList");
            //return DB.GetDataSetSql("SELECT distinct [dbo].[Users].[UserID],[dbo].[Users].[UserName],[dbo].[UserAnswertb].[UserID],	[dbo].[UserAnswertb].[PaperID],[dbo].[UserAnswertb].[ExamTime],[dbo].[UserAnswertb].[state],[dbo].[Paper].[PaperName] FROM [dbo].[Users],[dbo].[UserAnswertb],[dbo].[Paper] where Users.UserID=UserAnswertb.UserID and UserAnswertb.PaperID=Paper.PaperID and Paper.NeedTime!=0 ");
        }
        //从考生答题的数据库中读取成绩列表！
        public DataSet QueryUserPaperList1(string UID)
        {
            DataBase DB = new DataBase();
            //return DB.GetDataSet("Proc_UserPaperList");
            string SqlStr = string.Format("SELECT distinct [dbo].[Users].[UserID],[dbo].[Users].[UserName],[dbo].[UserAnswertb].[UserID],	[dbo].[UserAnswertb].[PaperID],[dbo].[UserAnswertb].[ExamTime],[dbo].[UserAnswertb].[state],[dbo].[Paper].[PaperName] FROM [dbo].[Users],[dbo].[UserAnswertb],[dbo].[Paper] where Users.UserID=UserAnswertb.UserID and UserAnswertb.PaperID=Paper.PaperID and Paper.NeedTime!=0 and UserAnswertb.UserID='{0}'", UID);
            return DB.GetDataSetSql(SqlStr);
        }
        //从评审后的成绩数据库中读取成绩列表！
        public DataSet QueryUserPaperList2(string UID)
        {
            DataBase DB = new DataBase();
            //return DB.GetDataSet("Proc_UserPaperList");
            string SqlStr = string.Format("SELECT distinct [dbo].[Users].[UserID],[dbo].[Users].[UserName],[dbo].[UserAnswertb].[UserID],	[dbo].[UserAnswertb].[PaperID],[dbo].[UserAnswertb].[ExamTime],[dbo].[UserAnswertb].[state],[dbo].[Paper].[PaperName] FROM [dbo].[Users],[dbo].[UserAnswertb],[dbo].[Paper] where Users.UserID=UserAnswertb.UserID and UserAnswertb.PaperID=Paper.PaperID and Paper.NeedTime!=0 and UserAnswertb.UserID='{0}'", UID);
            return DB.GetDataSetSql(SqlStr);
        }
        /// <summary>
        /// 获取考试需要的时间
        /// </summary>
        /// <param name="PaperID"></param>
        /// <returns></returns>
        public bool GetNeedTime(int PaperID)
        {
            SqlParameter[] Params = new SqlParameter[1];

            DataBase DB = new DataBase();
            string strsql = "SELECT NeedTime FROM paper WHERE PaperID=@PaperID";
            Params[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, PaperID);

            SqlDataReader DR = DB.RunStrGetReader(strsql, Params);
            if (!DR.Read())
            {
                return false;
            }
            else
            {
                this.needtime = (int)DR[0];//获取考试需要的时间
                return  true;
                 
            }
        }
        /// <summary>
        /// 检测试卷名是否已经存在
        /// </summary>
        /// <param name="PaperID"></param>
        /// <returns></returns>
        public bool IsPaperNameExist(string PaperName)
        {
            SqlParameter[] Params = new SqlParameter[1];

            DataBase DB = new DataBase();
            string strsql = "SELECT * FROM paper WHERE PaperName=@PaperName";
            Params[0] = DB.MakeInParam("@PaperName", SqlDbType.VarChar, 200, PaperName);

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
        
       

        #endregion 方法
    }
}