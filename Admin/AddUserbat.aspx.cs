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

public partial class Admin_AddUserbat : System.Web.UI.Page
{
    string strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Page.RegisterStartupScript("",  "<script>location='../default.aspx';</script>");
        }
        if (Convert.ToInt32(Session["roleID"]) == 5)
        {
            Page.RegisterStartupScript("", "<script>alert('你登录的用户权限不够！');location='default.aspx'</script>");
        }

        else
        {
            SqlConnection cn = new SqlConnection(strConn);
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Users", cn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Users");
            this.GridView1.DataSource = ds.Tables["Users"];
            this.GridView1.DataKeyNames = new string[] { "UserID" };
            this.GridView1.DataBind();
        }

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
        OleDbDataAdapter odda = new OleDbDataAdapter("select * from [Sheet1$]", conn);
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
                string UserID = dr[i]["学号"].ToString();//学号 excel列名【名称不能变,否则就会出错】
                string UserName = UserID;
                string UserPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(dr[i]["密码"].ToString().Trim(), "MD5"); 
                int roleid = 5;//5代表是学生，1代表是管理员
                string sqlcheck = "select count(*) from Users where UserID='" + UserID + "'";  //检查用户是否存在
                SqlCommand sqlcmd = new SqlCommand(sqlcheck, cn);
                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                if (count < 1)
                {
                    string insertstr = "insert into Users (UserID,UserName,UserPwd,RoleId) values('" + UserID + "','" + UserName + "','" + UserPwd + "','" + roleid + "')";

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
                    Page.RegisterStartupScript("", "<script>alert('内容重复！禁止导入');location='default.aspx'</script></script> ");
                    continue;
                }
            }
            Page.RegisterStartupScript("", "<script>alert('Excle表导入成功!');location='default.aspx'</script>");
        }

        cn.Close();

    }
}
