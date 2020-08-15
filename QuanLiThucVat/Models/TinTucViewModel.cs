using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiThucVat.Models
{
    public class TinTucViewModel
    {
        public int ID { get; set; }
        public string TieuDe { get; set; }
        public string DanNhap { get; set; }
        public string NoiDung { get; set; }
        public Nullable<int> IDHInhAnh { get; set; }
        public string DuongDanHinhAnh { get; set; }
    }
}