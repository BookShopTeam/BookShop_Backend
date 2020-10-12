namespace ShopQuocViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTGioHang")]
    public partial class CTGioHang
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaGH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaSach { get; set; }

        public int SoLuong { get; set; }

        public int TienCT { get; set; }

        public virtual GioHang GioHang { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
