using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiThucVat.Models
{
    public class BangXepHangViewModel
    {
        public Nullable<int> IDThucVat { get; set; }
        public string TenThucVat { get; set; }
        public string TenThucVatLaTin { get; set; }
        public Nullable<double> DoDayLa { get; set; }
        public Nullable<double> DoDayVo { get; set; }
        public Nullable<double> LuongNuocTrongLa { get; set; }
        public Nullable<double> LuongNuocTrongVo { get; set; }
        public Nullable<double> LuongTroThoTrongLa { get; set; }
        public Nullable<double> LuongTroThoTrongVo { get; set; }
        public Nullable<double> ThoiGianChayTrenLa { get; set; }
        public Nullable<double> ThoiGianChayTrenVo { get; set; }
        public Nullable<double> KhaNangSinhTruong { get; set; }
        public Nullable<double> KhaNangTaiSinh { get; set; }
        public Nullable<double> GiaTriKinhTe { get; set; }
        public Nullable<double> TongDiem { get; set; }
        public Nullable<int> XepHang1 { get; set; }
        public Nullable<int> XepHang2 { get; set; }
        public Nullable<int> XepHang3 { get; set; }
        public Nullable<int> XepHangTong { get; set; }
        public Nullable<double> Tam { get; set; }

    }
}