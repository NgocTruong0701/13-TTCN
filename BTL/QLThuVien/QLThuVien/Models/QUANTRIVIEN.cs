namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUANTRIVIEN")]
    public partial class QUANTRIVIEN
    {
        [Key]
        [Required(ErrorMessage = "Mã quản trị viên không được để trống")]
        [DisplayName("Mã quản trị viên")]
        [StringLength(10)]
        public string maQTV { get; set; }

        [Required(ErrorMessage = "Tên quản trị viên không được để trống")]
        [DisplayName("Tên quản trị viên")]
        [StringLength(30)]
        public string tenQTV { get; set; }

        [Required(ErrorMessage = "Tài khoản không được để trống")]
        [DisplayName("Tài khoản")]
        [StringLength(20)]
        public string taiKhoan { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DisplayName("Mật khẩu")]
        [StringLength(20)]
        public string matKhau { get; set; }
    }
}
