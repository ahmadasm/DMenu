using System;
namespace MenuTest.Models
{
    public class Menu
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public string CssClass { get; set; }
        public string Description { get; set; }
    }
}