using Proyecto_Dotnet_BE_SOAP.ec.edu.monster.controlador;
using Proyecto_Dotnet_BE_SOAP.ec.edu.monster.modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Dotnet_BE_SOAP.ec.edu.monster.vista
{
    public partial class movimientos : System.Web.UI.Page
    {

     


        protected void Page_Load(object sender, EventArgs e)
        {
            l2.Text = "Bienvenido  " + Session["name"].ToString();


            if (Page.IsPostBack)
            {

            }
            else {
                comoboBox();
            }

        }


        void  comoboBox() {
            
            ListItem z = new ListItem();
            CoreBankService.CoreBankServiceSoapClient bankClient = new CoreBankService.CoreBankServiceSoapClient();
            List<CoreBankService.Cuenta> user = bankClient.obtenerCuentas(Session["cedula"].ToString());

            

            for (int i=0; i<user.Count;i++) {
                    z = new ListItem(user[i].VCH_CUENNUMERO,i+"");
                    ddlLista.Items.Add(z);
                }
           

        }

  

        protected void btnMovi_Click(object sender, EventArgs e)
        {

            String valor=ddlLista.SelectedItem.Text;

            BECore core = new BECore();

            List<CoreBankService.Movimiento> user = core.detalleMovimientos(ddlLista.SelectedItem.Text);

            if (user != null)

            {
                gvMovimientos.DataSource = user.ToList();

                gvMovimientos.DataBind();
                

            }
            else
            {

            }


        }








    }




}





