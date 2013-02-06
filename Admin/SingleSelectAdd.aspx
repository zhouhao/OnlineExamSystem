<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="SingleSelectAdd.aspx.cs" Inherits="Admin_SingleSelectAdd" Title="单选题编辑与录入" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <table cellpadding="0" cellspacing="0" border="1"  bordercolor="#cccccc" style="border-collapse:collapse" width="100%" frame="below">
               <tr>
                    <td bgcolor="#eeeeee"  colspan="2" style="height: 25px"> <div class="title" align="left"><h4>
                        单选题</h4></div></td>                    
                   <td bgcolor="#eeeeee" colspan="1" style="width: 95px; height: 25px;">
                   </td>
                   <td bgcolor="#eeeeee" colspan="1" style="height: 25px; width: 302px;">
                   </td>
                </tr>
                 <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;" width="80px">科目：</td>
                    <td style="width: 229px" >&nbsp;<div align="left"><asp:dropdownlist id="ddlCourse" runat="server" Font-Size="9pt" Width="88px"></asp:dropdownlist></div>
                    </td>
                    <td bgcolor="#eeeeee" style="text-align:right;" width="80px">
                        难度系数：</td>
                    <td style="width: 302px">
                       &nbsp;<div align="left"> <asp:dropdownlist id="ddlDiff" runat="server" Font-Size="9pt" Width="88px">
                        </asp:DropDownList></div></td>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;">题目：</td>
                    <td colspan="3">
                    &nbsp;<div align="left"><asp:textbox id="txtTitle"  
                                runat="server" Width="100%" 
                                TextMode="MultiLine"　Height="50px" ontextchanged="txtTitle_TextChanged" 
                                AutoPostBack="True"></asp:textbox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle"
                            ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;">答案A：</td>
                    <td colspan="3">
                    &nbsp;<div align="left"><asp:textbox id="txtAnswerA"  runat="server"  Width="100%" TextMode="MultiLine"
							Height="50px"></asp:textbox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAnswerA"
                            ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                </tr>
                 <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;">答案B：</td>
                    <td colspan="3">
                    &nbsp;<div align="left"><asp:textbox id="txtAnswerB"  runat="server"  Width="100%" TextMode="MultiLine"
							Height="50px"></asp:textbox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAnswerB"
                            ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                </tr>
                 <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;">答案C：</td>
                    <td colspan="3">
                    &nbsp;<div align="left"><asp:textbox id="txtAnswerC"  runat="server"  Width="100%" TextMode="MultiLine"
							Height="50px"></asp:textbox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAnswerC"
                            ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                </tr>
                 <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;">答案D：</td>
                    <td colspan="3">
                    &nbsp;<div align="left"><asp:textbox id="txtAnswerD" runat="server"  Width="100%" TextMode="MultiLine"
							Height="50px"></asp:textbox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAnswerD"
                            ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;">答案：</td>
                    <td colspan="3">&nbsp;<div align="left"><asp:dropdownlist id="ddlAnswer" runat="server" Font-Size="9pt" Width="43px">
							<asp:ListItem Value="A">A</asp:ListItem>
							<asp:ListItem Value="B">B</asp:ListItem>
							<asp:ListItem Value="C">C</asp:ListItem>
							<asp:ListItem Value="D">D</asp:ListItem>
						</asp:dropdownlist></div></td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="3">
                    <asp:Label ID="lblMessage" runat="server" ForeColor=red></asp:Label><br />
                       <asp:ImageButton ID="imgBtnSave" runat="server" ImageUrl="../Images/Save.GIF" OnClick="imgBtnSave_Click" />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
					   <asp:ImageButton ID="imgBtnReturn" runat="server" CausesValidation="false" ImageUrl="../Images/Return.GIF" OnClick="imgBtnReturn_Click" /></tr>
            </table>         

</asp:Content>

