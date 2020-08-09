using Microsoft.AspNetCore.Mvc;
namespace MenuTest.ViewComponents
{
    public class CustomLinkItem:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Shared/Components/CustomLink/CustomLinkItem.cshtml");
        }
    }
}