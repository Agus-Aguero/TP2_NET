<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuUsuario.aspx.cs" Inherits="UI.Web.MenuUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menú</title>
</head>

<body class="container bg-light">
    <form id="form1" runat="server">
    <div class="row d-flex">
        <div class="col text-center">
             Menú de Usuario
        </div>
    </div>
        <asp:Label ID="lblPrueba" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
