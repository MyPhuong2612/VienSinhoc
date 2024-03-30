using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDoAnVienSinhHoc.Models;

namespace WebDoAnVienSinhHoc.Areas.NhanVien.Controllers
{
    public class NVKinhDoanhController : Controller
    {
        VSHEntities1 db = new VSHEntities1();
        // GET: NhanVien/NVKinhDoanh
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XemDonHang()
        {
            List<HoaDon> list = db.HoaDons.OrderBy(m=>m.NgayLap).ToList();
            return View(list);
        }
        public ActionResult CTDonHang(int? id)
        {
            List<CTHoaDon> list = db.CTHoaDons.Where(m => m.MaHD == id).ToList();
            return View(list);
        }

        public ActionResult DSKhachHang()
        {
            List<KhachHangTaiKhoan> list = db.KhachHangTaiKhoans.ToList();
            return View(list);
        }

        public ActionResult DuyetDon(int? id)
        {
            viewThongTinNhanVien nv = (viewThongTinNhanVien)Session["tenTaiKhoan"];
            var update = db.spDuyetDon(nv.MaNV, id);
            if (update == 0)
            {
                return RedirectToAction("XemDonHang");
            }
            return RedirectToAction("XemDonHang");
        }

    }
}