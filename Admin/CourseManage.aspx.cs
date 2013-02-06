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

public partial class Admin_CourseManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Page.RegisterStartupScript("",  "<script>location='../default.aspx';</script>");
        }
        if (Convert.ToInt32(Session["roleID"])!=1)
        {
            Page.RegisterStartupScript("", "<script>alert('你登录的用户权限不够！');location='../default.aspx'</script>");
        }

        if (!IsPostBack)
        {
            InitData();  //初始化试卷科目          
        }
        
        
        
    }
    //初始化试卷科目
    protected void InitData()
    {
        Course course = new Course();       //创建试卷科目对象
        DataSet ds = course.QueryCourse();  //查询试卷科目信息
        GridView1.DataSource = ds;          //为GridView控件指名数据源        
        GridView1.DataBind();               //绑定数据
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        InitData();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
   
            //首先判断是否是数据行
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标停留时更改背景色
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='Aqua'");
                //当鼠标移开时还原背景色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
        
    }
    //删除试卷科目事件
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Course course = new Course();           //创建Course对象
        int ID = int.Parse(GridView1.DataKeys[e.RowIndex].Values[0].ToString()); //取出要删除记录的主键值
        if (course.DeleteByProc(ID))
        {
            Page.RegisterStartupScript("", "<script language=javascript>alert('成功删除试卷科目！')</script>");
        }
        else
        {
            Page.RegisterStartupScript("", "<script language=javascript>alert('删除试卷科目失败！')</script>");
        }
        GridView1.EditIndex = -1;
        InitData();
    }
    //GridView控件RowUpdating事件
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int ID = int.Parse(GridView1.DataKeys[e.RowIndex].Values[0].ToString()); //取出要删除记录的主键值
        Course course = new Course();           //创建Course对象
        course.Name = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName")).Text;
        if (course.UpdateByProc(ID))//使用Users类UpdateByProc方法修改用户信息
        {
            Page.RegisterStartupScript("", "<script language=javascript>alert('修改成功!')</script>");
        }
        else
        {
            Page.RegisterStartupScript("", "<script language=javascript>alert('修改失败!')</script>");
        }
        GridView1.EditIndex = -1;
        InitData();
    }
    //GridView控件RowCanceling事件
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        InitData();
    }
    //GridView控件RowEditing事件
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;  //GridView编辑项索引等于单击行的索引
        InitData();
    }
}
