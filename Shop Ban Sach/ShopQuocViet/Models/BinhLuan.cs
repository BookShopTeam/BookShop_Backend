namespace ShopQuocViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaND { get; set; }

        [Column("BinhLuan", TypeName = "text")]
        public string BinhLuan1 { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
