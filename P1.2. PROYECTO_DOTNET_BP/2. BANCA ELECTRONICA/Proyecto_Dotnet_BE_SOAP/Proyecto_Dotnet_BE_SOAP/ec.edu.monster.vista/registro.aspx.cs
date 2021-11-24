using Proyecto_Dotnet_BE_SOAP.ec.edu.monster.controlador;
using Proyecto_Dotnet_BE_SOAP.ec.edu.monster.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Dotnet_BE_SOAP.ec.edu.monster.vista
{
    public partial class registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            CoreBankService.CoreBankServiceSoapClient bankClient = new CoreBankService.CoreBankServiceSoapClient();

            BECore core = new BECore();

           Boolean user = core.registrarUsuario(txtcedula.Text,txtcuenta.Text);



            if (user)
            {

                registro.MessageBox(this, "Usuario Creado");
                Response.Redirect("Home.aspx");

            }
            else
            {
                registro.MessageBox(this, "Datos Incorrectos o Usuario Existente");
            }




        }

        public static void MessageBox(System.Web.UI.Page page, string strMsg)
        {
            //+ character added after strMsg "')"
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + strMsg + "')", true);

        }
    }
}