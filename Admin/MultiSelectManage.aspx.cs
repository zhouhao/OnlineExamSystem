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

public partial class Admin_MultiSelectManage : System.Web.UI.Page
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
                InitDDLData();  //初始化试卷科目          
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
        GridViewBind();
    }
    //显示选择科目的单选题
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewBind();//为GridView绑定数据
    }
    protected void GridViewBind()
    {
        MultiProblem multiproblem = new MultiProblem();  //创建多选题对象
        DataSet ds = multiproblem.QueryMultiProblem(int.Parse(ddlCourse.SelectedValue));//根据试卷科目查询多选题信息
        GridView1.DataSource = ds.Tables[0].DefaultView;    //为GridView控件指名数据源
        GridView1.DataBind();                               //绑定数据
    }
    //删除试题事件
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        MultiProblem multiproblem = new MultiProblem();  //创建单选题对象
        int ID = int.Parse(GridView1.DataKeys[e.RowIndex].Values[0].ToString()); //取出要删除记录的主键值
        if (multiproblem.DeleteByProc(ID))
        {
            Page.RegisterStartupScript("", "<script language=javascript>alert('成功删除试题！')</script>");
        }
        else
        {
            Page.RegisterStartupScript("", "<script language=javascript>alert('删除试题失败！')</script>");
        }
        GridViewBind();//重新绑定数据
    }
    //删除多条记录
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        MultiProblem multi = new MultiProblem();//创建MultiProblem对象              
        foreach (GridViewRow dr in GridView1.Rows)//对GridView中的每一行进行判断
        {
            if (((CheckBox)dr.FindControl("xuanze")).Checked)//如果选择了进行删除
            {
                int ID = int.Parse(((Label)dr.FindControl("Label1")).Text);
                multi.ID = ID;
                multi.DeleteByProc(ID);
            }
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridViewBind();//重新绑定数据
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].ToolTip = e.Row.Cells[2].Text;
            if ((e.Row.Cells[2].Text).Length > 30)
            {
                e.Row.Cells[2].Text = (e.Row.Cells[2].Text).Substring(0, 30) + "...";
            }
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[4].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除\"" + e.Row.Cells[2].Text + "\"吗?')");
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
}
