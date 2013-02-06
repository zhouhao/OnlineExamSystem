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

public partial class Admin_RoleManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Page.RegisterStartupScript("", "<script>location='../default.aspx';</script>");
        }
        if (Convert.ToInt32(Session["roleID"]) != 1)
        {
            Page.RegisterStartupScript("", "<script>alert('你登录的用户权限不够！');location='default.aspx'</script>");
        }

        else
        {
            if (!Page.IsPostBack)
            {
                InitData();
            }
        }
        
    }
    private void InitData()
    {
        DataTable dt = Role.Query(new Hashtable());
        GridView1.DataSource = dt;
        GridView1.DataBind();

        for (int i = 0; i < dt.Rows.Count; i++)
        {

            //用户管理
            if (Examination.DataAccessHelper.GetSafeData.ValidateDataRow_N(dt.Rows[i], "HasDuty_UserManage") == 1)
                ((CheckBox)GridView1.Rows[i].FindControl("chkUserManage")).Checked = true;

            //试卷科目管理
            if (Examination.DataAccessHelper.GetSafeData.ValidateDataRow_N(dt.Rows[i], "HasDuty_CourseManage") == 1)
                ((CheckBox)GridView1.Rows[i].FindControl("chkCourseManage")).Checked = true;

            //试卷制定维护
            if (Examination.DataAccessHelper.GetSafeData.ValidateDataRow_N(dt.Rows[i], "HasDuty_PaperSetup") == 1)
                ((CheckBox)GridView1.Rows[i].FindControl("chkPaperSetup")).Checked = true;

            //用户试卷管理
            if (Examination.DataAccessHelper.GetSafeData.ValidateDataRow_N(dt.Rows[i], "HasDuty_UserPaperList") == 1)
                ((CheckBox)GridView1.Rows[i].FindControl("chkUserPaperList")).Checked = true;

            //试题类别管理
            if (Examination.DataAccessHelper.GetSafeData.ValidateDataRow_N(dt.Rows[i], "HasDuty_SingleSelectManage") == 1)
                ((CheckBox)GridView1.Rows[i].FindControl("chkTypeManage")).Checked = true;



        }
    }
    protected void ImageButtonGiant_Click(object sender, ImageClickEventArgs e)
    {
        Hashtable ht = new Hashtable();
        string where = "";

        foreach (GridViewRow row in GridView1.Rows)
        {
            ht.Clear();
            ht.Add("HasDuty_UserManage", ((CheckBox)row.FindControl("chkUserManage")).Checked == true ? 1 : 0);
            ht.Add("HasDuty_RoleManage", ((CheckBox)row.FindControl("chkUserManage")).Checked == true ? 1 : 0);
            ht.Add("HasDuty_Role", ((CheckBox)row.FindControl("chkUserManage")).Checked == true ? 1 : 0);
            ht.Add("HasDuty_CourseManage", ((CheckBox)row.FindControl("chkCourseManage")).Checked == true ? 1 : 0);
            ht.Add("HasDuty_PaperSetup", ((CheckBox)row.FindControl("chkPaperSetup")).Checked == true ? 1 : 0);
            ht.Add("HasDuty_PaperLists", ((CheckBox)row.FindControl("chkPaperSetup")).Checked == true ? 1 : 0);
            ht.Add("HasDuty_UserPaperList", ((CheckBox)row.FindControl("chkUserPaperList")).Checked == true ? 1 : 0);
            ht.Add("HasDuty_UserScore", ((CheckBox)row.FindControl("chkUserPaperList")).Checked == true ? 1 : 0);

            ht.Add("HasDuty_SingleSelectManage", ((CheckBox)row.FindControl("chkTypeManage")).Checked == true ? 1 : 0);
            ht.Add("HasDuty_MultiSelectManage", ((CheckBox)row.FindControl("chkTypeManage")).Checked == true ? 1 : 0);
            ht.Add("HasDuty_FillBlankManage", ((CheckBox)row.FindControl("chkTypeManage")).Checked == true ? 1 : 0);
            ht.Add("HasDuty_JudgeManage", ((CheckBox)row.FindControl("chkTypeManage")).Checked == true ? 1 : 0);
            ht.Add("HasDuty_QuestionManage", ((CheckBox)row.FindControl("chkTypeManage")).Checked == true ? 1 : 0);

            where = " Where RoleId=" + row.Cells[0].Text;
            Role.Update(ht, where);
        }
        Page.RegisterStartupScript("", "<script>alert('授权成功！');</script>");
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        InitData();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int i;
        //执行循环，保证每条数据都可以更新
        for (i = 0; i < GridView1.Rows.Count; i++)
        {
            //首先判断是否是数据行
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标停留时更改背景色
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#E4ECFB'");
                //当鼠标移开时还原背景色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
        }
    }
}