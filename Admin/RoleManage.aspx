<%@ Page Title="角色管理" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="RoleManage.aspx.cs" Inherits="Admin_RoleManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h4>&gt;&gt;权限管理</h4>  
                                        <hr/>
                       <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="12"
                                            OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" CellPadding="3" Font-Size="13px" Width="100%">
                           <Columns>
                             <asp:BoundField DataField="RoleId" HeaderText="编号" />
                             <asp:BoundField DataField="RoleName" HeaderText="角色" />
                                            
                                                <asp:TemplateField HeaderText="用户信息管理">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkUserManage" Visible="True" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                                
                                                <asp:TemplateField HeaderText="试卷科目管理">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkCourseManage" Visible="True" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="试卷制定维护">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkPaperSetup" Visible="True" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="用户试卷管理">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkUserPaperList" Visible="True" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="试题类别管理">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkTypeManage" Visible="True" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                    </Columns>
                       <FooterStyle BackColor="White" ForeColor="#000066" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                <br /><p align="center"><asp:ImageButton ID="ImageButtonGiant" runat="server" ImageUrl="~\Images\BtnGiant.gif" OnClick="ImageButtonGiant_Click"></asp:ImageButton></p>
                <br /><a href="Role.aspx" style="font-size: medium;"><font color="red"><u>角色管理</u></font></a>      
</asp:Content>

