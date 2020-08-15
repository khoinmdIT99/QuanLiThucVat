using QuanLiThucVat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace QuanLiThucVat.Repositories
{
    public class LoginResponsitory
    {
        QuanLyThucVatEntities db = new QuanLyThucVatEntities();
        public LoginResponsitory()
        {

        }
        public NguoiDungViewModel Login(NguoiDungViewModel model)
        {
     
            NguoiDungViewModel nguoiDung =  (from nd in db.Tb_NguoiDung


                                                    join ha in db.Tb_HinhAnh on nd.IDHInhAnh equals ha.ID

                                                    select new NguoiDungViewModel()
                                                    {
                                                    ID=nd.ID,
                                                    Email=nd.Email,
                                                     DiaChi=nd.DiaChi,
                                                     NgaySinh=nd.NgaySinh,
                                                     MatKhau=nd.MatKhau,
                                                     HoTen=nd.HoTen,
                                                     LaQuanTriVienCapCao=nd.LaQuanTriVienCapCao,
                                                     SoDienThoai=nd.SoDienThoai,
                                                     GioiTinh=nd.GioiTinh,
                                                     IDHInhAnh=nd.IDHInhAnh,
                                                     DuongDanHInhAnh=ha.DuongDan                                                   
                                                    }).Where(x=>x.Email==model.Email&& x.MatKhau==model.MatKhau).SingleOrDefault();
            return nguoiDung;
        }
       

    }
}