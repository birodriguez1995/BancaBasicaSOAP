using ProyectoDotnet_CoreBancario_SOAP.ec.edu.monster.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoDotnet_CoreBancario_SOAP.ec.edu.mosnter.controlador
{
    public class ServicioCore
    {
        public Cliente buscarCliente(String cedula, String cuenta1) {

            Cliente cli = new Cliente();
            try
            {
                DB.core_bancarioEntities db = new DB.core_bancarioEntities();

                var cliente = (from c in db.CLIENTE
                               where c.VCH_CLIECEDULA == cedula
                               select c).FirstOrDefault();
                if (cliente != null)
                {
                    cli.int_cliecodigo = (cliente.INT_CLIECODIGO);
                    cli.vch_clieapellido = (cliente.VCH_CLIEAPELLIDO);
                    cli.vch_cliecedula = (cliente.VCH_CLIECEDULA);
                    cli.vch_cliedireccion = (cliente.VCH_CLIEDIRECCION);
                    cli.vch_clieemail = (cliente.VCH_CLIEEMAIL);
                    cli.vch_clienombre = (cliente.VCH_CLIENOMBRE);
                    cli.vch_clietelefono = (cliente.VCH_CLIETELEFONO);



                    //Para determinar si existe una cuenta del cliente
                    var cuenta = (from c in db.CUENTA
                                  where c.VCH_CUENNUMERO == cuenta1
                                  && c.INT_CLIECODIGO == cli.int_cliecodigo
                                  select c
                                  ).FirstOrDefault();
                    if (cuenta != null)
                    {
                        return cli;
                    }
                    else {
                        return new Cliente();
                    }



                }
                else {
                    return new Cliente();
                }

            }
            catch (Exception ex)
            {
                return new Cliente();
            }

        }

        public List<Cuenta> cuentasClientes(String cedula) {

            DB.core_bancarioEntities db = new DB.core_bancarioEntities();
            try {


                List<Cuenta> listaCuenta = new List<Cuenta>();
                int numCliente = obtenerCodigoCliente(cedula);
                if (numCliente != 0)
                {
                    listaCuenta = (from c in db.CUENTA
                                   where c.INT_CLIECODIGO == numCliente
                                   select new Cuenta() {
                                       INT_CUENCODIGO = c.INT_CUENCODIGO,
                                       INT_CLIECODIGO = c.INT_CLIECODIGO,
                                       VCH_CUENNUMERO = c.VCH_CUENNUMERO,
                                       VCH_CUENTIPO = c.VCH_CUENTIPO,
                                       DEC_CUENSALDO = c.DEC_CUENSALDO,
                                       DTT_CUENFECHACREACION = c.DTT_CUENFECHACREACION
                                   }
                                   ).ToList();

                    return listaCuenta;
                }
                else
                {
                    List<Cuenta> listaCuenta1 = new List<Cuenta>();
                    return listaCuenta1;
                }
            }
            catch (Exception ex) {
                List<Cuenta> listaCuenta1 = new List<Cuenta>();
                return listaCuenta1;
            }
        }



        public List<Movimiento> listarMovimientos(String cuenta) {

            DB.core_bancarioEntities db = new DB.core_bancarioEntities();
            try
            {
                List<Movimiento> listaMovimiento = new List<Movimiento>();


                listaMovimiento = (from c in db.MOVIMIENTO
                                   where c.VCH_MOVICUENTORIG == cuenta
                                   select new Movimiento()
                                   {
                                       INT_MOVICODIGO = c.INT_MOVICODIGO,
                                       INT_CUENCODIGO = c.INT_CUENCODIGO,
                                       DTT_MOVIFECHA = c.DTT_MOVIFECHA,
                                       VCH_MOVITIPO = c.VCH_MOVITIPO,
                                       DEC_MOVIVALOR = c.DEC_MOVIVALOR,
                                       DEC_MOVISALDOFINAL = c.DEC_MOVISALDOFINAL,
                                       VCH_MOVICUENTORIG = c.VCH_MOVICUENTORIG,
                                       VCH_MOVICUENTDEST = c.VCH_MOVICUENTDEST
                                   }
                               ).ToList();

                return listaMovimiento;



            }
            catch (Exception ex)
            {
                List<Movimiento> listaCuenta1 = new List<Movimiento>();
                return listaCuenta1;
            }


        }

        public int obtenerCodigoCliente(String cedula) {
            Cliente cli = new Cliente();
            try
            {
                DB.core_bancarioEntities db = new DB.core_bancarioEntities();

                var cliente = (from c in db.CLIENTE
                               where c.VCH_CLIECEDULA == cedula
                               select c).FirstOrDefault();
                if (cliente != null)
                {
                    cli.int_cliecodigo = (cliente.INT_CLIECODIGO);
                    cli.vch_clieapellido = (cliente.VCH_CLIEAPELLIDO);
                    cli.vch_cliecedula = (cliente.VCH_CLIECEDULA);
                    cli.vch_cliedireccion = (cliente.VCH_CLIEDIRECCION);
                    cli.vch_clieemail = (cliente.VCH_CLIEEMAIL);
                    cli.vch_clienombre = (cliente.VCH_CLIENOMBRE);
                    cli.vch_clietelefono = (cliente.VCH_CLIETELEFONO);



                    //Para determinar si existe una cuenta del cliente

                    return cli.int_cliecodigo;


                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }

        }


        public Boolean valCuenta(String cuenta) {
            try
            {
                DB.core_bancarioEntities db = new DB.core_bancarioEntities();
                var cliente = (from c in db.CUENTA
                               where c.VCH_CUENNUMERO == cuenta
                               select c).FirstOrDefault();
                if (cliente != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }



        }

        public Boolean transferenciaDinero(String cuentaOrig, double monto, String cuentaDest)
        {
            try
            {
                DB.core_bancarioEntities db = new DB.core_bancarioEntities();

                if (valCuenta(cuentaOrig) == true && valCuenta(cuentaDest) == true && cuentaOrig != cuentaDest) {
                    double saldoO = this.obtenerSaldoCuenta(cuentaOrig);
                    double saldoD = this.obtenerSaldoCuenta(cuentaDest);

                    if (saldoO >= monto)
                    {
                        registroMovDebito(cuentaOrig, saldoO, monto, cuentaDest);
                        registroMovCredito(cuentaDest, saldoD, monto, cuentaOrig);
                        return true;
                    }
                    else {
                        return false;
                    }
                }

                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }



        }

        //REGISTRO MOVIMIENTO DEBITO
        //falta actualizar cuenta
        public void registroMovDebito(String o, double s, double m, String d) {
            try
            {
                DB.core_bancarioEntities db = new DB.core_bancarioEntities();


                DB.MOVIMIENTO movi = new DB.MOVIMIENTO();

                movi.INT_CUENCODIGO = obtenerCodigoCuenta(o);

                movi.DTT_MOVIFECHA = DateTime.Now;
                movi.VCH_MOVITIPO = "DÉBITO";
                movi.DEC_MOVIVALOR = Convert.ToDecimal(m);
                movi.DEC_MOVISALDOFINAL = Convert.ToDecimal(s - m);
                movi.VCH_MOVICUENTORIG = o;
                movi.VCH_MOVICUENTDEST = d;

                db.MOVIMIENTO.Add(movi);
                db.SaveChanges();


                var query = (from a in db.CUENTA
                             where a.VCH_CUENNUMERO == o
                             select a).FirstOrDefault();

                query.DEC_CUENSALDO = Convert.ToDecimal(s - m);


                db.SaveChanges();


            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR");
            }
        }



        //**/*/*/**
        //REGISTRO MOVIMIENTO DEBITO
        //falta actualizar cuenta
        public void registroMovCredito(String o, double s, double m, String d)
        {
            try
            {
                DB.core_bancarioEntities db = new DB.core_bancarioEntities();


                DB.MOVIMIENTO movi = new DB.MOVIMIENTO();

                movi.INT_CUENCODIGO = obtenerCodigoCuenta(o);

                movi.DTT_MOVIFECHA = DateTime.Now;
                movi.VCH_MOVITIPO = "CRÉDITO";
                movi.DEC_MOVIVALOR = Convert.ToDecimal(m);
                movi.DEC_MOVISALDOFINAL = Convert.ToDecimal(s + m);
                movi.VCH_MOVICUENTORIG = o;
                movi.VCH_MOVICUENTDEST = d;

                db.MOVIMIENTO.Add(movi);
                db.SaveChanges();


                var query = (from a in db.CUENTA
                             where a.VCH_CUENNUMERO == o
                             select a).FirstOrDefault();

                query.DEC_CUENSALDO = Convert.ToDecimal(s + m);


                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR");
            }
        }


        public Double obtenerSaldoCuenta(String cuenta) {

            DB.core_bancarioEntities db = new DB.core_bancarioEntities();

            var cliente = (from c in db.CUENTA
                           where c.VCH_CUENNUMERO == cuenta
                           select c).FirstOrDefault();
            if (cliente != null)
            {
                return Convert.ToDouble(cliente.DEC_CUENSALDO);
            }
            else {
                return Convert.ToDouble(-1);
            }


        }


        public int obtenerCodigoCuenta(String cuenta)
        {
            Cliente cli = new Cliente();
            try
            {
                DB.core_bancarioEntities db = new DB.core_bancarioEntities();




                var cliente = (from c in db.CUENTA
                               where c.VCH_CUENNUMERO == cuenta
                               select c).FirstOrDefault();
                if (cliente != null)
                {
                    return cliente.INT_CUENCODIGO;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }

        }


        //VALIDAR SALDO CUENTA
        public Cuenta obtenerCuenta(String cuenta) {
            Cuenta cuentaRec = new Cuenta();
            try {
                DB.core_bancarioEntities db = new DB.core_bancarioEntities();
                var cliente = (from c in db.CUENTA
                               where c.VCH_CUENNUMERO == cuenta
                               select c).FirstOrDefault();

                cuentaRec.INT_CUENCODIGO = cliente.INT_CUENCODIGO;
                cuentaRec.INT_CLIECODIGO = cliente.INT_CLIECODIGO;
                cuentaRec.VCH_CUENNUMERO = cliente.VCH_CUENNUMERO;
                cuentaRec.VCH_CUENTIPO = cliente.VCH_CUENTIPO;
                cuentaRec.DEC_CUENSALDO = cliente.DEC_CUENSALDO;
                cuentaRec.DTT_CUENFECHACREACION = cliente.DTT_CUENFECHACREACION;
                if (cliente != null)
                {
                    return cuentaRec;

                }
                else {
                    Cuenta cuentaRec1 = new Cuenta();
                    return cuentaRec1;
                }


            }
            catch (Exception e) {
                Cuenta cuentaRec1 = new Cuenta();
                return cuentaRec1;
            }
        }

        // Obtyener cliente destino
        public Cliente obtenerClienteDestino(String cuenta)
        {


            try
            {
                DB.core_bancarioEntities db = new DB.core_bancarioEntities();

                var cliente = (from c in db.CUENTA
                               where c.VCH_CUENNUMERO == cuenta
                               select c).FirstOrDefault();
                if (cliente != null)
                {
                    Cliente cli = new Cliente();
                    int cod = cliente.INT_CLIECODIGO;
                    cli = this.obtenerCliente(cod);
                    return cli;


                }
                else
                {
                    return new Cliente();
                }

            }
            catch (Exception ex)
            {
                return new Cliente();
            }

        }


        public Cliente obtenerCliente(int codigo)
        {

            
            try
            {
                DB.core_bancarioEntities db = new DB.core_bancarioEntities();

                var cliente = (from c in db.CLIENTE
                               where c.INT_CLIECODIGO == codigo
                               select c).FirstOrDefault();
                if (cliente != null)
                {
                    Cliente cli = new Cliente();
                    cli.int_cliecodigo = (cliente.INT_CLIECODIGO);
                    cli.vch_clieapellido = (cliente.VCH_CLIEAPELLIDO);
                    cli.vch_cliecedula = (cliente.VCH_CLIECEDULA);
                    cli.vch_cliedireccion = (cliente.VCH_CLIEDIRECCION);
                    cli.vch_clieemail = (cliente.VCH_CLIEEMAIL);
                    cli.vch_clienombre = (cliente.VCH_CLIENOMBRE);
                    cli.vch_clietelefono = (cliente.VCH_CLIETELEFONO);

                    return cli;
                }
                else
                {
                    return new Cliente();
                }

            }
            catch (Exception ex)
            {
                return new Cliente();
            }

        }


    }


    }



  






