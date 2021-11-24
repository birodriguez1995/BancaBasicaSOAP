using Proyecto_Dotnet_BE_SOAP.ec.edu.monster.controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Dotnet_BE_SOAP.ec.edu.monster.vista
{
    public partial class Consolidado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            l2.Text = "Bienvenido  "+Session["name"].ToString();
            cargarTabla();
            if (Page.IsPostBack)
            {
                cargarTabla();
            }
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            CoreBankService.CoreBankServiceSoapClient bankClient = new CoreBankService.CoreBankServiceSoapClient();

            BECore core = new BECore();
            
            List<CoreBankService.Cuenta> user = core.posicionConsolidad((String)Session["cedula"]);
            IEnumerable<CoreBankService.Cuenta> adapt = (core.posicionConsolidad((String)Session["cedula"]).ToList());

            if (user != null)

            {
                gvMovimientos.DataSource = user.ToList();
               
                
                gvMovimientos.DataBind();
                
            }
            else
            {

            }

        }

        public void cargarTabla() {
            CoreBankService.CoreBankServiceSoapClient bankClient = new CoreBankService.CoreBankServiceSoapClient();

            BECore core = new BECore();

            List<CoreBankService.Cuenta> user = core.posicionConsolidad((String)Session["cedula"]);
            IEnumerable<CoreBankService.Cuenta> adapt = (core.posicionConsolidad((String)Session["cedula"]).ToList());

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