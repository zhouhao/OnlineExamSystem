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
using Examination.DataAccessLayer;
using Examination.BusinessLogicLayer;
using System.Data.SqlClient;
using System.IO;
using System.Text;

public partial class Admin_PaperDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
                       Page.RegisterStartupScript("",  "<script>location='../default.aspx';</script>");
        }
        if (Convert.ToInt32(Session["roleID"]) == 5)
        {
            Page.RegisterStartupScript("", "<script>alert('你登录的用户权限不够！');location='default.aspx'</script>");
        }
        else
        {
            if (!IsPostBack)
            {
                InitData();

            }
        }
    }


    #region   Web   重写 使用gridView控件时必须重写
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for 
    }
    #endregion

    //初始化试卷，从数据库中将试题取出
    protected void InitData()
    {
        DataBase DB = new DataBase();
        int paperID = Convert.ToInt32(Request.QueryString["PaperID"].ToString());


        SqlParameter[] Params1 = new SqlParameter[2];
        Params1[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperID);               //试卷编号
        Params1[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "单选题");            //题目类型        
        DataSet ds1 = DB.GetDataSet("Proc_PaperDetail", Params1);
        GridView11.DataSource = ds1;
        GridView11.DataBind();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            ((Label)GridView11.HeaderRow.FindControl("Labelt2")).Text = ((Label)GridView11.Rows[0].FindControl("Labelm1")).Text;
        }

        SqlParameter[] Params2 = new SqlParameter[2];
        Params2[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperID);               //试卷编号
        Params2[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "多选题");            //题目类型        
        DataSet ds2 = DB.GetDataSet("Proc_PaperDetail", Params2);
        GridView2.DataSource = ds2;
        GridView2.DataBind();
        if (ds2.Tables[0].Rows.Count > 0)
        {
            ((Label)GridView2.HeaderRow.FindControl("Labelt5")).Text = ((Label)GridView2.Rows[0].FindControl("Labelm2")).Text;
        }

        SqlParameter[] Params3 = new SqlParameter[2];
        Params3[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperID);               //试卷编号
        Params3[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "判断题");            //题目类型        
        DataSet ds3 = DB.GetDataSet("Proc_PaperDetail", Params3);
        GridView3.DataSource = ds3;
        GridView3.DataBind();
        if (ds3.Tables[0].Rows.Count > 0)
        {
            ((Label)GridView3.HeaderRow.FindControl("Labelt8")).Text = ((Label)GridView3.Rows[0].FindControl("Labelm3")).Text;
        }

        SqlParameter[] Params4 = new SqlParameter[2];
        Params4[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperID);               //试卷编号
        Params4[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "填空题");            //题目类型        
        DataSet ds4 = DB.GetDataSet("Proc_PaperDetail", Params4);
        GridView4.DataSource = ds4;
        GridView4.DataBind();
        if (ds4.Tables[0].Rows.Count > 0)
        {
            ((Label)GridView4.HeaderRow.FindControl("Labelt11")).Text = ((Label)GridView4.Rows[0].FindControl("Labelm4")).Text;
        }
        SqlParameter[] Params5 = new SqlParameter[2];
        Params5[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperID);               //试卷编号
        Params5[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "问答题");            //题目类型        
        DataSet ds5 = DB.GetDataSet("Proc_PaperDetail", Params5);
        GridView5.DataSource = ds5;
        GridView5.DataBind();
        if (ds5.Tables[0].Rows.Count > 0)
        {
            ((Label)GridView5.HeaderRow.FindControl("Labelt14")).Text = ((Label)GridView5.Rows[0].FindControl("Labelm5")).Text;
        }
       
       

    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Server.Transfer("PaperLists.aspx");
    }

    protected void bunToWrod_Click(object sender, ImageClickEventArgs e)
    {
        ExportDataGrid("application/ms-word", "试卷.doc");
    }

    private void ExportDataGrid(string FileType, string FileName) //从DataGrid导出
    {

        Response.Charset = "GB2312";

        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");



        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());

        Response.ContentType = FileType;

        this.EnableViewState = false;

        StringWriter tw = new StringWriter();

        HtmlTextWriter hw = new HtmlTextWriter(tw);

        GridView11.RenderControl(hw);
        GridView2.RenderControl(hw);
        GridView3.RenderControl(hw);
        GridView4.RenderControl(hw);
        GridView5.RenderControl(hw);
        Response.Write(tw.ToString());

        Response.End();

    }
}
