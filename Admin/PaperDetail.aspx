<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="PaperDetail.aspx.cs" Inherits="Admin_PaperDetail" Title="试卷制定" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

                
        <table cellSpacing="0" style="FONT-SIZE: 12px; FONT-FAMILY: Tahoma; BORDER-COLLAPSE: collapse; " cellPadding="0" width=100%	bgColor="#ffffff" border="0" bordercolor=gray>
            <tr>
                <td>
                    <asp:GridView ID="GridView11" runat="server" Width=100% AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" CellPadding="3">
                        <Columns>
			                <asp:TemplateField>
			                <HeaderTemplate>
			                   <asp:Label id=Labelt1 runat="server" Text=一、单选题(每题>
				                </asp:Label>
				        <asp:Label id=Labelt2 runat="server">
				                </asp:Label>
                        <asp:Label ID="Labelt3" runat="server" Text=分)>
                        </asp:Label>
			                </HeaderTemplate>
				                <ItemTemplate>
					                <TABLE id="Table2" cellSpacing="0" cellPadding="0" BorderWidth="0px" width="100%" align="center" border="0">
						                
						                <TR>
							                <TD colSpan="3">
								                <asp:Label id=Label1 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
								                </asp:Label>
								                <asp:Label id=Label2 runat="server" Text='<%# Eval("Title","、{0}") %>'>
								                </asp:Label>
								                <asp:Label id=Label3 runat="server" Text='<%# Eval("ID") %>' Visible="False">
								                </asp:Label>
								                <asp:Label id=Labelm1 runat="server" Text='<%# Eval("Mark") %>' Visible=false>
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
			                <asp:TemplateField>
			                <HeaderTemplate>
			                   <asp:Label id=Labelt4 runat="server" Text=二、多选题(每题>
				                </asp:Label>
				        <asp:Label id=Labelt5 runat="server">
				                </asp:Label>
                        <asp:Label ID="Labelt6" runat="server" Text=分)>
                        </asp:Label>
			                </HeaderTemplate>
				                <ItemTemplate>
					                <TABLE id="Table3" cellSpacing="0"  BorderWidth="0px" width="100%" align="center" border="0">
						               <br />
						                <TR>
							                <TD colSpan="3">
								                <asp:Label id=Label9 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
								                </asp:Label>
								                <asp:Label id=Label10 runat="server" Text='<%# Eval("Title","、{0}") %>'>
								                </asp:Label>
								                <asp:Label id=Label6 runat="server" Text='<%# Eval("ID") %>' Visible="False">
								                </asp:Label>
								                 <asp:Label id=Labelm2 runat="server" Text='<%# Eval("Mark") %>' Visible=false>
				                                </asp:Label>
								                </TD>
						                </TR>
						                <TR>
							                <TD style="HEIGHT: 22px" width="35%">
								                A、<%# Eval("AnswerA") %></TD>
							                <TD style="HEIGHT: 22px" width="35%">
								               B、<%# Eval("AnswerB") %>'
								                </TD>
							                <TD style="HEIGHT: 22px"></TD>
						                </TR>
						                <TR>
							                <TD width="35%">
								                C、<%# Eval("AnswerC") %></TD>
							                <TD width="350%">
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
			                <asp:TemplateField>
			                 <HeaderTemplate>
			                   <asp:Label id=Labelt7 runat="server" Text=三、判断题(每题>
				                </asp:Label>
				        <asp:Label id=Labelt8 runat="server">
				                </asp:Label>
                        <asp:Label ID="Labelt9" runat="server" Text=分)>
                        </asp:Label>
			                </HeaderTemplate>
				                <ItemTemplate>
					                <TABLE id="Table4" cellSpacing="0"  BorderWidth="0px" width="100%" align="center" border="0">
						               <br />
						                <TR>
							                <TD width="80%" colspan=2>
								                <asp:Label id=Label19 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
								                </asp:Label>
								                <asp:Label id=Label20 runat="server" Text='<%# Eval("Title","、{0}") %>'>
								                </asp:Label>
								                <asp:Label id=Label7 runat="server" Text='<%# Eval("ID") %>' Visible="False">
								                </asp:Label>
								                <asp:Label id=Labelm3 runat="server" Text='<%# Eval("Mark") %>' Visible=false>
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
                    <asp:GridView ID="GridView4" runat="server" Width=100% AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px">
                        <Columns>
			                <asp:TemplateField>
			                 <HeaderTemplate>
			                   <asp:Label id=Labelt10 runat="server" Text=四、填空题(每题>
				                </asp:Label>
				        <asp:Label id=Labelt11 runat="server">
				                </asp:Label>
                        <asp:Label ID="Labelt12" runat="server" Text=分)>
                        </asp:Label>
			                </HeaderTemplate>
				                <ItemTemplate>
					                <TABLE id="Table5" cellSpacing="0"  BorderWidth="0px" width="100%" align="center" border="0">
						               <br />
						                <TR>
							                <TD>
								                <asp:Label id=Label16 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
								                </asp:Label>
								                <asp:Label id=Label17 runat="server" Text='<%# Eval("Title","、{0}") %>'>
								                </asp:Label>
								                
								                <asp:Label id=Label8 runat="server" Text='<%# Eval("ID") %>' Visible="False">
								                </asp:Label>
								                <asp:Label id=Labelm4 runat="server" Text='<%# Eval("Mark") %>' Visible=false>
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
			                <asp:TemplateField>
			                 <HeaderTemplate>
			                   <asp:Label id=Labelt13 runat="server" Text=五、问答题(每题>
				                </asp:Label>
				        <asp:Label id=Labelt14 runat="server">
				                </asp:Label>
                        <asp:Label ID="Labelt15" runat="server" Text=分)>
                        </asp:Label>
			                </HeaderTemplate>
				                <ItemTemplate>
					                <TABLE id="Table6" cellSpacing="0"  BorderWidth="0px" width="100%" align="center" border="0">
						                <br>
						                <TR>
							                <TD>
								                <asp:Label id=Label21 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
								                </asp:Label>
								                <asp:Label id=Label22 runat="server" Text='<%# Eval("Title","、{0}") %>'>
								                </asp:Label>	
								                <br />												               
								              	<br />	
								              	<br />	
								              	<br />	
								              	<br />	
								              	<br />	
								              	<br />	
								              	<br />	
								              	<br />	
								              	<br />	
								              	<br />	
								              	<br />										                
								                <asp:Label id=Label23 runat="server" Text='<%# Eval("ID") %>' Visible="False">
								                </asp:Label>
								                <asp:Label id=Labelm5 runat="server" Text='<%# Eval("Mark") %>' Visible=false>
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
                    <asp:ImageButton ID="imgBtnReturn" runat="server" CausesValidation="false" ImageUrl="../Images/Return.GIF" OnClick="imgBtnReturn_Click" />
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:ImageButton ID="bunToWrod" runat="server" CausesValidation="false" ImageUrl="~/Images/word.GIF" OnClick="bunToWrod_Click" /></td>
            </tr>
        </table>    

</asp:Content>

