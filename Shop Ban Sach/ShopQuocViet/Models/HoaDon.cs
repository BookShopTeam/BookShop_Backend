namespace ShopQuocViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            CTHoaDon = new HashSet<CTHoaDon>();
        }

        [StringLength(30)]
        public string MaND { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string HTTT { get; set; }

        [StringLength(30)]
        public string TenKH { get; set; }

        [StringLength(50)]
        public string TrangThaiVC { get; set; }

        public bool? ThanhToan { get; set; }

        [Key]
        public int MaHD { get; set; }

        [StringLength(100)]
        public string Ghichu { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngay { get; set; }

        public int? TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDon { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
