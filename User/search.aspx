<%@ Page Title="试题检索" Language="C#" MasterPageFile="~/User/MasterPage2.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="User_search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Panel ID="Panel1" runat="server" CssClass="panel">
            <table border="1px">
                <tr>
                    <td>
                        题型： 
                    </td>
                    <td>
                        <asp:CheckBoxList ID="CBLProblemClass" runat="server" 
                            onselectedindexchanged="CBLProblemClass_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="1" Selected="True">单选题 </asp:ListItem>
                            <asp:ListItem Value="2" Selected="True">多选题 </asp:ListItem>
                            <asp:ListItem Value="3" Selected="True">判断题 </asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>
                        关键字：</td>
                    <td>
                        <asp:TextBox ID="tbKeyWord" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="检索" />
                    </td>
                </tr>
                 <tr>
                    <td> <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">显示答案</asp:LinkButton>
                    </td>
                     
                    <td>
                        <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">隐藏答案</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td> &nbsp;
                    </td>
                     
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" 
                    NavigateUrl="~/User/Default.aspx" >返回首页</asp:HyperLink>
                    </td>
                </tr>
            </table>
             </asp:Panel>

    <table width="80%">
        <tr>
            <td>
                <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="False" 
                    Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label24" runat="server" Text="一、单选题"> </asp:Label>
                                <br />
                                <br />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <TABLE ID="Table2" align="center" border="0" cellPadding="1" cellSpacing="1" 
                                    width="100%">
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>">
                                            </asp:Label>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            A:<asp:RadioButton ID="RadioButton1" runat="server" GroupName="Sl" 
                                                Text='<%# Eval("AnswerA") %>' />
                                        </td>
                                        <td width="35%">
                                            B:<asp:RadioButton ID="RadioButton2" runat="server" GroupName="Sl" 
                                                Text='<%# Eval("AnswerB") %>' />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            C:<asp:RadioButton ID="RadioButton3" runat="server" GroupName="Sl" 
                                                Text='<%# Eval("AnswerC") %>' />
                                        </td>
                                        <td width="35%">
                                            D:<asp:RadioButton ID="RadioButton4" runat="server" GroupName="Sl" 
                                                Text='<%# Eval("AnswerD") %>' />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"> <asp:Label id="lbSingleAnswer" runat="server" Visible="false" Text='<%# Eval("Answer") %>'></asp:Label></td>
                                    </tr>
                                </TABLE>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label22" runat="server" Text="二、多选题"> </asp:Label>
                                <br />
                                <br />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <TABLE ID="Table3" align="center" border="0" cellPadding="1" cellSpacing="1" 
                                    width="100%">
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="Label5" runat="server" Text="<%# Container.DataItemIndex+1 %>">
                                            </asp:Label>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="HEIGHT: 22px" width="35%">
                                            A:<asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("AnswerA") %>' />
                                        </td>
                                        <td style="HEIGHT: 22px" width="35%">
                                            B:<asp:CheckBox ID="CheckBox2" runat="server" Text='<%# Eval("AnswerB") %>' />
                                        </td>
                                        <td style="HEIGHT: 22px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            C:<asp:CheckBox ID="CheckBox3" runat="server" Text='<%# Eval("AnswerC") %>' />
                                        </td>
                                        <td width="350%">
                                            D:<asp:CheckBox ID="CheckBox4" runat="server" Text='<%# Eval("AnswerD") %>' />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"> <asp:Label id="lbMultiAnswer" runat="server" Visible="false" Text='<%# Eval("Answer") %>'></asp:Label></td>
                                    </tr>
                                </TABLE>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                    PageSize="2" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label20" runat="server" Text="三、判断题"> </asp:Label>
                                <br />
                                <br />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <TABLE ID="Table4" align="center" border="0" cellPadding="1" cellSpacing="1" 
                                    width="100%">
                                    <tr>
                                        <td width="80%">
                                            <asp:Label ID="Label9" runat="server" Text="<%# Container.DataItemIndex+1 %>">
                                            </asp:Label>
                                            <asp:Label ID="Label10" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                            </asp:Label>
                                        </td>
                                        <td width="10%">
                                            <asp:RadioButton ID="RadioButton5" runat="server" Text="正确" GroupName="judge"/>
                                        </td>
                                        <td width="10%">
                                            <asp:RadioButton ID="RadioButton6" runat="server" Text="错误" GroupName="judge"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"> <asp:Label id="lbJudgeAnswer" runat="server" Visible="false" Text='<%# Eval("Answer") %>'></asp:Label></td>
                                    </tr>
                                </TABLE>
                                            
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                </asp:GridView>
            </td>
        </tr>                   
</table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="CBLProblemClass" 
                EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
   

</asp:Content>

