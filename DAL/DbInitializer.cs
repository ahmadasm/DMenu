using System;
using System.Linq;
using MenuTest.Models;
namespace MenuTest.Dal
{
    public interface IDbInitializer
    {
        public void Init();
    }
    public class DbInitializer:IDbInitializer
    {
        private readonly MenuDbContext _dbContext;
        public DbInitializer(MenuDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Init()
        {
            _dbContext.Database.EnsureCreated();
            if(!_dbContext.Menus.Any())
            {
                var menus = new Menu[]{
                    new Menu{Id = Guid.NewGuid(),Name="منو اصلی",IsPublic=true},
                    new Menu{Id = Guid.NewGuid(),Name="منو پیشخوان",IsPublic=false},
                };

                foreach(Menu menu in menus)
                {
                    _dbContext.Menus.Add(menu);
                }
                _dbContext.SaveChanges();
            }
        }
    }
}