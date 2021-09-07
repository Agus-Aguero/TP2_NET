<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>

<body class="container bg-light">
    <div class="row align-items-center text-center">   
        <form id="form1" runat="server">
            <label>Nombre de usuario</label>
            <br />
            <asp:TextBox ID="txtUser" runat="server" /> 
            <br />
            <label>Contraseña</label>
            <br />
            <asp:TextBox ID="txtPassword" runat="server" />
            <br />
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
        </form>
    </div>
</body>
</html>
