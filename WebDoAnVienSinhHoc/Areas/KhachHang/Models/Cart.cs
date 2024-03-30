using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDoAnVienSinhHoc.Models;

namespace WebDoAnVienSinhHoc.Areas.KhachHang.Models
{
    public class CartItem
    {
        public SanPham shoppingSanPham { get; set; }
        public int shoppingSoLuong { get; set; }
    }

    public class Cart
    {
        List<CartItem> items = new List<CartItem>();

        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }

        public void Them(SanPham sp, int sl = 1)
        {
            var item = items.FirstOrDefault(m => m.shoppingSanPham.ID == sp.ID);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    shoppingSanPham = sp,
                    shoppingSoLuong = sl
                });
            }
            else
            {
                item.shoppingSoLuong += sl;
            }
        }

        public void CapNhatSoLuong(int id, int sl)
        {
            var item = items.Find(m => m.shoppingSanPham.ID == id);
            if (item != null)
            {
                item.shoppingSoLuong = sl;
            }
        }

        public double tongDonGia()
        {
            var tong = items.Sum(m => m.shoppingSanPham.GiaBan * m.shoppingSoLuong);
            return (double)tong;
        }

        public void XoaMotSanPham(int id)
        {
            items.RemoveAll(m => m.shoppingSanPham.ID == id);
        }

        public void XoaGioHang()
        {
            items.Clear();
        }

        public int tongSoLuong()
        {
            return items.Sum(m => m.shoppingSoLuong);
        }

    }

    
}