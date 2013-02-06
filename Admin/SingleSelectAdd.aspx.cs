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
using System.Data.SqlClient;

public partial class Admin_SingleSelectAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Page.RegisterStartupScript("", "<script>location='../default.aspx';</script>");
        }
        if (Convert.ToInt32(Session["roleID"]) == 5)
        {
            Page.RegisterStartupScript("", "<script>alert('你登录的用户权限不够！');location='default.aspx'</script>");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                InitDDLData();          //初始化试卷科目下拉列表框 
                InitDDLDiffData();     //初始化难度系数
                if (Request["ID"] != null)//如果是修改题目，初始化数据
                {
                    InitData();
                }
            }
        }

    }
    //初始化试卷科目
    protected void InitDDLData()
    {
        Course course = new Course();       //创建试卷科目对象
        DataSet ds = course.QueryCourse();  //查询试卷科目信息
        ddlCourse.DataSource = ds;          //指名试卷科目列表框数据源
        ddlCourse.DataTextField = "Name";   //DataTextField显示Name字段值
        ddlCourse.DataValueField = "ID";    //DataValueField显示ID字段值
        ddlCourse.DataBind();               //绑定数据
    }

    //初始化难度系数
    protected void InitDDLDiffData()
    {
        Diff diff = new Diff();       //创建试卷难度对象
        DataSet ds = diff.QueryDiff();  //查询试卷科目信息
        ddlDiff.DataSource = ds;          //指名试卷科目列表框数据源
        ddlDiff.DataTextField = "DiffName";   //DataTextField显示Name字段值
        ddlDiff.DataValueField = "ID";    //DataValueField显示ID字段值
        ddlDiff.DataBind();               //绑定数据
    }


    //初始化数据
    protected void InitData()
    {
        int SingleProblemID = int.Parse(Request["ID"].ToString());  //取出传递过来的试题编号
        SingleProblem singleproblem = new SingleProblem();          //创建单选题对象
        if (singleproblem.LoadData(SingleProblemID))                //如果取出题目信息，分别放在相应控件显示
        {
            ddlCourse.SelectedValue = singleproblem.CourseID.ToString();
            ddlDiff.SelectedValue = singleproblem.DiffID.ToString();
            txtTitle.Text = singleproblem.Title;
            txtAnswerA.Text = singleproblem.AnswerA;
            txtAnswerB.Text = singleproblem.AnswerB;
            txtAnswerC.Text = singleproblem.AnswerC;
            txtAnswerD.Text = singleproblem.AnswerD;
            ddlAnswer.SelectedValue = singleproblem.Answer.ToUpper();
        }
        else                //查询出错，给出提示
        {
            lblMessage.Text = "加载数据出错！";
        }
    }

    //添加或修改事件
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            SingleProblem singleproblem = new SingleProblem();          //创建单选题对象
            singleproblem.CourseID = int.Parse(ddlCourse.SelectedValue);//为单选题对象各属性赋值
            singleproblem.DiffID = int.Parse(ddlDiff.SelectedValue);//为填空题对象各属性赋值
            singleproblem.Title = txtTitle.Text;
            //if (singleproblem.isReduplicated(txtTitle.Text.Trim()) == true)
            //{
            //    Page.RegisterStartupScript("", "<script>alert('改题已经存在！');</script>");
            //    txtTitle.Text = "";
            //    return;
            //}
            singleproblem.AnswerA = txtAnswerA.Text;
            singleproblem.AnswerB = txtAnswerB.Text;
            singleproblem.AnswerC = txtAnswerC.Text;
            singleproblem.AnswerD = txtAnswerD.Text;
            singleproblem.Answer = ddlAnswer.SelectedItem.Text;

            if (Request["ID"] != null)                                  //如果是修改题目信息
            {
                singleproblem.ID = int.Parse(Request["ID"].ToString()); //取出试题主键
                if (singleproblem.UpdateByProc(int.Parse(Request["ID"].ToString())))//调用修改试题方法修改试题
                {
                    lblMessage.Text = "成功修改该单选题！";
                    txtTitle.Text = "";
                    txtAnswerA.Text = "";
                    txtAnswerB.Text = "";
                    txtAnswerC.Text = "";
                    txtAnswerD.Text = "";
                    ddlAnswer.SelectedIndex = 0;
                }
                else
                {
                    lblMessage.Text = "修改该单选题失败！";
                }
            }
            else                                                        //如果是添加试题
            {
                if (singleproblem.InsertByProc())                       //调用添加试题方法添加试题
                {
                    lblMessage.Text = "成功添加该单选题！";
                    txtTitle.Text = "";
                    txtAnswerA.Text = "";
                    txtAnswerB.Text = "";
                    txtAnswerC.Text = "";
                    txtAnswerD.Text = "";
                    ddlAnswer.SelectedIndex = 0;
                }
                else
                {
                    lblMessage.Text = "添加该单选题失败！";
                }
            }
        }
    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Server.Transfer("SingleSelectManage.aspx");
    }
    protected void txtTitle_TextChanged(object sender, EventArgs e)
    {
        SingleProblem sp = new SingleProblem();
        if (sp.isReduplicated(txtTitle.Text.Trim()) == true)
        {
            Page.RegisterStartupScript("", "<script>alert('改题已经存在！');</script>");
            txtTitle.Text = "";
        }
    }
   
}
