using System.Web.Mvc;

namespace WebDoAnVienSinhHoc.Areas.TruyCap
{
    public class TruyCapAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TruyCap";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TruyCap_default",
                "TruyCap/{controller}/{action}/{id}",
                new { action = "DangNhap", id = UrlParameter.Optional }
            );
        }
    }
}