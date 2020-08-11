using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MenuTest.Dal;
namespace MenuTest.ViewComponents
{
    public class ShowMenu:ViewComponent
    {
        private readonly MenuDbContext _dbContext;
        public ShowMenu(MenuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IViewComponentResult Invoke(string name)
        {
            var menu = _dbContext.Menus.Include(i => i.Items).ThenInclude(ch => ch.Children)
                .Where(i => i.Name == name).FirstOrDefault();
            return View("~/Views/Shared/Components/Menu/ShowMenu.cshtml",menu);
        }
    }
}