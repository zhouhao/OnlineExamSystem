<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="QuestionManage.aspx.cs" Inherits="Admin_QuestionManage" Title="问答题管理" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<h4>&gt;&gt;问答题管理</h4>  
                                        <hr/> <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate><p align="left"><asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" Width="130px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList></p>
                      <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="12" OnRowDataBound="GridView1_RowDataBound" DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" CellPadding="3" Font-Size="13px" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>                       
                        <asp:TemplateField HeaderText="编号" Visible=false>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"><%# Eval("ID") %></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                 <center><asp:Label id="Label10" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label></center>
                            </ItemTemplate>
                        </asp:TemplateField> 
                          <asp:BoundField DataField="Title" HeaderText="题目" />
                                                                                   
                        <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="QuestionAdd.aspx?ID={0}" HeaderText="详细..." Text="详细..." />                                           
                        
                        <asp:CommandField ShowDeleteButton="True" HeaderText="删除" />
                    </Columns>
                       <FooterStyle BackColor="White" ForeColor="#000066" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
               
               </ContentTemplate>
                       <Triggers>
                           <asp:AsyncPostBackTrigger ControlID="ddlCourse" EventName="SelectedIndexChanged" />
                       </Triggers>
                   </asp:UpdatePanel>
                      <br /><a href="QuestionAdd.aspx" style="font-size:medium;"><font color=red><u>添加问答题</u></font></a>          
              

</asp:Content>

