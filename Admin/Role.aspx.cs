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

public partial class Admin_Role : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Page.RegisterStartupScript("", "<script>location='../default.aspx';</script>");
        }
        if (Convert.ToInt32(Session["roleID"]) != 1)
        {
            Page.RegisterStartupScript("", "<script>alert('你登录的用户权限不够！');location='default.aspx'</script>");
        }

        else
        {
            if (!Page.IsPostBack)
            {
                InitData();
            }
        }
    }
    //初始化角色
    protected void InitData()
    {
        Role role = new Role();     //创建试卷科目对象
        DataSet ds = role.QueryRoleNoAdminandUser();  //查询试卷科目信息
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
        int i;
        //执行循环，保证每条数据都可以更新
        for (i = 0; i < GridView1.Rows.Count; i++)
        {
            //首先判断是否是数据行
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标停留时更改背景色
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#E4ECFB'");
                //当鼠标移开时还原背景色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
        }
    }
    //删除试卷科目事件
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Role role = new Role();           //创建Course对象
        int roleid = int.Parse(GridView1.DataKeys[e.RowIndex].Values[0].ToString()); //取出要删除记录的主键值
        if (role.DeleteByProc(roleid))
        {
            Page.RegisterStartupScript("", "<script language=javascript>alert('成功删除角色！')</script>");
        }
        else
        {
            Page.RegisterStartupScript("", "<script language=javascript>alert('删除角色失败！')</script>");
        }
        GridView1.EditIndex = -1;
        InitData();
    }
    //GridView控件RowUpdating事件
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int ID = int.Parse(GridView1.DataKeys[e.RowIndex].Values[0].ToString()); //取出要删除记录的主键值
        Role role = new Role();           //创建Course对象
        role.RoleName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtRoleName")).Text;
        if (role.UpdateByProc(ID))//使用Users类UpdateByProc方法修改用户信息
        {
            Page.RegisterStartupScript("", "<script language=javascript>alert('修改成功!')</script>");//5+1+a+s+p+x
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
