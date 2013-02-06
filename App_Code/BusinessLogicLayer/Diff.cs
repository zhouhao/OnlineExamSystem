using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Examination.DataAccessLayer;
using Examination.DataAccessHelper;

/// <summary>
/// Diff 的摘要说明
/// </summary>

namespace Examination.BusinessLogicLayer
{
    public class Diff
    {
        #region 私有成员
        private int _ID;                                               //题目编号            
        private string _DiffName;                                         //题目        

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
        public string DiffName
        {
            set
            {
                this._DiffName = value;
            }
            get
            {
                return this._DiffName;
            }
        }

        #endregion 属性

        #region 方法

        //向Diff表中添加试卷科目信息
        //输出：
        //      插入成功：返回True；
        //      插入失败：返回False；
        public bool InsertByProc()
        {
            SqlParameter[] Params = new SqlParameter[1];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@DiffName", SqlDbType.VarChar, 50, DiffName);               //试卷科目名称           

            int Count = -1;
            Count = DB.RunProc("Proc_DiffAdd", Params);
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
            Params[1] = DB.MakeInParam("@DiffName", SqlDbType.VarChar, 200, DiffName);      //用户权限           

            int Count = -1;
            Count = DB.RunProc("Proc_DiffModify", Params);
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

            Params[0] = DB.MakeInParam("@ID", SqlDbType.Int, 4, CID);               //科目编号          

            int Count = -1;
            Count = DB.RunProc("Proc_DiffDelete", Params);
            if (Count > 0)
                return true;
            else return false;
        }

        //查询所用试卷科目
        //不需要参数
        public DataSet QueryDiff()
        {
            DataBase DB = new DataBase();
            return DB.GetDataSet("Proc_DiffList");
        }

        #endregion 方法
    }
}