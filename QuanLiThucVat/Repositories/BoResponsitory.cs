using QuanLiThucVat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiThucVat.Repositories
{
    public class BoResponsitory
    {
        QuanLyThucVatEntities db = new QuanLyThucVatEntities();
        public BoResponsitory()
        {

        }

        public List<BoViewModel> getAllListBo(string keyword)
        {
            return (from l in db.Tb_Bo
                    select new BoViewModel()
                    {
                        ID = l.ID,
                        TenBo=l.TenBo
                    }).Where(x => string.IsNullOrEmpty(keyword) || x.TenBo.Contains(keyword)).OrderByDescending(x => x.ID).ToList();
        }

        public int AddBo(BoViewModel model)
        {
            try
            {

                db.Tb_Bo.Add(new Tb_Bo()
                {                 
                    TenBo=model.TenBo
                });

                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int EditBo(BoViewModel model)
        {
            try
            {
                Tb_Bo tb_Bo = db.Tb_Bo.Find(model.ID);
                tb_Bo.TenBo = model.TenBo;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int DeleteBo(int id)
        {
            try
            {
                List<Tb_Ho> list = new List<Tb_Ho>();
                list = db.Tb_Ho.Where(x => x.ID == id).ToList();
                if (list.Count == 0)
                {
                    db.Tb_Bo.Remove(db.Tb_Bo.Find(id));
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


    }
}