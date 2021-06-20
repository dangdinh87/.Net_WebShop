namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [StringLength(50)]
        [Key]
        public string id { get; set; }

        [Required(ErrorMessage = "Nhập tên sản phẩm")]
        [StringLength(50)]
        public string TenSP { get; set; }

        [StringLength(500)]
       
        public string MoTa { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống")]
        public decimal? DonGia { get; set; }
        [DisplayName("Upload File")]
        [StringLength(500)]
        public string HinhAnh { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống")]
        [Range(1, 1000, ErrorMessage = "Số lượng phải lớn hơn 1")]
        public int? SoLuong { get; set; }

        [Required]
        [StringLength(50)]
        public string DanhMuc_Id { get; set; }

        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }
    }
}
