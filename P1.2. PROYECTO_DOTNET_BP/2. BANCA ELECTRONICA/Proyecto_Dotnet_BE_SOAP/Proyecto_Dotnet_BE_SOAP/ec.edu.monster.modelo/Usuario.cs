using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Dotnet_BE_SOAP.ec.edu.monster.modelo
{
    public class Usuario
    {
       
            public int INT_USUCODIGO { get; set; }
            public string VCH_USUNOMBRE { get; set; }
            public string VCH_USUAPELLIDO { get; set; }
            public string VCH_USUCEDULA { get; set; }
            public string VCH_USUDIRECCION { get; set; }
            public string VCH_USUTELEFONO { get; set; }
            public string VCH_USUEMAIL { get; set; }
            public string VCH_USUUSUARIO { get; set; }
            public string VCH_USUPASSWORD { get; set; }
       
    }
}