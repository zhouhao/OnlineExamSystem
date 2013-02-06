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

public partial class User_UserTest : System.Web.UI.Page
{
    private int paperid;
    private int sum = 0, right = 0, error = 0, noDone = 0;
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
                imgBtnSubmit.Attributes.Add("OnClick", "javascript:return confirm('确实要提交吗？')");
                lblPaperName.Text = Session["PaperName"].ToString();
                InitData();//绑定试题
            }
        }
    }
    //初始化试卷，从数据库中将试题取出
    protected void InitData()
    {
        DataBase DB = new DataBase();
        string userid = Session["UserID"].ToString();
        paperid = int.Parse(Session["PaperID"].ToString());

        DataSet ds = DB.GetDataSetSql("select * from UserAnswertb where UserID='" + userid + "' and PaperID='" + paperid + "'");
        
        if (ds.Tables[0].Rows.Count>0)
        {
            sum = right =  error =  noDone = 0;//初始化变量

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

            //得到题目总数
            sum = GridView11.Rows.Count + GridView2.Rows.Count + GridView3.Rows.Count + GridView4.Rows.Count ;

            if (GridView11.Rows.Count > 0)
            {
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
                    if (((Label)dr.FindControl("Label3")).Text.Trim() == ((Label)dr.FindControl("lbSingleAnswer")).Text.Trim())
                    {

                        right++;

                    }
                    else
                    {
                        if(((Label)dr.FindControl("Label3")).Text.Trim()=="")
                        {
                            noDone++;
                        }
                        else
                        {
                            dr.BackColor = System.Drawing.Color.LightPink;//错题以红色背景显示
                            error++;
                        }

                    }
                }
            }

            if (GridView2.Rows.Count > 0)
            {
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
                    if (((Label)dr.FindControl("Label7")).Text.Trim() == ((Label)dr.FindControl("lbMultiAnswer")).Text.Trim())
                    {
                        right++;
                    }
                    else
                    {
                        if(((Label)dr.FindControl("Label7")).Text.Trim()=="")
                        {
                            noDone++;
                        }
                        else
                        {
                            dr.BackColor = System.Drawing.Color.LightPink;//错题以红色背景显示
                            error++;
                        }
                    }
                }
            }

            if (GridView3.Rows.Count > 0)
            {         
                foreach (GridViewRow dr in GridView3.Rows)//对判断题每题进行判断用户选择答案
                {
                    try
                    {
                        if (bool.Parse(((Label)dr.FindControl("Label11")).Text.Trim()))
                        {
                            ((CheckBox)dr.FindControl("RadioButton5")).Checked = true;
                        }
                        else
                        {
                            ((CheckBox)dr.FindControl("RadioButton6")).Checked = true;
                        }
                    }
                    catch
                    {
                        ((CheckBox)dr.FindControl("RadioButton5")).Checked = false;
                        ((CheckBox)dr.FindControl("RadioButton6")).Checked = false;
                    }
                    if (((Label)dr.FindControl("Label11")).Text.Trim() == ((Label)dr.FindControl("lbJudgeAnswer")).Text.Trim())
                    {
                        right++;
                    }
                    else
                    {
                        if(((Label)dr.FindControl("Label11")).Text.Trim()=="")
                        {
                            noDone++;
                        }
                        else
                        {
                            dr.BackColor = System.Drawing.Color.LightPink;//错题以红色背景显示
                            error++;
                        }
                    }
                }
            }
            //取出填空题每题分值
            if (GridView4.Rows.Count > 0)
            {
                int score4 = 0;
                int fillmark = int.Parse(((Label)GridView4.Rows[0].FindControl("Label17")).Text);
                foreach (GridViewRow dr in GridView4.Rows)//对填空题每题进行判断用户选择答案
                {
                    string str = "";
                    str = ((TextBox)dr.FindControl("TextBox1")).Text.Trim();
                    if (str == ((Label)dr.FindControl("Label26")).Text.Trim())
                    {
                        right++;
                    }
                    else
                    {
                        if (str == "")
                        {
                            noDone++;
                        }
                        else
                        {
                            dr.BackColor = System.Drawing.Color.LightPink;//错题以红色背景显示
                            error++;
                        }

                    }
                }
            }

            lbSumUp.Text = "除问答题外，共"+sum.ToString()+"道客观题，其中正确"+right.ToString()+"道题，错误"+error.ToString()+"道题，"+noDone.ToString()+"没做！";
        }
        else
        {
            int paperID = paperid;
            lbSumUp.Text = "没有记录！";
            SqlParameter[] Params1 = new SqlParameter[2];
            Params1[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperID);               //试卷编号
            Params1[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "单选题");            //题目类型        
            DataSet ds1 = DB.GetDataSet("Proc_PaperDetail", Params1);
            if (ds1.Tables[0].Rows.Count > 0)//判断下是否有单选题
            {
                GridView11.DataSource = ds1;
                GridView11.DataBind();
                ((Label)GridView11.HeaderRow.FindControl("Label27")).Text = ((Label)GridView11.Rows[0].FindControl("Label4")).Text;
            }

            SqlParameter[] Params2 = new SqlParameter[2];
            Params2[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperID);               //试卷编号
            Params2[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "多选题");            //题目类型        
            DataSet ds2 = DB.GetDataSet("Proc_PaperDetail", Params2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                GridView2.DataSource = ds2;
                GridView2.DataBind();
                ((Label)GridView2.HeaderRow.FindControl("Label28")).Text = ((Label)GridView2.Rows[0].FindControl("Label8")).Text;
            }

            SqlParameter[] Params3 = new SqlParameter[2];
            Params3[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperID);               //试卷编号
            Params3[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "判断题");            //题目类型        
            DataSet ds3 = DB.GetDataSet("Proc_PaperDetail", Params3);
            if (ds3.Tables[0].Rows.Count > 0)
            {
                GridView3.DataSource = ds3;
                GridView3.DataBind();
                ((Label)GridView3.HeaderRow.FindControl("Label29")).Text = ((Label)GridView3.Rows[0].FindControl("Label12")).Text;
            }
            SqlParameter[] Params4 = new SqlParameter[2];
            Params4[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperID);               //试卷编号
            Params4[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "填空题");            //题目类型        
            DataSet ds4 = DB.GetDataSet("Proc_PaperDetail", Params4);
            if (ds4.Tables[0].Rows.Count > 0)
            {
                GridView4.DataSource = ds4;
                GridView4.DataBind();
                ((Label)GridView4.HeaderRow.FindControl("Label30")).Text = ((Label)GridView4.Rows[0].FindControl("Label17")).Text;
            }
            SqlParameter[] Params5 = new SqlParameter[2];
            Params5[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperID);               //试卷编号
            Params5[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "问答题");            //题目类型        
            DataSet ds5 = DB.GetDataSet("Proc_PaperDetail", Params5);
            if (ds5.Tables[0].Rows.Count > 0)
            {
                GridView5.DataSource = ds5;
                GridView5.DataBind();
                ((Label)GridView5.HeaderRow.FindControl("Label31")).Text = ((Label)GridView5.Rows[0].FindControl("Label21")).Text;
            }

        }
        

    }
    //提交试卷
    protected void imgBtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        deleteData();
        PageSubmit();            
        InitData();//绑定试题
        LinkButton2.Visible = true;

    }
    public void PageSubmit()
    {
        int paperid = Convert.ToInt32(Session["PaperID"].ToString());
        DataBase db = new DataBase();

        //取出单选题的每题分值
        if (GridView11.Rows.Count > 0)
        {
            int singlemark = int.Parse(((Label)GridView11.Rows[0].FindControl("Label4")).Text);
            foreach (GridViewRow dr in GridView11.Rows)
            {
                string str = "";
                if (((RadioButton)dr.FindControl("RadioButton1")).Checked)
                {
                    str = "A";
                }
                else if (((RadioButton)dr.FindControl("RadioButton2")).Checked)
                {
                    str = "B";
                }
                else if (((RadioButton)dr.FindControl("RadioButton3")).Checked)
                {
                    str = "C";
                }
                else if (((RadioButton)dr.FindControl("RadioButton4")).Checked)
                {
                    str = "D";
                }

                int titleid = int.Parse(((Label)dr.FindControl("Label40")).Text);
                string single = "insert into UserAnswertb(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + Session["userID"].ToString() + "','" + paperid + "','单选题','" + titleid + "','" + singlemark + "','" + str + "','" + DateTime.Now.ToString() + "')";
                db.Insert(single);
            }
        }


        //取出多选题每题分值
        if (GridView2.Rows.Count > 0)
        {
            int multimark = int.Parse(((Label)GridView2.Rows[0].FindControl("Label8")).Text);
            foreach (GridViewRow dr in GridView2.Rows)//对多选题每题进行判断用户选择答案
            {
                string str = "";
                if (((CheckBox)dr.FindControl("CheckBox1")).Checked)
                {
                    str += "A";
                }
                if (((CheckBox)dr.FindControl("CheckBox2")).Checked)
                {
                    str += "B";
                }
                if (((CheckBox)dr.FindControl("CheckBox3")).Checked)
                {
                    str += "C";
                }
                if (((CheckBox)dr.FindControl("CheckBox4")).Checked)
                {
                    str += "D";
                }
                int titleid = int.Parse(((Label)dr.FindControl("Label41")).Text);
                string Multi = "insert into UserAnswertb(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + Session["userID"].ToString() + "','" + paperid + "','多选题','" + titleid + "','" + multimark + "','" + str + "','" + DateTime.Now.ToString() + "')";
                db.Insert(Multi);
            }
        }


        //取出判断题每题分值
        if (GridView3.Rows.Count > 0)
        {
            int judgemark = int.Parse(((Label)GridView3.Rows[0].FindControl("Label12")).Text);
            foreach (GridViewRow dr in GridView3.Rows)//对判断题每题进行判断用户选择答案
            {
                string str = "";
                RadioButton rb5 = (RadioButton)dr.FindControl("RadioButton5");
                RadioButton rb6 = (RadioButton)dr.FindControl("RadioButton6");
                if (rb5.Checked)
                {
                    str = Convert.ToString(true);
                }
                if (rb6.Checked)
                {
                    str = Convert.ToString(false);
                }
                int titleid = int.Parse(((Label)dr.FindControl("Label42")).Text);
                string Judge = "insert into UserAnswertb(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + Session["userID"].ToString() + "','" + paperid + "','判断题','" + titleid + "','" + judgemark + "','" + str + "','" + DateTime.Now.ToString() + "')";
                db.Insert(Judge);
            }
        }
        

        
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
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
        if (GridView4.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView4.Rows)//对判断题每题进行判断用户选择答案
            {
                ((Label)dr.FindControl("Label26")).Visible = true;

            }
        }
        if (GridView5.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView5.Rows)//对判断题每题进行判断用户选择答案
            {
                ((TextBox)dr.FindControl("TextBox3")).Visible = true;

            }
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        deleteData();
        Page.RegisterStartupScript("", "<script>location='UserTest.aspx';</script>");
    }

    public void deleteData()
    {
        string Connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection cn = new SqlConnection(Connection);
        try
        {
            string userid = Session["UserID"].ToString();
            int PaperID = int.Parse(Session["PaperID"].ToString());          
            cn.Open();
            string sql = string.Format("delete from UserAnswertb where UserID='" + userid + "' and PaperID='" + PaperID + "'");
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();           
        }
        catch
        {
            Page.RegisterStartupScript("", "<script>location='../default.aspx';</script>");
        }
        finally
        {
            cn.Close();
        }
    }
}