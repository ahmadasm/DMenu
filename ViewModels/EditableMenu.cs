using System;
using System.Collections.Generic;
namespace MenuTest.ViewModels
{
    public class EditableMenu
    {
        public EditableMenu(){}
        public EditableMenu(Guid id,string name,bool isPublic,string cssClass,string description)
        {
            this.Id = id;
            this.Name = name;
            this.IsPublic = isPublic;
            this.CssClass = cssClass;
            this.Description = description;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public string CssClass { get; set; }
        public string Description { get; set; }
        public List<string> Parents { get; set; }
        public List<string> Text { get; set; }
        public List<string> Links { get; set; }
        public List<string> CssClasses { get; set; }
        public List<bool> OpenInNewTab { get; set; }
        public List<bool> LinkIsEnabled { get; set; }
    }
}