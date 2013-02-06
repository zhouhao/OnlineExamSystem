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

public partial class Web_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RedirectPage();
    }
    private void RedirectPage()
    {
        if (Session["userID"] == null)
            Response.Redirect("exit.aspx");

        Users user = new Users();
        string userid = Session["userID"].ToString();
        user.LoadData(userid);
        switch (user.RoleName)
        {
            case "管理员":
                Response.Redirect("PwdModify.aspx");
                break;
            case "学生":
                Response.Redirect("../User/Default.aspx");
                break;
            case "出题人":
                Response.Redirect("PwdModify.aspx");
                break;
            default:
                Response.Redirect("PwdModify.aspx");
                break;
        }
    }
}
