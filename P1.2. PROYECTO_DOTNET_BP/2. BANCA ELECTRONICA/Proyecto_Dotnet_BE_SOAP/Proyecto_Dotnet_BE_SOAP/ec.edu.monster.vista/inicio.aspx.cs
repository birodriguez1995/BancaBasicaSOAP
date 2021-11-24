using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Dotnet_BE_SOAP.ec.edu.monster.vista
{
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            l2.Text = "Bienvenido " + Session["name"].ToString();
        }
    }
}