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
            CTHoaDon = new HashSet<CTHoaDon>();
            GioHang = new HashSet<GioHang>();
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

        [StringLength(30)]
        public string LinkRe { get; set; }

        [StringLength(50)]
        public string KhoiLuong { get; set; }

        [StringLength(20)]
        public string DinhDang { get; set; }

        [StringLength(50)]
        public string KichThuoc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayPhatHanh { get; set; }

        public int? SoTrang { get; set; }

        public int? GiamGia { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANH> ANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDon { get; set; }

        public virtual ChuDe ChuDe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHang { get; set; }
    }
}
