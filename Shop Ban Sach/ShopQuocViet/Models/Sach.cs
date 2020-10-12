namespace ShopQuocViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            ANH = new HashSet<ANH>();
            BinhLuan = new HashSet<BinhLuan>();
            CTGioHang = new HashSet<CTGioHang>();
            DonHang = new HashSet<DonHang>();
        }

        [Key]
        [StringLength(10)]
        public string MaSach { get; set; }

        [StringLength(10)]
        public string MaCD { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSach { get; set; }

        [Required]
        [StringLength(50)]
        public string TacGia { get; set; }

        [StringLength(100)]
        public string NXB { get; set; }

        public int? GiaBia { get; set; }

        public int GiaBan { get; set; }

        public double? DanhGia { get; set; }

        [Column(TypeName = "text")]
        public string DuLieu { get; set; }

        [StringLength(30)]
        public string link { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANH> ANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTGioHang> CTGioHang { get; set; }

        public virtual ChuDe ChuDe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHang { get; set; }
    }
}
