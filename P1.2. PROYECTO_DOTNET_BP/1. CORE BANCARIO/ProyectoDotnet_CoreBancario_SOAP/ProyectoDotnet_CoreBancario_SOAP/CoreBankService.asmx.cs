using ProyectoDotnet_CoreBancario_SOAP.ec.edu.monster.modelo;
using ProyectoDotnet_CoreBancario_SOAP.ec.edu.mosnter.controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProyectoDotnet_CoreBancario_SOAP
{
    /// <summary>
    /// Summary description for CoreBankService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CoreBankService : System.Web.Services.WebService
    {


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public Cliente buscarCliente(String cedula, String cuenta) {
            ServicioCore service = new ServicioCore();
            return service.buscarCliente(cedula, cuenta);
        }

        [WebMethod]
        public List<Cuenta> obtenerCuentas(String cedula)
        {
            ServicioCore service = new ServicioCore();
            return service.cuentasClientes(cedula);

        }

        [WebMethod]
        public List<Movimiento> obtenerMovimientos(String cuenta)
        {
            ServicioCore service = new ServicioCore();
            return service.listarMovimientos(cuenta);
        }

        [WebMethod]
        public Boolean transferirDinero(String cuentaOrig, double monto, String cuentaDest)
        {
            ServicioCore service = new ServicioCore();
            return service.transferenciaDinero(cuentaOrig, monto, cuentaDest);
        }


        [WebMethod]
        public Double obtenerSaldoCuenta(String cuenta)
        {
            ServicioCore service = new ServicioCore();
            return service.obtenerSaldoCuenta(cuenta);
        }


        [WebMethod]
        public Cliente obtenerClienteDestino(String cuenta)
        {
            ServicioCore service = new ServicioCore();
            return service.obtenerClienteDestino(cuenta);
        }

        [WebMethod]
        public Boolean validarCuenta(String cuenta)
        {
            ServicioCore service = new ServicioCore();
            return service.valCuenta(cuenta);
        }

        [WebMethod]
        public Cuenta obtenerCuenta(String cuenta)
        {
            ServicioCore service = new ServicioCore();
            return service.obtenerCuenta(cuenta);
        }

        [WebMethod]
        public Cliente obtenerCliente(int num)
        {
            ServicioCore service = new ServicioCore();
            return service.obtenerCliente(num);
        }

    }
}
