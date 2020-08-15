using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiThucVat.Models
{
    public class ThucVatViewModel
    {
        public int ID { get; set; }
        public string TenVietNam { get; set; }
        public string TenLaTinh { get; set; }
        public string MoTa { get; set; }
        public Nullable<double> DoDayLa { get; set; }
        public Nullable<double> DoDayVo { get; set; }
        public Nullable<double> LuongNuocTrongLa { get; set; }
        public Nullable<double> LuongNuocTrongVo { get; set; }
        public Nullable<double> LuongTroThoTrongLa { get; set; }
        public Nullable<double> LuongTroThoTrongVo { get; set; }
        public Nullable<double> ThoiGianChayTrenLa { get; set; }
        public Nullable<double> ThoiGianChayTrenVo { get; set; }
        public Nullable<int> IDKhaNangSinhTruong { get; set; }
        public string KhaNangSinhTruong { get; set; }
        public Nullable<int> IDKhaNangTaiSinh { get; set; }
        public string KhaNangTaiSinh { get; set; }
        public Nullable<int> IDGiaTriKinhTe { get; set; }
        public string GiaTriKinhTe { get; set; }
        public Nullable<int> IDHInhAnh { get; set; }
        public string DuongDanHInhAnh { get; set; }
        public Nullable<int> IDHo { get; set; }
        public string TenHo { get; set; }
        public Nullable<int> IDBo { get; set; }
        public string TenBo { get; set; }
    }
}