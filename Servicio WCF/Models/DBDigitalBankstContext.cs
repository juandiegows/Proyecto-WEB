

using Microsoft.EntityFrameworkCore;

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

  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DBDigitalBankst;Persist Security Info=True;User ID=sa;Password=12345;TrustServerCertificate=True;", x => x.UseDateOnlyTimeOnly());
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