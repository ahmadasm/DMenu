using System.Collections.Generic;
namespace MenuTest.ViewModels
{
    public class EditableMenu
    {
        public int Id { get; set; }
        public List<string> Parents { get; set; }
        public List<string> Names { get; set; }
        public List<string> Links { get; set; }
    }
}