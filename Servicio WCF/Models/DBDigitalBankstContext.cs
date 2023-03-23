

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Servicio_WCF.Models
{
    public partial class DBDigitalBankstContext : DbContext
    {
        public DBDigitalBankstContext()
        {
        }

        public DBDigitalBankstContext(DbContextOptions<DBDigitalBankstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            if (!optionsBuilder.IsConfigured)
            {
                String cadena = "";
                cadena = $"Data Source={App.Default.DataSource};Initial Catalog={App.Default.InitialCatalog};Persist Security Info=True;User ID={App.Default.UserID};Password={App.Default.Password};TrustServerCertificate=True;";

                if (App.Default.AuthWindow) {
                    cadena = $"Data Source={App.Default.DataSource};Initial Catalog={App.Default.InitialCatalog};Integrated Security=True;";
                }
                cadena = "workstation id=DBDigitalBankst.mssql.somee.com;packet size=4096;user id=juandiegows_SQLLogin_1;pwd=rmv3ca7qwy;data source=DBDigitalBankst.mssql.somee.com;persist security info=False;initial catalog=DBDigitalBankst;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(cadena, x => x.UseDateOnlyTimeOnly());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.HasKey(e => e.Nombre);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.SexoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.Sexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Sexo");
            });

            OnModelCreatingGeneratedProcedures(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}