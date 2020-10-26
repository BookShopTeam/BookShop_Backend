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
            HoaDon = new HashSet<HoaDon>();
        }

        [Key]
        [Display(Name = "Tên đăng nhập")]
        //[RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$",ErrorMessage ="{0} không hợp lệ")]
        [Required(ErrorMessage = "Chưa điền {0}")]
        [StringLength(30,MinimumLength =6,ErrorMessage ="{0} phải ít nhất 6 kí tự")]
        public string TenDN { get; set; }

        [Display(Name = "Tên Người dùng")]
        [Required(ErrorMessage = "Chưa điền {0}")]
        [StringLength(40)]
        public string TenND { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Chưa điền {0}")]
        [StringLength(48,MinimumLength =8,ErrorMessage = "{0} phải ít nhất 8 kí tự")]
        public string MatKhau { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Chưa điền {0}")]
        [StringLength(15)]
        public string SDT { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Chưa điền {0}")]
        [StringLength(100)]
        public string DiaChi { get; set; }

        [Display(Name = "Email")]
       
        [Required(ErrorMessage = "Chưa điền {0}")]
        [StringLength(30)]
        public string Email { get; set; }

       
        [StringLength(20)]
        public string MaLoaiTK { get; set; }


        [Display(Name = "Ngày sinh")]
        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [NotMapped]
        [Display(Name = "xác nhận mật khẩu")]
        [Required(ErrorMessage = "Chưa điền {0}")]
        [StringLength(48)]
        [Compare("MatKhau",ErrorMessage ="Xác thực mật khẩu không khớp")]
        public string ReMatKhau { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDon { get; set; }

        public virtual LoaiTaiKhoan LoaiTaiKhoan { get; set; }
    }
}
