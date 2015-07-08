<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="FisiksAppWeb.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>




</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>
                <asp:TextBox ID="TextBox1" runat="server" Height="200px" Width="800px"></asp:TextBox>
                <ajaxToolkit:HtmlEditorExtender ID="TextBox1_HtmlEditorExtender" runat="server" TargetControlID="TextBox1">
                </ajaxToolkit:HtmlEditorExtender>
           
        </div>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox2"  />
        <br />
        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
    </form>
</body>
</html>






