using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Examination.DataAccessLayer;
using Examination.DataAccessHelper;


namespace Examination.BusinessLogicLayer
{
    //用户类
    public class TempExam
    {
        #region 私有成员
        private int _paperID;                                               //试卷编号
        private string _userid;
        private DateTime _BeginTime;

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
        public DateTime BeginTime
        {
            set
            {
                this._BeginTime = value;
            }
            get
            {
                return this._BeginTime;
            }
        }
        #endregion 属性

        #region 方法

        /// <summary>
        /// 考生第一次考某卷时要向TempExam插入一些必要的信息
        /// </summary>
        /// <returns></returns>
        public bool SetExamBegin(string UserID, int PaperID)
        {
            SqlParameter[] Params = new SqlParameter[3];
            DataBase DB = new DataBase();
           // string strsql = "INSERT INTO TempExam (UserID, PaperID,BeginTime) VALUES ( @UserID,@PaperID,@BeginTime)";
            Params[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, PaperID);
            Params[1] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 20, UserID);
            Params[2] = DB.MakeInParam("@BeginTime", SqlDbType.DateTime, 8, DateTime.Now);

            int Count = -1;
            //Count = DB.ProcStr(strsql, Params);
            Count = DB.RunProc("Proc_TempExamAdd", Params);
            if (Count > 0)
                return true;
            else 
                return false;
        }
        public bool CheckExist(string UserID, int PaperID)
        {
            SqlParameter[] Params = new SqlParameter[2];
            DataBase DB = new DataBase();
            string strsql = " SELECT * FROM TempExam WHERE UserID =@UserID and PaperID= @PaperID";
            Params[0] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 20, UserID);
            Params[1] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, PaperID);

            SqlDataReader DR = DB.RunStrGetReader(strsql, Params);
            if (!DR.HasRows)//DR.Read())
            {
                
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool GetBeginTime(string UserID, int PaperID)
        {
            SqlParameter[] Params = new SqlParameter[2];

            DataBase DB = new DataBase();
            string strsql = "SELECT BeginTime FROM TempExam WHERE PaperID=@PaperID and UserID=@UserID";
            Params[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, PaperID);
            Params[1] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 20, UserID);

            SqlDataReader DR = DB.RunStrGetReader(strsql, Params);
            if (!DR.Read())
            {
                return false;
            }
            else
            {
                this.BeginTime = (DateTime)DR[0];//获取考试开始的时间
                return true;
            }
        }
        public bool DeleteTempExam(string UserID, int PaperID)
        {
            SqlParameter[] Params = new SqlParameter[2];
            DataBase DB = new DataBase();
            string strsql = " delete FROM TempExam WHERE UserID =@UserID and PaperID= @PaperID";
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
       
        
        #endregion 方法
    }
}