<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="movimientos.aspx.cs" Inherits="Proyecto_Dotnet_BE_SOAP.ec.edu.monster.vista.movimientos" %>

<!DOCTYPE html>


<html>

<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="UTF-8">
    <link rel="stylesheet" type="text/css" href="estilos_movimientos.css" media="screen" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
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
       
          <a href="Home.aspx">Salir</a>
      </div>
    </li>
      
  </ul>
    <hr/ >
        <center><h1>DETALLE DE MOVIMIENTOS</h1></center>
 <hr />

    <center>
        <div class="selector">

        
        <p>Seleccione la cuenta</p>
        <div class="box">
            
              <asp:DropDownList runat="server" ID="ddlLista" />
               <asp:Button Text="Buscar" type="submit" ID="btnConsulta" runat="server" OnClick="btnMovi_Click" CssClass="fa fa-search" />
        </div>
                  
       
    </div>
    </center>
    <table>
        
        <asp:Label runat="server" ID="fer"></asp:Label>

<td colspan="4" class="auto-style8">
                            <center>
                            <asp:GridView ID="gvMovimientos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
                            <Columns>  
                             <asp:BoundField DataField="VCH_MOVICUENTDEST" HeaderText="DESTINO" />  
                            
                                <asp:BoundField DataField="DTT_MOVIFECHA" HeaderText="FECHA" />  
                            <asp:BoundField DataField="VCH_MOVITIPO" HeaderText="MOVIMIENTO" />  
                              <asp:BoundField DataField="DEC_MOVIVALOR" HeaderText="VALOR" />  

                             
                                <asp:BoundField DataField="DEC_MOVISALDOFINAL" HeaderText="SALDO FINAL" /> 
                        </Columns> 
                                
                                
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                                </center>
                        </td>



    </table>


  


</form>
</body>

</html>
