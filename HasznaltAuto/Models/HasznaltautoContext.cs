using System;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:gyurebalint-personalprojects.database.windows.net,1433;Initial Catalog=Hasznaltautok;Persist Security Info=False;User ID=gyurebalint;Password=sherLOCKED1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
