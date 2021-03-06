using System;
using System.Collections.Generic;
namespace MenuTest.Models
{
    public class Menu
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public string CssClass { get; set; }
        public string Description { get; set; }
        public virtual ICollection<MenuItem> Items { get; set; }
    }
    public static class MenuExtensions
    {
        public static string PublicToString(this Menu menu)
        {
            if(menu.IsPublic)
                return "بله";
            return "خیر";
        }
    }
}