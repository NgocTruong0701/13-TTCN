namespace PhieuBai_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("account")]
    public partial class account
    {
        public int id { get; set; }

        [Required(ErrorMessage = "User name khong duoc de trong")]
        [DisplayName("Ten nguoi dung")]
        [StringLength(50)]
        public string username { get; set; }

        [Required(ErrorMessage = "Ho ten khong duoc de trong")]
        [DisplayName("Ho ten")]
        [StringLength(30)]
        public string fullname { get; set; }

        [Required(ErrorMessage = "So dien thoai khong duoc de trong")]
        [DisplayName("So dien thoai")]
        [StringLength(20)]
        public string phone { get; set; }

        [Required(ErrorMessage = "Mat khau khong duoc de trong")]
        [DisplayName("Mat khau")]
        [StringLength(30)]
        public string password { get; set; }

        [Required(ErrorMessage = "Email khong duoc de trong")]
        [DisplayName("Email")]
        [StringLength(50)]
        public string email { get; set; }
    }
}
