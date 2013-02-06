<%@ Page Language="C#" MasterPageFile="~/ADMIN/MasterPage.master" AutoEventWireup="true" CodeFile="PwdModify.aspx.cs" Inherits="ADMIN_PwdChange" Title="修改密码--管理员" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <table cellpadding="0" cellspacing="0" border="1"  bordercolor="#cccccc" style="border-collapse:collapse" width="100%" frame="below">
               <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;width:100%;" colspan="2"> <div class="title" align="left"><h4>修改密码</h4></div></td>                    
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align:right; height: 25px;">原密码：</td>
                    <td style="height: 25px" >&nbsp;<div align="left"><asp:TextBox id="txtOldPwd" runat="server" TextMode="Password" Width="170px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPwd" ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;">新密码：</td>
                    <td >&nbsp;<div align="left"><asp:TextBox id="txtNewPwd" runat="server" TextMode="Password" Width="170px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPwd"
                                ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div></td>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;">确认密码：</td>
                    <td >&nbsp;<div align="left"><asp:TextBox id="txtConfirmPwd"  runat="server" MaxLength="20" TextMode=password Width="168px"></asp:TextBox>
                       <asp:CompareValidator id="cpv_newpassword" runat="server" ErrorMessage="确认密码不一致" ControlToValidate="txtConfirmPwd" ControlToCompare="txtNewPwd"></asp:CompareValidator></div></td>
                </tr>
                
                <tr>
                    <td></td>
                    <td >&nbsp; <asp:Label ID="lblMessage" runat="server" ForeColor=red></asp:Label><br />
                       <asp:ImageButton ID="imgBtnModifyPwd" runat="server" ImageUrl="../Images/Update.GIF" OnClick="imgBtnModifyPwd_Click1"/>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
					   <asp:ImageButton ID="imgBtnReset" runat="server" CausesValidation="false" ImageUrl="../Images/RESET.GIF" OnClick="imgBtnReset_Click"  /></td>
                </tr>
            </table>         

</asp:Content>

