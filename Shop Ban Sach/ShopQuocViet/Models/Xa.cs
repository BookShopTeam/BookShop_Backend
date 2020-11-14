namespace ShopQuocViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Xa")]
    public partial class Xa
    {
        [Key]
        [StringLength(10)]
        public string MaXa { get; set; }

        [Required]
        [StringLength(10)]
        public string MaHuyen { get; set; }

        [Required]
        [StringLength(50)]
        public string TenXa { get; set; }

        public virtual Huyen Huyen { get; set; }
    }
}
