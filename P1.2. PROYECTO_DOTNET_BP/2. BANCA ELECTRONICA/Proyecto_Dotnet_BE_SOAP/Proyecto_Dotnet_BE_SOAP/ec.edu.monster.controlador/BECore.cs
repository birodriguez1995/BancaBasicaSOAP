using Proyecto_Dotnet_BE_SOAP.Base;
using Proyecto_Dotnet_BE_SOAP.ec.edu.monster.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Dotnet_BE_SOAP.ec.edu.monster.controlador
{
    public class BECore
    {
        

        public Boolean registrarUsuario(String cedula, String cuenta) {

            CoreBankService.CoreBankServiceSoapClient bankClient = new CoreBankService.CoreBankServiceSoapClient();

           CoreBankService.Cliente cliente = bankClient.buscarCliente(cedula,cuenta);

            if (cliente.int_cliecodigo==0) {
                return false;
            }
            else {

                if (usuarioRepetido(cliente.vch_cliecedula))
                {

                    Base.banca_electronicaEntities be = new Base.banca_electronicaEntities();

                    Base.USUARIO user = new Base.USUARIO();

                    user.VCH_USUNOMBRE = cliente.vch_clienombre;
                    user.VCH_USUAPELLIDO = cliente.vch_clieapellido;
                    user.VCH_USUCEDULA = cliente.vch_cliecedula;
                    user.VCH_USUDIRECCION = cliente.vch_cliedireccion;
                    user.VCH_USUTELEFONO = cliente.vch_clietelefono;
                    user.VCH_USUEMAIL = cliente.vch_clieemail;
                    user.VCH_USUUSUARIO = cliente.vch_clieemail;
                    user.VCH_USUPASSWORD = cliente.vch_cliecedula;

                    be.USUARIO.Add(user);
                    be.SaveChanges();
                    return true;
                }
                else {
                    return false;
                }
                
            }
        }


        public Usuario loginUsuario(String email, String cedula) {

            Usuario usuario = new Usuario();
            Base.banca_electronicaEntities db = new Base.banca_electronicaEntities();

            var user = (from c in db.USUARIO
                        where c.VCH_USUPASSWORD == cedula 
                        &&
                        c.VCH_USUUSUARIO == email
                        select c).FirstOrDefault();

            
            if (user != null)
            {
                usuario.VCH_USUNOMBRE = user.VCH_USUNOMBRE;
                usuario.VCH_USUAPELLIDO = user.VCH_USUAPELLIDO;
                usuario.INT_USUCODIGO = user.INT_USUCODIGO;
                usuario.VCH_USUCEDULA = user.VCH_USUCEDULA;
                usuario.VCH_USUDIRECCION = user.VCH_USUDIRECCION;
                usuario.VCH_USUTELEFONO = user.VCH_USUTELEFONO;
                usuario.VCH_USUEMAIL = user.VCH_USUEMAIL;
                usuario.VCH_USUUSUARIO = user.VCH_USUUSUARIO;
                usuario.VCH_USUPASSWORD = user.VCH_USUPASSWORD;
                return usuario;

            }
            else
            {
                
                return new Usuario();
            }



        }

        public List<CoreBankService.Cuenta> posicionConsolidad(String cedula)
        {
            List<CoreBankService.Cuenta> listaCuentas = new List<CoreBankService.Cuenta>();


            CoreBankService.CoreBankServiceSoapClient bankClient = new CoreBankService.CoreBankServiceSoapClient();

            List<CoreBankService.Cuenta> lista = bankClient.obtenerCuentas(cedula);

            return lista;

        }


        public List<CoreBankService.Movimiento> detalleMovimientos(String cuenta) {
            //List<CoreBankService.Cuenta> listaCuentas = new List<CoreBankService.Cuenta>();

           

            CoreBankService.CoreBankServiceSoapClient bankClient = new CoreBankService.CoreBankServiceSoapClient();

            List<CoreBankService.Movimiento> listaCuentas = bankClient.obtenerMovimientos(cuenta);

            return listaCuentas;

        }


        public Boolean transferirMoney(String origen, double monto, String destino)
        {
            CoreBankService.CoreBankServiceSoapClient bankClient = new CoreBankService.CoreBankServiceSoapClient();

            return bankClient.transferirDinero(origen, monto, destino);
        }



        public double obtnerSaldo(String numCuenta)
        {
            CoreBankService.CoreBankServiceSoapClient bankClient = new CoreBankService.CoreBankServiceSoapClient();

            return bankClient.obtenerSaldoCuenta(numCuenta);
        }



        public Boolean usuarioRepetido(String cedula)
        {
            Base.banca_electronicaEntities db = new Base.banca_electronicaEntities();
            var user = (from c in db.USUARIO
                           where c.VCH_USUCEDULA == cedula
                           select c).FirstOrDefault();

            if (user == null)
            {
                return true;

            }
            else
            {
                
                return false;
            }


        }


        public CoreBankService.Cliente obtenerClienteDestino(String numCuenta)
        {
            CoreBankService.Cliente cl = new CoreBankService.Cliente();
            CoreBankService.CoreBankServiceSoapClient bankClient = new CoreBankService.CoreBankServiceSoapClient();
            return bankClient.obtenerClienteDestino(numCuenta);
        }


    }
}