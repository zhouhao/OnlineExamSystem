using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_isAvailble : System.Web.UI.Page
{
    string id = null;
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

        if (Request.QueryString["PaperID"] != null)
        {
            id = Request.QueryString["PaperID"].ToString();
        }
        else
        {
            Response.Redirect("PaperLists.aspx");
        }
        if (!IsPostBack)
        {
            string Connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(Connection);
            cn.Open();
            string sql = string.Format("update Paper set PaperState=1^PaperState where PaperID='" + id + "'");
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            Response.Redirect("PaperLists.aspx");
        }
    }
}