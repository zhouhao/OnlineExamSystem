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
using Examination.DataAccessLayer;
using System.Data.SqlClient;

public partial class Admin_PaperSetup : System.Web.UI.Page
{
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
            if (!IsPostBack)
            {
                if (Session["userID"].ToString() != null)
                {
                    InitData();  //初始化试卷科目 
                    InitDDLDiffData();//初始化试卷难度
                }
                else
                    Response.Redirect("login.aspx");
            }
        }
    }
    //初始化试卷科目
    protected void InitData()
    {
        Course course = new Course();       //创建试卷科目对象
        DataSet ds = course.QueryCourse();  //查询试卷科目信息
        ddlCourse.DataSource = ds;          //指名试卷科目列表框数据源
        ddlCourse.DataTextField = "Name";   //DataTextField显示Name字段值
        ddlCourse.DataValueField = "ID";    //DataValueField显示ID字段值
        ddlCourse.DataBind();               //绑定数据
    }

    //初始化试卷难度
    protected void InitDDLDiffData()
    {
        Diff diff = new Diff();       //创建试卷难度对象
        DataSet ds = diff.QueryDiff();  //查询试卷难度信息
        ddlDiff.DataSource = ds;          //指名试卷难度列表框数据源
        ddlDiff.DataTextField = "DiffName";   //DataTextField显示Name字段值
        ddlDiff.DataValueField = "ID";    //DataValueField显示ID字段值
        ddlDiff.DataBind();               //绑定数据
    }

    //根据设置自动生成试卷
    protected void imgBtnConfirm_Click(object sender, ImageClickEventArgs e)
    {
        int res = 0;
        if (txtSingleFen != null && txtSingleFen.Text != "" && txtSingleNum != null && txtSingleFen.Text != "")
        {
            res = res + int.Parse(txtSingleNum.Text) * int.Parse(txtSingleFen.Text);
        }
        if (txtMultiNum != null && txtMultiFen.Text != "" && txtMultiNum != null && txtMultiFen.Text != "")
        {
            res = res + int.Parse(txtMultiNum.Text) * int.Parse(txtMultiFen.Text);
        }
        if (txtJudgeFen != null && txtJudgeFen.Text != "" && txtJudgeNum != null && txtJudgeFen.Text != "")
        {
            res = res + int.Parse(txtJudgeNum.Text) * int.Parse(txtJudgeFen.Text);
        }
        if (txtFillFen != null && txtFillFen.Text != "" && txtFillNum != null && txtFillFen.Text != "")
        {
            res = res + int.Parse(txtFillNum.Text) * int.Parse(txtFillFen.Text);
        }
        if (txtQuestionFen != null && txtQuestionFen.Text != "" && txtSingleNum != null && txtQuestionFen.Text != "")
        {
            res = res + int.Parse(txtQuestionNum.Text) * int.Parse(txtQuestionFen.Text);
        }
       


        lblres.Text = "总分为:" + res.ToString() + "分";

        Panel1.Visible = true;
        int course = int.Parse(ddlCourse.SelectedValue);//选择科目
        int diff = int.Parse(ddlDiff.SelectedValue); //选择的难度

        DataBase db = new DataBase();//创建DataBase类对象
        string GridView1Str = "select top " + int.Parse(txtSingleNum.Text.Trim()) + " * from SingleProblem where courseId=" + course + " and diffid >= " + (diff-2) + " and diffid <= " + (diff+2) + " order by newid()";//根据参数设置查询单选题Sql语句
        DataSet ds1 = db.GetDataSetSql(GridView1Str);//调用DataBase类方法GetDataSetSql方法查询数据
        GridView11.DataSource = ds1.Tables[0].DefaultView;//为单选题GridView控件指名数据源
        GridView11.DataBind();//绑定数据
        string GridView2Str = "select top " + int.Parse(txtMultiNum.Text.Trim()) + " * from MultiProblem where courseId=" + course + " and diffid >= " + (diff - 2) + " and diffid <= " + (diff + 2) + " order by newid()";//根据参数设置查询多选题Sql语句
        DataSet ds2 = db.GetDataSetSql(GridView2Str);//调用DataBase类方法GetDataSetSql方法查询数据
        GridView2.DataSource = ds2.Tables[0].DefaultView;//为多选题GridView控件指名数据源
        GridView2.DataBind();//绑定数据
        string GridView3Str = "select top " + int.Parse(txtJudgeNum.Text.Trim()) + " * from JudgeProblem where courseId=" + course + " and diffid >= " + (diff - 2) + " and diffid <= " + (diff + 2) + " order by newid()";//根据参数设置查询判断题Sql语句
        DataSet ds3 = db.GetDataSetSql(GridView3Str);//调用DataBase类方法GetDataSetSql方法查询数据
        GridView3.DataSource = ds3.Tables[0].DefaultView;//为判断题GridView控件指名数据源
        GridView3.DataBind();//绑定数据
        string GridView4Str = "select top " + int.Parse(txtFillNum.Text.Trim()) + " * from FillBlankProblem where courseId=" + course + " and diffid >= " + (diff - 2) + " and diffid <= " + (diff + 2) + " order by newid()";//根据参数设置查询填空题Sql语句
        DataSet ds4 = db.GetDataSetSql(GridView4Str);//调用DataBase类方法GetDataSetSql方法查询数据
        GridView4.DataSource = ds4.Tables[0].DefaultView;//为填空题GridView控件指名数据源
        GridView4.DataBind();//绑定数据
        string GridView5Str = "select top " + int.Parse(txtQuestionNum.Text.Trim()) + " * from QuestionProblem where courseId=" + course + " and diffid >= " + (diff - 2) + " and diffid <= " + (diff + 2) + " order by newid()";//根据参数设置查询填空题Sql语句
        DataSet ds5 = db.GetDataSetSql(GridView5Str);//调用DataBase类方法GetDataSetSql方法查询数据
        GridView5.DataSource = ds5.Tables[0].DefaultView;//为填空题GridView控件指名数据源
        GridView5.DataBind();//绑定数据
        
        
    }
    //将生成试卷保存到数据库
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        DataBase db = new DataBase();
        string insertpaper = "insert into Paper(CourseID,PaperName,PaperState,NeedTime) values(" + int.Parse(ddlCourse.SelectedValue) + ",'" + txtPaperName.Text + "',0," +int.Parse(ddlNeedTime.SelectedValue)*60+ ") SELECT @@IDENTITY as id";

        int afterID = GetIDInsert(insertpaper);//保存试卷，并返回自动生成的试卷编号
        if (afterID > 0)
        {
            foreach (GridViewRow dr in GridView11.Rows)//保存试卷单选题信息
            {
                string single = "insert into PaperDetail(PaperID,Type,TitleID,Mark) values(" + afterID + ",'单选题'," + int.Parse(((Label)dr.FindControl("Label3")).Text) + "," + int.Parse(txtSingleFen.Text) + ")";
                db.Insert(single);
            }
            foreach (GridViewRow dr in GridView2.Rows)//保存试卷多选题信息
            {
                string multi = "insert into PaperDetail(PaperID,Type,TitleID,Mark) values(" + afterID + ",'多选题'," + int.Parse(((Label)dr.FindControl("Label6")).Text) + "," + int.Parse(txtMultiFen.Text) + ")";
                db.Insert(multi);
            }
            foreach (GridViewRow dr in GridView3.Rows)//保存试卷判断题信息
            {
                string judge = "insert into PaperDetail(PaperID,Type,TitleID,Mark) values(" + afterID + ",'判断题'," + int.Parse(((Label)dr.FindControl("Label7")).Text) + "," + int.Parse(txtJudgeFen.Text) + ")";
                db.Insert(judge);
            }
            foreach (GridViewRow dr in GridView4.Rows)//保存试卷填空题信息
            {
                string fill = "insert into PaperDetail(PaperID,Type,TitleID,Mark) values(" + afterID + ",'填空题'," + int.Parse(((Label)dr.FindControl("Label8")).Text) + "," + int.Parse(txtFillFen.Text) + ")";
                db.Insert(fill);
            }
            foreach (GridViewRow dr in GridView5.Rows)//保存试卷填空题信息
            {
                string que = "insert into PaperDetail(PaperID,Type,TitleID,Mark) values(" + afterID + ",'问答题'," + int.Parse(((Label)dr.FindControl("Label23")).Text) + "," + int.Parse(txtQuestionFen.Text) + ")";
                db.Insert(que);
            }
            Page.RegisterStartupScript("", "<script language=javascript>alert('保存成功');location='PaperLists.aspx'</script>");
        }

    }


    public int GetIDInsert(string XSqlString)
    {
        SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        Connection.Open();
        SqlCommand cmd = new SqlCommand(XSqlString, Connection);
        int Id = Convert.ToInt32(cmd.ExecuteScalar());
        return Id;
    }
    protected void txtPaperName_TextChanged(object sender, EventArgs e)
    {
        if (!IsPaperNameNotExist())
            Page.RegisterStartupScript("", "<script>alert('很遗憾！该试卷名称已经存在！！！');</script>");
    }
    public bool IsPaperNameNotExist()
    {
        Paper pp = new Paper();
        if (pp.IsPaperNameExist(txtPaperName.Text.Trim()))
        {
            txtPaperName.Text = "";
            return false;
        }
        else
        {
            return true;

        }
    }
}
