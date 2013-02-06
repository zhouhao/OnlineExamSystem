<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="PaperSetup.aspx.cs" Inherits="Admin_PaperSetup" Title="试卷制定" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table cellpadding="0" cellspacing="0" border="1"  bordercolor="#cccccc" style="border-collapse:collapse" width="100%" frame="below">
               <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;width:100%;" colspan="4"> <div class="title" align="left"><h4>试卷制定(随机出题) &nbsp; &nbsp; <a href="papersetup2.aspx"><font color="red">人工出题</font></a></h4></div></td>                    
                </tr>
                <tr>
                    <td colspan="2">
                    <table border="0" height="100%" width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 100px" bgcolor="#eeeeee">
                           
                                试卷科目：<br />
                                </td>
                            <td style="width: 100px">
                                <br />
                                <asp:Dropdownlist id="ddlCourse" runat="server" Font-Size="9pt" Width="88px">
                                </asp:DropDownList><br />
                            </td>
                            <td style="width: 100px" bgcolor="#eeeeee">
                                难度系数：</td>
                            <td style="width: 100px">
                                <br />
                                <asp:Dropdownlist id="ddlDiff" runat="server" Font-Size="9pt" Width="88px">
                                </asp:DropDownList><br />
                            </td>
                        </tr>
                    </table>
                    </td>
                    <td colspan="2">
                          <table border="0" height="100%" width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 100px" bgcolor="#eeeeee">
                           
                                试卷名称：<br />
                                </td>
                            <td >&nbsp;<div align="left">  <asp:TextBox ID="txtPaperName" runat="server" 
                                    Width="120px" AutoPostBack="True" ontextchanged="txtPaperName_TextChanged"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPaperName" ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                            </td>
                            <td style="width: 100px" bgcolor="#eeeeee">
                                考试时间(分钟)：</td>
                            <td style="width: 100px">
                                <br />
                                <asp:Dropdownlist id="ddlNeedTime" runat="server" Font-Size="9pt" Width="88px">
                                    <asp:ListItem Value="0" Selected="True">不限时</asp:ListItem>                                  
                                    <asp:ListItem>60</asp:ListItem>                                   
                                </asp:DropDownList><br />
                            </td>
                        </tr>
                    </table>
                    </td>
                </tr>
                
                 <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;width:100%;" colspan="4"> <div class="title" align="left"><h4>单选题：</h4></div></td>                    
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;">题目数目：</td>
                    <td >&nbsp;<div align="left"><asp:TextBox ID="txtSingleNum" runat="server" Width="120px"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSingleNum" ValidationExpression="^\+?[0-9]*$" ErrorMessage="只能为正整数" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="不能为空" ControlToValidate="txtSingleNum" Display="Dynamic"></asp:RequiredFieldValidator></div>
                    </td>
                    <td bgcolor="#eeeeee" style="text-align:right;">每题分值：</td>
                     <td >&nbsp;<div align="left">   <asp:TextBox ID="txtSingleFen" runat="server" Width="120px"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSingleFen" ValidationExpression="^\+?[0-9]*$" ErrorMessage="只能为正整数" Display="Dynamic"></asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="不能为空" ControlToValidate="txtSingleFen" Display="Dynamic"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>
                 <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;width:100%;" colspan="4"> <div class="title" align="left"><h4>多选题：</h4></div></td>                    
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;">题目数目：</td>
                    <td >&nbsp;<div align="left"><asp:TextBox ID="txtMultiNum" runat="server" Width="120px"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMultiNum" ValidationExpression="^\+?[0-9]*$" ErrorMessage="只能为正整数" Display="Dynamic"></asp:RegularExpressionValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="不能为空" ControlToValidate="txtMultiNum"></asp:RequiredFieldValidator></div>
                    </td>
                    <td bgcolor="#eeeeee" style="text-align:right;">每题分值：</td>
                     <td >&nbsp;<div align="left">    <asp:TextBox ID="txtMultiFen" runat="server" Width="120px"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtMultiFen" ValidationExpression="^\+?[0-9]*$" ErrorMessage="只能为正整数" Display ="Dynamic"></asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="不能为空" ControlToValidate="txtMultiFen"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>
                 <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;width:100%;" colspan="4"> <div class="title" align="left"><h4>判断题：</h4></div></td>                    
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;">题目数目：</td>
                    <td >&nbsp;<div align="left"><asp:TextBox ID="txtJudgeNum" runat="server" Width="120px"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtJudgeNum" ValidationExpression="^\+?[0-9]*$" ErrorMessage="只能为正整数" Display="Dynamic"></asp:RegularExpressionValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="不能为空" ControlToValidate="txtJudgeNum"></asp:RequiredFieldValidator></div>
                    </td>
                    <td bgcolor="#eeeeee" style="text-align:right;">每题分值：</td>
                     <td >&nbsp;<div align="left">   <asp:TextBox ID="txtJudgeFen" runat="server" Width="120px"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtJudgeFen" ValidationExpression="^\+?[0-9]*$" ErrorMessage="只能为正整数" Display ="Dynamic"></asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="不能为空" ControlToValidate="txtJudgeFen"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>
