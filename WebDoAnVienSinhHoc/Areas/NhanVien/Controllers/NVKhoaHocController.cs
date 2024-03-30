using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDoAnVienSinhHoc.Models;


namespace WebDoAnVienSinhHoc.Areas.NhanVien.Controllers
{
    public class NVKhoaHocController : Controller
    {
        // GET: NhanVien/NVQuanLy
        VSHEntities1 db = new VSHEntities1();
        
        public ActionResult Index()
        {
            if (Session["tenTaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            return View();
        }
        public ActionResult SanPhamThuongMai(string search)
        {
            if (Session["tenTaiKhoan"] == null)
            {
                List<spSearch_SanPham_Result> list = db.spSearch_SanPham(search).ToList();
                return View(list);
            }
            return RedirectToAction("DangNhap", "TaiKhoan", "KhachHang");
        }

        public ActionResult CTSanPhamThuongMai(int? id)
        {
            return View(db.SanPhams.Where(m => m.ID == id).ToList());
        }

        public ActionResult SanPhamChuaMa(string search)
        {
            List<spTimSPKhongMa_Result> list = db.spTimSPKhongMa(search).ToList();
            return View(list);
        }

        public ActionResult DuyetSP(FormCollection form)
        {
            int id = int.Parse(form["id"]);
            string maChung = (form["maChung"]);

            int update = db.spDuyetSP(id, maChung);
            if (update == 0)
            {
                return RedirectToAction("SanPhamChuaMa");
            }
            return RedirectToAction("SanPhamChuaMa");
        }
    }
}