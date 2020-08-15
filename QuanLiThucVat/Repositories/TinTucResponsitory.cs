using QuanLiThucVat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiThucVat.Repositories
{
    public class TinTucResponsitory
    {
        QuanLyThucVatEntities db = new QuanLyThucVatEntities();
        public TinTucResponsitory()
        {

        }

        public List<TinTucViewModel> getAllListTinTuc(string keyword)
        {
            return (from tt in db.Tb_TinTuc
                    join ha in db.Tb_HinhAnh on tt.IDHInhAnh equals ha.ID
                    select new TinTucViewModel()
                    {
                        ID = tt.ID,
                        DanNhap = tt.DanNhap,
                        NoiDung = tt.NoiDung,
                        TieuDe = tt.TieuDe,
                        IDHInhAnh = ha.ID,
                        DuongDanHinhAnh = ha.DuongDan,

                    }).Where(x => string.IsNullOrEmpty(keyword) || x.TieuDe.Contains(keyword)).OrderByDescending(x => x.ID).ToList();
        }
        public List<TinTucViewModel> getListTinTuc()
        {
            return (from tt in db.Tb_TinTuc
                    join ha in db.Tb_HinhAnh on tt.IDHInhAnh equals ha.ID
                    select new TinTucViewModel()
                    {
                        ID = tt.ID,
                        DanNhap = tt.DanNhap,
                        NoiDung = tt.NoiDung,
                        TieuDe = tt.TieuDe,
                        IDHInhAnh = ha.ID,
                        DuongDanHinhAnh = ha.DuongDan,
                    }).Take(10).OrderByDescending(x => x.ID).ToList();
        }
        public TinTucViewModel getTinTucById(int id)
        {
            return (from tt in db.Tb_TinTuc
                    join ha in db.Tb_HinhAnh on tt.IDHInhAnh equals ha.ID
                    select new TinTucViewModel()
                    {
                        ID = tt.ID,
                        DanNhap = tt.DanNhap,
                        NoiDung = tt.NoiDung,
                        TieuDe = tt.TieuDe,
                        IDHInhAnh = ha.ID,
                        DuongDanHinhAnh = ha.DuongDan,
                    }).Where(x => x.ID == id).OrderByDescending(x => x.ID).FirstOrDefault();
        }
        public int AddTinTuc(TinTucViewModel model)
        {
            try
            {
                Tb_HinhAnh tb_HinhAnh = new Tb_HinhAnh();
                tb_HinhAnh.DuongDan = model.DuongDanHinhAnh;
                db.Tb_HinhAnh.Add(tb_HinhAnh);
                db.SaveChanges();
                db.Tb_TinTuc.Add(new Tb_TinTuc()
                {
                    TieuDe = model.TieuDe,
                    DanNhap = model.DanNhap,
                    NoiDung = model.NoiDung,
                    IDHInhAnh = tb_HinhAnh.ID,

                });

                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int EditTinTuc(TinTucViewModel model)
        {
            try
            {
                int? IDHInhAnh = db.Tb_TinTuc.Where(x => x.ID == model.ID).First().IDHInhAnh;
                Tb_HinhAnh tb_HinhAnh = db.Tb_HinhAnh.Find(IDHInhAnh);
                if (model.DuongDanHinhAnh != null)
                {
                    tb_HinhAnh.DuongDan = model.DuongDanHinhAnh;
                    db.SaveChanges();
                }
                Tb_TinTuc tb_TinTuc = db.Tb_TinTuc.Find(model.ID);
                tb_TinTuc.TieuDe = model.TieuDe;
                tb_TinTuc.NoiDung = model.NoiDung;
                tb_TinTuc.DanNhap = model.DanNhap;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteTinTuc(int id)
        {
            try
            {
                db.Tb_TinTuc.Remove(db.Tb_TinTuc.Find(id));
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}