<tr>
                    <td bgcolor="#eeeeee" style="text-align:right;width:100%;" colspan="4"> <div class="title" align="left"><h4>填空题：</h4></div></td>                    
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align:right; height: 14px;">题目数目：</td>
                    <td style="height: 14px" >&nbsp;<div align="left"><asp:TextBox ID="txtFillNum" runat="server" Width="120px"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtFillNum" ValidationExpression="^\+?[0-9]*$" ErrorMessage="只能为正整数" Display="Dynamic"></asp:RegularExpressionValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="不能为空" ControlToValidate="txtFillNum"></asp:RequiredFieldValidator></div>
                    </td>
                    <td bgcolor="#eeeeee" style="text-align:right; height: 14px;">每题分值：</td>
                     <td style="height: 14px" >&nbsp;<div align="left">    <asp:TextBox ID="txtFillFen" runat="server" Width="120px"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtFillFen" ValidationExpression="^\+?[0-9]*$" ErrorMessage="只能为正整数" Display="Dynamic"></asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="不能为空" ControlToValidate="txtFillFen"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>
                  <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;width:100%;" colspan="4"> <div class="title" align="left"><h4>问答题：</h4></div></td>                    
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align:right; height: 25px;">题目数目：</td>
                    <td style="height: 25px" >&nbsp;<div align="left"><asp:TextBox ID="txtQuestionNum" runat="server" Width="120px"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtQuestionNum" ValidationExpression="^\+?[0-9]*$" ErrorMessage="只能为正整数" Display="Dynamic"></asp:RegularExpressionValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="不能为空" ControlToValidate="txtQuestionNum"></asp:RequiredFieldValidator></div>
                    </td>
                    <td bgcolor="#eeeeee" style="text-align:right; height: 25px;">每题分值：</td>
                     <td style="height: 25px" >&nbsp;<div align="left">    <asp:TextBox ID="txtQuestionFen" runat="server" Width="120px"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtQuestionFen" ValidationExpression="^\+?[0-9]*$" ErrorMessage="只能为正整数" Display="Dynamic"></asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="不能为空" ControlToValidate="txtQuestionFen"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>

               <tr height=40>
				    <td colspan=4 align=center>
                        <asp:ImageButton ID="imgBtnConfirm" runat="server" ImageUrl="~/Images/Confirm.GIF" OnClick="imgBtnConfirm_Click"/><br />
                        <asp:Label ID="lblres" runat="server" Text=""></asp:Label>
                    </td>
				</tr>
				
				
				
				
				<tr>
				    <td colspan=4>
                        <asp:Panel ID="Panel1" runat="server" Width=100% Visible="False">
                            <table cellSpacing="0" style="FONT-SIZE: 12px; FONT-FAMILY: Tahoma; BORDER-COLLAPSE: collapse; " cellPadding="0" width=100%	bgColor="#ffffff" border="1" bordercolor=gray>
				                <tr>
				                    <td>
				                        <asp:GridView ID="GridView11" runat="server" Width=100% AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" CellPadding="3">
                                            <Columns>
								                <asp:TemplateField HeaderText="一、单选题">
									                <ItemTemplate>
										                <TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
											                <br />
											                <TR>
												                <TD colSpan="3">
													                <asp:Label id=Label1 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
													                </asp:Label>
													                <asp:Label id=Label2 runat="server" Text='<%# Eval("Title","、{0}") %>'>
													                </asp:Label>
													                <asp:Label id=Label3 runat="server" Text='<%# Eval("ID") %>' Visible="False">
													                </asp:Label>
													                </TD>
											                </TR>
											                 <TR>
												                <TD width="35%">
													                A、<%# Eval("AnswerA") %></TD>
												                <TD width="35%">
													                B、<%# Eval("AnswerB") %></TD>
												                <TD></TD>
											                </TR>
											                <TR>
												                <TD width="35%">
													               C、<%# Eval("AnswerC") %></TD>
												                <TD width="35%">
													               D、<%# Eval("AnswerD") %></TD>
												                <TD></TD>
											                </TR>
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
				                        <asp:GridView ID="GridView2" runat="server" Width=100% AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" CellPadding="3">
                                            <Columns>
								                <asp:TemplateField HeaderText="二、多选题">
									                <ItemTemplate>
										                <TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
											               <br />
											                <TR>
												                <TD colSpan="3">
													                <asp:Label id=Label9 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
													                </asp:Label>
													                <asp:Label id=Label10 runat="server" Text='<%# Eval("Title","、{0}") %>'>
													                </asp:Label>
													                <asp:Label id=Label6 runat="server" Text='<%# Eval("ID") %>' Visible="False">
													                </asp:Label>
													                </TD>
											                </TR>
											                 <TR>
												                <TD width="35%">
													                A、<%# Eval("AnswerA") %></TD>
												                <TD width="35%">
													                B、<%# Eval("AnswerB") %></TD>
												                <TD></TD>
											                </TR>
											                <TR>
												                <TD width="35%">
													               C、<%# Eval("AnswerC") %></TD>
												                <TD width="35%">
													               D、<%# Eval("AnswerD") %></TD>
												                <TD></TD>
											                </TR>
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
				                        <asp:GridView ID="GridView3" runat="server" Width=100% AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" CellPadding="3">
                                            <Columns>
								                <asp:TemplateField HeaderText="三、判断题">
									                <ItemTemplate>
										                <TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
											               <br />
											                <TR>
												                <TD width="85%" colspan=2>
													                <asp:Label id=Label19 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
													                </asp:Label>
													                <asp:Label id=Label20 runat="server" Text='<%# Eval("Title","、{0}") %>'>
													                </asp:Label>
													                <asp:Label id=Label7 runat="server" Text='<%# Eval("ID") %>' Visible="False">
													                </asp:Label>
													                </TD>
												                </tr>
													                <tr>
												                <TD width="10%">
													                A、正确</TD>
													                <TD width="80%" align="left">
													                B、错误</TD>
											                </TR>
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
								                <asp:TemplateField HeaderText="四、填空题">
									                <ItemTemplate>
										                <TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
											               <br />
											                <TR>
												                <TD>
													                <asp:Label id=Label16 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
													                </asp:Label>
													                <asp:Label id=Label17 runat="server" Text='<%# Eval("Title","、{0}") %>'>
													                </asp:Label>
													                
													                <asp:Label id=Label8 runat="server" Text='<%# Eval("ID") %>' Visible="False">
													                </asp:Label>													                
													                </TD>
											                </TR>
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
				                        <asp:GridView ID="GridView5" runat="server" Width=100% AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" CellPadding="3">
                                            <Columns>
								                <asp:TemplateField HeaderText="五、问答题">
									                <ItemTemplate>
										                <TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
											                <br>
											                <TR>
												                <TD>
													                <asp:Label id=Label21 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
													                </asp:Label>
													                <asp:Label id=Label22 runat="server" Text='<%# Eval("Title","、{0}") %>'>
													                </asp:Label>	
													                <br />												               
													                <asp:TextBox id="txtAnswer" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>													                
													                <asp:Label id=Label23 runat="server" Text='<%# Eval("ID") %>' Visible="False">
													                </asp:Label>													                
													                </TD>
											                </TR>
										                </TABLE>
									                </ItemTemplate>
								                </asp:TemplateField>
							                </Columns>
                                            <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                        </asp:GridView>
				                    </td>
				                </tr>
				                			
                
				                				              			                
				                <tr>
				                    <td align=center style="height: 31px">
                                        <asp:ImageButton ID="imgBtnSave" runat="server" ImageUrl="~/Images/Save.GIF" OnClick="imgBtnSave_Click" /></td>
				                </tr>
				            </table>
                        </asp:Panel>
				    </td>
				</tr>
				
            </table>         

</asp:Content>

