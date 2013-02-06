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

public partial class Web_UserAdd : System.Web.UI.Page
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
       
    }
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            Users user = new Users();       //创建Users对象
            user.UserID = txtUserID.Text.Trim();
            if (!user.CheckUser(user.UserID))//使用CheckUser方法验证用户是否存在
            {
                user.UserName = txtUserName.Text;
                user.UserPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtUserPwd.Text, "MD5"); 
                user.RoleId = Convert.ToInt16(ddlRole.SelectedValue);
               
                    if (user.InsertByProc())
                    {
                        lblMessage.Text = "成功插入该用户信息！";
                        Server.Transfer("UserManage.aspx");
                    }
              else
               {
                   lblMessage.Text = "添加用户失败！";
               }
            }
            else//用户存在，给出提示
            {
                lblMessage.Text = "数据库中存在具有该编号的用户，请重新输入！";
            }
        }
    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Server.Transfer("UserManage.aspx");       
    }
}
