using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDoAnVienSinhHoc.Models;

namespace WebDoAnVienSinhHoc.Areas.KhachHang.Controllers
{
    public class SanPhamController : Controller
    {
        VSHEntities1 db = new VSHEntities1();
        // GET: KhachHang/SanPham

        public ActionResult ListSP(string search)
        {
            List<spSearch_SanPham_Result> list = db.spSearch_SanPham(search).ToList();
            return View(list);
        }
             
        public ActionResult DetailSP(int? id)
        {
            return View(db.SanPhams.Where(m => m.ID == id).ToList());
        }

        public ActionResult SanPhamDaDat()
        {
            KhachHangTaiKhoan ca = (KhachHangTaiKhoan)Session["tenTaiKhoan"];
            List<spSanPhamDaDat_Result> list = db.spSanPhamDaDat(ca.TenTaiKhoan).ToList();
            return View(list);
        }
    }
}