namespace ShopQuocViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomDiaChi")]
    public partial class NhomDiaChi
    {
        [Key]
        [StringLength(10)]
        public string MaDC { get; set; }

        [StringLength(10)]
        public string MaKH { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }
    }
}
