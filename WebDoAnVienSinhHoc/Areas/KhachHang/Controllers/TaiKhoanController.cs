using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebDoAnVienSinhHoc.Models;

namespace WebDoAnVienSinhHoc.Areas.KhachHang.Controllers
{D:\nqm\aspnet\WebDoAnVienSinhHoc\WebDoAnVienSinhHoc\Areas\Admin\
    public class TaiKhoanController : Controller
    {
        // GET: KhachHang/TaiKhoan
        VSHEntities1 db = new VSHEntities1();

        public ActionResult HoSoKH()
        {
            if (Session["tenTaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "TaiKhoan", "KhachHang");
            }
            else
            {
                KhachHangTaiKhoan ca = (KhachHangTaiKhoan)Session["tenTaiKhoan"];
                List<spShowHoSoKH_Result> list = db.spShowHoSoKH(ca.TenTaiKhoan).ToList();
                return View(list);
            }
        }

        // GET: ~/TruyCap/TaiKhoan/DangKy
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(string tenTaiKhoan, string matKhau, string hoTen, DateTime? ngaySinh, string gioiTinh, string diaChi, int? maXa)
        {
            var insert = db.spDangKy1(tenTaiKhoan, matKhau, hoTen, ngaySinh, gioiTinh, diaChi, maXa);
            return RedirectToAction("HoSoKH");
        }

        // GET: ~/TruyCap/TaiKhoan/DangXuat
        public ActionResult DangXuat()
        {
            Session.Remove("tenTaiKhoan");
            FormsAuthentication.SignOut();
            return RedirectToAction("ListSP", "SanPham","KhachHang");
        }

        // GET: ~/TruyCap/TaiKhoan/CapNhatMatKhau
        public ActionResult CapNhatMatKhau(string tenTaiKhoan, string matKhauMoi)
        {
            var taiKhoan = db.KhachHangTaiKhoans.SingleOrDefault(m => m.TenTaiKhoan == tenTaiKhoan);
            if (taiKhoan != null)
            {
                var update = db.spCapNhatMatKhau(tenTaiKhoan, matKhauMoi);
                if (update == 0)
                {
                    return RedirectToAction("CapNhatMatKhau");
                }
                return RedirectToAction("DangNhap");
            }
            return View();
        }
    }
}