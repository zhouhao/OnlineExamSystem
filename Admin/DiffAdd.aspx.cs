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

public partial class Admin_DiffAdd : System.Web.UI.Page
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

    }
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            Diff Diff = new Diff();               //创建试卷难度对象
            Diff.DiffName = txtName.Text;                 //设置试卷难度对象属性
            if (Diff.InsertByProc())                  //调用添加试卷难度方法添加试卷难度
            {
                lblMessage.Text = "成功添加该试卷难度！";
                txtName.Text = "";

            }
            else
            {
                lblMessage.Text = "添加该试卷难度失败！";
            }

        }
    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Server.Transfer("DiffManage.aspx");
    }
}
