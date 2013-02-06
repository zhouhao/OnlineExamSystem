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

public partial class User_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Page.RegisterStartupScript("",  "<script>location='../default.aspx';</script>");
        }
        else
        {
            labUser.Text = Session["UserName"].ToString();
        }
        
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["userID"] = Session["PaperID"] = Session["PaperName"] = "";
       // HttpContext.Current.Cache.Remove(Session["userID"].ToString());
        Session.Clear();
        Session.Abandon();
        Response.Redirect("../default.aspx");
    }
}
