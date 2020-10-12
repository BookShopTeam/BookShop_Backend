namespace ShopQuocViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ANH")]
    public partial class ANH
    {
        [Key]
        [StringLength(20)]
        public string MaAnh { get; set; }

        [Required]
        [StringLength(10)]
        public string MaSach { get; set; }

        [StringLength(50)]
        public string PathAnh { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
