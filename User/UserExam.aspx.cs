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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
             Page.RegisterStartupScript("",  "<script>location='../default.aspx';</script>");
        }
        else
        {
            this.lbtime.Text = this.index / 60 + "分后自动提交试卷！";
            if (!IsPostBack)
            {
                imgBtnSubmit.Attributes.Add("OnClick", "javascript:return confirm('确实要交卷吗？')");
                lblPaperName.Text = Session["PaperName"].ToString();
                InitData();
                this.lblend.Visible = false;
            }
        }
    }
    //初始化试卷，从数据库中将试题取出
    protected void InitData()
    {
        DataBase DB = new DataBase();
        int paperID = int.Parse(Session["PaperID"].ToString());
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
            ((Label)GridView4.HeaderRow.FindControl("Label45")).Text = ((Label)GridView4.Rows[0].FindControl("Label17")).Text;
        }
        SqlParameter[] Params5 = new SqlParameter[2];
        Params5[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperID);               //试卷编号
        Params5[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "问答题");            //题目类型        
        DataSet ds5 = DB.GetDataSet("Proc_PaperDetail", Params5);
        if (ds5.Tables[0].Rows.Count > 0)
        {
            GridView5.DataSource = ds5;
            GridView5.DataBind();
            ((Label)GridView5.HeaderRow.FindControl("Label31")).Text = ((Label)GridView5.Rows[0].FindControl("Label37")).Text;
        }
    }
    //提交试卷
    protected void imgBtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        if (index > 0)
        {
            PageSubmit();
            Page.RegisterStartupScript("", "<script language=javascript>alert('试卷已提交!');location='Default.aspx'</script>");
            this.imgBtnSubmit.Enabled = false;
            imgBtnSubmit.Visible = false;
        }
        if (index == 0)
        {
            BindData();
        }
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
                //CheckBox cbox5 = (CheckBox)dr.FindControl("CheckBox5");
                //CheckBox cbox6 = (CheckBox)dr.FindControl("CheckBox6");
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
        //取出填空题每题分值
        if (GridView4.Rows.Count > 0)
        {
            int fillmark = int.Parse(((Label)GridView4.Rows[0].FindControl("Label17")).Text);
            foreach (GridViewRow dr in GridView4.Rows)
            {
                string str = "";
                str = ((TextBox)dr.FindControl("TextBox1")).Text.Trim();
                int titleid = int.Parse(((Label)dr.FindControl("Label43")).Text);
                string Fill = "insert into UserAnswertb(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + Session["userID"].ToString() + "','" + paperid + "','填空题','" + titleid + "','" + fillmark + "','" + str + "','" + DateTime.Now.ToString() + "')";
                db.Insert(Fill);
            }
        }
        //取出问答题每题分值
        if (GridView5.Rows.Count > 0)
        {
            int quemark = int.Parse(((Label)GridView5.Rows[0].FindControl("Label37")).Text);
            foreach (GridViewRow dr in GridView5.Rows)
            {
                string str = "";
                str = ((TextBox)dr.FindControl("TextBox2")).Text.Trim();
                int titleid = int.Parse(((Label)dr.FindControl("Label44")).Text);
                string Que = "insert into UserAnswertb(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + Session["userID"].ToString() + "','" + paperid + "','问答题','" + titleid + "','" + quemark + "','" + str + "','" + DateTime.Now.ToString() + "')";
                db.Insert(Que);
            }
        }
        TempExam te = new TempExam();
        te.DeleteTempExam(Session["UserID"].ToString(), Convert.ToInt32(Session["PaperID"]));
    }

    //触发Timer控件的Timer1_Tick事件实现考试倒计时功能
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        this.index--;
        //考试时间到了
        if (this.index <= 0)//不能只设置等于0
        {
            //设置Timer控件不可见
            this.Timer1.Enabled = false;
            // BindData();
            PageSubmit();
            Response.Redirect("Default.aspx");
        }
        else
        {
            //显示考试剩余时间
            this.lbtime.Text = this.index / 60 + "分" + this.index % 60 + "秒将停止考试，请及时“提交”试卷，保存考试结果！";
        }
    }
    /// <summary>
    /// 定义在线考试总时间变量index,
    /// 并设置读写属性
    /// </summary>
    private int index
    {
        get
        {
            return Convert.ToInt32(Session["time"]);
        }
        set
        {
            Session["time"] = value;
        }
    }
    public void BindData()
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        int paperid = Convert.ToInt32(Session["PaperID"].ToString());
        string strsql = "insert into UserAnswertb(UserID,PaperID,ExamTime) values('" + Session["userID"].ToString() + "','" + paperid + "','" + DateTime.Now.ToString() + "')";
        SqlConnection mycon = new SqlConnection(ConnectionString);
        SqlCommand mycmd = new SqlCommand(strsql, mycon);
        mycon.Open();
        mycmd.ExecuteNonQuery();
        mycon.Close();
    }

}
