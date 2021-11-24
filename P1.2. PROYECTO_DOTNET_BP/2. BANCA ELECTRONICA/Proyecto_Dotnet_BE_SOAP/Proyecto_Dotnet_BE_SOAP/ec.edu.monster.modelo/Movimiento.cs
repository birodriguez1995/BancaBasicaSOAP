using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Dotnet_BE_SOAP.ec.edu.monster.modelo
{
    public class Movimiento
    {
        public int INT_MOVICODIGO { get; set; }
        public int INT_CUENCODIGO { get; set; }
        public Nullable<System.DateTime> DTT_MOVIFECHA { get; set; }
        public string VCH_MOVITIPO { get; set; }
        public Nullable<decimal> DEC_MOVIVALOR { get; set; }
        public Nullable<decimal> DEC_MOVISALDOFINAL { get; set; }
        public string VCH_MOVICUENTORIG { get; set; }
        public string VCH_MOVICUENTDEST { get; set; }
    }
}