<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tranferencia.aspx.cs" Inherits="Proyecto_Dotnet_BE_SOAP.ec.edu.monster.vista.Tranferencia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="UTF-8">
    <link rel="stylesheet" type="text/css" href="estilos_transferencias.css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="cabecera">
        <section class="columnsc">
            <div class="columnc">
            </div>
            <div class="columnc">
                <h1 class="texto_cabecera">BanQuito</h1>
            </div>
            <div class="columnc">
                <img src="img/cabecera.png" width="300" height="150">
            </div>
        </section>
    </div>
       
<div> 
            <section>
    <asp:Label ID="l22" runat="server"></asp:Label>      
</section>
</div>


     <ul>
    <li><a href="inicio.aspx">Inicio</a></li>
    <li class="dropdown">
      <a href="javascript:void(0)" class="dropbtn">Banca electrónica</a>
      <div class="dropdown-content">
        <a href="Consolidado.aspx">Posición consolidada</a>
        <a href="movimientos.aspx">Detalle de movimientos</a>
        <a href="Tranferencia.aspx">Transferencias</a>
      </div>
    </li>
    <li class="dropdown">
      <a href="javascript:void(0)" class="dropbtn">Sesión</a>
      <div class="dropdown-content">
        <a href="Home.aspx">Salir</a>
      </div>
    </li>
      
  </ul>
       
    <div class="center">
           
        <hr>
        </hr>
        <h2>Transferencia</h2>
        <hr>
        </hr>
        <p>Ingresa el monto a transferir</p>
        <input type="text" id="monto" runat="server"></input>
        
        <p>Seleccione la cuenta de origen</p>
        <div class="box">
            <asp:DropDownList runat="server" ID="ddlLista" />
        </div>
        <p>Ingresa el numero de cuenta</p>
        <input type="text" id="cuenta"   runat="server"></input>
             
           
        <button class="button"  id="btnLogin" runat="server" onclick="btnLogin_Click"  >
            <asp:Button  type="submit" ID="Button1" runat="server" OnClick="btnLogin_Click" Text="Ingresar"/>

        </button>
        <br></br>
        <div class="in_card" id="card2" runat="server">
            <p>Desde</p> 
            <h1><asp:Label ID="label1" runat="server"></asp:Label>  </h1>
            <p>Saldo disponible</p>
            <h1> <asp:Label ID="label2" runat="server"></asp:Label>   </h1>
           
        </div>
        <br></br>
        <div class="in_card"  id="card1" runat="server">
            <p>Para</p>
            <h1><asp:Label ID="label3" runat="server"></asp:Label>   </h1>
            <p>Cuenta</p>
            <h1><asp:Label ID="label4" runat="server"></asp:Label> </h1>
              
        </div>
        <button class="button"><asp:Button  type="submit" ID="Button3" runat="server" OnClick="btnTrans_Click" Text="Ingresar"/></button>
    </div>
    </form>
</body>
</html>
