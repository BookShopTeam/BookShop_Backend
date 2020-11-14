using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopQuocViet.Models
{
    public class ChiTietDHSession
    {
        BookModel1 db = new BookModel1();
        public string maSach { get; set; }
        public string tenSach { get; set; }
        public int soLuong { get; set; }
        public int giaBan { get; set; }
      
    }
}