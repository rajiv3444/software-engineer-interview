using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Zip.EmiCalc.DataAccessRepository.EFModels
{
    public partial class zipCoContext : DbContext
    {
        public zipCoContext()
        {
        }

        public zipCoContext(DbContextOptions<zipCoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<PaymentPlan> PaymentPlan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=zipCo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.OrderId)
                    .HasColumnName("orderId")
                    .ValueGeneratedNever();

                entity.Property(e => e.OrderAmount)
                    .HasColumnName("orderAmount")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("orderDate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<PaymentPlan>(entity =>
            {
                entity.HasKey(e => e.PlanId);

                entity.ToTable("paymentPlan");

                entity.Property(e => e.PlanId)
                    .HasColumnName("planId")
                    .ValueGeneratedNever();

                entity.Property(e => e.FrequencyInDays).HasColumnName("frequencyInDays");

                entity.Property(e => e.InstalmentCount).HasColumnName("instalmentCount");

                entity.Property(e => e.OrderRefId).HasColumnName("orderRefId");

                entity.Property(e => e.PerInstalmentCharge)
                    .HasColumnName("perInstalmentCharge")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.OrderRef)
                    .WithMany(p => p.PaymentPlan)
                    .HasForeignKey(d => d.OrderRefId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_paymentPlan_order");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
