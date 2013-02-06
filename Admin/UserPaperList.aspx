<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="UserPaperList.aspx.cs" Inherits="Admin_UserPaperList" Title="考试列表" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <h4>&gt;&gt;用户试卷评阅</h4>  
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataKeyNames ="UserID,PaperID" 
                                          OnRowDataBound="GridView1_RowDataBound" 
                                          OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="8" 
                                          AutoGenerateColumns="False" Font-Size="13px" Width="100%" 
                                          OnRowDeleting="GridView1_RowDeleting" SkinID="gvSkin">
                    <Columns> 
                           <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True"/>
                            <asp:BoundField DataField="PaperID" Visible="False" HeaderText="PaperID" ReadOnly="True"/>
                            <asp:TemplateField HeaderText="用户姓名">                               
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server"><%# Eval("UserName") %></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" />
                            </asp:TemplateField>
                             <asp:HyperLinkField DataNavigateUrlFields="UserID,PaperID" 
                               DataNavigateUrlFormatString="UserPaper.aspx?UserID={0}&amp;PaperID={1}" 
                               DataTextField="PaperName" HeaderText="试卷(点击查看)">                       
<ItemStyle Font-Bold="True"></ItemStyle>
                           </asp:HyperLinkField>
                            <asp:TemplateField HeaderText="考试时间">                                
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server"><%# Eval("ExamTime") %></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" />
                            </asp:TemplateField>    
                            <asp:BoundField HeaderText="是否评阅" DataField="state" /> 
                              <%-- <asp:CommandField ShowDeleteButton="True" HeaderText="删除" />--%>
                            <asp:TemplateField ShowHeader="False" HeaderText="删除" > 
                                <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('这将删除对应的考试信息，确定删除？');" 
                                                Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                    </Columns>
                </asp:GridView>                      
               <asp:Label ID="LabelPageInfo" runat="server"></asp:Label>
                <br />

</asp:Content>

