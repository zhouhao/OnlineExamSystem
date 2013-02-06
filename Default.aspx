<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>试卷生成系统</title>
    <link href="/CSS/Style.css" type="text/css" rel="STYLESHEET"/>
</head>
<body onload="javascript:form1.TxtUserName.focus();" bgcolor="#5A7080">
    <form id="form1" runat="server">
   <div align="center">       
       <br />
       <br />
       <br />
       <br />
       <br />
<table cellspacing="0" cellpadding="0" align="center" style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid">  
  <tr><td align="center">
    <img height="205" alt="" src="images/logo.png" width="609"/>
  </td></tr>
  <tr height="35">
    <td align="center" background="images/bg.bmp">
        <b>用户名：<asp:TextBox ID="TxtUserName"  onmouseover="this.focus()" onfocus="this.select()" runat="server" Height="20px" Width="100px"></asp:TextBox></b>&nbsp;&nbsp;
        &nbsp;<b>密码：</b> 
        <asp:TextBox ID="TxtUserPwd" runat="server" onmouseover="this.focus()" onfocus="this.select()" Height="20px" TextMode="Password" Width="100px" ></asp:TextBox>
        &nbsp; &nbsp;&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle"
            ImageUrl="~/images/btn.png" OnClick="ImageButton1_Click" /></td></tr>
  </table>  
       <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="White" Text="试卷生成系统. All Rights Reserved"></asp:Label></DIV>
    </form>
</body>
</html>
