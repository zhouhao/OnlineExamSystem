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

public partial class User_search : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["keyWord"]==null || Session["keyWord"].ToString().Trim() == "")//Session["userID"] == null || 
        {
            Page.RegisterStartupScript("", "<script>location='../default.aspx';</script>");
        }
        else
        {
            if (!IsPostBack)
            {
                string keyWord = Session["keyWord"].ToString();
                tbKeyWord.Text = keyWord;
                Bind(keyWord);
            }
        }
    }
    protected void Bind(string keyWord)
    {
        DataBase DB = new DataBase();

        Hashtable ht1 = new Hashtable();
        ht1.Add("Title", keyWord);
        ht1.Add("AnswerA", keyWord);
        ht1.Add("AnswerB", keyWord);
        ht1.Add("AnswerC", keyWord);
        ht1.Add("AnswerD", keyWord);
   
        DataSet ds1 = DB.AdvancedSearch("SingleProblem", ht1);

        if (ds1.Tables[0].Rows.Count > 0)//判断下是否有单选题
        {
            GridView11.DataSource = ds1;
            GridView11.DataBind();
        }

      
        DataSet ds2 = DB.AdvancedSearch("MultiProblem", ht1);
        if (ds2.Tables[0].Rows.Count > 0)
        {
            GridView2.DataSource = ds2;
            GridView2.DataBind();
        }

        Hashtable ht2 = new Hashtable();
        ht2.Add("Title", keyWord);
        DataSet ds3 = DB.AdvancedSearch("JudgeProblem", ht2);
        if (ds3.Tables[0].Rows.Count > 0)
        {
            GridView3.DataSource = ds3;
            GridView3.DataBind();
        }
        

    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["keyWord"] = tbKeyWord.Text.Trim();
        Response.Redirect("search.aspx");
    }
    protected void CBLProblemClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CBLProblemClass.Items[0].Selected == false)
            GridView11.Visible = false;
        else
            GridView11.Visible = true;

        if (CBLProblemClass.Items[1].Selected == false)
            GridView2.Visible = false;
        else
            GridView2.Visible = true;
        if (CBLProblemClass.Items[2].Selected == false)
            GridView3.Visible = false;
        else
            GridView3.Visible = true;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (GridView11.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView11.Rows)
            {
                ((Label)dr.FindControl("lbSingleAnswer")).Visible = true;
            }
        }

        if (GridView2.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView2.Rows)
            {

                ((Label)dr.FindControl("lbMultiAnswer")).Visible = true;
            }
        }

        if (GridView3.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView3.Rows)//对判断题每题进行判断用户选择答案
            {
                ((Label)dr.FindControl("lbJudgeAnswer")).Visible = true;

            }
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (GridView11.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView11.Rows)
            {
                ((Label)dr.FindControl("lbSingleAnswer")).Visible = false;
            }
        }

        if (GridView2.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView2.Rows)
            {

                ((Label)dr.FindControl("lbMultiAnswer")).Visible = false;
            }
        }

        if (GridView3.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView3.Rows)
            {
                ((Label)dr.FindControl("lbJudgeAnswer")).Visible = false;

            }
        }
    }
}