using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HasznaltAuto.Models
{
    public partial class HasznaltautoContext : DbContext
    {
        public HasznaltautoContext()
        {
        }

        public HasznaltautoContext(DbContextOptions<HasznaltautoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hasznaltauto> Hasznaltauto { get; set; }
        public virtual DbSet<Kepek> Kepek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["Hasznaltauto"].ConnectionString);
                //"Data Source=gyurebalint-personalprojects.database.windows.net;Initial Catalog=Hasznaltautok;User ID=gyurebalint;Password=sherLOCKED1234;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hasznaltauto>(entity =>
            {
                entity.Property(e => e.AbroncsMeret).IsUnicode(false);

                entity.Property(e => e.Allapot).IsUnicode(false);

                entity.Property(e => e.AutoGyarto).IsUnicode(false);

                entity.Property(e => e.AutoTipus).IsUnicode(false);

                entity.Property(e => e.Hajtas).IsUnicode(false);

                entity.Property(e => e.Hirdeteskod).IsUnicode(false);

                entity.Property(e => e.Kivitel).IsUnicode(false);

                entity.Property(e => e.KlimaFajta).IsUnicode(false);

                entity.Property(e => e.Leiras).IsUnicode(false);

                entity.Property(e => e.Link).IsUnicode(false);

                entity.Property(e => e.Okmanyok).IsUnicode(false);

                entity.Property(e => e.Regdate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sebessegvalto).IsUnicode(false);

                entity.Property(e => e.Szin).IsUnicode(false);

                entity.Property(e => e.Uzemanyag).IsUnicode(false);
            });

            modelBuilder.Entity<Kepek>(entity =>
            {
                entity.HasKey(e => e.ImagesId)
                    .HasName("PK__Kepek__0E2E80DF52146487");

                entity.Property(e => e.Hash).IsUnicode(false);

                entity.Property(e => e.Hirdeteskod).IsUnicode(false);

                entity.HasOne(d => d.Hasznaltauto)
                    .WithMany(p => p.Kepek)
                    .HasForeignKey(d => d.HasznaltautoId)
                    .HasConstraintName("FK__Kepek__Hasznalta__73BA3083");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
