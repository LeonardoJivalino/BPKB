using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BPKB_BackEnd.Data
{
    public partial class BPKBContext : DbContext
    {
        public BPKBContext()
        {
        }

        public BPKBContext(DbContextOptions<BPKBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MsStorageLocation> MsStorageLocations { get; set; } = null!;
        public virtual DbSet<MsUser> MsUsers { get; set; } = null!;
        public virtual DbSet<TrBpkb> TrBpkbs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=BPKB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MsStorageLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__ms_stora__771831EAFCBE3705");

                entity.ToTable("ms_storage_location");

                entity.Property(e => e.LocationId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("location_id");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("location_name");
            });

            modelBuilder.Entity<MsUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__ms_user__B9BE370F5E1833D2");

                entity.ToTable("ms_user");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_name");
            });

            modelBuilder.Entity<TrBpkb>(entity =>
            {
                entity.HasKey(e => e.AgreementNumber)
                    .HasName("PK__tr_bpkb__21912C80FD26830C");

                entity.ToTable("tr_bpkb");

                entity.Property(e => e.AgreementNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("agreement_number");

                entity.Property(e => e.BpkbDate)
                    .HasColumnType("datetime")
                    .HasColumnName("bpkb_date");

                entity.Property(e => e.BpkbDateIn)
                    .HasColumnType("datetime")
                    .HasColumnName("bpkb_date_in");

                entity.Property(e => e.BpkbNo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("bpkb_no");

                entity.Property(e => e.BranchId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("branch_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.FakturDate)
                    .HasColumnType("datetime")
                    .HasColumnName("faktur_date");

                entity.Property(e => e.FakturNo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("faktur_no");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated_on");

                entity.Property(e => e.LocationId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("location_id");

                entity.Property(e => e.PoliceNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("police_no");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.TrBpkbs)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_tr_bpkb_location");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
