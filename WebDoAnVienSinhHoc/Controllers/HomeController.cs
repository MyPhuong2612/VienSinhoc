using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using WebDoAnVienSinhHoc.Models;

namespace WebDoAnVienSinhHoc.Controllers
{
    public class HomeController : Controller
    {
        VSHEntities1 db = new VSHEntities1();
        public ActionResult Index()
        {
            return View();
        }
        
        //CHỨC NĂNG ĐĂNG NHẬP
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string tenTaiKhoan, string matKhau)
        {
            var nhanVien = db.viewThongTinNhanViens.SingleOrDefault(m => m.TenTK == tenTaiKhoan && m.MatKhau == matKhau);
            var khachHang = db.KhachHangTaiKhoans.SingleOrDefault(m => m.TenTaiKhoan == tenTaiKhoan && m.MatKhau == matKhau);
            //kiểm tra tài khoản nhân viên
            if (nhanVien != null)
            {
                //nếu tài khoản là Admin
                if (nhanVien.TenTK.Equals("AdminDN"))
                {
                    Session["tenTaiKhoan"] = nhanVien;
                    return RedirectToAction("Index", "NhanVien", new { area = "Admin" });
                }
                if (nhanVien.MaPB == 1)
                {
                    Session["tenTaiKhoan"] = nhanVien;
                    return RedirectToAction("Index", "NVToChuc", new { area = "NhanVien" });
                }
                if (nhanVien.MaPB == 2)
                {
                    Session["tenTaiKhoan"] = nhanVien;
                    return RedirectToAction("Index", "NVNhanSu", new { area = "NhanVien" });
                }
                if (nhanVien.MaPB == 3)
                {
                    Session["tenTaiKhoan"] = nhanVien;
                    return RedirectToAction("Index", "NVKhoaHoc", new { area = "NhanVien" });
                }
                if (nhanVien.MaPB == 4)
                {
                    Session["tenTaiKhoan"] = nhanVien;
                    return RedirectToAction("Index", "NVKinhDoanh", new { area = "NhanVien" });
                }
                if (nhanVien.MaPB == 5)
                {
                    Session["tenTaiKhoan"] = nhanVien;
                    return RedirectToAction("Index", "NVNghienCuu", new { area = "NhanVien" });
                }
            }
            //kiểm tra tài khoản khách hàng
            else if (khachHang != null)
            {
                Session["tenTaiKhoan"] = khachHang;
                return RedirectToAction("ListSP", "SanPham", new { area = "KhachHang" });
            }

            return RedirectToAction("DangNhap", "Home");
        }

        //CHỨC NĂNG ĐĂNG XUẤT
        public ActionResult DangXuat()
        {
            Session.Remove("tenTaiKhoan");
            FormsAuthentication.SignOut();
            return RedirectToAction("DangNhap", "Home");
        }
    }
}