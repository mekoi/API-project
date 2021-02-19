using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MarketPriceLibrary.Models
{
    public partial class MarketDataDBContext : DbContext
    {
        public MarketDataDBContext()
        {
        }

        public MarketDataDBContext(DbContextOptions<MarketDataDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssetClass> AssetClass { get; set; }
        public virtual DbSet<Instrument> Instrument { get; set; }
        public virtual DbSet<MarketPrice> MarketPrice { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=instancecomp306.cxs6dspt83l7.us-east-2.rds.amazonaws.com,1433;database=MarketDataDB;User ID=master;Password=123Pass321;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetClass>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("PK__AssetCla__CB1927C006F188BC");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Instrument>(entity =>
            {
                entity.Property(e => e.InstrumentName).HasMaxLength(25);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Instrument)
                    .HasForeignKey(d => d.ClassId);
            });

            modelBuilder.Entity<MarketPrice>(entity =>
            {
                entity.HasKey(e => e.PriceId)
                    .HasName("PK__MarketPr__49575BAFDAE6D434");

                entity.HasIndex(e => new { e.InstrumentId, e.Date })
                    .HasName("UNIQUE_InstrumentId_Date")
                    .IsUnique();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Instrument)
                    .WithMany(p => p.MarketPrice)
                    .HasForeignKey(d => d.InstrumentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MarketPrice_Instrument");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
