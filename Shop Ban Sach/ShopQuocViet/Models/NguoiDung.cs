namespace ShopQuocViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            BinhLuan = new HashSet<BinhLuan>();
            GioHang = new HashSet<GioHang>();
        }

        [Key]
        [StringLength(10)]
        public string TenDN { get; set; }

        [Required]
        [StringLength(100)]
        public string TenND { get; set; }

        [Required]
        [StringLength(20)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(15)]
        public string SDT { get; set; }

        [Required]
        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string MaLoaiTK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHang { get; set; }

        public virtual LoaiTaiKhoan LoaiTaiKhoan { get; set; }
    }
}
