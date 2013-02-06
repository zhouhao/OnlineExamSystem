using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.OleDb;

public partial class Admin_Excel2Data : System.Web.UI.Page
{
    string strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["userID"] == null)
        //{
        //    Page.RegisterStartupScript("", "<script>location='../default.aspx';</script>");
        //}
        //if (Convert.ToInt32(Session["roleID"]) == 5)
        //{
        //    Page.RegisterStartupScript("", "<script>alert('你登录的用户权限不够！');location='default.aspx'</script>");
        //}

        //else
        //{
        //    //SqlConnection cn = new SqlConnection(strConn);
        //    //cn.Open();
        //    //SqlDataAdapter sda = new SqlDataAdapter("select * from Users", cn);
        //    //DataSet ds = new DataSet();
        //    //sda.Fill(ds, "Users");
        //    //this.GridView1.DataSource = ds.Tables["Users"];
        //    //this.GridView1.DataKeyNames = new string[] { "UserID" };
        //    //this.GridView1.DataBind();
        //}

    }
    /// <summary>
    /// 查询EXCEL电子表格添加到DATASET
    /// </summary>
    /// <param name="filenameurl">服务器路径</param>
    /// <param name="table">表名</param>
    /// 


    public DataSet ExecleDs(string filenameurl, string table)
    {
        string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + filenameurl + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
        OleDbConnection conn = new OleDbConnection(strConn);
        conn.Open();
        DataSet ds = new DataSet();
        string sql = "";
        switch (ddlProblemClass.SelectedValue)
        {
            case "单选题": sql = "select 原题内容,选择A,选择B,选择C,选择D,答案 from [单选$]"; break;
            case "多选题": sql = "select 原题内容,选择A,选择B,选择C,选择D,答案 from [多选$]"; break;
            case "判断题": sql = "select 原题内容,答案 from [判断$]"; break;
        }
        OleDbDataAdapter odda = new OleDbDataAdapter(sql, conn);
        odda.Fill(ds, table);
        return ds;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile == false)//HasFile用来检查FileUpload是否有指定文件
        {
            Page.RegisterStartupScript("", "<script>alert('请您选择Excel文件')</script> ");
            return;//当无文件时,返回
        }
        string IsXls = System.IO.Path.GetExtension(FileUpload1.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名
        if (IsXls != ".xls")
        {
            Page.RegisterStartupScript("", "<script>alert('只可以选择Excel文件')</script>");
            return;//当选择的不是Excel文件时,返回
        }
        SqlConnection cn = new SqlConnection(strConn);
        cn.Open();
        string filename = DateTime.Now.ToString("yyyymmddhhMM") + FileUpload1.FileName;              //获取Execle文件名  DateTime日期函数
        string savePath = Server.MapPath(("~\\upfiles\\") + filename);//Server.MapPath 获得虚拟服务器相对路径
        FileUpload1.SaveAs(savePath);                        //SaveAs 将上传的文件内容保存在服务器上
        
        DataSet ds = ExecleDs(savePath, filename);           //调用自定义方法

        DataRow[] dr = ds.Tables[0].Select();            //定义一个DataRow数组
        int rowsnum = ds.Tables[0].Rows.Count;
        if (rowsnum == 0)
        {
            Page.RegisterStartupScript("", "<script>alert('Excel表为空表,无数据!')</script>");   //当Excel表为空时,对用户进行提示
        }
        else
        {
            for (int i = 0; i < dr.Length; i++)
            {
                string title = dr[i]["原题内容"].ToString();//学号 excel列名【名称不能变,否则就会出错】
                string answerA = "";
                string answerB = "";
                string answerC = "";
                string answerD = "";
                if (ddlProblemClass.SelectedValue != "判断题")
                {
                    answerA = dr[i]["选择A"].ToString();
                    answerB = dr[i]["选择B"].ToString();
                    answerC = dr[i]["选择C"].ToString();
                    answerD = dr[i]["选择D"].ToString();
                }
                string answer = dr[i]["答案"].ToString();
                string sqlcheck = "";
                string insertstr = "";
                switch (ddlProblemClass.SelectedValue)
                {
                    case "判断题": sqlcheck = "select count(*) from JudgeProblem where Title='" + title + "'";
                                   insertstr = "insert into JudgeProblem (CourseID,Title,Answer,DiffID) values('" + ddlProblemCourse.SelectedValue+ "','" + title + "','" + answer + "','" + 1 + "')";
                                   break;
                    case "单选题": sqlcheck = "select count(*) from SingleProblem where Title='" + title + "'";
                                   insertstr = "insert into SingleProblem (CourseID,Title,AnswerA,AnswerB,AnswerC,AnswerD,Answer,DiffID) values('" + ddlProblemCourse.SelectedValue + "','" + title + "','" + answerA + "','" + answerB + "','" + answerC + "','" + answerD + "','" + answer + "','" + 1 + "')";
                                   break;
                    case "多选题": sqlcheck = "select count(*) from MultiProblem where Title='" + title + "'";
                                   insertstr = "insert into MultiProblem (CourseID,Title,AnswerA,AnswerB,AnswerC,AnswerD,Answer,DiffID) values('" + ddlProblemCourse.SelectedValue + "','" + title + "','" + answerA + "','" + answerB + "','" + answerC + "','" + answerD + "','" + answer + "','" + 1 + "')";
                                   break;
                }
                //string sqlcheck = "select count(*) from JudgeProblem where Title='" + UserID + "'";  //检查用户是否存在
                SqlCommand sqlcmd = new SqlCommand(sqlcheck, cn);
                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                if (count < 1)
                {
                    //string insertstr = "insert into JudgeProblem (CourseID,Title,Answer,DiffID) values('" + 1 + "','" + UserID + "','" + UserPwd + "','" + 1 + "')";

                    SqlCommand cmd = new SqlCommand(insertstr, cn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (MembershipCreateUserException ex)       //捕捉异常
                    {
                        Page.RegisterStartupScript("", "<script>alert('导入内容:" + ex.Message + "')</script>");
                    }
                }
                else
                {
                    Page.RegisterStartupScript("", "<script>alert('内容重复！禁止导入');</script></script> ");
                    continue;
                }
            }
            Page.RegisterStartupScript("", "<script>alert('Excle表导入成功!');</script>");
            this.GridView1.DataSource = ds.Tables[0];        
            this.GridView1.DataBind();
        }

        cn.Close();

    }
}