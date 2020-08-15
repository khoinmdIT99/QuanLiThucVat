using QuanLiThucVat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiThucVat.Repositories
{
    public class HoResponsitory
    {
        QuanLyThucVatEntities db = new QuanLyThucVatEntities();
        public HoResponsitory()
        {

        }

        public List<HoViewModel> getAllListHo(string keyword)
        {
            return (from h in db.Tb_Ho
                    join b in db.Tb_Bo on h.IDBo equals b.ID
                    select new HoViewModel()
                    {
                        ID = h.ID,
                        TenHo=h.TenHo,
                        IDBo=b.ID,                       
                        TenBo = b.TenBo,

                    }).Where(x => string.IsNullOrEmpty(keyword) || x.TenHo.Contains(keyword)).OrderByDescending(x => x.ID).ToList();
        }

        public int AddHo(HoViewModel model)
        {
            try
            {

                db.Tb_Ho.Add(new Tb_Ho()
                {
                    TenHo=model.TenHo,                  
                    IDBo = model.IDBo,
                });

                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int EditHo(HoViewModel model)
        {
            try
            {
                Tb_Ho tb_Ho = db.Tb_Ho.Find(model.ID);
                tb_Ho.TenHo = model.TenHo;
                tb_Ho.IDBo = model.IDBo;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int DeleteHo(int id)
        {
            try
            {
                List<Tb_ThucVat> list = new List<Tb_ThucVat>();
                list = db.Tb_ThucVat.Where(x => x.IDHo == id).ToList();
                if (list.Count == 0)
                {
                    db.Tb_Ho.Remove(db.Tb_Ho.Find(id));
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch
            {
                return -1;
            }
        }
        public List<BoViewModel> getAllListBo()
        {
            return (from b in db.Tb_Bo
                    select new BoViewModel()
                    {
                        ID = b.ID,
                        TenBo = b.TenBo
                    }).OrderBy(x=>x.TenBo).ToList();
        }
    }
}