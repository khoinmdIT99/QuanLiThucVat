using QuanLiThucVat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiThucVat.Repositories
{
    public class NguoiDungResponsitory
    {
        QuanLyThucVatEntities db = new QuanLyThucVatEntities();
        public NguoiDungResponsitory()
        {

        }

        public List<NguoiDungViewModel> getAllListNguoiDung(string keyword)
        {
            return (from nd in db.Tb_NguoiDung
                    join ha in db.Tb_HinhAnh on nd.IDHInhAnh equals ha.ID
                    select new NguoiDungViewModel()
                    {
                        ID = nd.ID,
                        DiaChi = nd.DiaChi,
                        Email = nd.Email,
                         HoTen=nd.HoTen,
                        GioiTinh = nd.GioiTinh,
                        MatKhau = nd.MatKhau,
                        LaQuanTriVienCapCao = nd.LaQuanTriVienCapCao,
                        NgaySinh = nd.NgaySinh,
                        SoDienThoai = nd.SoDienThoai,
                        IDHInhAnh = ha.ID,

                        DuongDanHInhAnh = ha.DuongDan,

                    }).Where(x => string.IsNullOrEmpty(keyword) || x.Email.Contains(keyword)).OrderByDescending(x => x.ID).ToList();
        }

        public int AddNguoiDung(NguoiDungViewModel model)
        {
            try
            {
                Tb_HinhAnh tb_HinhAnh = new Tb_HinhAnh();
                tb_HinhAnh.DuongDan = model.DuongDanHInhAnh;
                db.Tb_HinhAnh.Add(tb_HinhAnh);
                db.SaveChanges();
                db.Tb_NguoiDung.Add(new Tb_NguoiDung()
                {
                    DiaChi = model.DiaChi,
                    Email = model.Email,
                    GioiTinh = model.GioiTinh,
                    MatKhau = MaHoaMD5(model.MatKhau),
                    HoTen=model.HoTen,
                    LaQuanTriVienCapCao = model.LaQuanTriVienCapCao,
                    NgaySinh = model.NgaySinh,
                    SoDienThoai = model.SoDienThoai,
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

        public int EditNguoiDung(NguoiDungViewModel model)
        {
            try
            {
                int? IDHInhAnh = db.Tb_NguoiDung.Where(x => x.ID == model.ID).First().IDHInhAnh;
                Tb_HinhAnh tb_HinhAnh = db.Tb_HinhAnh.Find(IDHInhAnh);
                if (model.DuongDanHInhAnh != null)
                {
                    tb_HinhAnh.DuongDan = model.DuongDanHInhAnh;
                    db.SaveChanges();
                }
                Tb_NguoiDung tb_NguoiDung = db.Tb_NguoiDung.Find(model.ID);
                tb_NguoiDung.DiaChi = model.DiaChi;
                tb_NguoiDung.Email = model.Email;
                tb_NguoiDung.GioiTinh = model.GioiTinh;
                if(model.MatKhau.Trim().Length>0)
                {
                    tb_NguoiDung.MatKhau = MaHoaMD5(model.MatKhau);

                }
                tb_NguoiDung.NgaySinh = model.NgaySinh;
                tb_NguoiDung.SoDienThoai = model.SoDienThoai;
                tb_NguoiDung.HoTen = model.HoTen;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteNguoiDung(int id)
        {
            try
            {
                db.Tb_NguoiDung.Remove(db.Tb_NguoiDung.Find(id));
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public bool CheckEmailExist(string email)
        {
            return db.Tb_NguoiDung.Any(x => x.Email == email);
        }
        public string MaHoaMD5(String text)
        {
            string result = "";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(text);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (byte b in buffer)
            {
                result += b.ToString("X2");
            }
            return result.ToLower();
        }
    }
}