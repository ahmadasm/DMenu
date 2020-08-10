using System;
using System.Collections.Generic;
namespace MenuTest.Models
{
    public class MenuItem
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Href { get; set; }
        public bool OpenInNewTab { get; set; }
        public string CssClass { get; set; }
        public Guid? ParentId { get; set; }
        public virtual ICollection<MenuItem> Children { get; set; }
    }
}