<%@ Page Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="User_Default" Title="考生首页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table cellpadding="0" cellspacing="0" border="1"  bordercolor="#cccccc" style="border-collapse:collapse" width="100%" frame="below">
               
               <tr style="text-align:right;width:100%;">
                    <td bgcolor="#EDF1F6"> 
                    <div class="title" align="left"><h4>
                        在线测验：</h4></div></td>                    
                
                    <td bgcolor="#EDF1F6" style="text-align:right;">
                        检测试题：</td>
                    <td ><div align="left"><asp:DropDownList id="ddlTestPaper" runat="server" Width="127px"></asp:DropDownList>
                    <a href="#TB_inline?height=600&width=800&inlineId=myOnPageContent" title="在线测试试题列表" class="thickbox" type="button">试卷列表</a>
                     <asp:Label ID="lblTestMessage" runat="server" ForeColor="red"></asp:Label>
                       </div>
                    </td>
                
                    <td>
                       <div align="left"><br /><a href="javasricpt:location.replace('UserTest.aspx')">
                           <asp:ImageButton ID="ImgStartTest" runat="server" Height="21px" 
                               ImageUrl="~/images/kcks_04.jpg" onclick="ImgStartTest_Click" Width="85px" 
                               CausesValidation="False" />
                           </a>
                           </div></td>
                    
                </tr>
                <tr>
                    <td bgcolor="#EDF1F6"> <div class="title" align="left"><h4>
                        模拟考试：</h4></div></td>                    
                
                    <td bgcolor="#EDF1F6" style="text-align:right;">
                        模拟试题：</td>
                    <td ><div align="left"><asp:DropDownList id="ddlPaper" runat="server" Width="127px"></asp:DropDownList>
                     <asp:Label ID="lblExamMessage" runat="server" ForeColor="red"></asp:Label>
                       </div>
                    </td>
                
                    <td>
                       <div><br /><a href="javasricpt:location.replace('UserExam.aspx')">
                           <asp:ImageButton ID="ImgStartExam" runat="server" Height="21px" 
                               ImageUrl="~/images/kcks_03.jpg" onclick="ImgStartExam_Click" Width="85px" 
                               CausesValidation="False" />
                           </a>
                       <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/User/intro.aspx" Target="_blank">阅读考试说明</asp:HyperLink></div></td>
                       
                </tr>
                <tr>
                    <td bgcolor="#EDF1F6"><div class="title" align="left"><h4>试题检索：</h4></div></td>
                    <td  bgcolor="#EDF1F6" style="text-align:right;">关键字：</td>
                    <td><asp:TextBox ID="tbKeyWord" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:LinkButton ID="LinkButton3" runat="server"  onclick="LinkButton3_Click">检索</asp:LinkButton>
                    </td>
                </tr>
            
                 <tr>
                    <td bgcolor="#EDF1F6" style="text-align:right;width:100%;" colspan="4"> <div class="title" align="left"><h4>
                        模考成绩记录：<asp:Label ID="lblScore" runat="server" Text="" Width="126px"></asp:Label>
                        <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">显示/隐藏</asp:LinkButton>
                        </h4></div></td>                    
                </tr>
                <tr>
                    <td  style="text-align:right;" colspan="4">
                        <div align="left">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataKeyNames ="UserID,PaperID" 
                                          OnRowDataBound="GridView1_RowDataBound" 
                                          OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="8" 
                                          AutoGenerateColumns="False" Font-Size="13px" Width="100%" 
                                          OnRowDeleting="GridView1_RowDeleting" SkinID="gvSkin">
                    <Columns>                       
                        <asp:TemplateField HeaderText="成绩编号" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server"><%# Eval("ID") %></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="姓名">                               
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server"><%# Eval("UserName") %></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" />
                            </asp:TemplateField>
                             <asp:HyperLinkField DataNavigateUrlFields="UserID,PaperID" 
                               DataNavigateUrlFormatString="UserPaper.aspx?UserID={0}&amp;PaperID={1}" 
                               DataTextField="PaperName" Target="_blank" HeaderText="试卷(点击查看)">                       
                           <ItemStyle Font-Bold="True"></ItemStyle>
                           </asp:HyperLinkField>
                            <asp:TemplateField HeaderText="成绩">                                
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server"><%# Eval("Score") %></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" />
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="开始考试时间">                                
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server"><%# Eval("ExamTime") %></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" />
                            </asp:TemplateField>  
                            <asp:BoundField DataField="JudgeTime" HeaderText="评卷时间" />                     
                            <asp:BoundField DataField="PingYu" HeaderText="评语" />
                    </Columns>                 
                </asp:GridView>  
                <asp:Label ID="LabelPageInfo" runat="server"></asp:Label> 
                       
                       </div>
                        </td>
                </tr>
            </table>         

    <div id="myOnPageContent" style="display:none;">   
        <iframe style="width: 780px; height:580px;" frameborder="0" name="mainFrame"  src="paperlist.aspx">
        </iframe>      
    </div>
</asp:Content>

