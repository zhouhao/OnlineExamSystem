using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Examination.DataAccessLayer;
using System.Data;

public partial class User_paperlist : System.Web.UI.Page
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
                Bind();
            }
        }
        
    }
    public void Bind()
    {
        DataBase DB = new DataBase();
        DataSet ds = DB.GetDataSetSql("SELECT [PaperID], [PaperName] FROM [Paper] WHERE ([NeedTime] = 0)");
        DataList1.DataSource = ds;
        DataList1.DataKeyField = "PaperID";
        DataList1.DataBind();
    }

    
}