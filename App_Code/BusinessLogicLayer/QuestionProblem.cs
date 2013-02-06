using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Examination.DataAccessLayer;
using Examination.DataAccessHelper;

namespace Examination.BusinessLogicLayer
{
    //问答题
	public class QuestionProblem
	{
        #region 私有成员
        private int _ID;                                               //题目编号
        private int _CourseID;                                         //所属科目        
        private string _Title;                                         //题目  
        private int _DiffID;                                    //难度系数
        private string _Answer;                                       //答案

        #endregion 私有成员

        #region 属性

        public int ID
        {
            set
            {
                this._ID = value;
            }
            get
            {
                return this._ID;
            }
        }
        public int CourseID
        {
            set
            {
                this._CourseID = value;
            }
            get
            {
                return this._CourseID;
            }
        }
        public int DiffID
        {
            set
            {
                this._DiffID = value;
            }
            get
            {
                return this._DiffID;
            }
        }

        public string Title
        {
            set
            {
                this._Title = value;
            }
            get
            {
                return this._Title;
            }
        }
        public string Answer
        {
            set
            {
                this._Answer = value;
            }
            get
            {
                return this._Answer;
            }
        }
        #endregion 属性

         #region 方法

        //根据题目ID 初始化题目
        //输入：
        //      TID - 题目编号；
        //输出：
        //      题目存在：返回True；
        //      题目不在：返回False；
        public bool LoadData(int TID)
        {
            SqlParameter[] Params = new SqlParameter[1];
            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@ID", SqlDbType.Int, 4, TID);                  //用户编号            

            DataSet ds = DB.GetDataSet("Proc_QuestionProblemDetail", Params);
            ds.CaseSensitive = false;
            DataRow DR;
            if (ds.Tables[0].Rows.Count > 0)
            {
                DR = ds.Tables[0].Rows[0];
                this._CourseID = GetSafeData.ValidateDataRow_N(DR, "CourseID");                   //科目编号                
                this._Title = GetSafeData.ValidateDataRow_S(DR, "Title");                         //题目 
                this._Answer = GetSafeData.ValidateDataRow_S(DR, "Answer");                     //答案                
                this._DiffID = GetSafeData.ValidateDataRow_N(DR, "DiffID");            //难度系数            
                return true;
            }
            else
            {
                return false;
            }
        }


        //向SingleProblem表中添加题目信息(采用存储过程)
        //输出：
        //      插入成功：返回True；
        //      插入失败：返回False；
        public bool InsertByProc()
        {
            SqlParameter[] Params = new SqlParameter[4];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@CourseID", SqlDbType.Int, 4, CourseID);                 //科目编号
            Params[1] = DB.MakeInParam("@Title", SqlDbType.VarChar, 1000, Title);                //题目 
            Params[2] = DB.MakeInParam("@DiffID", SqlDbType.Int, 4, DiffID);      //难度系数                   
            Params[3] = DB.MakeInParam("@Answer", SqlDbType.VarChar, 1000, Answer);                      //答案A            
            int Count = -1;
            Count = DB.RunProc("Proc_QuestionProblemAdd", Params);
            if (Count > 0)
                return true;
            else return false;
        }

        //更新判断题的信息
        public bool UpdateByProc(int TID)
        {
            SqlParameter[] Params = new SqlParameter[5];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@ID", SqlDbType.Int, 4, TID);                           //题目编号
            Params[1] = DB.MakeInParam("@CourseID", SqlDbType.Int, 4, CourseID);                //科目编号
            Params[2] = DB.MakeInParam("@Title", SqlDbType.VarChar, 1000, Title);               //题目  
            Params[3] = DB.MakeInParam("@DiffID", SqlDbType.Int, 4, DiffID);      //难度系数                  
            Params[4] = DB.MakeInParam("@Answer", SqlDbType.VarChar, 1000, Answer);                      //答案A            
            
            int Count = -1;
            Count = DB.RunProc("Proc_QuestionProblemModify", Params);
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
        public bool DeleteByProc(int TID)
        {
            SqlParameter[] Params = new SqlParameter[1];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@ID", SqlDbType.Int, 4, TID);               //题目编号          

            int Count = -1;
            Count = DB.RunProc("Proc_QuestionProblemDelete", Params);
            if (Count > 0)
                return true;
            else return false;
        }

        //查询问答题
        //课程编号
        public DataSet QueryQuestionProblem(int TCourseID)
        {
            SqlParameter[] Params = new SqlParameter[1];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@CourseID", SqlDbType.Int, 4, TCourseID);               //题目编号           
            return DB.GetDataSet("Proc_QuestionProblemList", Params);
        }
        public bool isReduplicated(string title)
        {
            SqlParameter[] Params = new SqlParameter[1];
            DataBase DB = new DataBase();
            Params[0] = DB.MakeInParam("@Title", SqlDbType.VarChar, 1000, title);               //题目            
            if (DB.GetRecordCount("select count(*) from QuestionProblem where Title='" + title + "' ") != 0)
                return true;
            else
                return false;
        }
        #endregion 方法
    }
}
