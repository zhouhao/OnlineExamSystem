<%@ Page Title="在线测试" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="UserTest.aspx.cs" Inherits="User_UserTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div style="margin-left:auto; margin-right:auto;">
<asp:Panel ID="Panel1" runat="server" CssClass="panel">
    <table border="1px">
        <tr>
            <td style="width:160px;">
                <a href="#top">返回顶端</a>&nbsp; &nbsp;<asp:LinkButton ID="LinkButton1" 
                    runat="server" onclick="LinkButton1_Click" OnClientClick="javascript:return confirm('这将删除你之前的考试记录，确定删除吗?')"  >删除记录</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="imgBtnSubmit" runat="server" 
                    ImageUrl="~/Images/Submit.GIF" OnClick="imgBtnSubmit_Click" />
      
                <asp:LinkButton ID="LinkButton2" runat="server" Visible="False" 
                    onclick="LinkButton2_Click">显示答案</asp:LinkButton>
                    &nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink2" runat="server" 
                    NavigateUrl="~/User/Default.aspx" >返回首页</asp:HyperLink>                           
            </td>
        </tr>
        <tr>
            <td>测验统计:</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbSumUp" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Panel>
<table width="80%">
    <tr height="40">
           <td align="center">
                            <a name="top"></a><font color="#4D2600" size="5">
                            <asp:Label ID="Label7" runat="server" Text="测试试题：" />
                            <asp:Label ID="Label30" runat="server" Text="&lt;&lt;" />
                            <asp:Label ID="lblPaperName" runat="server"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text="&gt;&gt;" />
                            
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
                                                        <asp:Label id="Label3" runat="server" Text='<%# Eval("UserAnswer") %>' Visible="False"></asp:Label>
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
                                                        <asp:Label id="Label7" runat="server" Text='<%# Eval("UserAnswer") %>' Visible="False"></asp:Label>
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
                                                        <asp:Label id="Label11" runat="server" Text='<%# Eval("UserAnswer")%>' Visible="false"></asp:Label>
                                                        <asp:Label ID="Label12" runat="server" Text='<%# Eval("Mark") %>' 
                                                            Visible="false"> </asp:Label>
                                                        <asp:Label ID="Label42" runat="server" Text='<%# Eval("TitleID") %>' 
                                                            Visible="False"></asp:Label>
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
                     <tr>
				  <td>
				            <asp:GridView ID="GridView4" runat="server" Width=100% AutoGenerateColumns="False">
                                <Columns>
								    <asp:TemplateField >
				                        <HeaderTemplate>				                    
				                        <asp:Label id="Label18" runat="server" Text=四、填空题(每题></asp:Label>
									    <asp:Label id="Label30" runat="server" ></asp:Label>
                                        <asp:Label ID="Label19" runat="server" Text=分)> </asp:Label>                                                   
				                    </HeaderTemplate>
									    <ItemTemplate>
										    <TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
											    <br />
											    <TR>
												    <TD>
													    <asp:Label id=Label13 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
													    </asp:Label>
													    <asp:Label id=Label14 runat="server" Text='<%# Eval("Title","、{0}") %>'>
													    </asp:Label>
													        <asp:TextBox id="TextBox1" Text='<%# Eval("UserAnswer") %>' runat="server" Width="150px" style="BORDER-BOTTOM:   gray   1px   solid" BorderStyle="None"></asp:TextBox>
													    <asp:Label id="Label17" runat="server" Text='<%# Eval("Mark") %>' Visible=false></asp:Label>												                
													    </TD>
											    </TR>
											        <tr>
											        <td>
											         <asp:Label id="Label26" runat="server" Visible="false" Text='<%# Eval("Answer") %>'></asp:Label>
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
				                        <asp:GridView ID="GridView5" runat="server" Width=100% AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                            <Columns>
								                <asp:TemplateField>
								                 <HeaderTemplate>				                    
				                                    <asp:Label id="Label32" runat="server" Text=五、问答题(每题></asp:Label>
									                <asp:Label id="Label31" runat="server" ></asp:Label>
                                                    <asp:Label ID="Label33" runat="server" Text=分)></asp:Label>                                                   
				                                </HeaderTemplate>
									                <ItemTemplate>
										                <TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
											                <br>
											                <TR>
												                <TD>
													                <asp:Label id=Label18 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
													                </asp:Label>
													                <asp:Label id=Label19 runat="server" Text='<%# Eval("Title","、{0}") %>'>
													                </asp:Label>	
													                <br />												               
													            
													              <asp:TextBox ID="TextBox2" runat="server" TextMode="multiLine"  Width="100%" Text='<%# Eval("UserAnswer") %>'></asp:TextBox>													                
													                <asp:Label id=Label21 runat="server" Text='<%# Eval("Mark") %>' Visible=false></asp:Label>												                
													                </TD>
											                </TR>
											                 <tr>
											                  <td>
											                  <br />
											                  <asp:TextBox ID="TextBox3" runat="server" Visible="false" TextMode="multiLine" Width="100%" Height="60px" ReadOnly="true" Text='<%#Eval("Answer") %>'></asp:TextBox>
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
                    
</table>
</div>
</asp:Content>

