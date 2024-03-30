using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDoAnVienSinhHoc.Models;
using System.Web.Mvc;
using System.Data;
using System.IO;

namespace WebDoAnVienSinhHoc.Areas.NhanVien.Controllers
{
    public class NVNghienCuuController : Controller
    {
        VSHEntities1 db = new VSHEntities1();
        // GET: NhanVien/NVNghienCuu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DSSanPham(string search)
        {
            List<spSearch_SanPham_Result> list = db.spSearch_SanPham(search).ToList();
            return View(list);
        }

        public ActionResult ChiTietSP(int? id)
        {
            return View(db.SanPhams.Where(m => m.ID == id).ToList());
        }
        public ActionResult DSKhongMaChung(string search)
        {
            List<spTimSPKhongMa_Result> list = db.spTimSPKhongMa(search).ToList();
            return View(list);
        }
        public ActionResult TaoSanPham()
        {
            SanPham model = new SanPham();
            return View(model);
        }
        [HttpPost]
        //, HttpPostedFileBase fileImg
        public ActionResult TaoSanPham(SanPham model)
        {
            //db.SanPhams.Add(model);
            //db.SaveChanges();
            //return RedirectToAction("DSKhongMaChung");
            try
            {
                if (model.imgUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.imgUpload.FileName);
                    string extension = Path.GetExtension(model.imgUpload.FileName);
                    fileName = fileName + extension;
                    model.HinhAnh = "~/Content/images/" + fileName;
                    model.imgUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                db.SanPhams.Add(model);
                db.SaveChanges();
                //if (fileImg.ContentLength > 0)
                //{
                //    string rootFolder = Server.MapPath("/Content/images/");
                //    string path = rootFolder + fileImg.FileName;
                //    fileImg.SaveAs(path);
                //    model.HinhAnh = "/Content/images/" + fileImg.FileName;
                //}
                //db.SanPhams.Add(model);
                //db.SaveChanges();
                return RedirectToAction("DSKhongMaChung");
            }
            catch
            {
                return View(model);
                throw;
            }
        }

    }
}