using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace controller.usuario.Model
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Idusuario);

                entity.HasIndex(e => e.Email)
                    .HasName("Email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Idperfil)
                    .HasName("fk_Usuarios_Perfis1_idx");

                entity.HasIndex(e => e.Idrevendedora)
                    .HasName("fk_Usuario_Revendedora1_idx");

                entity.HasIndex(e => e.Login)
                    .HasName("Login_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idusuario)
                    .HasColumnName("IDUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cpf).HasColumnType("varchar(14)");

                entity.Property(e => e.Email).HasColumnType("varchar(100)");

                entity.Property(e => e.Idperfil)
                    .HasColumnName("IDPerfil")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idrevendedora)
                    .HasColumnName("IDRevendedora")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IndAtivo).HasDefaultValueSql("'1'");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });
        }
    }
}
