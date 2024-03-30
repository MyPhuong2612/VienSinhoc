using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDoAnVienSinhHoc.Models;
using System.Web.Mvc;

namespace WebDoAnVienSinhHoc.Areas.NhanVien.Controllers
{
    public class NVNhanSuController : Controller
    {
        VSHEntities1 db = new VSHEntities1();

        // GET: NhanVien/NVNhanSu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThemNhanVien()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemNhanVien(string tenTaiKhoan, string matKhau, string hoTen, DateTime? ngaySinh, string gioiTinh, decimal? luong, string sdt, string emai, int? maCV, int? maPB, int? maXa, string diaChi)
        {
            var insert = db.spThemNhanVien(tenTaiKhoan, matKhau, hoTen, ngaySinh, gioiTinh, luong, sdt, emai, maCV, maPB, maXa, diaChi);
            return RedirectToAction("Index");
        }

        //NGHIÊN CỨU
        public ActionResult DanhSachNhanVienNghienCuu()
        {
            return View(db.viewThongTinNhanViens.Where(m => m.MaPB == 5).OrderBy(o => o.MaNV).ToList());
        }
        public ActionResult CTDanhSachNhanVienNghienCuu(int? id)
        {
            return View(db.viewThongTinNhanViens.Where(m => m.MaNV==id).OrderBy(o => o.MaNV).ToList());
        }


        //KINH DOANH
        public ActionResult DanhSachNhanVienKinhDoanh()
        {
            return View(db.viewThongTinNhanViens.Where(m => m.MaPB == 4).OrderBy(o => o.MaNV).ToList());
        }
        //KHOA HỌC
        public ActionResult DanhSachNhanVienKhoaHoc()
        {
            return View(db.viewThongTinNhanViens.Where(m => m.MaPB == 3).OrderBy(o => o.MaNV).ToList());
        }
        //NHÂN SỰ
        public ActionResult DanhSachNhanVienNhanSu()
        {
            return View(db.viewThongTinNhanViens.Where(m => m.MaPB == 2).OrderBy(o => o.MaNV).ToList());
        }
        //TỔ CHỨC
        public ActionResult DanhSachNhanVienToChuc()
        {
            return View(db.viewThongTinNhanViens.Where(m => m.MaPB == 1).OrderBy(o => o.MaNV).ToList());
        }
    }
}