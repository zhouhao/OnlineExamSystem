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
using Examination.BusinessLogicLayer;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

public partial class User_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Page.RegisterStartupScript("",  "<script>location='../default.aspx';</script>");
        }
        else
        {
            if (!IsPostBack)
            {
                InitData();//初始化科目列表框
                //ScoreInitData();  //初始化成绩
                GridView1_InitData();//初始化试卷分析
                GridView1.Visible = false;

            }
        }
    }
    //初始化考试科目下拉列表框
    protected void InitData()
    {
        Paper paper = new Paper();              //创建Paper对象
        string userid = Session["userID"].ToString();
        DataSet ds = paper.QueryExamPaper(userid);        //查询所有可用试卷
        if (ds.Tables[0].Rows.Count >= 1)
        {
            ddlPaper.DataSource = ds;           //指名考试科目列表框数据源
            ddlPaper.DataTextField = "PaperName";   //DataTextField显示Name字段值
            ddlPaper.DataValueField = "PaperID";    //DataValueField显示ID字段值
            ddlPaper.DataBind();                //绑定数据

        }
        else
        {
            ddlPaper.Enabled = false;
            ImgStartExam.Enabled = false;
            lblExamMessage.Text = "没有试卷！";
        }
        Paper pp = new Paper();
        DataSet DS = pp.QueryTestPaper();
        if (DS.Tables[0].Rows.Count >= 1)
        {
            ddlTestPaper.DataSource = DS;           //指名考试科目列表框数据源
            ddlTestPaper.DataTextField = "PaperName";   //DataTextField显示Name字段值
            ddlTestPaper.DataValueField = "PaperID";    //DataValueField显示ID字段值
            ddlTestPaper.DataBind();                //绑定数据

        }
        else
        {
            ddlTestPaper.Enabled = false;
            ImgStartTest.Enabled = false;
            lblTestMessage.Text = "没有试卷！";
        }
    }
    //protected void ScoreInitData()//初始化成绩
    //{
    //    Scores score = new Scores();        //创建Scores对象       
    //    DataSet ds = score.QueryUserScore(Session["userID"].ToString());
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        GridView1.DataSource = ds;          //为GridView控件指名数据源        
    //        GridView1.DataBind();               //绑定数据
    //    }
    //    else
    //    {
    //        lblScore.Text = "没有成绩!";
    //    }
    //}
    //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GridView1.PageIndex = e.NewPageIndex;
    //    ScoreInitData();
    //}
 
    //protected void imgBtnModifyPwd_Click1(object sender, ImageClickEventArgs e)
    //{
    //    Users user = new Users();//创建Users对象user
    //    user.LoadData(Session["userID"].ToString());
    //    string txtOldPwdMd5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtOldPwd.Text.Trim(), "MD5").ToString();
    //    if (user.UserPwd == txtOldPwdMd5)//验证用户输入原密码是否正确
    //    {
    //        string txtNewPwdMD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtNewPwd.Text.Trim(), "MD5").ToString();
    //        user.UserPwd = txtNewPwdMD5;
    //        if (user.ModifyPassword(this.Session["userID"].ToString()))//更改用户密码
    //        {
    //            lblPwd.Text = "成功修改密码!";
    //        }
    //        else//修改密码失败
    //        {
    //            lblPwd.Text = "修改密码失败!";
    //        }
    //    }
    //    else//原密码错误
    //    {
    //        lblPwd.Text = "输入原密码错误,请重新输入!";
    //    }
    //}
    //protected void imgBtnReset_Click(object sender, ImageClickEventArgs e)
    //{
    //    txtOldPwd.Text = txtNewPwd.Text = txtConfirmPwd.Text = "";
    //}
