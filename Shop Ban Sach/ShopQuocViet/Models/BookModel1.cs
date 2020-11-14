namespace ShopQuocViet.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookModel1 : DbContext
    {
        public BookModel1()
            : base("name=BookModel1")
        {
        }

        public virtual DbSet<ANH> ANH { get; set; }
        public virtual DbSet<CTHoaDon> CTHoaDon { get; set; }
        public virtual DbSet<ChuDe> ChuDe { get; set; }
        public virtual DbSet<DanhGia> DanhGia { get; set; }
        public virtual DbSet<DanhMuc> DanhMuc { get; set; }
        public virtual DbSet<GioHang> GioHang { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<Huyen> Huyen { get; set; }
        public virtual DbSet<LoaiTaiKhoan> LoaiTaiKhoan { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<NhomDiaChi> NhomDiaChi { get; set; }
        public virtual DbSet<Quyen> Quyen { get; set; }
        public virtual DbSet<Sach> Sach { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tinh> Tinh { get; set; }
        public virtual DbSet<Xa> Xa { get; set; }
        public virtual DbSet<ChiTietDH> ChiTietDH { get; set; }
        public virtual DbSet<TTSach> TTSach { get; set; }
        public virtual DbSet<ViewChiTietHD> ViewChiTietHD { get; set; }
        public virtual DbSet<ViewTenDM> ViewTenDM { get; set; }

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

            modelBuilder.Entity<CTHoaDon>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<ChuDe>()
                .Property(e => e.MaCD)
                .IsUnicode(false);

            modelBuilder.Entity<ChuDe>()
                .Property(e => e.MaDM)
                .IsUnicode(false);

            modelBuilder.Entity<DanhGia>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<DanhGia>()
                .Property(e => e.MaND)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMuc>()
                .Property(e => e.MaDM)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.ChuDe)
                .WithRequired(e => e.DanhMuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GioHang>()
                .Property(e => e.MaND)
                .IsUnicode(false);

            modelBuilder.Entity<GioHang>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaND)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.CTHoaDon)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Huyen>()
                .Property(e => e.MaHuyen)
                .IsUnicode(false);

            modelBuilder.Entity<Huyen>()
                .Property(e => e.MaTinh)
                .IsUnicode(false);

            modelBuilder.Entity<Huyen>()
                .HasMany(e => e.Xa)
                .WithRequired(e => e.Huyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiTaiKhoan>()
                .Property(e => e.IDLoaiTK)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiTaiKhoan>()
                .HasMany(e => e.NguoiDung)
                .WithRequired(e => e.LoaiTaiKhoan)
                .HasForeignKey(e => e.MaLoaiTK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiTaiKhoan>()
                .HasMany(e => e.Quyen)
                .WithMany(e => e.LoaiTaiKhoan)
                .Map(m => m.ToTable("DanhSachQuyen").MapLeftKey("IDLoaiTK").MapRightKey("MaQuyen"));

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
                .HasMany(e => e.DanhGia)
                .WithRequired(e => e.NguoiDung)
                .HasForeignKey(e => e.MaND)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.GioHang)
                .WithRequired(e => e.NguoiDung)
                .HasForeignKey(e => e.MaND)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.HoaDon)
                .WithOptional(e => e.NguoiDung)
                .HasForeignKey(e => e.MaND);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.NhomDiaChi)
                .WithRequired(e => e.NguoiDung)
                .HasForeignKey(e => e.MaKH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhomDiaChi>()
                .Property(e => e.MaDC)
                .IsUnicode(false);

            modelBuilder.Entity<NhomDiaChi>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<Quyen>()
                .Property(e => e.TenQuyen)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaCD)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.KhoiLuong)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.KichThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.CTHoaDon)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.DanhGia1)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.GioHang)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tinh>()
                .Property(e => e.MaTinh)
                .IsUnicode(false);

            modelBuilder.Entity<Tinh>()
                .HasMany(e => e.Huyen)
                .WithRequired(e => e.Tinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Xa>()
                .Property(e => e.MaXa)
                .IsUnicode(false);

            modelBuilder.Entity<Xa>()
                .Property(e => e.MaHuyen)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDH>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDH>()
                .Property(e => e.MaND)
                .IsUnicode(false);

            modelBuilder.Entity<TTSach>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<TTSach>()
                .Property(e => e.MaCD)
                .IsUnicode(false);

            modelBuilder.Entity<TTSach>()
                .Property(e => e.KhoiLuong)
                .IsUnicode(false);

            modelBuilder.Entity<TTSach>()
                .Property(e => e.KichThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<TTSach>()
                .Property(e => e.MaAnh)
                .IsUnicode(false);

            modelBuilder.Entity<TTSach>()
                .Property(e => e.PathAnh)
                .IsUnicode(false);

            modelBuilder.Entity<ViewChiTietHD>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<ViewTenDM>()
                .Property(e => e.MaCD)
                .IsUnicode(false);
        }
    }
}
