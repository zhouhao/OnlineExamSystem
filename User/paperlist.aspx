<%@ Page Language="C#" AutoEventWireup="true" CodeFile="paperlist.aspx.cs" Inherits="User_paperlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../CSS/CSS.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DataList ID="DataList1" runat="server" GridLines="Both" RepeatColumns="7" RepeatDirection="Horizontal">
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Width="100px" Text="">
                    <a href="#" onclick="javascript:window.open('string2Session.aspx?paperid=<%# Eval("PaperID") %>&papername=<%# Eval("PaperName") %>','_top')"><%# Eval("PaperName") %></a>
                </asp:Label>
            </ItemTemplate>
            <SelectedItemStyle BackColor="#CCFFFF" />
        </asp:DataList>
    
    </div>
    </form>
</body>
</html>
