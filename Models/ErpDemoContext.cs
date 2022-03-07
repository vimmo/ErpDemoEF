using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Protocols;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ErpDemoEF.Models
{
    public partial class ErpDemoContext : DbContext
    {
        public ErpDemoContext()
        {
        }

        public ErpDemoContext(DbContextOptions<ErpDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articoli> Articoli { get; set; }
        public virtual DbSet<ArticoliListini> ArticoliListini { get; set; }
        public virtual DbSet<CausaliMagazzino> CausaliMagazzino { get; set; }
        public virtual DbSet<Clienti> Clienti { get; set; }
        public virtual DbSet<Listini> Listini { get; set; }
        public virtual DbSet<Movimenti> Movimenti { get; set; }
        public virtual DbSet<MovimentiRighe> MovimentiRighe { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=VINB22;Database=ErpDemo;User ID=sa;Password=sa");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articoli>(entity =>
            {
                entity.Property(e => e.Descrizione)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArticoliListini>(entity =>
            {
                entity.HasKey(e => new { e.Articolo, e.Listino });

                entity.HasOne(d => d.ArticoloNavigation)
                    .WithMany(p => p.ArticoliListini)
                    .HasForeignKey(d => d.Articolo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticoliListini_Articoli");

                entity.HasOne(d => d.ListinoNavigation)
                    .WithMany(p => p.ArticoliListini)
                    .HasForeignKey(d => d.Listino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticoliListini_Listini");
            });

            modelBuilder.Entity<CausaliMagazzino>(entity =>
            {
                entity.HasKey(e => e.Codice);

                entity.Property(e => e.Codice)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Clienti>(entity =>
            {
                entity.Property(e => e.Città)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Indirizzo)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.RagioneSociale)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.ListinoNavigation)
                    .WithMany(p => p.Clienti)
                    .HasForeignKey(d => d.Listino)
                    .HasConstraintName("FK_Clienti_Listini");
            });

            modelBuilder.Entity<Listini>(entity =>
            {
                entity.Property(e => e.Descrizione)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movimenti>(entity =>
            {
                entity.Property(e => e.Causale)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.HasOne(d => d.CausaleNavigation)
                    .WithMany(p => p.Movimenti)
                    .HasForeignKey(d => d.Causale)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movimenti_CausaliMagazzino");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.Movimenti)
                    .HasForeignKey(d => d.Cliente)
                    .HasConstraintName("FK_Movimenti_Clienti");
            });

            modelBuilder.Entity<MovimentiRighe>(entity =>
            {
                entity.HasKey(e => new { e.id, e.Riga });

                entity.Property(e => e.Riga).ValueGeneratedOnAdd();

                entity.HasOne(d => d.ArticoloNavigation)
                    .WithMany(p => p.MovimentiRighe)
                    .HasForeignKey(d => d.Articolo)
                    .HasConstraintName("FK_MovimentiRighe_Articoli");

                entity.HasOne(d => d.idNavigation)
                    .WithMany(p => p.MovimentiRighe)
                    .HasForeignKey(d => d.id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovimentiRighe_Movimenti");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
