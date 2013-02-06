<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="UserManage.aspx.cs" Inherits="Admin_UserManage" Title="用户管理" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h4>&gt;&gt;用户管理</h4>  
                                        <hr/>
                ※用户ID：
                <asp:TextBox ID="tbxUserID" runat="server" Width="66px"></asp:TextBox>
                                         ※姓名：  <asp:TextBox ID="tbxUserName" runat="server" Width="66px"></asp:TextBox>
                                        <asp:ImageButton ID="ImageButtonQuery" runat="server" ImageUrl="../Images/BtnQuery.gif" OnClick="ImageButtonQuery_Click"></asp:ImageButton>
                                         <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../Images/BtnBack.gif" OnClick="ImageButtonBack_Click"></asp:ImageButton><br />
                                        
                       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="8" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound"  OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="UserID"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="13px" Width="100%">
                    <Columns>    
                    <asp:TemplateField>
                           <ItemTemplate>
                              <asp:CheckBox ID="chkSelected" runat="server" Checked="False" Visible="True" /></ItemTemplate>
                         </asp:TemplateField>
                    <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>                                        
                        <asp:TemplateField HeaderText="用户ID">                           
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="姓名">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbxName" Width="70px" runat="server" Text='<%# Eval("UserName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server"><%# Eval("UserName") %></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="角色">
                            <EditItemTemplate>                                
                                <asp:DropDownList ID="ddlRole" runat="server" Width="80px" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server"><%# Eval("RoleName") %></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>   
                        
                        <asp:CommandField ShowEditButton="True" HeaderText="编辑" />
                        <asp:TemplateField ShowHeader="False" HeaderText="删除" > 
                            <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('此操作还将删除与用户相关的一切考试信息！ 确定删除？');" 
                                            Text="删除"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                       <FooterStyle BackColor="White" ForeColor="#000066" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                 <asp:Label ID="LabelPageInfo" runat="server"></asp:Label>
                <br /><asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="true" Text="全选" Width="54px" OnCheckedChanged="chkSelectAll_CheckedChanged" />
                <asp:HyperLink ID="HyperLinkAdd" runat="server" ImageUrl="../Images/BtnAdd.gif" NavigateUrl="UserAdd.aspx">HyperLink</asp:HyperLink>
                &nbsp;<asp:ImageButton ID="ImageButtonDelete" runat="server" ImageUrl="../Images/BtnDelete.gif" OnClientClick="return confirm('该操作将删除对应用户的所有信息！ 确定删除？')" OnClick="ImageButtonDelete_Click"></asp:ImageButton>
                &nbsp;<asp:ImageButton ID="ImageButtonResetPassword" runat="server" ImageUrl="../Images/BtnResetPassword.gif" OnClientClick="return confirm('确定重置用户密码吗？')" OnClick="ImageButtonResetPassword_Click"></asp:ImageButton>
                                  

</asp:Content>

