<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="PaperSetup2.aspx.cs" Inherits="Admin_PaperSetup2" Title="人工选题" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

<table cellpadding="0" cellspacing="0" border="1"  bordercolor="#cccccc" style="border-collapse:collapse" width="100%" frame="below">
               <tr>
                    <td bgcolor="#eeeeee" style="width:100%;" colspan="4"> <div class="title" align="left"><h4>试卷制定</h4></div></td>                    
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;"><b>试卷科目：</b></td>
                    <td >&nbsp;<div align="left"><asp:dropdownlist id="ddlCourse" runat="server" Font-Size="9pt" Width="88px" AutoPostBack="True" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:dropdownlist></div>
                    </td>
                    <td bgcolor="#eeeeee" style="text-align:right;">试卷名称：</td>
                     <td >&nbsp;<div align="left">  <asp:TextBox ID="txtPaperName" runat="server" Width="120px"></asp:TextBox><asp:LinkButton
                         ID="LinkButton1" runat="server" CausesValidation="False" OnClick="LinkButton1_Click">检测是否重名</asp:LinkButton>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPaperName" ErrorMessage="不能为空！" Display="Dynamic"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>                 
				<tr> 
                    <td bgcolor="#eeeeee" style="text-align:right;"><b>单选题</b>每题分值：</td>
                     <td>&nbsp;<div align="left">   <asp:TextBox ID="txtSingleFen" runat="server" Width="120px"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSingleFen" ValidationExpression="^\+?[0-9]*$" ErrorMessage="只能为正整数" Display="Dynamic"></asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="不能为空" ControlToValidate="txtSingleFen" Display="Dynamic"></asp:RequiredFieldValidator></div>
                    </td>
                    <td bgcolor="#eeeeee" style="text-align:right;">考试时间：</td>
                    <td>
                        <asp:Dropdownlist id="ddlNeedTime" runat="server" Font-Size="9pt" Width="88px">
                                    <asp:ListItem Value="0" Selected="True">不限时</asp:ListItem> 
                                    <asp:ListItem>60</asp:ListItem>
                                </asp:DropDownList>
                    </td>
                </tr>                
                <tr>                   
                    <td bgcolor="#eeeeee" style="text-align:right;"><b>多选题</b>每题分值：</td>
                     <td colspan="3">&nbsp;<div align="left">    <asp:TextBox ID="txtMultiFen" runat="server" Width="120px"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtMultiFen" ValidationExpression="^\+?[0-9]*$" ErrorMessage="只能为正整数" Display="Dynamic"></asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="不能为空" ControlToValidate="txtMultiFen" Display="Dynamic"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>                
                <tr>                   
                    <td bgcolor="#eeeeee" style="text-align:right;"><b>判断题</b>每题分值：</td>
                     <td colspan="3">&nbsp;<div align="left">   <asp:TextBox ID="txtJudgeFen" runat="server" Width="120px"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtJudgeFen" ValidationExpression="^\+?[0-9]*$" ErrorMessage="只能为正整数" Display="Dynamic"></asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="不能为空" ControlToValidate="txtJudgeFen" Display="Dynamic"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>    
                 <tr>                    
                    <td bgcolor="#eeeeee" style="text-align:right;"><b>填空题</b>每题分值：</td>
                     <td colspan="3">&nbsp;<div align="left">    <asp:TextBox ID="txtFillFen" runat="server" Width="120px"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtFillFen" ValidationExpression="^\+?[0-9]*$" ErrorMessage="只能为正整数" Display ="Dynamic"></asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="不能为空" ControlToValidate="txtFillFen" Display="Dynamic"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>                 
                <tr>                   
                    <td bgcolor="#eeeeee" style="text-align:right;"><b>问答题</b>每题分值：</td>
                     <td colspan="3">&nbsp;<div align="left">    <asp:TextBox ID="txtQuestionFen" runat="server" Width="120px"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtQuestionFen" ValidationExpression="^\+?[0-9]*$" ErrorMessage="只能为正整数" Display ="Dynamic"></asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="不能为空" ControlToValidate="txtQuestionFen" Display ="Dynamic"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>                           
				<tr>
				    <td colspan=4>                       
                            <table cellSpacing="0" style="FONT-SIZE: 12px; FONT-FAMILY: Tahoma; BORDER-COLLAPSE: collapse; " cellPadding="0" width=100%	bgColor="#ffffff" border="1" bordercolor=gray>
				                <tr>
				                    <td>
				                        <asp:GridView ID="GridView11" runat="server" Width=100% AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" CellPadding="3">
                                            <Columns>
                                           <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect1" runat="server" ></asp:CheckBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="20px"/>
                                        </asp:TemplateField>
								            <asp:TemplateField HeaderText="一、单选题">
									                <ItemTemplate>										               												               
													  <asp:Label id=Label2 runat="server" Text='<%# Eval("Title","{0}") %>'></asp:Label>
													 <asp:Label id=Label3 runat="server" Text='<%# Eval("ID") %>' Visible="False"></asp:Label>													                
									                </ItemTemplate>
								                </asp:TemplateField>
							                </Columns>
                                            <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                        </asp:GridView>
                                        &nbsp;
                                    </td>
				                </tr>
				                <tr>
				                    <td>
				                        <asp:GridView ID="GridView2" runat="server" Width=100% AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" CellPadding="3">
                                            <Columns>
                                             <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect2" runat="server" ></asp:CheckBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="20px"/>
                                        </asp:TemplateField>
								                <asp:TemplateField HeaderText="二、多选题">
									                <ItemTemplate>										               
													   <asp:Label id=Label10 runat="server" Text='<%# Eval("Title","{0}") %>'></asp:Label>
													 <asp:Label id=Label6 runat="server" Text='<%# Eval("ID") %>' Visible="False"></asp:Label>
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
                                               <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect3" runat="server" ></asp:CheckBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="20px"/>
                                        </asp:TemplateField>
								                <asp:TemplateField HeaderText="三、判断题">
									                <ItemTemplate>										               
													   <asp:Label id=Label20 runat="server" Text='<%# Eval("Title","{0}") %>'></asp:Label>
													   <asp:Label id=Label7 runat="server" Text='<%# Eval("ID") %>' Visible="False"></asp:Label>													               
									                </ItemTemplate>
								                </asp:TemplateField>
							                </Columns>
                                            <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                        </asp:GridView>
				                    </td>
				                </tr>
				                 <tr>
				                    <td style="height: 25px">
				                        <asp:GridView ID="GridView4" runat="server" Width=100% AutoGenerateColumns="False">
                                            <Columns>
                                               <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect4" runat="server" ></asp:CheckBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="20px"/>
                                        </asp:TemplateField>
								                <asp:TemplateField HeaderText="四、填空题">
									                <ItemTemplate>										               
													<asp:Label id=Label17 runat="server" Text='<%# Eval("Title","{0}") %>'></asp:Label>
													
												<asp:Label id=Label8 runat="server" Text='<%# Eval("ID") %>' Visible="False"></asp:Label>
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
                                               <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect5" runat="server" ></asp:CheckBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="20px"/>
                                        </asp:TemplateField>
								                <asp:TemplateField HeaderText="五、问答题">
									                <ItemTemplate>
											         <asp:Label id=Label22 runat="server" Text='<%# Eval("Title","{0}") %>'></asp:Label>	<br />													             											               
													 <asp:TextBox id="txtAnswer" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>													                
													 <asp:Label id=Label23 runat="server" Text='<%# Eval("ID") %>' Visible="False"></asp:Label>	
									                </ItemTemplate>
								                </asp:TemplateField>
							                </Columns>
                                            <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                        </asp:GridView>
				                    </td>
				                </tr>
				                
				                <tr>
				                    <td>

                                        <br /><asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="true" Text="全选" Width="54px" OnCheckedChanged="chkSelectAll_CheckedChanged" />
				                    </td>
				                </tr>
				                
				                
				                <tr>
				                    <td align=center style="height: 31px">
                                        <asp:ImageButton ID="imgBtnSave" runat="server" ImageUrl="~/Images/Save.GIF" OnClick="imgBtnSave_Click"/></td>
				                </tr>
				            </table>                      
				    </td>
				</tr>
				
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlCourse" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

