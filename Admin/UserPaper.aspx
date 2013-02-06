<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="UserPaper.aspx.cs" Inherits="Admin_UserPaper" Title="试卷评阅" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <table cellpadding="0" cellspacing="0" border="1"  bordercolor="#cccccc" style="border-collapse:collapse" width="100%" frame="below">
              <tr>
                    <td style="text-align:right;">
                       试卷：</td>
                     <td  colspan="3">
                         &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label16" runat="server" Text="考试时间：" Width="103px"></asp:Label>
                                     <asp:Label ID="lblExamtime" runat="server" Width="236px"></asp:Label>
                         <asp:Label ID="Xpaperid" runat="server" Text="" Visible="false"></asp:Label></td>
                </tr>
                 <tr>
                    <td colspan="2"><b>评卷说明：单选题、多选题、判断题、填空题是系统自动评分的，问答题需要人工评分。</b></td>
                                  
                </tr>
                
                 <tr>
                    <td bgcolor="#f6dda4" style="text-align:right;">单选题得分：</td>
                    <td >&nbsp;<div align="left">&nbsp;&nbsp;<asp:Label ID="sinScore" runat="server" Text="0" Font-Bold="true"></asp:Label>                  
                    </div></td>                   
                </tr>
                  <tr>
                    <td bgcolor="#f6dda4" style="text-align:right;">多选题得分：</td>
                    <td >&nbsp;<div align="left">&nbsp;&nbsp;<asp:Label ID="mulScore" runat="server" Text="0" Font-Bold="true"></asp:Label>            
                    
                    </div></td>                   
                </tr>
                  <tr>
                    <td bgcolor="#f6dda4" style="text-align:right;">判断题得分：</td>
                    <td >&nbsp;<div align="left">&nbsp;&nbsp;<asp:Label ID="judScore" runat="server" Text="0" Font-Bold="true"></asp:Label> 
                    </div></td>                   
                </tr>
                  <tr>
                    <td bgcolor="#f6dda4" style="text-align:right;">填空题得分：</td>
                    <td >&nbsp;<div align="left">&nbsp;&nbsp;<asp:Label ID="filScore" runat="server" Text="0" Font-Bold="true"></asp:Label> 
                    </div></td>                   
                </tr>
                <tr>
                    <td bgcolor="#f6dda4" style="text-align:right;">问答题得分：</td>
                    <td >&nbsp;<div align="left"><asp:Label  id="queScore" runat="server" Font-Bold="true"></asp:Label>
                        &nbsp; &nbsp;<asp:Label  id="lblQuestion" runat="server" Text="(>>请在下面对问答题进行判分<<)" Font-Bold="true"></asp:Label>        
                    </div></td>                   
                </tr>
                 <tr>
                    <td bgcolor="#f6dda4" style="text-align:right;">总分：</td>
                    <td >&nbsp; &nbsp;<div align="left"> &nbsp;<asp:Label id="sumScore" runat="server" Font-Bold="true"></asp:Label>                  
                       </div></td>                   
                </tr>
                 <tr>
                    <td bgcolor="#f6dda4" style="text-align:right;">评语：</td>
                    <td >&nbsp; &nbsp;<div align="left"><asp:TextBox id="tbxPingyu" runat="server" Font-Bold="true" Width="100%"></asp:TextBox>                  
                       </div></td>                   
                </tr>
                 <tr>
                    <td></td>
                    <td >&nbsp;<div align="left">                        
                        <asp:ImageButton ID="imgBtnSave" runat="server" ImageUrl="../Images/Save.GIF" OnClick="imgBtnSave_Click" />
                        <asp:Label ID="lblMessage" runat="server" Width="300px" ForeColor=Red></asp:Label>
                         <asp:ImageButton ID="imgBtnReturn" runat="server" CausesValidation="false" ImageUrl="../Images/Return.GIF" OnClick="imgBtnReturn_Click" /></div></td>                   
                </tr>
				<tr>
				    <td colspan=4>                       
                            <table cellSpacing="0" style="FONT-SIZE: 12px; FONT-FAMILY: Tahoma; BORDER-COLLAPSE: collapse; " cellPadding="0" width=100%	bgColor="#ffffff" border="1" bordercolor=gray>
				                <tr>
				                    <td>
				                        <asp:GridView ID="GridView11" runat="server" Width=100% AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                            <Columns>
								                 <asp:TemplateField>
				                                   <HeaderTemplate>				                    
				                                       <asp:Label id="Label24" runat="server" Text="一、单选题(每题"></asp:Label>
									                   <asp:Label id="Label27" runat="server"></asp:Label>
                                                       <asp:Label ID="Label25" runat="server" Text="分)"></asp:Label>                                                       
				                                  </HeaderTemplate>
									                <ItemTemplate>
										                <TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
											                <br />
											                <TR>
												                <TD colSpan="3">
													                <asp:Label id=Label1 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
													                </asp:Label>
													                <asp:Label id=Label2 runat="server" Text='<%# Eval("Title","、{0}") %>'>
													                </asp:Label>
													                <asp:Label id=Label3 runat="server" Text='<%# Eval("UserAnswer") %>' Visible="False"></asp:Label>
													                <asp:Label id=Label4 runat="server" Text='<%# Eval("Mark") %>' Visible=false></asp:Label>
													                </TD>
											                </TR>
											                <TR>
												                <TD width="35%">
													                A:<asp:RadioButton id=RadioButton1 runat="server" Text='<%# Eval("AnswerA") %>' GroupName="Sl">
													                </asp:RadioButton></TD>
												                <TD width="35%">
													                B:<asp:RadioButton id=RadioButton2 runat="server" Text='<%# Eval("AnswerB") %>' GroupName="Sl">
													                </asp:RadioButton></TD>
												                <TD></TD>
											                </TR>
											                <TR>
												                <TD width="35%">
													                C:<asp:RadioButton id=RadioButton3 runat="server" Text='<%# Eval("AnswerC") %>' GroupName="Sl">
													                </asp:RadioButton></TD>
												                <TD width="35%">
													                D:<asp:RadioButton id=RadioButton4 runat="server" Text='<%# Eval("AnswerD") %>' GroupName="Sl">
													                </asp:RadioButton></TD>
												                <TD></TD>
											                </TR>
											                <tr>
											                  <td colspan="3">
											                  参考答案： <asp:Label id=Label23 runat="server" Text='<%# Eval("Answer") %>'></asp:Label>
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
				                        <asp:GridView ID="GridView2" runat="server" Width=100% AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                            <Columns>
								                <asp:TemplateField>
				                                 <HeaderTemplate>				                    
				                                    <asp:Label id="Label22" runat="server" Text=二、多选题(每题></asp:Label>
									                <asp:Label id="Label28" runat="server"></asp:Label>
                                                    <asp:Label ID="Label23" runat="server" Text=分)></asp:Label>                                                   
				                                </HeaderTemplate>
									                <ItemTemplate>
										                <TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
											               <br />
											                <TR>
												                <TD colSpan="3">
													                <asp:Label id=Label5 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
													                </asp:Label>
													                <asp:Label id=Label6 runat="server" Text='<%# Eval("Title","、{0}") %>'>
													                </asp:Label>
													                 <asp:Label id=Label7 runat="server" Text='<%# Eval("UserAnswer") %>' Visible="False"></asp:Label>
													                <asp:Label id=Label8 runat="server" Text='<%# Eval("Mark") %>' Visible=false></asp:Label>
													                </TD>
											                </TR>
											                <TR>
												                <TD style="HEIGHT: 22px" width="35%">
													                A:<asp:CheckBox id=CheckBox1 runat="server" Text='<%# Eval("AnswerA") %>'>
													                </asp:CheckBox></TD>
												                <TD style="HEIGHT: 22px" width="35%">
													                B:<asp:CheckBox id=CheckBox2 runat="server" Text='<%# Eval("AnswerB") %>'>
													                </asp:CheckBox></TD>
												                <TD style="HEIGHT: 22px"></TD>
											                </TR>
											                <TR>
												                <TD width="35%">
													                C:<asp:CheckBox id=CheckBox3 runat="server" Text='<%# Eval("AnswerC") %>'>
													                </asp:CheckBox></TD>
												                <TD width="350%">
													                D:<asp:CheckBox id=CheckBox4 runat="server" Text='<%# Eval("AnswerD") %>'>
													                </asp:CheckBox></TD>
												                <TD></TD>
											                </TR>
											                 <tr>
											                  <td colspan="3">
											                  参考答案：<asp:Label id=Label27 runat="server" Text='<%# Eval("Answer") %>'></asp:Label>
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
				                        <asp:GridView ID="GridView3" runat="server" Width=100% AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                            <Columns>
								                <asp:TemplateField>
				                               <HeaderTemplate>				                    
				                                   <asp:Label id="Label20" runat="server" Text=三、判断题(每题></asp:Label>
									                <asp:Label id="Label29" runat="server"></asp:Label>
                                                   <asp:Label ID="Label21" runat="server" Text=分)></asp:Label>                                                  
				                                </HeaderTemplate>
									                <ItemTemplate>
										                <TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
											               <br />
											                <tr>
												                <td width="84%">
													                <asp:Label id="Label9" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
													                </asp:Label>
													                <asp:Label id=Label10 runat="server" Text='<%# Eval("Title","、{0}") %>'>
													                </asp:Label>
													                 <asp:Label id=Label11 runat="server" Text='<%# Eval("UserAnswer")%>' Visible="false"></asp:Label>
													                <asp:Label id=Label12 runat="server" Text='<%# Eval("Mark") %>' Visible="false"></asp:Label>
													                </td>
												                <td width="8%">
													                <asp:CheckBox id="CheckBox5" runat="server" Text="正确"></asp:CheckBox></td>
													             <td width="8%">
													             <asp:CheckBox ID="CheckBox6" runat="server" Text="错误" />
													             </td>   
											                </tr>
											                 <tr>
											                  <td colspan="3">
											                  参考答案： <asp:Label id="Label21" runat="server" Text='<%# Eval("Answer").ToString()=="True"?"正确":"错误" %>'></asp:Label>
											                             <asp:Label id="Label41" runat="server" Text='<%# Eval("Answer")%>' Visible="false"></asp:Label>
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
											                  参考答案： <asp:Label id="Label26" runat="server" Text='<%# Eval("Answer") %>'></asp:Label>
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
													                (本题得分：<asp:TextBox ID="tbxqueScore" runat="server" Width="50px"></asp:TextBox>
													                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbxqueScore" ValidationExpression="^\d+$" ErrorMessage="只能为正整数或0" Display="dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="不能为空" ControlToValidate="tbxqueScore" Display="dynamic"></asp:RequiredFieldValidator>)
													                <br />												               
													            
													              <asp:TextBox ID="TextBox2" runat="server" TextMode="multiLine" ReadOnly="true" Width="100%" Text='<%# Eval("UserAnswer") %>'></asp:TextBox>													                
													                <asp:Label id=Label21 runat="server" Text='<%# Eval("Mark") %>' Visible=false></asp:Label>												                
													                </TD>
											                </TR>
											                 <tr>
											                  <td>
											                  参考答案： <br />
											                  <asp:TextBox ID="TextBox3" runat="server" TextMode="multiLine" Width="100%" Height="60px" ReadOnly="true" Text='<%#Eval("Answer") %>'></asp:TextBox>
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
				                <tr>
				                   <td>
				                    <br /><center> <asp:Button ID="Button1" runat="server" Text="考生试卷总分数计算" 
                                               OnClick="Button1_Click" CausesValidation="true" SkinID="btnSkin"/>	
				                    </center>									              											            
				                   </td>
				                </tr>
				               
				            </table>         

</asp:Content>

