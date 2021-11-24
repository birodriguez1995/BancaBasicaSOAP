<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="Proyecto_Dotnet_BE_SOAP.ec.edu.monster.vista.inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="UTF-8">
    <link rel="stylesheet" type="text/css" href="estilos_inicio.css" media="screen" />
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
    <asp:Label ID="l2" runat="server"></asp:Label>      
</section>
</div>



    <ul>
        <li><a href="inicio.html">Inicio</a></li>
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
                <a href="#">Salir</a>
            </div>
        </li>
    </ul>

    <div class="wrapper">

        <header>
            <h1>Servicios</h1>
        </header>

        <section class="columns">

            <div class="column">
                <h2>Posición consolidada</h2>
                <div class="flip-card">
                    <div class="flip-card-inner">
                        <div class="flip-card-front">
                            <img src="img/posicion.jpg" alt="Avatar" style="width:300px;height:300px;">
                        </div>
                        <div class="flip-card-back">
                            <h1>Posición consolidada</h1>
                            <p>Muestra las cuentas que se tiene con la información de la misma</p>
                        </div>
                    </div>
                </div>
            </div>

            <div class="column">
                <h2>Detalle de movimientos</h2>
                <div class="flip-card">
                    <div class="flip-card-inner">
                        <div class="flip-card-front">
                            <img src="img/movimientos.jpg" alt="Avatar" style="width:300px;height:300px;">
                        </div>
                        <div class="flip-card-back">
                            <h1>Detalle de movimientos</h1>
                            <p>Muestra una lista de todos los movimientos ordenados por la fecha en que fueron realizados</p>
                        </div>
                    </div>
                </div>
            </div>

            <div class="column">
                <h2>Transferencias</h2>
                <div class="flip-card">
                    <div class="flip-card-inner">
                        <div class="flip-card-front">
                            <img src="img/transferencias.png" alt="Avatar" style="width:300px;height:300px;">
                        </div>
                        <div class="flip-card-back">
                            <h1>Transferencias</h1>
                            <p>Se puede tranferir dinero entre las cuentas pertenecientes al cliente o a otras del mismo banco</p>
                        </div>
                    </div>
                </div>
            </div>

        </section>

    </div>
    </form>
</body>
</html>
