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
using OnLineExam.AjaxClass;

public partial class Admin_CourseAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Page.RegisterStartupScript("",  "<script>location='../default.aspx';</script>");
        }
        if (Convert.ToInt32(Session["roleID"]) == 5)
        {
            Page.RegisterStartupScript("", "<script>alert('你登录的用户权限不够！');location='../default.aspx'</script>");
        }

    }
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            Course course = new Course();               //创建试卷科目对象
            if (course.IsCourseNameExist(txtName.Text.Trim()))
            {
                AjaxCommond ac = new AjaxCommond();
                ac.OpenDialogForButton((ImageButton)sender, "该名称已被占用！！！");
                txtName.Text = "";
            }
            else
            {
                course.Name = txtName.Text;                 //设置试卷科目对象属性
                if (course.InsertByProc())                  //调用添加试卷科目方法添加试卷科目
                {
                    lblMessage.Text = "成功添加该试卷科目！";
                    txtName.Text = "";

                }
                else
                {
                    lblMessage.Text = "添加该试卷科目失败！";
                }
            }
            

        }
    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Page.RegisterStartupScript("", "<script>location='CourseManage.aspx';</script>");
        //Server.Transfer("CourseManage.aspx");
    }
}
