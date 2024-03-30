using System.Web.Mvc;

namespace WebDoAnVienSinhHoc.Areas.KhachHang
{
    public class KhachHangAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "KhachHang";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "KhachHang_default",
                "KhachHang/{controller}/{action}/{id}",
                new { action = "ListSP", id = UrlParameter.Optional }
            );
        }
    }
}