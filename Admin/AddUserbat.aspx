<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AddUserbat.aspx.cs" Inherits="Admin_AddUserbat" Title="批量添加用户" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 576px; border-collapse: separate; text-align: center">
        <tr>
            <td colspan="3">
                &nbsp;Excel导入SQL数据库</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: left">
                &nbsp; &nbsp;&nbsp;<asp:FileUpload ID="FileUpload1" runat="server" Width="305px" Height="22px" />
                &nbsp; &nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="导入SQL" /></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView1" runat="server" Height="133px" Width="100%">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

