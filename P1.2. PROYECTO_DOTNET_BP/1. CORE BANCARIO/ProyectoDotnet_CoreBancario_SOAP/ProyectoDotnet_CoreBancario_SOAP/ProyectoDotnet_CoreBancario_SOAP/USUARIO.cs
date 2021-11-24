namespace ProyectoDotnet_CoreBancario_SOAP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [Key]
        public int INT_USUCODIGO { get; set; }

        [StringLength(50)]
        public string VCH_USUNOMBRE { get; set; }

        [StringLength(50)]
        public string VCH_USUAPELLIDO { get; set; }

        [StringLength(10)]
        public string VCH_USUCEDULA { get; set; }

        [StringLength(100)]
        public string VCH_USUDIRECCION { get; set; }

        [StringLength(20)]
        public string VCH_USUTELEFONO { get; set; }

        [StringLength(100)]
        public string VCH_USUEMAIL { get; set; }

        [StringLength(100)]
        public string VCH_USUUSUARIO { get; set; }

        [StringLength(100)]
        public string VCH_USUPASSWORD { get; set; }
    }
}
