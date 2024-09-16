<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3b.aspx.cs" Inherits="TP4.Ejercicio3b" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <strong>Listado de libros:</strong></div>
        <asp:GridView ID="grdLibros" runat="server">
        </asp:GridView>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Ejercicio3.aspx">Consultar otro tema</asp:HyperLink>
    </form>
</body>
</html>
