<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="JudgeAdd.aspx.cs" Inherits="Admin_JudgeAdd" Title="判断题编辑与添加" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <table cellpadding="0" cellspacing="0" border="1"  bordercolor="#cccccc" style="border-collapse:collapse" width="100%" >
               <tr>
                    <td bgcolor="#eeeeee"  colspan="2" style="height: 25px"> <div class="title" align="left"><h4>
                        判断题</h4></div></td>                    
                   <td bgcolor="#eeeeee" colspan="1" style="width: 95px; height: 25px;">
                   </td>
                   <td bgcolor="#eeeeee" colspan="1" style="height: 25px">
                   </td>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;" width="80px">科目：</td>
                    <td style="width: 229px" >&nbsp;<div align="left"><asp:dropdownlist id="ddlCourse" runat="server" Font-Size="9pt" Width="88px"></asp:dropdownlist></div>
                    </td>
                    <td bgcolor="#eeeeee" style="text-align:right;" width="80px">
                        难度系数：</td>
                    <td>
                       &nbsp;<div align="left"> <asp:dropdownlist id="ddlDiff" runat="server" Font-Size="9pt" Width="88px">
                        </asp:DropDownList></div></td>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;">题目：</td>
                    <td colspan="3">
                    &nbsp;<div align="left"><asp:textbox id="txtTitle"  
                                runat="server" Width="100%" TextMode="MultiLine"	Height="60px" 
                                AutoPostBack="True" ontextchanged="txtTitle_TextChanged"></asp:textbox>
						 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle"
                            ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                </tr>
                 <tr>
                    <td bgcolor="#eeeeee" style="text-align:right;">答案：</td>
                    <td colspan="3">&nbsp;<div align="left"><asp:RadioButtonList ID="rblAnswer" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="true">正确</asp:ListItem>
                            <asp:ListItem Value="false">错误</asp:ListItem>
                        </asp:RadioButtonList></div></td>
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

