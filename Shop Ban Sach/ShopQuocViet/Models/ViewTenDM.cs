namespace ShopQuocViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewTenDM")]
    public partial class ViewTenDM
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaCD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string TenDM { get; set; }
    }
}
