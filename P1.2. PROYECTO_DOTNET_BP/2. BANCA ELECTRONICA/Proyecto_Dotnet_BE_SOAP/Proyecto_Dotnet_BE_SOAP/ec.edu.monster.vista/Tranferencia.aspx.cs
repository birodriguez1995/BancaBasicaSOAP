using Proyecto_Dotnet_BE_SOAP.ec.edu.monster.controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Dotnet_BE_SOAP.ec.edu.monster.vista
{
    public partial class Tranferencia : System.Web.UI.Page
    {
        ListItem z;

        protected void Page_Load(object sender, EventArgs e)
        {
            //l2.Text = "Bienvenido ve  " + Session["name"].ToString();
            l22.Text = "Bienvenido " + Session["name"].ToString();
            card1.Visible = false;
            card2.Visible = false;
            Button3.Visible = false;
            if (Page.IsPostBack)
            {

            }
            else
            {
                comoboBox();
               
            }
        }

        public void limpiar() {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            monto.Value = "";
            cuenta.Value = "";
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
           
            CoreBankService.CoreBankServiceSoapClient bankClient = new CoreBankService.CoreBankServiceSoapClient();
            BECore core = new BECore();
            if ( cuenta.Value != "" && monto.Value != "" ) {
                if (cuenta.Value!= ddlLista.SelectedItem.Text && core.obtnerSaldo(ddlLista.SelectedItem.Text) > Convert.ToDouble(monto.Value) && bankClient.validarCuenta(cuenta.Value))
                {
                    CoreBankService.Cliente cli = (core.obtenerClienteDestino(cuenta.Value));
                    ShowMessage("CORRECTO");
                    label1.Text = ddlLista.SelectedItem.Text;
                    label2.Text = core.obtnerSaldo(ddlLista.SelectedItem.Text) + "";
                    label3.Text = cli.vch_clienombre + " " + cli.vch_clieapellido;
                    label4.Text = cuenta.Value;
                    card1.Visible = true;
                    card2.Visible = true;
                    Button3.Visible = true;



                }
                else
                {
                    ShowMessage("ERRRO");
                }
            }
            else
            {
                ShowMessage("LLENA LOS DATOS VE");
            }



        }


        protected void btnTrans_Click(object sender, EventArgs e) {
            CoreBankService.CoreBankServiceSoapClient bankClient = new CoreBankService.CoreBankServiceSoapClient();
            if (bankClient.transferirDinero(ddlLista.SelectedItem.Text, Convert.ToDouble(monto.Value), cuenta.Value))
            {
                ShowMessage("TRANSFERENCIA REALIZADA");
                card1.Visible = false;
                card2.Visible = false;
                Button3.Visible = false;
                limpiar();
            }
            else
            {
                ShowMessage("ERROR");
            }

        }


            void comoboBox()
        {
            CoreBankService.CoreBankServiceSoapClient bankClient = new CoreBankService.CoreBankServiceSoapClient();
            List<CoreBankService.Cuenta> user = bankClient.obtenerCuentas((string)Session["cedula"]);
            

            if (user != null)

            {
                

                for (int i = 0; i < user.Count; i++)
                {
                    z = new ListItem(user[i].VCH_CUENNUMERO, i + "");
                    ddlLista.Items.Add(z);
                }
            }
            else
            {

            }

        }

        public void ShowMessage(string message)
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
    }
    }