protected void ImgStartExam_Click(object sender, ImageClickEventArgs e)
{
    Users user = new Users();
    //if (user.IsTest(Session["userID"].ToString().Trim(), Convert.ToInt32(ddlPaper.SelectedValue)))
    //{
    //    lblExamMessage.Text = "您已经考试过了,不能再考试！";
    //}
    //else
    //{
        Session["PaperID"] = ddlPaper.SelectedValue;
        Session["PaperName"] = ddlPaper.SelectedItem.Text;
        TempExam te = new TempExam();
        Paper pp = new Paper();
        te.PaperID = Convert.ToInt32(Session["PaperID"]);
        te.UserID = Session["UserID"].ToString();
        pp.GetNeedTime(Convert.ToInt32(Session["PaperID"]));//获取数据库内规定的考试时间

        if (te.CheckExist(te.UserID,te.PaperID))
        {
            te.GetBeginTime(te.UserID,te.PaperID);
            long TimeLeft=pp.needtime- Microsoft.VisualBasic.DateAndTime.DateDiff(DateInterval.Second, te.BeginTime, DateTime.Now, Microsoft.VisualBasic.FirstDayOfWeek.Monday, Microsoft.VisualBasic.FirstWeekOfYear.Jan1);//得到曾经考试的记录时间与当前时间的时间差，以“秒”为单位
            if (TimeLeft > 0)
            {
                Session["time"] = TimeLeft;
            }
            else
            {
                Page.RegisterStartupScript("", "<script>alert('你规定的考试时间过了，该卷成绩将取消！')</script>");
                te.DeleteTempExam(te.UserID, te.PaperID);
                BindData();
                return;
            }
        }
        else
        {
            Session["time"] = pp.needtime;
            te.SetExamBegin(te.UserID, te.PaperID);
        }
        Response.Redirect("UserExam.aspx");    //转向考试界面     
    //}
}
    protected void ImgStartTest_Click(object sender, ImageClickEventArgs e)
    {
        Users user = new Users();        
        Session["PaperID"] = ddlTestPaper.SelectedValue;
        Session["PaperName"] = ddlTestPaper.SelectedItem.Text;           
        Response.Redirect("UserTest.aspx");    //转向考试界面     
       
    }
    public void BindData()
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        int paperid = Convert.ToInt32(Session["PaperID"].ToString());
        string strsql = "insert into UserAnswertb(UserID,PaperID,ExamTime) values('" + Session["userID"].ToString() + "','" + paperid + "','" + DateTime.Now.ToString() + "')";
        SqlConnection mycon = new SqlConnection(ConnectionString);
        SqlCommand mycmd = new SqlCommand(strsql, mycon);
        mycon.Open();
        mycmd.ExecuteNonQuery();
        mycon.Close();
    }
    protected void GridView1_InitData()
    {
        //Paper paper = new Paper();
        //DataSet ds = paper.QueryUserPaperList1(Session["UserID"].ToString());
        Scores score = new Scores();        //创建Scores对象       
        DataSet ds = score.QueryUserScore(Session["UserID"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
            LabelPageInfo.Text = "当前（第" + (GridView1.PageIndex + 1).ToString() + "页 共" + GridView1.PageCount.ToString() + "页）";
        }
        else
        {
            lblScore.Text = "没有成绩!";
            LabelPageInfo.Text = "";
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1_InitData();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[6].ToolTip = e.Row.Cells[6].Text;
            if ((e.Row.Cells[6].Text).Length > 20)
            {
                e.Row.Cells[6].Text = (e.Row.Cells[6].Text).Substring(0, 20) + "...";
            }
        }

        //首先判断是否是数据行
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //当鼠标停留时更改背景色
            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='Aqua'");
            //当鼠标移开时还原背景色
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
        }

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string UserID = GridView1.DataKeys[e.RowIndex].Values[0].ToString(); //取出要删除记录的主键值1
        int PaperID = int.Parse(GridView1.DataKeys[e.RowIndex].Values[1].ToString().Trim());//取出要删除记录的主键值2
        Paper paper = new Paper();
        if (paper.DeleteByProc(UserID, PaperID))
        {
            Page.RegisterStartupScript("", "<script language=javascript>alert('成功删除！')</script>");
        }
        else
        {
            Page.RegisterStartupScript("", "<script language=javascript>alert('删除失败！')</script>");
        }
        GridView1_InitData();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (GridView1.Visible == false)
            GridView1.Visible = true;
        else
            GridView1.Visible = false;
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Session["keyWord"] = tbKeyWord.Text.Trim();
        Response.Redirect("search.aspx");
    }
}
