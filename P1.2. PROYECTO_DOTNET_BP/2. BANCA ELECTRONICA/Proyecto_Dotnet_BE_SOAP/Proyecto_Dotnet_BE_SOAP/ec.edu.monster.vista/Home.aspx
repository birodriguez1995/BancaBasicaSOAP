<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Proyecto_Dotnet_BE_SOAP.ec.edu.monster.vista.Home" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="UTF-8">
    <link rel="stylesheet" type="text/css" href="estilos_login.css" media="screen" />
</head>
<body>
    <div class="separador"></div>
    <form id="form1" runat="server">

        <div class="imgcontainer">
            <img src="img/banco_login.png" alt="Avatar" class="avatar">
        </div>
        <div class="container">
            <label for="uname"><b>Usuario</b></label>
            

            <asp:TextBox ID="txtusuario" runat="server"  > </asp:TextBox>
            <label for="psw"><b>Contraseña</b></label>
            
            <asp:TextBox ID="txtpassword" runat="server" type="password"> </asp:TextBox>
            <button type="submit">Ingresar</button>
            <asp:Button  type="submit" ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Ingresar"/>
        </div>
    </form>
</body>
<footer>
    <div class="copyright" style="background-color: #0d47a1;">
        <div class="container-fluid" style="background-color: #0d47a1; color: #bbdefb;">
            <p>Sanipatin Kevin - Rodriguez Fernando - Vargas Kenedy</p>
            <p>UNIVERSIDAD DE LAS FUERZAS ARMADAS - ESPE</p>
        </div>
    </div>
</footer>
</html>
