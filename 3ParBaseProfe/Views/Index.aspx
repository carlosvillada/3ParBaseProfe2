<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_3ParBaseProfe.Views.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background-color: #f0f8ff;
            font-family: Arial, sans-serif;
            margin: 0;
        }
        .login-container {
            width: 300px;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0px 0px 10px 0px rgba(0, 0, 0, 0.1);
            text-align: center;
        }
        h2 {
            color: #333;
            margin-bottom: 20px;
        }
        .input-field {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ddd;
            border-radius: 5px;
        }
        .btn-login {
            width: 100%;
            padding: 10px;
            background-color: #4CAF50;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
        }
        .btn-login:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Iniciar Sesión</h2>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="input-field" Placeholder="Usuario"></asp:TextBox>
            <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" CssClass="input-field" Placeholder="Contraseña"></asp:TextBox>
            <asp:Button ID="btnEntrar" runat="server" Text="Entrar" CssClass="btn-login" OnClick="btnEntrar_Click" />
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>

