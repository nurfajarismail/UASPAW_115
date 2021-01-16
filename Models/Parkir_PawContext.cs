using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UASPAW_115.Models
{
    public partial class Parkir_PawContext : DbContext
    {
        public Parkir_PawContext()
        {
        }

        public Parkir_PawContext(DbContextOptions<Parkir_PawContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FormKeluar> FormKeluar { get; set; }
        public virtual DbSet<FormMasuk> FormMasuk { get; set; }
        public virtual DbSet<JenisKendaraan> JenisKendaraan { get; set; }
        public virtual DbSet<Tarif> Tarif { get; set; }

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormKeluar>(entity =>
            {
                entity.HasKey(e => e.IdKeluar);

                entity.ToTable("Form_keluar");

                entity.Property(e => e.IdKeluar).HasColumnName("ID_keluar");

                entity.Property(e => e.IdKendaraan).HasColumnName("ID_Kendaraan");

                entity.Property(e => e.IdMasuk).HasColumnName("ID_Masuk");

                entity.Property(e => e.IdTarif).HasColumnName("ID_Tarif");

                entity.Property(e => e.TanggalKeluar)
                    .HasColumnName("Tanggal_keluar")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdKendaraanNavigation)
                    .WithMany(p => p.FormKeluar)
                    .HasForeignKey(d => d.IdKendaraan)
                    .HasConstraintName("FK_Form_keluar_Jenis_Kendaraan");

                entity.HasOne(d => d.IdMasukNavigation)
                    .WithMany(p => p.FormKeluar)
                    .HasForeignKey(d => d.IdMasuk)
                    .HasConstraintName("FK_Form_keluar_Form_masuk");

                entity.HasOne(d => d.IdTarifNavigation)
                    .WithMany(p => p.FormKeluar)
                    .HasForeignKey(d => d.IdTarif)
                    .HasConstraintName("FK_Form_keluar_Tarif");
            });

            modelBuilder.Entity<FormMasuk>(entity =>
            {
                entity.HasKey(e => e.IdMasuk);

                entity.ToTable("Form_masuk");

                entity.Property(e => e.IdMasuk).HasColumnName("ID_Masuk");

                entity.Property(e => e.NoPolisi)
                    .HasColumnName("No_Polisi")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TanggalMasuk)
                    .HasColumnName("Tanggal_masuk")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<JenisKendaraan>(entity =>
            {
                entity.HasKey(e => e.IdKendaraan);

                entity.ToTable("Jenis_Kendaraan");

                entity.Property(e => e.IdKendaraan).HasColumnName("ID_Kendaraan");

                entity.Property(e => e.JenisKendaraan1)
                    .HasColumnName("Jenis_Kendaraan")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tarif>(entity =>
            {
                entity.HasKey(e => e.IdTarif);

                entity.Property(e => e.IdTarif).HasColumnName("ID_Tarif");

                entity.Property(e => e.TarifHarga)
                    .HasColumnName("Tarif_Harga")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}
