using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopQuocViet.Models
{
    public class Cart
    {
        BookModel db = new BookModel();
        public string iMaSach { get; set; }
        public string sTenSach { get; set; }
        public string slink { get; set; }
        public int iDonGia { get; set; }
        public int iSoLuong { get; set; }
        public int ThanhTien {
            get { return iSoLuong * iDonGia; } }
        
        public Cart(string MaSach)
        {
            iMaSach = MaSach;
            TTSach sach = db.TTSach.Single(n => n.MaSach == iMaSach);
            sTenSach = sach.TenSach;
            //slink = db.ANHs.Single(n => n.PathAnh == slink);
            iDonGia = sach.GiaBan;
            iSoLuong = 1;
        }
         

    }
}