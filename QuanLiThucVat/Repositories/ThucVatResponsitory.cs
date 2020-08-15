using QuanLiThucVat.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace QuanLiThucVat.Repositories
{
    public class ThucVatResponsitory
    {
        QuanLyThucVatEntities db = new QuanLyThucVatEntities();
        public ThucVatResponsitory()
        {

        }

        public List<ThucVatViewModel> getAllListThucVat(string keyword)
        {
            return (from tv in db.Tb_ThucVat
                    join ha in db.Tb_HinhAnh on tv.IDHInhAnh equals ha.ID
                    join gt in db.Tb_GiaTriKinhTe on tv.IDGiaTriKinhTe equals gt.ID
                    join ts in db.Tb_KhaNangTaiSinh on tv.IDKhaNangTaiSinh equals ts.ID
                    join st in db.Tb_KhaNangSinhTruong on tv.IDKhaNangSinhTruong equals st.ID
                    join h in db.Tb_Ho on tv.IDHo equals h.ID
                    select new ThucVatViewModel()
                    {
                        ID = tv.ID,
                        TenLaTinh = tv.TenLaTinh,
                        TenVietNam = tv.TenVietNam,
                        MoTa = tv.MoTa,
                        DoDayLa = tv.DoDayLa,
                        DoDayVo = tv.DoDayVo,
                        LuongNuocTrongLa = tv.LuongNuocTrongLa,
                        LuongNuocTrongVo = tv.LuongNuocTrongVo,
                        LuongTroThoTrongLa = tv.LuongTroThoTrongLa,
                        LuongTroThoTrongVo = tv.LuongTroThoTrongVo,
                        ThoiGianChayTrenLa = tv.ThoiGianChayTrenLa,
                        ThoiGianChayTrenVo = tv.ThoiGianChayTrenVo,
                        IDGiaTriKinhTe = gt.ID,
                        GiaTriKinhTe = gt.MoTa,
                        IDKhaNangTaiSinh = ts.ID,
                        KhaNangTaiSinh = ts.MoTa,
                        IDKhaNangSinhTruong = st.ID,
                        KhaNangSinhTruong = st.MoTa,
                        IDHInhAnh = ha.ID,
                        DuongDanHInhAnh = ha.DuongDan,
                        IDHo = h.ID,
                        TenHo = h.TenHo

                    }).Where(x => string.IsNullOrEmpty(keyword) || x.TenVietNam.Contains(keyword)).OrderByDescending(x => x.ID).ToList();
        }
        public List<ThucVatViewModel> getAllListThucVat(string tenVietNam, string tenLaTinh, string IDBo, string IDHo)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select tv.ID,tv.TenVietNam,tv.TenLaTinh,tv.MoTa,tv.DoDayLa,tv.DoDayVo,");
            sql.Append(" tv.LuongNuocTrongLa,tv.LuongNuocTrongVo,tv.LuongTroThoTrongLa,tv.LuongTroThoTrongVo,");
            sql.Append(" tv.ThoiGianChayTrenLa,tv.ThoiGianChayTrenVo,tv.IDGiaTriKinhTe,");
            sql.Append(" gt.MoTa as GiaTriKinhTe,tv.IDKhaNangTaiSinh,ts.MoTa as KhaNangTaiSinh,tv.IDKhaNangSinhTruong,");
            sql.Append(" st.MoTa as KhaNangSinhTruong,tv.IDHInhAnh,ha.DuongDan as DuongDanHInhAnh,tv.IDHo,h.TenHo,h.IDBo,b.TenBo from Tb_ThucVat as tv");
            sql.Append(" inner join Tb_HinhAnh as ha on tv.IDHInhAnh=ha.ID inner join Tb_GiaTriKinhTe as gt on tv.IDGiaTriKinhTe=gt.ID");
            sql.Append(" inner join Tb_KhaNangTaiSinh as ts on tv.IDKhaNangTaiSinh=ts.ID inner join Tb_KhaNangSinhTruong as st on tv.IDKhaNangSinhTruong=st.ID");
            sql.Append(" inner join Tb_Ho as h on tv.IDHo=h.ID inner join Tb_Bo as b on h.IDBo=b.ID ");

            if (!string.IsNullOrWhiteSpace(tenVietNam))
            {
                sql.Append("and tv.TenVietNam COLLATE Latin1_General_CI_AI LIKE N'%'+@ten_viet_nam+'%' ");
            }
            if (!string.IsNullOrWhiteSpace(tenLaTinh))
            {
                sql.Append("and tv.TenLaTinh COLLATE Latin1_General_CI_AI LIKE N'%'+@ten_la_tinh+'%' ");
            }
            if (!string.IsNullOrEmpty(IDHo))
            {
                if (Int32.Parse(IDHo) != 0)
                {
                    sql.Append("and tv.IDHo = @ho ");
                }

            }
            if (!string.IsNullOrEmpty(IDBo))
            {
                if (Int32.Parse(IDBo) != 0)
                {
                    sql.Append("and h.IDBo = @bo ");
                }

            }
          
            List<ThucVatViewModel> listUser = db.Database.SqlQuery<ThucVatViewModel>(sql.ToString(),
             new SqlParameter("ten_viet_nam", tenVietNam),
             new SqlParameter("ten_la_tinh", tenLaTinh),
             new SqlParameter("ho", IDHo),
             new SqlParameter("bo", IDBo)).OrderBy(x=>x.TenVietNam).ToList();
            return listUser;
        }
        public int AddThucVat(ThucVatViewModel model)
        {
            try
            {
                Tb_HinhAnh tb_HinhAnh = new Tb_HinhAnh();
                tb_HinhAnh.DuongDan = model.DuongDanHInhAnh;
                db.Tb_HinhAnh.Add(tb_HinhAnh);
                db.SaveChanges();
                db.Tb_ThucVat.Add(new Tb_ThucVat()
                {
                    TenLaTinh = model.TenLaTinh,
                    TenVietNam = model.TenVietNam,
                    MoTa = model.MoTa,
                    IDGiaTriKinhTe = model.IDGiaTriKinhTe,
                    IDKhaNangSinhTruong = model.IDKhaNangSinhTruong,
                    IDKhaNangTaiSinh = model.IDKhaNangTaiSinh,
                    IDHInhAnh = tb_HinhAnh.ID,
                    IDHo=model.IDHo,
                    DoDayLa = model.DoDayLa,
                    DoDayVo = model.DoDayVo,
                    LuongNuocTrongLa = model.LuongNuocTrongLa,
                    LuongNuocTrongVo = model.LuongNuocTrongVo,
                    LuongTroThoTrongLa = model.LuongTroThoTrongLa,
                    LuongTroThoTrongVo = model.LuongTroThoTrongVo,
                    ThoiGianChayTrenLa = model.ThoiGianChayTrenLa,
                    ThoiGianChayTrenVo = model.ThoiGianChayTrenVo
                });

                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int EditThucVat(ThucVatViewModel model)
        {
            try
            {
                int? IDHInhAnh = db.Tb_ThucVat.Where(x => x.ID == model.ID).First().IDHInhAnh;
                Tb_HinhAnh tb_HinhAnh = db.Tb_HinhAnh.Find(IDHInhAnh);
                if (model.DuongDanHInhAnh != null)
                {
                    tb_HinhAnh.DuongDan = model.DuongDanHInhAnh;
                    db.SaveChanges();
                }


                Tb_ThucVat tb_ThucVat = db.Tb_ThucVat.Find(model.ID);
                tb_ThucVat.TenLaTinh = model.TenLaTinh;
                tb_ThucVat.TenVietNam = model.TenVietNam;
                tb_ThucVat.MoTa = model.MoTa;
                tb_ThucVat.IDGiaTriKinhTe = model.IDGiaTriKinhTe;
                tb_ThucVat.IDKhaNangSinhTruong = model.IDKhaNangSinhTruong;
                tb_ThucVat.IDKhaNangTaiSinh = model.IDKhaNangTaiSinh;
                tb_ThucVat.IDHo = model.IDHo;
                tb_ThucVat.DoDayLa = model.DoDayLa;
                tb_ThucVat.DoDayVo = model.DoDayVo;
                tb_ThucVat.LuongNuocTrongLa = model.LuongNuocTrongLa;
                tb_ThucVat.LuongNuocTrongVo = model.LuongNuocTrongVo;
                tb_ThucVat.LuongTroThoTrongLa = model.LuongTroThoTrongLa;
                tb_ThucVat.LuongTroThoTrongVo = model.LuongTroThoTrongVo;
                tb_ThucVat.ThoiGianChayTrenLa = model.ThoiGianChayTrenLa;
                tb_ThucVat.ThoiGianChayTrenVo = model.ThoiGianChayTrenVo;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteThucVat(int id)
        {
            try
            {
                db.Tb_ThucVat.Remove(db.Tb_ThucVat.Find(id));
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public List<ThucVatViewModel> getListKhaNangSinhTruong()
        {
            return db.Tb_KhaNangSinhTruong.Select(x => new ThucVatViewModel()
            {
                IDKhaNangSinhTruong = x.ID,
                KhaNangSinhTruong = x.MoTa
            }).ToList();
        }
        public List<ThucVatViewModel> getListKhaNangTaiSinh()
        {
            return db.Tb_KhaNangTaiSinh.Select(x => new ThucVatViewModel()
            {
                IDKhaNangTaiSinh = x.ID,
                KhaNangTaiSinh = x.MoTa
            }).ToList();
        }
        public List<ThucVatViewModel> getListGiaTriKinhTe()
        {
            return db.Tb_GiaTriKinhTe.Select(x => new ThucVatViewModel()
            {
                IDGiaTriKinhTe = x.ID,
                GiaTriKinhTe = x.MoTa
            }).ToList();
        }
        public List<ThucVatViewModel> getListHo()
        {
            return db.Tb_Ho.Select(x => new ThucVatViewModel()
            {
                IDHo=x.ID,
                TenHo = x.TenHo
            }).OrderBy(x => x.TenHo).ToList();
        }
        public List<ThucVatViewModel> getListBo()
        {
            return db.Tb_Bo.Select(x => new ThucVatViewModel()
            {
                IDBo = x.ID,
                TenBo = x.TenBo
            }).OrderBy(x=>x.TenBo).ToList();
        }
        public ThucVatViewModel getListThucVatById(int id)
        {

            return (from tv in db.Tb_ThucVat
                    join ha in db.Tb_HinhAnh on tv.IDHInhAnh equals ha.ID
                    join gt in db.Tb_GiaTriKinhTe on tv.IDGiaTriKinhTe equals gt.ID
                    join ts in db.Tb_KhaNangTaiSinh on tv.IDKhaNangTaiSinh equals ts.ID
                    join st in db.Tb_KhaNangSinhTruong on tv.IDKhaNangSinhTruong equals st.ID
                    join h in db.Tb_Ho on tv.IDHo equals h.ID
                    join b in db.Tb_Bo on h.IDBo equals b.ID
                    orderby tv.ID ascending
                    select new ThucVatViewModel()
                    {
                        ID = tv.ID,
                        TenLaTinh = tv.TenLaTinh,
                        TenVietNam = tv.TenVietNam,
                        MoTa = tv.MoTa,
                        DoDayLa=tv.DoDayLa,
                        DoDayVo=tv.DoDayVo,
                        LuongNuocTrongLa=tv.LuongNuocTrongLa,
                        LuongNuocTrongVo=tv.LuongNuocTrongVo,
                        LuongTroThoTrongLa=tv.LuongTroThoTrongLa,
                        LuongTroThoTrongVo=tv.LuongTroThoTrongVo,
                        ThoiGianChayTrenLa=tv.ThoiGianChayTrenLa,
                        ThoiGianChayTrenVo=tv.ThoiGianChayTrenVo,
                        IDGiaTriKinhTe = gt.ID,
                        GiaTriKinhTe = gt.MoTa,
                        IDKhaNangTaiSinh = ts.ID,
                        KhaNangTaiSinh = ts.MoTa,
                        IDKhaNangSinhTruong = st.ID,
                        KhaNangSinhTruong = st.MoTa,
                        IDHInhAnh = ha.ID,
                        DuongDanHInhAnh = ha.DuongDan,
                        IDHo=h.ID,
                        TenHo=h.TenHo,
                        IDBo=b.ID,
                        TenBo=b.TenBo,
                        
                    }).Where(x => x.ID == id).FirstOrDefault();
        }
        public List<HoViewModel> getListHoByBoID(int id)
        {
            if(id!=0)
            {
                return (from h in db.Tb_Ho
                        join b in db.Tb_Bo on h.IDBo equals b.ID
                        select new HoViewModel()
                        {
                            ID = h.ID,
                            TenHo = h.TenHo,
                            IDBo = b.ID,
                            TenBo = b.TenBo,
                        }).Where(x => x.IDBo == id).OrderByDescending(x => x.TenHo).ToList();
            }
            return (from h in db.Tb_Ho
                    join b in db.Tb_Bo on h.IDBo equals b.ID
                    select new HoViewModel()
                    {
                        ID = h.ID,
                        TenHo = h.TenHo,
                        IDBo = b.ID,
                        TenBo = b.TenBo,
                    }).OrderByDescending(x => x.TenHo).ToList();
        }

    }
}