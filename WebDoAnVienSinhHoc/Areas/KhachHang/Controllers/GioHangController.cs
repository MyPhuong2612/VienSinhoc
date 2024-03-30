using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDoAnVienSinhHoc.Models;
using WebDoAnVienSinhHoc.Areas.KhachHang.Models;

namespace WebDoAnVienSinhHoc.Areas.KhachHang.Controllers
{
    public class GioHangController : Controller
    {
        VSHEntities1 db = new VSHEntities1();

        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }


        // GET: KhachHang/GioHang
        public ActionResult ThemVaoGioHang(int id)
        {
            if (Session["tenTaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "TaiKhoan", "KhachHang");
            }
            else
            {
                var sp = db.SanPhams.SingleOrDefault(m => m.ID == id);
                if (sp != null)
                {
                    GetCart().Them(sp);
                }
                return RedirectToAction("XemGioHang", "GioHang", "KhachHang");
            }
        }

        public ActionResult XemGioHang()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("XemGioHang", "GioHang", "KhachHang");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }

        public ActionResult CapNhatSoLuongGioHang(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int idSanPham = int.Parse(form["idSanPham"]);
            int soLuong = int.Parse(form["soLuong"]);
            cart.CapNhatSoLuong(idSanPham, soLuong);
            return RedirectToAction("XemGioHang", "GioHang", "KhachHang");
        }

        public ActionResult XoaMotSanPham(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.XoaMotSanPham(id);
            return RedirectToAction("XemGioHang", "GioHang", "KhachHang");
        }

        public PartialViewResult BagGioHang()
        {
            int count = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            {
                count = cart.tongSoLuong();
            }
            ViewBag.tongSL = count;
            return PartialView("BagGioHang");
        }

        public ActionResult ThanhToan() //FormCollection form
        {
            try
            {

                KhachHangTaiKhoan ca = (KhachHangTaiKhoan)Session["tenTaiKhoan"];
                Cart cart = Session["Cart"] as Cart;
                HoaDon hd = new HoaDon();
                hd.NgayLap = DateTime.Now;
                hd.MaKH = ca.MaKH;
                db.HoaDons.Add(hd);
                foreach (var item in cart.Items)
                {
                    CTHoaDon cth = new CTHoaDon();
                    cth.MaHD = hd.MaHD;
                    cth.MaSP = item.shoppingSanPham.ID;
                    cth.SoLuong = item.shoppingSoLuong;
                    db.CTHoaDons.Add(cth);
                }
                db.SaveChanges();
                cart.XoaGioHang();
                return RedirectToAction("ThanhToanThanhCong", "GioHang", "KhachHang");
            }
            catch (Exception)
            {
                return RedirectToAction("ThanhToanThatBai", "GioHang", "KhachHang");
                throw;
            }
        }

        public ActionResult ThanhToanThanhCong()
        {
            return View();
        }
        public ActionResult ThanhToanThatBai()
        {
            return View();
        }
    }
}