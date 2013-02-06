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

public partial class Admin_UserManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Page.RegisterStartupScript("",  "<script>location='../default.aspx';</script>");
        }
        if (Convert.ToInt32(Session["roleID"])!=1)
        {
            Page.RegisterStartupScript("", "<script>alert('你登录的用户权限不够！');location='default.aspx'</script>");
        }
        
        else
        {
            if (!Page.IsPostBack)
            {
                GridViewBind();
            }
        }
        
    }
    private void GridViewBind()
    {
        Users user = new Users();//创建Users类对象user
        DataSet ds = user.QueryUsers();//使用Users类QueryUsers方法查询所有用户信息
        GridView1.DataSource = ds;//为GridView控件指名数据源
        GridView1.DataBind();//GridView控件绑定数据
        LabelPageInfo.Text = "当前（第" + (GridView1.PageIndex + 1).ToString() + "页 共" + GridView1.PageCount.ToString() + "页）";
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridViewBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (((DropDownList)e.Row.FindControl("ddlRole")) != null)
        {
            DropDownList ddlrole = (DropDownList)e.Row.FindControl("ddlRole");

            //  生成 DropDownList 的值，绑定数据
            string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State.ToString() == "Closed") conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Proc_RoleList", conn);
            da.Fill(ds);
            if (conn.State.ToString() == "Open") conn.Close();

            ddlrole.DataSource = ds.Tables[0].DefaultView;
            ddlrole.DataTextField = "RoleName";
            ddlrole.DataValueField = "RoleId";
            ddlrole.DataBind();

            
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
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        GridViewBind();
    }
    //GridView控件RowDeleting事件
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string userID = GridView1.DataKeys[e.RowIndex].Values[0].ToString(); //取出要删除记录的主键值
        
        Users user = new Users();//创建Users类对象user
        if (!user.DeleteAllByProc(userID))//根据主键使用DeleteAllByProc方法删除用户和该用户的考试相关信息
        {
            Page.RegisterStartupScript("", "<script language=javascript>alert('删除失败!')</script>");
        }
        GridView1.EditIndex = -1;
        GridViewBind();//重新绑定数据

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;  //GridView编辑项索引等于单击行的索引
        GridViewBind();
    }

    //GridView控件RowUpdating事件
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string userID = GridView1.DataKeys[e.RowIndex].Values[0].ToString(); //取出记录的主键值
        Users user = new Users();
        user.UserName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbxName")).Text;
        user.RoleId = Convert.ToInt32(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlRole")).SelectedValue);   //取出修改后的值
        //user.UserPwd = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbxPwd")).Text;
        if (user.UpdateByProc(userID))//使用Users类UpdateByProc方法修改用户信息
        {
            GridViewBind();
            Page.RegisterStartupScript("", "<script language=javascript>alert('修改成功!')</script>");
        }
        else
        {
            Page.RegisterStartupScript("", "<script language=javascript>alert('修改成功!')</script>");
        }
        GridView1.EditIndex = -1;
        GridViewBind();
    }

    protected void ImageButtonQuery_Click(object sender, ImageClickEventArgs e)
    {
        Hashtable queryItems = new Hashtable();
        queryItems.Add("UserID", tbxUserID.Text.Trim());
        queryItems.Add("UserName", tbxUserName.Text.Trim());
        DataTable dt = Examination.BusinessLogicLayer.Users.QueryUsers(queryItems);
        if (dt.Rows.Count >= 1)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            Page.RegisterStartupScript("", "<script language=javascript>alert('没有这个用户!')</script>");
        }
    }

    protected void ImageButtonDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                bool isChecked = ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked;
                if (isChecked)
                {
                    string userID = ((Label)GridView1.Rows[i].FindControl("Label1")).Text;
                    Users user = new Users();//创建Users类对象user
                    if (!user.DeleteAllByProc(userID))//根据主键使用DeleteAllByProc方法删除用户和该用户的考试相关信息
                    {
                        Page.RegisterStartupScript("", "<script language=javascript>alert('" + userID + "删除失败!')</script>");

                    }

                }
            }
            //Page.RegisterStartupScript("", "<script language=javascript>alert('删除成功!')</script>");

        }
        catch(Exception ex)
        {
            Page.RegisterStartupScript("", "<script language=javascript>alert('删除失败!')</script>");

        }
        GridViewBind();
    }
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked = this.chkSelectAll.Checked;
        }
    }
    protected void ImageButtonResetPassword_Click(object sender, ImageClickEventArgs e)
    {
        int numOfChecked = 0;
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            bool isChecked = ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked;
            if (isChecked)
            {
                numOfChecked++;
            }
        }
        if (numOfChecked == 1)
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                bool isChecked = ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked;
                if (isChecked)
                {
                    string UserID = ((Label)GridView1.Rows[i].FindControl("Label1")).Text;

                    Random ran = new Random();
                    string newPassword = (ran.Next(999999).ToString().PadLeft(6, '8'));	//随机生成一个密码

                    Users user = new Users();//创建Users对象user
                    //user.UserPwd = newPassword;
                    user.UserPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newPassword, "MD5").ToString();
                    if (user.ModifyPassword(UserID))//更改用户密码
                    {
                        Page.RegisterStartupScript("", "<Script language=JavaScript>alert('" + UserID + "的密码已经重置，新密码为【" + newPassword + "】。');</Script>");
                    }
                    else//修改密码失败
                    {
                        Page.RegisterStartupScript("", "<Script language=JavaScript>alert('" + UserID + "重置密码失败!');</Script>");
                    }
                }
            }

        }
        else
        {
            Page.RegisterStartupScript("", "<Script language=JavaScript>alert('您只能选择一个用户!');</Script>");
            return;
        }
    }
    protected void ImageButtonBack_Click(object sender, ImageClickEventArgs e)
    {
        GridViewBind();
    }
}
