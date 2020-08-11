using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MenuTest.Models;
namespace MenuTest.ViewComponents
{
    public class SitesMenuItems:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<Site> sites = new List<Site>(){
                new Site(){Name="گوگل",Href="http://google.com"},
                new Site(){Name="یاهو",Href="http://yahoo.com"},
                new Site(){Name="مایکروسافت",Href="http://microsoft.com"},
                new Site(){Name="اوبر",Href="http://uber.com"},
                new Site(){Name="نتفلیکس",Href="http://netflix.com"},
                new Site(){Name="یوتیوب",Href="http://youtube.com"},
            };
            return View("~/Views/Shared/Components/CustomLink/SitesMenuItems.cshtml",sites);
        }
    }
}