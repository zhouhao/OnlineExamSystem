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

public partial class ADMIN_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userID"] == null)
        {
            Page.RegisterStartupScript("", "<script>location='../default.aspx';</script>");
        }
        if (Convert.ToInt32(Session["roleID"]) == 5)
        {
            Page.RegisterStartupScript("", "<script>alert('你登录的用户权限不够！');location='../default.aspx'</script>");
        }

        else
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    string loginName = Session["userID"].ToString();
                    Users user = new Users();
                    user.LoadData(loginName);
                    labUser.Text = user.UserName;
                }
                catch
                {
                    Page.RegisterStartupScript("", "<script>location='../default.aspx'</script>");
                }

            }
        }
    }
}
