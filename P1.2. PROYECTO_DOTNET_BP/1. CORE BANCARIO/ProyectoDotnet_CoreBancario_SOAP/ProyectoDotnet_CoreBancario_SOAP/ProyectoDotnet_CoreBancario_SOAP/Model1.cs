namespace ProyectoDotnet_CoreBancario_SOAP
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<USUARIO> USUARIO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<USUARIO>()
                .Property(e => e.VCH_USUNOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.VCH_USUAPELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.VCH_USUCEDULA)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.VCH_USUDIRECCION)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.VCH_USUTELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.VCH_USUEMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.VCH_USUUSUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.VCH_USUPASSWORD)
                .IsUnicode(false);
        }
    }
}
