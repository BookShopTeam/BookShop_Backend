namespace ShopQuocViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TTSach")]
    public partial class TTSach
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaSach { get; set; }

        [StringLength(10)]
        public string MaCD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string TenCD { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string TenSach { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string TacGia { get; set; }

        [StringLength(100)]
        public string NXB { get; set; }

        public int? GiaBia { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        [Key]
        [Column(Order = 5)]
        [StringLength(20)]
        public string MaAnh { get; set; }

        [StringLength(50)]
        public string PathAnh { get; set; }
    }
}
