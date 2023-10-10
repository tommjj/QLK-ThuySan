using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QL_ThuySan.models
{
    public partial class Models : DbContext
    {
        public Models()
            : base("name=Models")
        {
        }

        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Kho> Khoes { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<PhieuXuat> PhieuXuats { get; set; }
        public virtual DbSet<ThuySan> ThuySans { get; set; }
        public virtual DbSet<TonKho> TonKhoes { get; set; }
        public virtual DbSet<TTPhieuNhap> TTPhieuNhaps { get; set; }
        public virtual DbSet<TTPhieuXuat> TTPhieuXuats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .Property(e => e.username)
                .IsFixedLength();

            modelBuilder.Entity<account>()
                .Property(e => e.password)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.sdt)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.PhieuXuats)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kho>()
                .HasMany(e => e.PhieuNhaps)
                .WithRequired(e => e.Kho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kho>()
                .HasMany(e => e.PhieuXuats)
                .WithRequired(e => e.Kho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kho>()
                .HasMany(e => e.TonKhoes)
                .WithRequired(e => e.Kho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.sdt)
                .IsFixedLength();

            modelBuilder.Entity<NhaCungCap>()
                .HasMany(e => e.PhieuNhaps)
                .WithRequired(e => e.NhaCungCap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuNhap>()
                .HasMany(e => e.TTPhieuNhaps)
                .WithRequired(e => e.PhieuNhap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuXuat>()
                .HasMany(e => e.TTPhieuXuats)
                .WithRequired(e => e.PhieuXuat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThuySan>()
                .Property(e => e.ten)
                .IsUnicode(false);

            modelBuilder.Entity<ThuySan>()
                .Property(e => e.gia_ban)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ThuySan>()
                .HasMany(e => e.TonKhoes)
                .WithRequired(e => e.ThuySan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThuySan>()
                .HasMany(e => e.TTPhieuNhaps)
                .WithRequired(e => e.ThuySan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThuySan>()
                .HasMany(e => e.TTPhieuXuats)
                .WithRequired(e => e.ThuySan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TTPhieuNhap>()
                .Property(e => e.gia_nhap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TTPhieuXuat>()
                .Property(e => e.gia_xuat)
                .HasPrecision(19, 4);
        }
    }
}
