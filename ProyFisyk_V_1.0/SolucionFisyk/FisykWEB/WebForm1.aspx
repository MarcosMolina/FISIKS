<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FisykWEB.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lbl1" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        ID<asp:TextBox ID="txtId" runat="server"></asp:TextBox>
        <br />
        tipo documento<asp:TextBox ID="txtTpDoc" runat="server">1</asp:TextBox>
        <br />
        nro dcoumento<asp:TextBox ID="txtNroDoc" runat="server">21</asp:TextBox>
        <br />
        nombre<asp:TextBox ID="txtNom" runat="server">Mark</asp:TextBox>
        <br />
        apellido<asp:TextBox ID="txtApe" runat="server">pollo</asp:TextBox>
        <br />
        fecha nacimiento<asp:TextBox ID="txtFecNac" runat="server">flecha</asp:TextBox>
        <br />
        telefono<asp:TextBox ID="txtTel" runat="server">0800</asp:TextBox>
        <br />
        sexo<asp:TextBox ID="txtSexo" runat="server">T</asp:TextBox>
&nbsp;<br />
        domicilio<asp:TextBox ID="txtDom" runat="server">1</asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" Text="Grabar" Width="110px" />
    
    </div>
    </form>
</body>
</html>
