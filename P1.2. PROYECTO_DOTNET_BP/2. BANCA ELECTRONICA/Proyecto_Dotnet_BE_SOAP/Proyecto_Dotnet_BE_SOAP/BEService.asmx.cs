using Proyecto_Dotnet_BE_SOAP.ec.edu.monster.controlador;
using Proyecto_Dotnet_BE_SOAP.ec.edu.monster.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Proyecto_Dotnet_BE_SOAP
{
    /// <summary>
    /// Summary description for BEService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BEService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public Boolean RegistrarUsuario(String cedula, String cuenta)
        {
            BECore core = new BECore();

            return core.registrarUsuario(cedula, cuenta);
        }


        [WebMethod]
        public Boolean usuarioRepetido(String cedula)
        {
            BECore core = new BECore();

            return core.usuarioRepetido(cedula);
        }

        [WebMethod]
        public List<CoreBankService.Cuenta> posicionConsolidad(String cedula)
        {
            BECore core = new BECore();
            return core.posicionConsolidad(cedula);

        }


        [WebMethod]
        public Usuario loginUsuario(String email, String cedula)
        {
            BECore core = new BECore();
            return core.loginUsuario(email,cedula);

        }

        //detalleMovimientos
        [WebMethod]
        public List<CoreBankService.Movimiento> detalleMovimientos(String cuenta)
        {
            BECore core = new BECore();
            return core.detalleMovimientos(cuenta);
        }

        [WebMethod]
        public Boolean transferirDinero(String origen, double monto, String destino)
        {

            BECore core = new BECore();
            return core.transferirMoney(origen, monto, destino);
        }

    }
}