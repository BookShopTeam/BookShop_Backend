using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopQuocViet.Models;
namespace ShopQuocViet.Models
{
    public class ItemGioHang
    {
        public int MaSach { get; set; }
 
        public int SoLuong { get; set; }

        //public itemGioHang(int iMaSP)
        //{
        //    using (BookModel db = new BookModel())
        //    {
        //        this.Ma = iMaSP;
        //        Sach sp = db.Sach.Single(n => n.MaSach == iMaSP);
        //        this.TenSP = sp.TenSP;
        //        //khởi tạo thì sl = 1
        //        this.SoLuong = 1;
        //    }
        //}
        //public itemGioHang(int iMaSP, int sl)
        //{
        //    using (QuanLyBanHangEntities db = new QuanLyBanHangEntities())
        //    {
        //        this.MaSP = iMaSP;
        //        SanPham sp = db.SanPhams.Single(n => n.MaSP == iMaSP);
        //        this.TenSP = sp.TenSP;
        //        this.NguoiBan = sp.ThanhVien.TaiKhoan;
        //        this.DonGia = sp.DonGia.Value;
        //        this.HinhAnh = sp.HinhAnh;
        //        this.SoLuong = sl;
        //        this.ThanhTien = DonGia * SoLuong;

        //    }


        //}
    }
}