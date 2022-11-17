using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SuperShop.Models.Data
{
    public partial class FakeDexContext : DbContext
    {
        public FakeDexContext()
        {
        }

        public FakeDexContext(DbContextOptions<FakeDexContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Shipping> Shipping { get; set; } = null!;
        public virtual DbSet<Tracking> Tracking { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;
        public virtual DbSet<Suggestion> Suggestion { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("host=localhost;port=3306;user id=root;password=s3cur3P4ssw0rd;database=FakeDex", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.ToTable("Shipping");

                entity.HasIndex(e => e.IdUser, "IX_Shipping_idUseremail");

                entity.Property(e => e.AddressD)
                    .HasMaxLength(255)
                    .HasColumnName("addressD");

                entity.Property(e => e.AddressO)
                    .HasMaxLength(255)
                    .HasColumnName("addressO");

                entity.Property(e => e.IdUser)
                    .HasMaxLength(100)
                    .HasColumnName("idUser");

                entity.Property(e => e.NameD)
                    .HasMaxLength(255)
                    .HasColumnName("nameD");

                entity.Property(e => e.NameO)
                    .HasMaxLength(255)
                    .HasColumnName("nameO");

                entity.Property(e => e.PriceD).HasColumnName("priceD");

                entity.Property(e => e.PriceP).HasColumnName("priceP");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Total).HasColumnName("total");
            });

            modelBuilder.Entity<Tracking>(entity =>
            {
                entity.ToTable("Tracking");

                entity.HasIndex(e => e.ShippingId, "IX_Tracking_shippingIdId");

                entity.Property(e => e.Latitud).HasColumnName("latitud");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Longitud).HasColumnName("longitud");

                entity.Property(e => e.ShippingId).HasColumnName("shippingId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PRIMARY");

                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "IX_User_email")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin").HasDefaultValue(false);
            });

            modelBuilder.Entity<Suggestion>(entity =>
            {

                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("Suggestion");

                entity.HasIndex(e => e.Id, "IX_Suggestion_id").IsUnique();

                entity.Property(e => e.Email).HasColumnName("Email");

                entity.Property(e => e.Asunto).HasColumnName("Asunto");

                entity.Property(e => e.Descripcion).HasColumnName("Descripcion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
