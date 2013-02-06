using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_MasterPage2 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["userID"] == null)
        //{
        //    Page.RegisterStartupScript("", "<script>location='../default.aspx';</script>");
        //}
        //else
        //{
        //    labUser.Text = Session["UserName"].ToString();
        //}
        labUser.Text = "周浩";
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["userID"] = Session["PaperID"] = Session["PaperName"] = "";
        Session.Clear();
        Session.Abandon();
        Response.Redirect("../default.aspx");
    }
}
