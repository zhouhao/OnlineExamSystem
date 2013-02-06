<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="UserScore.aspx.cs" Inherits="Admin_UserPaper" Title="试卷审核" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h4>&gt;&gt;成绩管理<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/导出EXCEL}.gif" 
                                          OnClick="ImageButton2_Click" />
                                      </h4>  
                      <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                          OnRowDataBound="GridView1_RowDataBound" 
                                          OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="12" 
                                          AutoGenerateColumns="False" DataKeyNames="ID" Font-Size="13px" Width="100%"  
                                          OnRowDeleting="GridView1_RowDeleting" SkinID="gvSkin" Height="100%" >
                    <Columns>                       
                        <asp:TemplateField HeaderText="成绩编号" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server"><%# Eval("ID") %></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="用户ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserID" runat="server"><%# Eval("UserID") %></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                           
                            <asp:BoundField DataField="UserName" HeaderText="姓名" />
                            <asp:TemplateField HeaderText="试卷">
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("PaperName") %>'></asp:Label>
                                    <asp:Label ID="lblPaperID" runat="server" Text='<%# Eval("PaperID") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                                    
                            <asp:TemplateField HeaderText="成绩">                                
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server"><%# Eval("Score") %></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" />
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="考试时间">                                
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server"><%# Eval("ExamTime") %></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" />
                            </asp:TemplateField>                                
                           <asp:TemplateField HeaderText="评卷时间">                                
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server"><%# Eval("JudgeTime") %></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" />
                            </asp:TemplateField>                                                    
                        <asp:CommandField ShowDeleteButton="True" HeaderText="删除" >
                            <HeaderStyle Wrap="False" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
              <br /> 

</asp:Content>

