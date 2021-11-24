using Proyecto_Dotnet_BE_SOAP.ec.edu.monster.controlador;
using Proyecto_Dotnet_BE_SOAP.ec.edu.monster.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Proyecto_Dotnet_BE_SOAP.ec.edu.monster.vista
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            CoreBankService.CoreBankServiceSoapClient bankClient = new CoreBankService.CoreBankServiceSoapClient();

            BECore core = new BECore();

            Usuario user = core.loginUsuario(txtusuario.Text, txtpassword.Text);



            //List<CoreBankService.Cuenta> lista = bankClient.obtenerCuentas("1716130321");

           
            if (user.INT_USUCODIGO != 0)
            {

                Home.MessageBox(this, "Success !"+ user.INT_USUCODIGO);
                Session["name"] = user.VCH_USUNOMBRE +" "+ user.VCH_USUAPELLIDO;
                Session["codigo"] = user.VCH_USUUSUARIO;
              
                Session["cedula"] = user.VCH_USUCEDULA;

                Response.Redirect("inicio.aspx");

            }
            else
            {
                Home.MessageBox(this, "Oh no !"+ user.INT_USUCODIGO);
            }


           

        }

        public static void MessageBox(System.Web.UI.Page page, string strMsg)
        {
            //+ character added after strMsg "')"
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + strMsg + "')", true);

        }
    }
}

