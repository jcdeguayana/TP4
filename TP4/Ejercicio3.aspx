<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3.aspx.cs" Inherits="TP4.Ejercicio3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;Seleccionar Tema:&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlTemas" runat="server">
            </asp:DropDownList>
        </div>
        <p>
&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Ver libros</asp:LinkButton>
        </p>
    </form>
</body>
</html>
