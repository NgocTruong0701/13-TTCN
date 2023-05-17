namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            PHIEUMUON_SACH = new HashSet<PHIEUMUON_SACH>();
            PHIEUTRA_SACH = new HashSet<PHIEUTRA_SACH>();
        }

        [Key]
        [Required(ErrorMessage = "Mã sách không được để trống")]
        [DisplayName("Mã sách")]
        [StringLength(10)]
        public string maSach { get; set; }

        [Required(ErrorMessage = "Tên sách không được để trống")]
        [DisplayName("Tên sách")]
        [StringLength(30)]
        public string tenSach { get; set; }

        [Required(ErrorMessage = "Năm xuất bản không được để trống")]
        [DisplayName("Năm xuất bản")]
        public DateTime namXB { get; set; }

        [DisplayName("Ảnh bìa")]
        [StringLength(50)]
        public string anhBia { get; set; }

        [Required(ErrorMessage = "Mô tả không được để trống")]
        [DisplayName("Mô tả")]
        [StringLength(150)]
        public string moTa { get; set; }

        [Required(ErrorMessage = "Giá tiền sách không được để trống")]
        [DisplayName("Giá tiền")]
        [Column(TypeName = "money")]
        public decimal giaSach { get; set; }

        [Required(ErrorMessage = "Số bản lưu không được để trống")]
        [DisplayName("Số bản lưu")]
        public int soBanLuu { get; set; }

        [Required(ErrorMessage = "Số trang không được để trống")]
        [DisplayName("Số trang")]
        public int soTrang { get; set; }

        [Required(ErrorMessage = "Tình trạng sách không được để trống")]
        [DisplayName("Tình trạng sách")]
        [StringLength(20)]
        public string tinhTrang { get; set; }

        [Required(ErrorMessage = "Ngôn ngữ của sách không được để trống")]
        [DisplayName("Ngôn ngữ")]
        [StringLength(20)]
        public string ngonNgu { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn tác giả")]
        [DisplayName("Tác giả")]
        [StringLength(10)]
        public string maTacGia { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn chủ đề")]
        [DisplayName("Chủ đề")]
        [StringLength(10)]
        public string maChuDe { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn nhà xuất bản")]
        [DisplayName("Nhà xuất bản")]
        [StringLength(10)]
        public string maNXB { get; set; }

        public virtual CHUDESACH CHUDESACH { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUMUON_SACH> PHIEUMUON_SACH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTRA_SACH> PHIEUTRA_SACH { get; set; }

        public virtual TACGIA TACGIA { get; set; }
    }
}
