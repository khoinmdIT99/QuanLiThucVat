using QuanLiThucVat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiThucVat.Repositories
{

    public class DashBoardResponsitory
    {
        QuanLyThucVatEntities db = new QuanLyThucVatEntities();
        public DashBoardViewModel GetDashBoard()
        {
            return new DashBoardViewModel()
            {
                TreeNumber = db.Tb_ThucVat.Count(),
                UserNumber = db.Tb_NguoiDung.Count(),
                BoNumber = db.Tb_Bo.Count(),
                HoNumber = db.Tb_Ho.Count(),
                NewNumber = db.Tb_TinTuc.Count()
            };
        }
    }
}