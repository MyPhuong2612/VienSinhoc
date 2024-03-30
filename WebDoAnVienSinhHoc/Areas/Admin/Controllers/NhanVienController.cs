using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDoAnVienSinhHoc.Models;

namespace WebDoAnVienSinhHoc.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        VSHEntities1 db = new VSHEntities1();
        // GET: Admin/NhanVien
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DanhSachNhanVienNghienCuu()
        {
            if (Session["tenTaiKhoan"] != null)
            {
                return View(db.NhanViens.Where(m => m.MaPB == 5).OrderBy(o => o.MaNV).ToList());
            }
            return RedirectToAction("DangNhap", "Home");
        }

        public ActionResult DanhSachNhanVienKinhDoanh()
        {
            return View(db.NhanViens.Where(m => m.MaPB == 4).OrderBy(o=>o.MaNV).ToList());
        }

        public ActionResult DanhSachNhanVienKhoaHoc()
        {
            return View(db.NhanViens.Where(m => m.MaPB == 3).OrderBy(o => o.MaNV).ToList());
        }

        public ActionResult DanhSachNhanVienNhanSu()
        {
            return View(db.NhanViens.Where(m => m.MaPB == 2).OrderBy(o => o.MaNV).ToList());
        }
        public ActionResult DanhSachNhanVienToChuc()
        {
            return View(db.NhanViens.Where(m => m.MaPB == 1 ).OrderBy(o => o.MaNV).ToList());
        }
    }
}