using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLiThucVat.Models
{
    public class NguoiDungViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 kí tự")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 đến 50 kí tự")]
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public Nullable<bool> GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public Nullable<bool> LaQuanTriVienCapCao { get; set; }
        public Nullable<int> IDHInhAnh { get; set; }
        public string DuongDanHInhAnh { get; set; }
    }
}