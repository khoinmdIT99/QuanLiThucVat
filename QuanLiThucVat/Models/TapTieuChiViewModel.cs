using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiThucVat.Models
{
    public class TapTieuChiViewModel
    {
        public int ID { get; set; }
        public Nullable<int> IDThucVat { get; set; }
        public string TenThucVat { get; set; }
        public Nullable<double> DoDayLa { get; set; }
        public Nullable<double> DoDayVo { get; set; }
        public Nullable<double> LuongNuocTrongLa { get; set; }
        public Nullable<double> LuongNuocTrongVo { get; set; }
        public Nullable<double> LuongTroThoTrongLa { get; set; }
        public Nullable<double> LuongTroThoTrongVo { get; set; }
        public Nullable<double> ThoiGianChayTrenLa { get; set; }
        public Nullable<double> ThoiGianChayTrenVo { get; set; }
    }
}