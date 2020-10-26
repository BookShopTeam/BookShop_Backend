namespace ShopQuocViet.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookShopModel : DbContext
    {
        public BookShopModel()
            : base("name=BookShopModel")
        {
        }

        public virtual DbSet<ANH> ANH { get; set; }
        public virtual DbSet<BinhLuan> BinhLuan { get; set; }
        public virtual DbSet<CTGioHang> CTGioHang { get; set; }
        public virtual DbSet<ChuDe> ChuDe { get; set; }
        public virtual DbSet<DanhMuc> DanhMuc { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<GioHang> GioHang { get; set; }
        public virtual DbSet<LoaiTaiKhoan> LoaiTaiKhoan { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<Sach> Sach { get; set; }
        public object TTSach { get; internal set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ANH>()
                .Property(e => e.MaAnh)
                .IsUnicode(false);

            modelBuilder.Entity<ANH>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<ANH>()
                .Property(e => e.PathAnh)
                .IsUnicode(false);

            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.MaND)
                .IsUnicode(false);

            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.BinhLuan1)
                .IsUnicode(false);

            modelBuilder.Entity<CTGioHang>()
                .Property(e => e.MaGH)
                .IsUnicode(false);

            modelBuilder.Entity<CTGioHang>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<ChuDe>()
                .Property(e => e.MaCD)
                .IsUnicode(false);

            modelBuilder.Entity<ChuDe>()
                .Property(e => e.MaDM)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMuc>()
                .Property(e => e.MaDM)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.ChuDe)
                .WithRequired(e => e.DanhMuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.MaDH)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.MaGH)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<GioHang>()
                .Property(e => e.MaGH)
                .IsUnicode(false);

            modelBuilder.Entity<GioHang>()
                .Property(e => e.MaND)
                .IsUnicode(false);

            modelBuilder.Entity<GioHang>()
                .HasMany(e => e.CTGioHang)
                .WithRequired(e => e.GioHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GioHang>()
                .HasMany(e => e.DonHang)
                .WithRequired(e => e.GioHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiTaiKhoan>()
                .Property(e => e.IDLoaiTK)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiTaiKhoan>()
                .HasMany(e => e.NguoiDung)
                .WithRequired(e => e.LoaiTaiKhoan)
                .HasForeignKey(e => e.MaLoaiTK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MaLoaiTK)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.BinhLuan)
                .WithRequired(e => e.NguoiDung)
                .HasForeignKey(e => e.MaND)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.GioHang)
                .WithRequired(e => e.NguoiDung)
                .HasForeignKey(e => e.MaND)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaCD)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MoTa)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.LinkRe)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.ANH)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.BinhLuan)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.CTGioHang)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.DonHang)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);
        }
    }
}
