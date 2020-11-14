namespace ShopQuocViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Huyen")]
    public partial class Huyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Huyen()
        {
            Xa = new HashSet<Xa>();
        }

        [Key]
        [StringLength(10)]
        public string MaHuyen { get; set; }

        [Required]
        [StringLength(10)]
        public string MaTinh { get; set; }

        [Required]
        [StringLength(50)]
        public string TenHuyen { get; set; }

        public int? TienShip { get; set; }

        public virtual Tinh Tinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Xa> Xa { get; set; }
    }
}
