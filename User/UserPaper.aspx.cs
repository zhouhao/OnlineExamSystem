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
using System.Data.SqlClient;
using Examination.BusinessLogicLayer;

public partial class Admin_UserPaper : System.Web.UI.Page
{
    private int paperid;
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
                //调用自定义方法绑定数据库中试题信息
                PaperData();
               //获取问答题的得分
                queScore.Text = Convert.ToString(Convert.ToInt32(sumScore.Text)-Convert.ToInt32(sinScore.Text) - Convert.ToInt32(mulScore.Text) - Convert.ToInt32(judScore.Text) - Convert.ToInt32(filScore.Text));
            }
        }
    }

    //初始化试卷，从数据库中将试题取出
    protected void PaperData()
    {
        string userid = Request.QueryString["UserID"].ToString();
        paperid = int.Parse(Request.QueryString["PaperID"].ToString());

        DataBase DB = new DataBase();

        DataSet ds = DB.GetDataSetSql("select PaperName,ExamTime from [UserAnswertb],[Paper] where[UserAnswertb].PaperID=[Paper].PaperID and UserID='" + userid + "' and [UserAnswertb].PaperID='" + paperid + "'");
        DataRow[] row = ds.Tables[0].Select();
        //获取试卷基本信息
        lblExamtime.Text = row[0]["ExamTime"].ToString();
        lblExamname.Text = row[0]["PaperName"].ToString();
        //获取总分
        ds = DB.GetDataSetSql("select Score from Scoretb where UserID='" + userid + "' and PaperID='" + paperid + "'");
        DataRow[] rowSum = ds.Tables[0].Select();
        sumScore.Text = rowSum[0]["Score"].ToString();
        

        SqlParameter[] Params1 = new SqlParameter[3];
        Params1[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperid);
        Params1[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "单选题");
        Params1[2] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 50, userid);
        DataSet ds1 = DB.GetDataSet("Proc_UserAnswertb", Params1);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            GridView11.DataSource = ds1;
            GridView11.DataBind();
            ((Label)GridView11.HeaderRow.FindControl("Label27")).Text = ((Label)GridView11.Rows[0].FindControl("Label4")).Text;
        }


        SqlParameter[] Params2 = new SqlParameter[3];
        Params2[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperid);
        Params2[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "多选题");
        Params2[2] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 50, userid);
        DataSet ds2 = DB.GetDataSet("Proc_UserAnswertb", Params2);
        if (ds2.Tables[0].Rows.Count > 0)
        {
            GridView2.DataSource = ds2;
            GridView2.DataBind();
            ((Label)GridView2.HeaderRow.FindControl("Label28")).Text = ((Label)GridView2.Rows[0].FindControl("Label8")).Text;
        }


        SqlParameter[] Params3 = new SqlParameter[3];
        Params3[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperid);
        Params3[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "判断题");
        Params3[2] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 50, userid);
        DataSet ds3 = DB.GetDataSet("Proc_UserAnswertb", Params3);
        if (ds3.Tables[0].Rows.Count > 0)
        {
            GridView3.DataSource = ds3;
            GridView3.DataBind();
            ((Label)GridView3.HeaderRow.FindControl("Label29")).Text = ((Label)GridView3.Rows[0].FindControl("Label12")).Text;
        }
        SqlParameter[] Params4 = new SqlParameter[3];
        Params4[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperid);
        Params4[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "填空题");
        Params4[2] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 50, userid);
        DataSet ds4 = DB.GetDataSet("Proc_UserAnswertb", Params4);
        if (ds4.Tables[0].Rows.Count > 0)
        {
            GridView4.DataSource = ds4;
            GridView4.DataBind();
            ((Label)GridView4.HeaderRow.FindControl("Label30")).Text = ((Label)GridView4.Rows[0].FindControl("Label17")).Text;
        }

        SqlParameter[] Params5 = new SqlParameter[3];
        Params5[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperid);
        Params5[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "问答题");
        Params5[2] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 50, userid);
        DataSet ds5 = DB.GetDataSet("Proc_UserAnswertb", Params5);
        if (ds5.Tables[0].Rows.Count > 0)
        {
            GridView5.DataSource = ds5;
            GridView5.DataBind();
            ((Label)GridView5.HeaderRow.FindControl("Label31")).Text = ((Label)GridView5.Rows[0].FindControl("Label21")).Text;
        }

        if (GridView11.Rows.Count > 0)
        {
            int score1 = 0;
            int singlemark = int.Parse(((Label)GridView11.Rows[0].FindControl("Label4")).Text);//取出单选题的每题分值
            foreach (GridViewRow dr in GridView11.Rows)
            {
                if (((Label)dr.FindControl("Label3")).Text.Trim() == "A")
                {
                    ((RadioButton)dr.FindControl("RadioButton1")).Checked = true;
                }
                else if (((Label)dr.FindControl("Label3")).Text.Trim() == "B")
                {
                    ((RadioButton)dr.FindControl("RadioButton2")).Checked = true;
                }
                else if (((Label)dr.FindControl("Label3")).Text.Trim() == "C")
                {
                    ((RadioButton)dr.FindControl("RadioButton3")).Checked = true;
                }
                else if (((Label)dr.FindControl("Label3")).Text.Trim() == "D")
                {
                    ((RadioButton)dr.FindControl("RadioButton4")).Checked = true;
                }
                if (((Label)dr.FindControl("Label3")).Text.Trim() == ((Label)dr.FindControl("Label23")).Text.Trim())
                {
                    score1 = score1 + singlemark;
                    sinScore.Text = Convert.ToString(score1);
                    //dr.Visible = false;//单选题

                }
                else
                {
                    dr.BackColor = System.Drawing.Color.LightPink;//错题以红色背景显示                   
                }
            }
        }

        if (GridView2.Rows.Count > 0)
        {
            int score2 = 0;
            int multimark = int.Parse(((Label)GridView2.Rows[0].FindControl("Label8")).Text);//取出多选题每题分值
            foreach (GridViewRow dr in GridView2.Rows)
            {
                if (((Label)dr.FindControl("Label7")).Text.Trim() == "A")
                {
                    ((CheckBox)dr.FindControl("CheckBox1")).Checked = true;
                }
                if (((Label)dr.FindControl("Label7")).Text.Trim() == "B")
                {
                    ((CheckBox)dr.FindControl("CheckBox2")).Checked = true;
                }
                if (((Label)dr.FindControl("Label7")).Text.Trim() == "C")
                {
                    ((CheckBox)dr.FindControl("CheckBox3")).Checked = true;
                }
                if (((Label)dr.FindControl("Label7")).Text.Trim() == "D")
                {
                    ((CheckBox)dr.FindControl("CheckBox4")).Checked = true;
                }
                if (((Label)dr.FindControl("Label7")).Text.Trim() == "AB")
                {
                    ((CheckBox)dr.FindControl("CheckBox1")).Checked = true;
                    ((CheckBox)dr.FindControl("CheckBox2")).Checked = true;
                }
                if (((Label)dr.FindControl("Label7")).Text.Trim() == "AC")
                {
                    ((CheckBox)dr.FindControl("CheckBox1")).Checked = true;
                    ((CheckBox)dr.FindControl("CheckBox3")).Checked = true;
                }
                if (((Label)dr.FindControl("Label7")).Text.Trim() == "AD")
                {
                    ((CheckBox)dr.FindControl("CheckBox1")).Checked = true;
                    ((CheckBox)dr.FindControl("CheckBox4")).Checked = true;
                }
                if (((Label)dr.FindControl("Label7")).Text.Trim() == "BC")
                {
                    ((CheckBox)dr.FindControl("CheckBox2")).Checked = true;
                    ((CheckBox)dr.FindControl("CheckBox3")).Checked = true;
                }
                if (((Label)dr.FindControl("Label7")).Text.Trim() == "BD")
                {
                    ((CheckBox)dr.FindControl("CheckBox2")).Checked = true;
                    ((CheckBox)dr.FindControl("CheckBox4")).Checked = true;
                }
                if (((Label)dr.FindControl("Label7")).Text.Trim() == "CD")
                {
                    ((CheckBox)dr.FindControl("CheckBox3")).Checked = true;
                    ((CheckBox)dr.FindControl("CheckBox4")).Checked = true;
                }
                if (((Label)dr.FindControl("Label7")).Text.Trim() == "ABC")
                {
                    ((CheckBox)dr.FindControl("CheckBox1")).Checked = true;
                    ((CheckBox)dr.FindControl("CheckBox2")).Checked = true;
                    ((CheckBox)dr.FindControl("CheckBox3")).Checked = true;
                }
                if (((Label)dr.FindControl("Label7")).Text.Trim() == "ABD")
                {
                    ((CheckBox)dr.FindControl("CheckBox1")).Checked = true;
                    ((CheckBox)dr.FindControl("CheckBox2")).Checked = true;
                    ((CheckBox)dr.FindControl("CheckBox4")).Checked = true;
                }
                if (((Label)dr.FindControl("Label7")).Text.Trim() == "ACD")
                {
                    ((CheckBox)dr.FindControl("CheckBox1")).Checked = true;
                    ((CheckBox)dr.FindControl("CheckBox3")).Checked = true;
                    ((CheckBox)dr.FindControl("CheckBox4")).Checked = true;
                }
                if (((Label)dr.FindControl("Label7")).Text.Trim() == "ABCD")
                {
                    ((CheckBox)dr.FindControl("CheckBox1")).Checked = true;
                    ((CheckBox)dr.FindControl("CheckBox2")).Checked = true;
                    ((CheckBox)dr.FindControl("CheckBox3")).Checked = true;
                    ((CheckBox)dr.FindControl("CheckBox4")).Checked = true;
                }
                if (((Label)dr.FindControl("Label7")).Text.Trim() == ((Label)dr.FindControl("Label27")).Text.Trim())
                {
                    score2 = score2 + multimark;
                    mulScore.Text = Convert.ToString(score2);
                }
                else
                {
                    dr.BackColor = System.Drawing.Color.LightPink;//错题以红色背景显示
                    
                }
            }
        }

        if (GridView3.Rows.Count > 0)
        {
            int score3 = 0;
            int judgemark = int.Parse(((Label)GridView3.Rows[0].FindControl("Label12")).Text);//取出判断题每题分值
            foreach (GridViewRow dr in GridView3.Rows)//对判断题每题进行判断用户选择答案
            {
                try
                {
                    if (bool.Parse(((Label)dr.FindControl("Label11")).Text.Trim()))
                    {
                        ((CheckBox)dr.FindControl("CheckBox5")).Checked = true;
                    }
                    else
                    {
                        ((CheckBox)dr.FindControl("CheckBox6")).Checked = true;
                    }
                }
                catch 
                {
                    ((CheckBox)dr.FindControl("CheckBox5")).Checked = false;
                    ((CheckBox)dr.FindControl("CheckBox6")).Checked = false;
                }
                if (((Label)dr.FindControl("Label11")).Text.Trim() == ((Label)dr.FindControl("Label41")).Text.Trim())
                {
                    score3 = score3 + judgemark;
                    judScore.Text = Convert.ToString(score3);
                }
                else
                {
                    dr.BackColor = System.Drawing.Color.LightPink;//错题以红色背景显示

                }
            }
        }
        

        //计算总分

    }

    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Server.Transfer("UserPaperList.aspx");
    }

    protected void lbOnlyShowErrors_Click(object sender, EventArgs e)
    {
        if (GridView11.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView11.Rows)
            {
                if (((Label)dr.FindControl("Label3")).Text.Trim() == ((Label)dr.FindControl("Label23")).Text.Trim())
                {
                    dr.Visible = false;//单选题

                }
                else
                {
                    dr.BackColor = System.Drawing.Color.LightPink;//错题以红色背景显示
                }
            }
        }

        if (GridView2.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView2.Rows)
            {
                
                if (((Label)dr.FindControl("Label7")).Text.Trim() == ((Label)dr.FindControl("Label27")).Text.Trim())
                {
                    dr.Visible = false;//多选题
                }
                else
                {
                    dr.BackColor = System.Drawing.Color.LightPink;//错题以红色背景显示

                }
            }
        }

        if (GridView3.Rows.Count > 0)
        {          
            foreach (GridViewRow dr in GridView3.Rows)//对判断题每题进行判断用户选择答案
            {
                if (((Label)dr.FindControl("Label11")).Text.Trim() == ((Label)dr.FindControl("Label41")).Text.Trim())
                {
                    dr.Visible = false;//判断题
                }
                else
                {
                    dr.BackColor = System.Drawing.Color.LightPink;//错题以红色背景显示

                }
            }
        }
        if (GridView4.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView4.Rows)//对填空题每题进行判断用户选择答案
            {
                if (((Label)dr.FindControl("Label26")).Text.Trim() == ((TextBox)dr.FindControl("TextBox1")).Text.Trim())
                {
                    dr.Visible = false;//判断题
                }
                else
                {
                    dr.BackColor = System.Drawing.Color.LightPink;//错题以红色背景显示
                }
            }
        }

    }
    protected void LinkButton_Click(object sender, EventArgs e)
    {
        Page.RegisterStartupScript("", "<script>window.location.href = window.location.href; window.location.reload; </script>"); 

    }
}
