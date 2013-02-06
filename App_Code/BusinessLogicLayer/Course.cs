using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Examination.DataAccessLayer;
using Examination.DataAccessHelper;


namespace Examination.BusinessLogicLayer
{
    //试卷科目类
    public class Course
    {
        #region 私有成员
        private int _ID;                                               //题目编号            
        private string _Name;                                         //题目        

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
        public string Name
        {
            set
            {
                this._Name = value;
            }
            get
            {
                return this._Name;
            }
        }
        
        #endregion 属性

        #region 方法
        
        //向Course表中添加试卷科目信息
        //输出：
        //      插入成功：返回True；
        //      插入失败：返回False；
        public bool InsertByProc()
        {
            SqlParameter[] Params = new SqlParameter[1];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@Name", SqlDbType.VarChar, 50, Name);               //试卷科目名称           

            int Count = -1;
            Count = DB.RunProc("Proc_CourseAdd", Params);
            if (Count > 0)
                return true;
            else return false;
        }

        //更新科目的信息
        public bool UpdateByProc(int CID)
        {
            SqlParameter[] Params = new SqlParameter[2];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@ID", SqlDbType.Int, 4, CID);               //用户编号            
            Params[1] = DB.MakeInParam("@Name", SqlDbType.VarChar, 200, Name);      //用户权限           

            int Count = -1;
            Count = DB.RunProc("Proc_CourseModify", Params);
            if (Count > 0)
                return true;
            else return false;
        }
        
        //删除科目
        //输入：
        //      CID - 科目编号；
        //输出：
        //      删除成功：返回True；
        //      删除失败：返回False；
        public bool DeleteByProc(int CID)
        {
            SqlParameter[] Params = new SqlParameter[1];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@ID", SqlDbType.Int,4, CID);               //科目编号          
            
            int Count = -1;
            Count = DB.RunProc("Proc_CourseDelete", Params);
            if (Count > 0)
                return true;
            else return false;
        }
        
        //查询所用试卷科目
        //不需要参数
        public DataSet QueryCourse()
        {
            DataBase DB = new DataBase();           
            return DB.GetDataSet("Proc_CourseList");
        }
        /// <summary>
        /// 检测课程名是否已经存在
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool IsCourseNameExist(string Name)
        {
            SqlParameter[] Params = new SqlParameter[1];

            DataBase DB = new DataBase();
            string strsql = "SELECT * FROM Course WHERE Name=@Name";
            Params[0] = DB.MakeInParam("@Name", SqlDbType.VarChar, 200, Name);

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