using System;
using System.Linq;
using MenuTest.Models;
namespace MenuTest.Dal
{
    public static class DbInitializer
    {
        public static void Init(MenuDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            if(!dbContext.Menus.Any())
            {
                var menus = new Menu[]{
                    new Menu{Id = Guid.NewGuid(),Name="منو اصلی",IsPublic=true},
                    new Menu{Id = Guid.NewGuid(),Name="منو پیشخوان",IsPublic=false},
                };

                foreach(Menu menu in menus)
                {
                    dbContext.Menus.Add(menu);
                }
                dbContext.SaveChanges();
            }
        }
    }
}