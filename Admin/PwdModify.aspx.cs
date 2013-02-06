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

public partial class ADMIN_PwdChange : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["roleID"])==5)
        {
            Page.RegisterStartupScript("", "<script>location='exit.aspx'</script>");
        }
        else
        {
            Users user = new Users();
            if (!user.IsAdmin(Session["userID"].ToString()))
            {
                Page.RegisterStartupScript("", "<script>alert('没有管理员权限，该页不能访问！');location='exit.aspx';</script>");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    this.txtOldPwd.Focus();
                }
            }
        }
       
        
    }

    protected void imgBtnReset_Click(object sender, ImageClickEventArgs e)
    {
        txtOldPwd.Text = txtNewPwd.Text = txtConfirmPwd.Text = "";
    }
    protected void imgBtnModifyPwd_Click1(object sender, ImageClickEventArgs e)
    {
        Users user = new Users();//创建Users对象user
        user.LoadData(Session["userID"].ToString());

        if (user.UserPwd == FormsAuthentication.HashPasswordForStoringInConfigFile(txtOldPwd.Text.Trim(), "MD5"))//验证用户输入原密码是否正确
        {
            user.UserPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtNewPwd.Text.Trim(), "MD5");
            if (user.ModifyPassword(this.Session["userID"].ToString()))//更改用户密码
            {
                lblMessage.Text = "成功修改密码!";
            }
            else//修改密码失败
            {
                lblMessage.Text = "修改密码失败!";
            }
        }
        else//原密码错误
        {
            lblMessage.Text = "输入原密码错误,请重新输入!";
        }
    }  
}
