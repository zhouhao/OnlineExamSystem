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


public partial class Admin_RoleAdd : System.Web.UI.Page
{
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
    }
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            Role role = new Role();       //创建Users对象
            role.RoleName = txtRoleName.Text.Trim();
            if (!role.CheckRole(role.RoleName))//使用CheckRole方法验证角色名是否存在
            {
                role.RoleName = txtRoleName.Text;
                role.HasDuty_CourseManage = Convert.ToInt32("0");
                role.HasDuty_FillBlankManage = Convert.ToInt32("0");
                role.HasDuty_JudgeManage = Convert.ToInt32("0");
                role.HasDuty_MultiSelectManage = Convert.ToInt32("0");
                role.HasDuty_PaperLists = Convert.ToInt32("0");
                role.HasDuty_PaperSetup = Convert.ToInt32("0");
                role.HasDuty_QuestionManage = Convert.ToInt32("0");
                role.HasDuty_RoleManage = Convert.ToInt32("0");
                role.HasDuty_Role = Convert.ToInt32("0");
                role.HasDuty_SingleSelectManage = Convert.ToInt32("0");
                role.HasDuty_UserManage = Convert.ToInt32("0");
                role.HasDuty_UserScore = Convert.ToInt32("0");
                if (role.InsertByProc())
                {
                    lblMessage.Text = "成功插入该角色信息！";
                    Server.Transfer("RoleManage.aspx");
                }
                else
                {
                    lblMessage.Text = "添加角色失败！";
                }
            }
            else//用户存在，给出提示
            {
                lblMessage.Text = "数据库中存在具有该名称的角色，请重新输入！";
            }
        }
    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Server.Transfer("Role.aspx");
    }
}