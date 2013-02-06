<%@ Page Title="Excel题导入" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Excel2Data.aspx.cs" Inherits="Admin_Excel2Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width: 576px; border-collapse: separate;">
        <tr>
            <td>题型：<asp:DropDownList ID="ddlProblemClass" runat="server">
                    <asp:ListItem>单选题</asp:ListItem>
                    <asp:ListItem>多选题</asp:ListItem>
                    <asp:ListItem>判断题</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                
                类别：<asp:DropDownList ID="ddlProblemCourse" runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                &nbsp; &nbsp;&nbsp;<asp:FileUpload ID="FileUpload1" runat="server" Width="305px" Height="22px" />
                &nbsp; &nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="导入SQL" /></td>
        </tr>
        <tr>
            <td>
                
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
                
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="SELECT * FROM [Course]"></asp:SqlDataSource>
</asp:Content>

