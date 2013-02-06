<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="PaperLists.aspx.cs" Inherits="Admin_PaperLists" Title="试卷管理" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <h4>&gt;&gt;试卷管理</h4>  
                                        <hr/><asp:Label runat="server" ID="lblMessage" Text=""></asp:Label>
                       <asp:GridView ID="GridView1" runat="server"　AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="12" OnRowDataBound="GridView1_RowDataBound" Width=100% AutoGenerateColumns="False" DataKeyNames="PaperID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" CellPadding="3" Font-Size="13px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" >
                    <Columns>
                        <asp:TemplateField HeaderText="编号" Visible=False>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"><%# Eval("PaperID") %></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="试卷科目">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server"><%# Eval("Name") %></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Wrap="False" />
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="试卷名称">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server"><%# Eval("PaperName") %></asp:Label>
                            </ItemTemplate>                            
                            <HeaderStyle Wrap="False" />
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="考试时间">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server"><%# getTime(DataBinder.Eval(Container.DataItem, "NeedTime").ToString())%></asp:Label>
<%--                                 <asp:Label ID="Label5" runat="server"><%# bool.Parse(Eval("NeedTime").ToString())?int.Parse(Eval("NeedTime").ToString())/60 %>分<%# int.Parse(Eval("NeedTime").ToString())%60 %>秒</asp:Label>--%>
                            </ItemTemplate>                            
                            <HeaderStyle Wrap="False" />
                        </asp:TemplateField>
                                                                           
                        <asp:HyperLinkField DataNavigateUrlFields="PaperID" DataNavigateUrlFormatString="PaperDetail.aspx?PaperID={0}" HeaderText="详细..." Text="详细..." >
                            <HeaderStyle Wrap="False" />
                        </asp:HyperLinkField>
                        <asp:TemplateField HeaderText="试卷状态">
                        <ItemTemplate>
                            <asp:Label ID="LabelPaperState" runat="server"  Text='<%# bool.Parse(Eval("PaperState").ToString())?"可用":"不可用" %>'></asp:Label>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("PaperID", "isAvailble.aspx?PaperID={0}") %>'
                                Text='<%# bool.Parse(Eval("PaperState").ToString())?"设为不可用":"设为可用" %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>   
                        <asp:CommandField ShowDeleteButton="True" HeaderText="删除" >
                            <HeaderStyle Wrap="False" />
                        </asp:CommandField>
                    </Columns>
                       <FooterStyle BackColor="White" ForeColor="#000066" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                     
              

</asp:Content>

