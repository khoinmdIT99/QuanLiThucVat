using QuanLiThucVat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiThucVat.Repositories
{
    public class BangXepHangResponsitory
    {
        QuanLyThucVatEntities db = new QuanLyThucVatEntities();
        public BangXepHangResponsitory()
        {

        }
        public List<BangXepHangViewModel> getBangXepHang()
        {
            return (from tv in db.Tb_ThucVat
                    join gt in db.Tb_GiaTriKinhTe on tv.IDGiaTriKinhTe equals gt.ID
                    join ts in db.Tb_KhaNangTaiSinh on tv.IDKhaNangTaiSinh equals ts.ID
                    join st in db.Tb_KhaNangSinhTruong on tv.IDKhaNangSinhTruong equals st.ID

                    select new BangXepHangViewModel()
                    {
                        IDThucVat = tv.ID,
                        TenThucVat = tv.TenVietNam,
                        TenThucVatLaTin = tv.TenLaTinh,
                        DoDayLa = tv.DoDayLa,
                        DoDayVo = tv.DoDayVo,
                        LuongNuocTrongLa = tv.LuongNuocTrongLa,
                        LuongNuocTrongVo = tv.LuongNuocTrongVo,
                        LuongTroThoTrongLa = tv.LuongTroThoTrongLa,
                        LuongTroThoTrongVo = tv.LuongTroThoTrongVo,
                        ThoiGianChayTrenLa = tv.ThoiGianChayTrenLa,
                        ThoiGianChayTrenVo = tv.ThoiGianChayTrenVo,
                        KhaNangSinhTruong = st.DiemTuongUng,
                        KhaNangTaiSinh = ts.DiemTuongUng,
                        GiaTriKinhTe = gt.DiemTuongUng
                    }).OrderByDescending(x => x.IDThucVat).ToList();
        }
        public List<BangXepHangViewModel> ConvertBangXepHangThuHang(List<BangXepHangViewModel> list, string keyword)
        {
            //luong nuoctrong la
            list = list.OrderBy(x => x.LuongNuocTrongLa).ToList();

            int trung = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].LuongNuocTrongLa == list[i + 1].LuongNuocTrongLa)
                {
                    list[i].LuongNuocTrongLa = trung + 2;
                }
                else
                {
                    list[i].LuongNuocTrongLa = i + 2;
                    trung = i;
                }

            }
            list[list.Count - 1].LuongNuocTrongLa = list.Count + 1;
            //luong nuoc trong vo
            list = list.OrderBy(x => x.LuongNuocTrongVo).ToList();
            trung = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].LuongNuocTrongVo == list[i + 1].LuongNuocTrongVo)
                {
                    list[i].LuongNuocTrongVo = trung + 2;
                }
                else
                {
                    list[i].LuongNuocTrongVo = i + 2;
                    trung = i;
                }
            }
            list[list.Count - 1].LuongNuocTrongVo = list.Count + 1;
            //luong tro tho trong la
            list = list.OrderBy(x => x.LuongTroThoTrongLa).ToList();
            trung = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].LuongTroThoTrongLa == list[i + 1].LuongTroThoTrongLa)
                {
                    list[i].LuongTroThoTrongLa = trung + 2;
                }
                else
                {
                    list[i].LuongTroThoTrongLa = i + 2;
                    trung = i;
                }

            }
            list[list.Count - 1].LuongTroThoTrongLa = list.Count + 1;
            //luong tro tho trong vo
            list = list.OrderBy(x => x.LuongTroThoTrongVo).ToList();
            trung = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].LuongTroThoTrongVo == list[i + 1].LuongTroThoTrongVo)
                {
                    list[i].LuongTroThoTrongVo = trung + 2;
                }
                else
                {
                    list[i].LuongTroThoTrongVo = i + 2;
                    trung = i;
                }
            }
            list[list.Count - 1].LuongTroThoTrongVo = list.Count + 1;

            //thoi gian chay tren vo
            list = list.OrderBy(x => x.ThoiGianChayTrenLa).ToList();
            trung = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].ThoiGianChayTrenLa == list[i + 1].ThoiGianChayTrenLa)
                {
                    list[i].ThoiGianChayTrenLa = trung + 2;
                }
                else
                {
                    list[i].ThoiGianChayTrenLa = i + 2;
                    trung = i;
                }
            }
            list[list.Count - 1].ThoiGianChayTrenLa = list.Count + 1;
            //thoi gian chay tren vo
            list = list.OrderBy(x => x.ThoiGianChayTrenVo).ToList();
            trung = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].ThoiGianChayTrenVo == list[i + 1].ThoiGianChayTrenVo)
                {
                    list[i].ThoiGianChayTrenVo = trung + 2;
                }
                else
                {
                    list[i].ThoiGianChayTrenVo = i + 2;
                    trung = i;
                }
            }
            list[list.Count - 1].ThoiGianChayTrenVo = list.Count + 1;

            //Do day la
            list = list.OrderBy(x => x.DoDayLa).ToList();
            trung = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].DoDayLa == list[i + 1].DoDayLa)
                {
                    list[i].DoDayLa = trung + 2;
                }
                else
                {
                    list[i].DoDayLa = i + 2;
                    trung = i;
                }
            }
            list[list.Count - 1].DoDayLa = list.Count + 1;

            //do day vo
            list = list.OrderBy(x => x.DoDayVo).ToList();
            trung = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].DoDayVo == list[i + 1].DoDayVo)
                {
                    list[i].DoDayVo = trung + 2;
                }
                else
                {
                    list[i].DoDayVo = i + 2;
                    trung = i;
                }
            }
            list[list.Count - 1].DoDayVo = list.Count + 1;

            //kha nang sinh truong
            list = list.OrderBy(x => x.KhaNangSinhTruong).ToList();
            trung = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].KhaNangSinhTruong == list[i + 1].KhaNangSinhTruong)
                {
                    list[i].KhaNangSinhTruong = trung + 2;
                }
                else
                {
                    list[i].KhaNangSinhTruong = i + 2;
                    trung = i;
                }
            }
            list[list.Count - 1].KhaNangSinhTruong = list.Count + 1;
            list = list.OrderBy(x => x.KhaNangSinhTruong).ToList();
            trung = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].KhaNangSinhTruong == list[i + 1].KhaNangSinhTruong)
                {
                    list[i].KhaNangSinhTruong = trung + 2;
                }
                else
                {
                    list[i].KhaNangSinhTruong = i + 2;
                    trung = i;
                }
            }
            list[list.Count - 1].KhaNangSinhTruong = list.Count + 1;
            //kha nang tai sinh
            list = list.OrderBy(x => x.KhaNangTaiSinh).ToList();
            trung = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].KhaNangTaiSinh == list[i + 1].KhaNangTaiSinh)
                {
                    list[i].KhaNangTaiSinh = trung + 2;
                }
                else
                {
                    list[i].KhaNangTaiSinh = i + 2;
                    trung = i;
                }
            }
            list[list.Count - 1].KhaNangTaiSinh = list.Count + 1;

            //gia tri kinh te
            list = list.OrderBy(x => x.GiaTriKinhTe).ToList();
            trung = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].GiaTriKinhTe == list[i + 1].GiaTriKinhTe)
                {
                    list[i].GiaTriKinhTe = trung + 2;
                }
                else
                {
                    list[i].GiaTriKinhTe = i + 2;
                    trung = i;
                }
            }
            list[list.Count - 1].GiaTriKinhTe = list.Count + 1;

            //set tong diem
            foreach (var item in list)
            {
                item.TongDiem = Math.Round(0.5 / 4 * (item.LuongNuocTrongLa.Value + item.LuongNuocTrongVo.Value + item.DoDayLa.Value + item.DoDayVo.Value)
                    + 0.4 / 4 * (item.LuongTroThoTrongLa.Value + item.LuongTroThoTrongVo.Value + item.ThoiGianChayTrenLa.Value + item.ThoiGianChayTrenVo.Value)
                    + 0.1 / 3 * (item.KhaNangSinhTruong.Value + item.KhaNangSinhTruong.Value + item.GiaTriKinhTe.Value), 2);
            }
            //set vi thu xep hang
            list = list.OrderByDescending(x => x.TongDiem).ToList();
            trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].TongDiem == list[i - 1].TongDiem)
                {
                    list[i].XepHang1 = trung + 1;
                }
                else
                {
                    list[i].XepHang1 = i + 1;
                    trung = i;
                }
            }
            list[0].XepHang1 = 1;

            return list.Where(x => String.IsNullOrEmpty(keyword) || x.TenThucVat.Contains(keyword)).OrderBy(x => x.XepHang1).ToList();
        }
        public List<BangXepHangViewModel> ConvertBangXepHangCanhTac(List<BangXepHangViewModel> list, string keyword)
        {
            double maxLuongNuocTrongLa = list.Max(x => x.LuongNuocTrongLa.Value);
            double maxLuongNuocTrongVo = list.Max(x => x.LuongNuocTrongVo.Value);
            double maxLuongTroThoTrongLa = list.Max(x => x.LuongTroThoTrongLa.Value);
            double maxLuongTroThoTrongVo = list.Max(x => x.LuongTroThoTrongVo.Value);
            double maxThoiGianChayTrenLa = list.Max(x => x.ThoiGianChayTrenLa.Value);
            double maxThoiGianChayTrenVo = list.Max(x => x.ThoiGianChayTrenVo.Value);
            double maxDoDayLa = list.Max(x => x.DoDayLa.Value);
            double maxDoDayVo = list.Max(x => x.DoDayVo.Value);
            double maxKhaNangSinhTruong = list.Max(x => x.KhaNangSinhTruong.Value);
            double maxKhaNangTaiSinh = list.Max(x => x.KhaNangTaiSinh.Value);
            double maxGiaTriKinhTe = list.Max(x => x.GiaTriKinhTe.Value);

            foreach (var item in list)
            {
                item.LuongNuocTrongLa = Math.Round(maxLuongNuocTrongLa / item.LuongNuocTrongLa.Value, 2);
                item.LuongNuocTrongVo = Math.Round(maxLuongNuocTrongVo / item.LuongNuocTrongVo.Value, 2);
                item.LuongTroThoTrongLa = Math.Round(maxLuongTroThoTrongLa / item.LuongTroThoTrongLa.Value, 2);
                item.LuongTroThoTrongVo = Math.Round(maxLuongTroThoTrongVo / item.LuongTroThoTrongVo.Value, 2);
                item.ThoiGianChayTrenLa = Math.Round(maxThoiGianChayTrenLa / item.ThoiGianChayTrenLa.Value, 2);
                item.ThoiGianChayTrenVo = Math.Round(maxThoiGianChayTrenVo / item.ThoiGianChayTrenVo.Value, 2);
                item.DoDayLa = Math.Round(maxDoDayLa / item.DoDayLa.Value, 2);
                item.DoDayVo = Math.Round(maxDoDayVo / item.DoDayVo.Value, 2);
                item.KhaNangSinhTruong = Math.Round(maxKhaNangSinhTruong / item.KhaNangSinhTruong.Value, 2);
                item.KhaNangTaiSinh = Math.Round(maxKhaNangTaiSinh / item.KhaNangTaiSinh.Value, 2);
                item.GiaTriKinhTe = Math.Round(maxGiaTriKinhTe / item.GiaTriKinhTe.Value, 2);
            }

            //set tong diem
            foreach (var item in list)
            {
                item.TongDiem = Math.Round(0.5 / 4 * (item.LuongNuocTrongLa.Value + item.LuongNuocTrongVo.Value + item.DoDayLa.Value + item.DoDayVo.Value)
                    + 0.4 / 4 * (item.LuongTroThoTrongLa.Value + item.LuongTroThoTrongVo.Value + item.ThoiGianChayTrenLa.Value + item.ThoiGianChayTrenVo.Value)
                    + 0.1 / 3 * (item.KhaNangSinhTruong.Value + item.KhaNangSinhTruong.Value + item.GiaTriKinhTe.Value), 2);
            }
            //set vi thu xep hang
            list = list.OrderBy(x => x.TongDiem).ToList();
            int trung = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].TongDiem == list[i + 1].TongDiem)
                {
                    list[i].XepHang2 = trung + 1;
                }
                else
                {
                    list[i].XepHang2 = i + 1;
                    trung = i;
                }
            }
            list[list.Count - 1].XepHang2 = list.Count;



            return list.Where(x => String.IsNullOrEmpty(keyword) || x.TenThucVat.Contains(keyword)).OrderBy(x => x.XepHang2).ToList();
        }
        public List<BangXepHangViewModel> ConvertBangXepHangCanhTacCaiTien(List<BangXepHangViewModel> list, string keyword)
        {
            double maxLuongNuocTrongLa = list.Max(x => x.LuongNuocTrongLa.Value);
            double maxLuongNuocTrongVo = list.Max(x => x.LuongNuocTrongVo.Value);
            double maxLuongTroThoTrongLa = list.Max(x => x.LuongTroThoTrongLa.Value);
            double maxLuongTroThoTrongVo = list.Max(x => x.LuongTroThoTrongVo.Value);
            double maxThoiGianChayTrenLa = list.Max(x => x.ThoiGianChayTrenLa.Value);
            double maxThoiGianChayTrenVo = list.Max(x => x.ThoiGianChayTrenVo.Value);
            double maxDoDayLa = list.Max(x => x.DoDayLa.Value);
            double maxDoDayVo = list.Max(x => x.DoDayVo.Value);
            double maxKhaNangSinhTruong = list.Max(x => x.KhaNangSinhTruong.Value);
            double maxKhaNangTaiSinh = list.Max(x => x.KhaNangTaiSinh.Value);
            double maxGiaTriKinhTe = list.Max(x => x.GiaTriKinhTe.Value);

            foreach (var item in list)
            {
                item.LuongNuocTrongLa = Math.Round(item.LuongNuocTrongLa.Value / maxLuongNuocTrongLa, 2);
                item.LuongNuocTrongVo = Math.Round(item.LuongNuocTrongVo.Value / maxLuongNuocTrongVo, 2);
                item.LuongTroThoTrongLa = Math.Round(item.LuongTroThoTrongLa.Value / maxLuongTroThoTrongLa, 2);
                item.LuongTroThoTrongVo = Math.Round(item.LuongTroThoTrongVo.Value / maxLuongTroThoTrongVo, 2);
                item.ThoiGianChayTrenLa = Math.Round(item.ThoiGianChayTrenLa.Value / maxThoiGianChayTrenLa, 2);
                item.ThoiGianChayTrenVo = Math.Round(item.ThoiGianChayTrenVo.Value / maxThoiGianChayTrenVo, 2);
                item.DoDayLa = Math.Round(item.DoDayLa.Value / maxDoDayLa, 2);
                item.DoDayVo = Math.Round(item.DoDayVo.Value / maxDoDayVo, 2);
                item.KhaNangSinhTruong = Math.Round(item.KhaNangSinhTruong.Value / maxKhaNangSinhTruong, 2);
                item.KhaNangTaiSinh = Math.Round(item.KhaNangTaiSinh.Value / maxKhaNangTaiSinh, 2);
                item.GiaTriKinhTe = Math.Round(item.GiaTriKinhTe.Value / maxGiaTriKinhTe, 2);
            }

            //set tong diem
            foreach (var item in list)
            {
                item.TongDiem = Math.Round(0.5 / 4 * (item.LuongNuocTrongLa.Value + item.LuongNuocTrongVo.Value + item.DoDayLa.Value + item.DoDayVo.Value)
                    + 0.4 / 4 * (item.LuongTroThoTrongLa.Value + item.LuongTroThoTrongVo.Value + item.ThoiGianChayTrenLa.Value + item.ThoiGianChayTrenVo.Value)
                    + 0.1 / 3 * (item.KhaNangSinhTruong.Value + item.KhaNangSinhTruong.Value + item.GiaTriKinhTe.Value), 2);
            }
            //set vi thu xep hang
            list = list.OrderByDescending(x => x.TongDiem).ToList();
            int trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].TongDiem == list[i - 1].TongDiem)
                {
                    list[i].XepHang3 = trung + 1;
                }
                else
                {
                    list[i].XepHang3 = i + 1;
                    trung = i;
                }
            }
            list[0].XepHang3 = 1;

            return list.Where(x => String.IsNullOrEmpty(keyword) || x.TenThucVat.Contains(keyword)).OrderBy(x => x.XepHang3).ToList();
        }
        public List<BangXepHangViewModel> BangXepHangTongHop(List<BangXepHangViewModel> list, string keyword)
        {
            int j = 0;
            List<BangXepHangViewModel> list1 = ConvertBangXepHangThuHang(getBangXepHang(), null).OrderByDescending(x => x.IDThucVat).ToList();
            List<BangXepHangViewModel> list2 = ConvertBangXepHangCanhTac(getBangXepHang(), null).OrderByDescending(x => x.IDThucVat).ToList();
            List<BangXepHangViewModel> list3 = ConvertBangXepHangCanhTacCaiTien(getBangXepHang(), null).OrderByDescending(x => x.IDThucVat).ToList();

            foreach (var item in list)
            {
                int xepHang1 = list1[j].XepHang1.Value;
                int xepHang2 = list2[j].XepHang2.Value;
                int xepHang3 = list3[j].XepHang3.Value;
                item.TongDiem = Math.Round((double)(xepHang1 + xepHang2 + xepHang3) / 3, 2);
                j++;
            }
            list = list.OrderBy(x => x.TongDiem).ToList();
            int trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].TongDiem == list[i - 1].TongDiem)
                {
                    list[i].XepHangTong = trung + 1;
                }
                else
                {
                    list[i].XepHangTong = i + 1;
                    trung = i;
                }
            }
            list[0].XepHangTong = 1;
            return list.Where(x => String.IsNullOrEmpty(keyword) || x.TenThucVat.Contains(keyword)).OrderBy(x => x.XepHangTong).ToList();
        }

        public List<BangXepHangViewModel> ConvertBangXepHangThuHangfilter(List<BangXepHangViewModel> list, bool check1, bool check2, bool check3, bool check4, bool check5,
            bool check6, bool check7, bool check8, bool check9, bool check10, bool check11, string keyword)
        {
            //luong nuoctrong la
            list = list.OrderBy(x => x.LuongNuocTrongLa).ToList();
            int trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].LuongNuocTrongLa == list[i - 1].LuongNuocTrongLa)
                {
                    list[i].Tam = trung + 1;
                }
                else
                {
                    list[i].Tam = i + 1;
                    trung = i;
                }
            }

            list[0].Tam = 1;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].LuongNuocTrongLa = list[i].Tam;
            }

            //luong nuoc trong vo
            list = list.OrderBy(x => x.LuongNuocTrongVo).ToList();
            trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].LuongNuocTrongVo == list[i - 1].LuongNuocTrongVo)
                {
                    list[i].Tam = trung + 1;
                }
                else
                {
                    list[i].Tam = i + 1;
                    trung = i;
                }
            }

            list[0].Tam = 1;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].LuongNuocTrongVo = list[i].Tam;
            }
            //luong tro tho trong la
            list = list.OrderBy(x => x.LuongTroThoTrongLa).ToList();
            trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].LuongTroThoTrongLa == list[i - 1].LuongTroThoTrongLa)
                {
                    list[i].Tam = trung + 1;
                }
                else
                {
                    list[i].Tam = i + 1;
                    trung = i;
                }
            }

            list[0].Tam = 1;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].LuongTroThoTrongLa = list[i].Tam;
            }
            //luong tro tho trong vo
            list = list.OrderBy(x => x.LuongTroThoTrongVo).ToList();
            trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].LuongTroThoTrongVo == list[i - 1].LuongTroThoTrongVo)
                {
                    list[i].Tam = trung + 1;
                }
                else
                {
                    list[i].Tam = i + 1;
                    trung = i;
                }
            }

            list[0].Tam = 1;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].LuongTroThoTrongVo = list[i].Tam;
            }

            //thoi gian chay tren la
            list = list.OrderBy(x => x.ThoiGianChayTrenLa).ToList();
            trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].ThoiGianChayTrenLa == list[i - 1].ThoiGianChayTrenLa)
                {
                    list[i].Tam = trung + 1;
                }
                else
                {
                    list[i].Tam = i + 1;
                    trung = i;
                }
            }

            list[0].Tam = 1;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].ThoiGianChayTrenLa = list[i].Tam;
            }
            //thoi gian chay tren vo
            list = list.OrderBy(x => x.ThoiGianChayTrenVo).ToList();
            trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].ThoiGianChayTrenVo == list[i - 1].ThoiGianChayTrenVo)
                {
                    list[i].Tam = trung + 1;
                }
                else
                {
                    list[i].Tam = i + 1;
                    trung = i;
                }
            }

            list[0].Tam = 1;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].ThoiGianChayTrenVo = list[i].Tam;
            }

            //Do day la
            list = list.OrderBy(x => x.DoDayLa).ToList();
            trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].DoDayLa == list[i - 1].DoDayLa)
                {
                    list[i].Tam = trung + 1;
                }
                else
                {
                    list[i].Tam = i + 1;
                    trung = i;
                }
            }

            list[0].Tam = 1;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].DoDayLa = list[i].Tam;
            }
            //do day vo
            list = list.OrderBy(x => x.DoDayVo).ToList();
            trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].DoDayVo == list[i - 1].DoDayVo)
                {
                    list[i].Tam = trung + 1;
                }
                else
                {
                    list[i].Tam = i + 1;
                    trung = i;
                }
            }

            list[0].Tam = 1;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].DoDayVo = list[i].Tam;
            }

            //kha nang sinh truong
            list = list.OrderBy(x => x.KhaNangSinhTruong).ToList();
            trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].KhaNangSinhTruong == list[i - 1].KhaNangSinhTruong)
                {
                    list[i].Tam = trung + 1;
                }
                else
                {
                    list[i].Tam = i + 1;
                    trung = i;
                }
            }

            list[0].Tam = 1;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].KhaNangSinhTruong = list[i].Tam;
            }
            //kha nang tai sinh
            list = list.OrderBy(x => x.KhaNangTaiSinh).ToList();
            trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].KhaNangTaiSinh == list[i - 1].KhaNangTaiSinh)
                {
                    list[i].Tam = trung + 1;
                }
                else
                {
                    list[i].Tam = i + 1;
                    trung = i;
                }
            }

            list[0].Tam = 1;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].KhaNangTaiSinh = list[i].Tam;
            }

            //gia tri kinh te
            list = list.OrderBy(x => x.GiaTriKinhTe).ToList();
            trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].GiaTriKinhTe == list[i - 1].GiaTriKinhTe)
                {
                    list[i].Tam = trung + 1;
                }
                else
                {
                    list[i].Tam = i + 1;
                    trung = i;
                }
            }

            list[0].Tam = 1;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].GiaTriKinhTe = list[i].Tam;
            }

            //set tong diem
            foreach (var item in list)
            {
                var tc1 = (check1 == true) ? item.LuongNuocTrongLa.Value : 0;
                var tc2 = (check2 == true) ? item.LuongNuocTrongVo.Value : 0;
                var tc3 = (check3 == true) ? item.LuongTroThoTrongLa.Value : 0;
                var tc4 = (check4 == true) ? item.LuongTroThoTrongVo.Value : 0;
                var tc5 = (check5 == true) ? item.ThoiGianChayTrenLa.Value : 0;
                var tc6 = (check6 == true) ? item.ThoiGianChayTrenVo.Value : 0;
                var tc7 = (check7 == true) ? item.DoDayLa.Value : 0;
                var tc8 = (check8 == true) ? item.DoDayVo.Value : 0;
                var tc9 = (check9 == true) ? item.KhaNangTaiSinh.Value : 0;
                var tc10 = (check10 == true) ? item.KhaNangSinhTruong.Value : 0;
                var tc11 = (check11 == true) ? item.GiaTriKinhTe.Value : 0;
                item.TongDiem = Math.Round(0.5 / 4 * (tc1 + tc2 + tc7 + tc8) + 0.4 / 4 * (tc3 + tc4 + tc5 + tc6) + 0.1 / 3 * (tc9 + tc10 + tc11), 3);

            }
            //set vi thu xep hang
            list = list.OrderByDescending(x => x.TongDiem).ToList();
            trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].TongDiem == list[i - 1].TongDiem)
                {
                    list[i].XepHang1 = trung + 1;
                }
                else
                {
                    list[i].XepHang1 = i + 1;
                    trung = i;
                }
            }
            list[0].XepHang1 = 1;

            return list.Where(x => String.IsNullOrEmpty(keyword) || x.TenThucVat.Contains(keyword)).OrderBy(x => x.XepHang1).ToList();
        }
        public List<BangXepHangViewModel> ConvertBangXepHangCanhTacfilter(List<BangXepHangViewModel> list, bool check1, bool check2, bool check3, bool check4, bool check5,
            bool check6, bool check7, bool check8, bool check9, bool check10, bool check11, string keyword)
        {
            double maxLuongNuocTrongLa = list.Max(x => x.LuongNuocTrongLa.Value);
            double maxLuongNuocTrongVo = list.Max(x => x.LuongNuocTrongVo.Value);
            double maxLuongTroThoTrongLa = list.Max(x => x.LuongTroThoTrongLa.Value);
            double maxLuongTroThoTrongVo = list.Max(x => x.LuongTroThoTrongVo.Value);
            double maxThoiGianChayTrenLa = list.Max(x => x.ThoiGianChayTrenLa.Value);
            double maxThoiGianChayTrenVo = list.Max(x => x.ThoiGianChayTrenVo.Value);
            double maxDoDayLa = list.Max(x => x.DoDayLa.Value);
            double maxDoDayVo = list.Max(x => x.DoDayVo.Value);
            double maxKhaNangSinhTruong = list.Max(x => x.KhaNangSinhTruong.Value);
            double maxKhaNangTaiSinh = list.Max(x => x.KhaNangTaiSinh.Value);
            double maxGiaTriKinhTe = list.Max(x => x.GiaTriKinhTe.Value);

            foreach (var item in list)
            {
                item.LuongNuocTrongLa = Math.Round(maxLuongNuocTrongLa / item.LuongNuocTrongLa.Value, 2);
                item.LuongNuocTrongVo = Math.Round(maxLuongNuocTrongVo / item.LuongNuocTrongVo.Value, 2);
                item.LuongTroThoTrongLa = Math.Round(maxLuongTroThoTrongLa / item.LuongTroThoTrongLa.Value, 2);
                item.LuongTroThoTrongVo = Math.Round(maxLuongTroThoTrongVo / item.LuongTroThoTrongVo.Value, 2);
                item.ThoiGianChayTrenLa = Math.Round(maxThoiGianChayTrenLa / item.ThoiGianChayTrenLa.Value, 2);
                item.ThoiGianChayTrenVo = Math.Round(maxThoiGianChayTrenVo / item.ThoiGianChayTrenVo.Value, 2);
                item.DoDayLa = Math.Round(maxDoDayLa / item.DoDayLa.Value, 2);
                item.DoDayVo = Math.Round(maxDoDayVo / item.DoDayVo.Value, 2);
                item.KhaNangSinhTruong = Math.Round(maxKhaNangSinhTruong / item.KhaNangSinhTruong.Value, 2);
                item.KhaNangTaiSinh = Math.Round(maxKhaNangTaiSinh / item.KhaNangTaiSinh.Value, 2);
                item.GiaTriKinhTe = Math.Round(maxGiaTriKinhTe / item.GiaTriKinhTe.Value, 2);
            }

            //set tong diem
            foreach (var item in list)
            {
                var tc1 = (check1 == true) ? item.LuongNuocTrongLa.Value : 0;
                var tc2 = (check2 == true) ? item.LuongNuocTrongVo.Value : 0;
                var tc3 = (check3 == true) ? item.LuongTroThoTrongLa.Value : 0;
                var tc4 = (check4 == true) ? item.LuongTroThoTrongVo.Value : 0;
                var tc5 = (check5 == true) ? item.ThoiGianChayTrenLa.Value : 0;
                var tc6 = (check6 == true) ? item.ThoiGianChayTrenVo.Value : 0;
                var tc7 = (check7 == true) ? item.DoDayLa.Value : 0;
                var tc8 = (check8 == true) ? item.DoDayVo.Value : 0;
                var tc9 = (check9 == true) ? item.KhaNangTaiSinh.Value : 0;
                var tc10 = (check10 == true) ? item.KhaNangSinhTruong.Value : 0;
                var tc11 = (check11 == true) ? item.GiaTriKinhTe.Value : 0;
                item.TongDiem = Math.Round(0.5 / 4 * (tc1 + tc2 + tc7 + tc8) + 0.4 / 4 * (tc3 + tc4 + tc5 + tc6) + 0.1 / 3 * (tc9 + tc10 + tc11), 3);
            }
            //set vi thu xep hang
            list = list.OrderBy(x => x.TongDiem).ToList();
            int trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].TongDiem == list[i - 1].TongDiem)
                {
                    list[i].XepHang2 = trung + 1;
                }
                else
                {
                    list[i].XepHang2 = i + 1;
                    trung = i;
                }
            }
            list[0].XepHang2 = 1;



            return list.Where(x => String.IsNullOrEmpty(keyword) || x.TenThucVat.Contains(keyword)).OrderBy(x => x.XepHang2).ToList();
        }
        public List<BangXepHangViewModel> ConvertBangXepHangCanhTacCaiTienfilter(List<BangXepHangViewModel> list, bool check1, bool check2, bool check3, bool check4, bool check5,
            bool check6, bool check7, bool check8, bool check9, bool check10, bool check11, string keyword)
        {
            double maxLuongNuocTrongLa = list.Max(x => x.LuongNuocTrongLa.Value);
            double maxLuongNuocTrongVo = list.Max(x => x.LuongNuocTrongVo.Value);
            double maxLuongTroThoTrongLa = list.Max(x => x.LuongTroThoTrongLa.Value);
            double maxLuongTroThoTrongVo = list.Max(x => x.LuongTroThoTrongVo.Value);
            double maxThoiGianChayTrenLa = list.Max(x => x.ThoiGianChayTrenLa.Value);
            double maxThoiGianChayTrenVo = list.Max(x => x.ThoiGianChayTrenVo.Value);
            double maxDoDayLa = list.Max(x => x.DoDayLa.Value);
            double maxDoDayVo = list.Max(x => x.DoDayVo.Value);
            double maxKhaNangSinhTruong = list.Max(x => x.KhaNangSinhTruong.Value);
            double maxKhaNangTaiSinh = list.Max(x => x.KhaNangTaiSinh.Value);
            double maxGiaTriKinhTe = list.Max(x => x.GiaTriKinhTe.Value);

            foreach (var item in list)
            {
                item.LuongNuocTrongLa = Math.Round(item.LuongNuocTrongLa.Value / maxLuongNuocTrongLa, 2);
                item.LuongNuocTrongVo = Math.Round(item.LuongNuocTrongVo.Value / maxLuongNuocTrongVo, 2);
                item.LuongTroThoTrongLa = Math.Round(item.LuongTroThoTrongLa.Value / maxLuongTroThoTrongLa, 2);
                item.LuongTroThoTrongVo = Math.Round(item.LuongTroThoTrongVo.Value / maxLuongTroThoTrongVo, 2);
                item.ThoiGianChayTrenLa = Math.Round(item.ThoiGianChayTrenLa.Value / maxThoiGianChayTrenLa, 2);
                item.ThoiGianChayTrenVo = Math.Round(item.ThoiGianChayTrenVo.Value / maxThoiGianChayTrenVo, 2);
                item.DoDayLa = Math.Round(item.DoDayLa.Value / maxDoDayLa, 2);
                item.DoDayVo = Math.Round(item.DoDayVo.Value / maxDoDayVo, 2);
                item.KhaNangSinhTruong = Math.Round(item.KhaNangSinhTruong.Value / maxKhaNangSinhTruong, 2);
                item.KhaNangTaiSinh = Math.Round(item.KhaNangTaiSinh.Value / maxKhaNangTaiSinh, 2);
                item.GiaTriKinhTe = Math.Round(item.GiaTriKinhTe.Value / maxGiaTriKinhTe, 2);
            }

            //set tong diem
            foreach (var item in list)
            {
                var tc1 = (check1 == true) ? item.LuongNuocTrongLa.Value : 0;
                var tc2 = (check2 == true) ? item.LuongNuocTrongVo.Value : 0;
                var tc3 = (check3 == true) ? item.LuongTroThoTrongLa.Value : 0;
                var tc4 = (check4 == true) ? item.LuongTroThoTrongVo.Value : 0;
                var tc5 = (check5 == true) ? item.ThoiGianChayTrenLa.Value : 0;
                var tc6 = (check6 == true) ? item.ThoiGianChayTrenVo.Value : 0;
                var tc7 = (check7 == true) ? item.DoDayLa.Value : 0;
                var tc8 = (check8 == true) ? item.DoDayVo.Value : 0;
                var tc9 = (check9 == true) ? item.KhaNangTaiSinh.Value : 0;
                var tc10 = (check10 == true) ? item.KhaNangSinhTruong.Value : 0;
                var tc11 = (check11 == true) ? item.GiaTriKinhTe.Value : 0;
                item.TongDiem = Math.Round(0.5 / 4 * (tc1 + tc2 + tc7 + tc8) + 0.4 / 4 * (tc3 + tc4 + tc5 + tc6) + 0.1 / 3 * (tc9 + tc10 + tc11), 3);
            }
            //set vi thu xep hang
            list = list.OrderByDescending(x => x.TongDiem).ToList();
            int trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].TongDiem == list[i - 1].TongDiem)
                {
                    list[i].XepHang3 = trung + 1;
                }
                else
                {
                    list[i].XepHang3 = i + 1;
                    trung = i;
                }
            }
            list[0].XepHang3 = 1;

            return list.Where(x => String.IsNullOrEmpty(keyword) || x.TenThucVat.Contains(keyword)).OrderBy(x => x.XepHang3).ToList();
        }
        public List<BangXepHangViewModel> BangXepHangTongHopfilter(List<BangXepHangViewModel> list, bool check1, bool check2, bool check3, bool check4, bool check5,
            bool check6, bool check7, bool check8, bool check9, bool check10, bool check11, string keyword)
        {
            int j = 0;
            List<BangXepHangViewModel> list1 = ConvertBangXepHangThuHangfilter(getBangXepHang(), check1, check2, check3, check4, check5,
                check6, check7, check8, check9, check10, check11, null).OrderByDescending(x => x.IDThucVat).ToList();
            List<BangXepHangViewModel> list2 = ConvertBangXepHangCanhTacfilter(getBangXepHang(), check1, check2, check3, check4, check5,
                check6, check7, check8, check9, check10, check11, null).OrderByDescending(x => x.IDThucVat).ToList();
            List<BangXepHangViewModel> list3 = ConvertBangXepHangCanhTacCaiTienfilter(getBangXepHang(), check1, check2, check3, check4, check5,
                check6, check7, check8, check9, check10, check11, null).OrderByDescending(x => x.IDThucVat).ToList();

            foreach (var item in list)
            {
                int xepHang1 = list1[j].XepHang1.Value;
                int xepHang2 = list2[j].XepHang2.Value;
                int xepHang3 = list3[j].XepHang3.Value;
                item.TongDiem = Math.Round((double)(xepHang1 + xepHang2 + xepHang3) / 3, 2);
                j++;
            }
            list = list.OrderBy(x => x.TongDiem).ToList();
            int trung = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].TongDiem == list[i - 1].TongDiem)
                {
                    list[i].XepHangTong = trung + 1;
                }
                else
                {
                    list[i].XepHangTong = i + 1;
                    trung = i;
                }
            }
            list[0].XepHangTong = 1;
            return list.Where(x => String.IsNullOrEmpty(keyword) || x.TenThucVat.Contains(keyword)).OrderBy(x => x.XepHangTong).ToList();
        }

    }
}