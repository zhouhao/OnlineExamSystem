using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Examination.BusinessLogicLayer;


public partial class _Default : System.Web.UI.Page 
{
    Label lblMessage = new Label();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["roleID"]!=null)
            RedirectPage(int.Parse(Session["roleID"].ToString()));

        if (!IsPostBack)//判断页面是否首次加载
        {
            if (!Object.Equals(Request.Cookies["UserID"], null))
            {
                //创建一个Cookie对象，实现记住用户名
                HttpCookie readcookie = Request.Cookies["UserID"];
                this.TxtUserName.Text = readcookie.Value;
            }
        } 
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        Users user = new Users();//创建Users对象user
        string uid = TxtUserName.Text.Trim();
        
        string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(TxtUserPwd.Text.Trim(), "MD5");
        if (user.CheckPassword(uid))//根据用户编号查询用户密码
        {
            if (user.UserPwd == pwd)//输入密码与用户密码相同
            {             
                CreateCookie();
                Session["userID"] = uid;//存储用户编号
                user.LoadData(uid);
                Session["UserName"] = user.UserName;
                Session["roleID"] = user.RoleId;
                RedirectPage(user.RoleName);

            }
            else//密码错误，给出提示
            {
                lblMessage.Text = "您输入的密码错误！";
            }
        }
        else//用户不存在，给出提示
        {
            lblMessage.Text = "该用户不存在！";
        }
        Page.RegisterStartupScript("", "<script>alert('" + lblMessage.Text + "');</script>");
        
    }
        private void CreateCookie()
        {
            HttpCookie cookie = new HttpCookie("UserID");
            cookie.Value = this.TxtUserName.Text;
            cookie.Expires = DateTime.MaxValue;
            Response.AppendCookie(cookie);
        }
    private void RedirectPage(string RoleName)
    {
        switch (RoleName)
        {
            case "管理员":
                Response.Redirect("Admin/PwdModify.aspx");
                break;
            case "学生":
                Response.Redirect("User/Default.aspx");
                break;
            case "出题人":
                Response.Redirect("Admin/PwdModify.aspx");
                break;
            default:
                
                Response.Redirect("Admin/PwdModify.aspx");
                break;
        }
    }
    private void RedirectPage(int RoleID)
    {
        switch (RoleID)
        {
            case 1:
                Response.Redirect("Admin/PwdModify.aspx");
                break;
            case 5:
                Response.Redirect("User/Default.aspx");
                break;
            case 6:
                Response.Redirect("Admin/PwdModify.aspx");
                break;
            default:
                Response.Redirect("Admin/PwdModify.aspx");
                break;
        }
    }
}
