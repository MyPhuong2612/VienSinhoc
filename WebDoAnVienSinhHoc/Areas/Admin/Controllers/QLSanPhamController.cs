using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDoAnVienSinhHoc.Models;
using System.Web.Mvc;
using System.Data;
using System.IO;


namespace WebDoAnVienSinhHoc.Areas.Admin.Controllers
{
    public class QLSanPhamController : Controller
    {
        VSHEntities1 db = new VSHEntities1();

        // GET: Admin/QLSanPham
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SanPhamThuongMai(string search)
        {
            List<spSearch_SanPham_Result> list = db.spSearch_SanPham(search).ToList();
            return View(list);
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

        public ActionResult TaoSanPham()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoSanPham(SanPham model)
        {
            if (string.IsNullOrEmpty(model.TenKhoaHoc))
            {
                ModelState.AddModelError("", "Thiếu thông tin");
                return View(model);
            }
            try
            {
                db.SanPhams.Add(model);
                db.SaveChanges();
                return RedirectToAction("SanPhamChuaMa");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
                throw;
            }
        }
    }
}