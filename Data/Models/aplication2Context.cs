using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Models
{
    public partial class aplication2Context : DbContext
    {
        public aplication2Context()
        {
        }

        public aplication2Context(DbContextOptions<aplication2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Aerolinea> Aerolinea { get; set; }
        public virtual DbSet<Aeronave> Aeronave { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Prestamo> Prestamo { get; set; }
        public virtual DbSet<Ruta> Ruta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CARLOS\\SQLEXPRESS;Database=aplication2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Aerolinea>(entity =>
            {
                entity.ToTable("aerolinea");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPais).HasColumnName("idPais");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Aerolinea)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aerolinea__idPai__398D8EEE");
            });

            modelBuilder.Entity<Aeronave>(entity =>
            {
                entity.ToTable("aeronave");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdAerolinea).HasColumnName("idAerolinea");

                entity.Property(e => e.Latitud)
                    .HasColumnName("latitud")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Longitud)
                    .HasColumnName("longitud")
                    .HasColumnType("decimal(7, 4)");

                entity.HasOne(d => d.IdAerolineaNavigation)
                    .WithMany(p => p.Aeronave)
                    .HasForeignKey(d => d.IdAerolinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aeronave__idAero__3C69FB99");
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.ToTable("pais");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Latitud)
                    .HasColumnName("latitud")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Longitud)
                    .HasColumnName("longitud")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.ToTable("prestamo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fechafin)
                    .HasColumnName("fechafin")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechainicio)
                    .HasColumnName("fechainicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPrestador).HasColumnName("idPrestador");

                entity.Property(e => e.IdPropietario).HasColumnName("idPropietario");

                entity.Property(e => e.Idaeronave).HasColumnName("idaeronave");

                entity.HasOne(d => d.IdPrestadorNavigation)
                    .WithMany(p => p.PrestamoIdPrestadorNavigation)
                    .HasForeignKey(d => d.IdPrestador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__prestamo__idPres__44FF419A");

                entity.HasOne(d => d.IdPropietarioNavigation)
                    .WithMany(p => p.PrestamoIdPropietarioNavigation)
                    .HasForeignKey(d => d.IdPropietario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__prestamo__idProp__440B1D61");

                entity.HasOne(d => d.IdaeronaveNavigation)
                    .WithMany(p => p.Prestamo)
                    .HasForeignKey(d => d.Idaeronave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__prestamo__idaero__45F365D3");
            });

            modelBuilder.Entity<Ruta>(entity =>
            {
                entity.ToTable("ruta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fechafin)
                    .HasColumnName("fechafin")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechainicio)
                    .HasColumnName("fechainicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdAeronave).HasColumnName("idAeronave");

                entity.Property(e => e.IdDestino).HasColumnName("idDestino");

                entity.Property(e => e.IdOrigen).HasColumnName("idOrigen");

                entity.HasOne(d => d.IdAeronaveNavigation)
                    .WithMany(p => p.Ruta)
                    .HasForeignKey(d => d.IdAeronave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ruta__idAeronave__3F466844");

                entity.HasOne(d => d.IdDestinoNavigation)
                    .WithMany(p => p.RutaIdDestinoNavigation)
                    .HasForeignKey(d => d.IdDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ruta__idDestino__412EB0B6");

                entity.HasOne(d => d.IdOrigenNavigation)
                    .WithMany(p => p.RutaIdOrigenNavigation)
                    .HasForeignKey(d => d.IdOrigen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ruta__idOrigen__403A8C7D");
            });
        }
    }
}
