<%@ Page Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="UserExam.aspx.cs" Inherits="User_UserTest" Title="在线考试" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="margin-left:auto; margin-right:auto;">
<table width="100%">
    <tr height="40">
           <td align="center">
                            <a name="top"></a><font color="#4D2600" size="5">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                            <asp:Label ID="Label7" runat="server" Text="考试试题：" />
                            <asp:Label ID="Label30" runat="server" Text="&lt;&lt;" />
                            <asp:Label ID="lblPaperName" runat="server"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text="&gt;&gt;" />
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table class="style1">
                                        <tr>
                                            <td class="style2">
                                                <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick">
                                                </asp:Timer>
                                            </td>
                                            <td class="style3">
                                                <asp:Label ID="lbtime" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td class="style4">
                                                <font color="#4D2600" size="5">
                                                <font color="#4D2600" size="5">
                                                
                                                </font><font color="#4D2600" size="5">
                                               
                                                </font><font color="#4D2600" size="5">
                                                <font color="#4D2600" size="5">
                                                <asp:Label ID="lblend" runat="server" Text="Label"></asp:Label>
                            </font>
                                                </font></td>
                                            <td class="style5">
                                                <font color="#4D2600" size="5">
                                                &nbsp;</font><font color="#4D2600" size="5">&nbsp;</font><font color="#4D2600" size="5">&nbsp;</font><font color="#4D2600" size="5">&nbsp;</font><font color="#4D2600" size="5">&nbsp;</font><font color="#4D2600" size="5">&nbsp;</font></td>
                                            <td>
                                                </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            </font>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="False" 
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label24" runat="server" Text="一、单选题(每题"> </asp:Label>
                                            <asp:Label ID="Label27" runat="server"> </asp:Label>
                                            <asp:Label ID="Label25" runat="server" Text="分)"> </asp:Label>
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
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Mark") %>' 
                                                            Visible="false"> </asp:Label>
                                                        <asp:Label ID="Label40" runat="server" Text='<%# Eval("TitleID") %>' 
                                                            Visible="False"></asp:Label>
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
                                            <asp:Label ID="Label22" runat="server" Text="二、多选题(每题"> </asp:Label>
                                            <asp:Label ID="Label28" runat="server"> </asp:Label>
                                            <asp:Label ID="Label23" runat="server" Text="分)"> </asp:Label>
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
                                                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Mark") %>' 
                                                            Visible="false"> </asp:Label>
                                                        <asp:Label ID="Label41" runat="server" Text='<%# Eval("TitleID") %>' 
                                                            Visible="False"></asp:Label>
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
                                            <asp:Label ID="Label20" runat="server" Text="三、判断题(每题"> </asp:Label>
                                            <asp:Label ID="Label29" runat="server"> </asp:Label>
                                            <asp:Label ID="Label21" runat="server" Text="分)"> </asp:Label>
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
                                                        <asp:Label ID="Label12" runat="server" Text='<%# Eval("Mark") %>' 
                                                            Visible="false"> </asp:Label>
                                                        <asp:Label ID="Label42" runat="server" Text='<%# Eval("TitleID") %>' 
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                    <td width="10%">
                                                     <%--   <asp:CheckBox ID="CheckBox5" runat="server" Text="正确" />--%>
                                                        <asp:RadioButton ID="RadioButton5" runat="server" Text="正确" GroupName="judge"/>
                                                    </td>
                                                    <td width="10%">
                                                    <%--<asp:CheckBox ID="CheckBox6" runat="server" Text="错误" />--%>
                                                        <asp:RadioButton ID="RadioButton6" runat="server" Text="错误" GroupName="judge"/>
                                                    </td>
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
                            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label18" runat="server" Text="四、填空题(每题"> </asp:Label>
                                            <asp:Label ID="Label45" runat="server"> </asp:Label>
                                            <asp:Label ID="Label19" runat="server" Text="分)"> </asp:Label>
                                            <br />
                                            <br />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <TABLE ID="Table5" align="center" border="0" cellPadding="1" cellSpacing="1" 
                                                width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label13" runat="server" Text="<%# Container.DataItemIndex+1 %>">
                                                        </asp:Label>
                                                        <asp:Label ID="Label14" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                                        </asp:Label>
                                                        <asp:TextBox ID="TextBox1" runat="server" BorderStyle="None" 
                                                            style="BORDER-BOTTOM:   gray   1px   solid" Width="100px"></asp:TextBox>
                                                        <%--<asp:Label ID="Label15" runat="server" Text='<%# Eval("BackTitle") %>'>
                                                        </asp:Label>--%>
                                                        <asp:Label ID="Label17" runat="server" Text='<%# Eval("Mark") %>' 
                                                            Visible="false"> </asp:Label>
                                                        <asp:Label ID="Label43" runat="server" Text='<%# Eval("TitleID") %>' 
                                                            Visible="False"></asp:Label>
                                                    </td>
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
                            <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label32" runat="server" Text="五、问答题(每题"> </asp:Label>
                                            <asp:Label ID="Label31" runat="server"> </asp:Label>
                                            <asp:Label ID="Label33" runat="server" Text="分)"> </asp:Label>
                                            <br />
                                            <br />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <TABLE ID="Table6" align="center" border="0" cellPadding="1" cellSpacing="1" 
                                                width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label46" runat="server" Text="<%# Container.DataItemIndex+1 %>">
                                                        </asp:Label>
                                                        <asp:Label ID="Label34" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                                        </asp:Label>
                                                        <br />
                                                        <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                                        <asp:Label ID="Label37" runat="server" Text='<%# Eval("Mark") %>' 
                                                            Visible="false"> </asp:Label>
                                                        <asp:Label ID="Label44" runat="server" Text='<%# Eval("TitleID") %>' 
                                                            Visible="False"></asp:Label>
                                                    </td>
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
                        <td align="center">
                            <br />
                            <a href="#top">返回顶端</a> &nbsp; <asp:ImageButton ID="imgBtnSubmit" runat="server" 
                                ImageUrl="~/Images/Submit.GIF" OnClick="imgBtnSubmit_Click" />
                            &nbsp;</td>
                    </tr>
</table>
</div>
</asp:Content>

