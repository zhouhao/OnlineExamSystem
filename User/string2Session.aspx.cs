using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_string2Session : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Page.RegisterStartupScript("", "<script>location='../default.aspx';</script>");
        }
        else
        {
            if (!IsPostBack)
            {
                int paperid = int.Parse(Request.QueryString["paperid"].ToString());
                Session["PaperID"] = paperid;
                Session["PaperName"] = Request.QueryString["papername"].ToString();
                Response.Redirect("UserTest.aspx");
            }
        }
    }
}