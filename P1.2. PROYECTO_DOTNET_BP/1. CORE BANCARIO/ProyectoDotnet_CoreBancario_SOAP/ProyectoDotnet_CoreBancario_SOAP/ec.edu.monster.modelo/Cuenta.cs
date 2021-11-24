using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoDotnet_CoreBancario_SOAP.ec.edu.monster.modelo
{
    public class Cuenta
    {
        public int INT_CUENCODIGO { get; set; }
        public int INT_CLIECODIGO { get; set; }
        public string VCH_CUENNUMERO { get; set; }
        public string VCH_CUENTIPO { get; set; }
        public Nullable<decimal> DEC_CUENSALDO { get; set; }
        public Nullable<System.DateTime> DTT_CUENFECHACREACION { get; set; }

    }
}