using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cupertino.Support.Local.Models
{
    public class FileItem
    {
        public string Names { get; set; }
        public string Paths { get; set; }
        public string Type { get; set; }
        public string Extension { get; set; }
        public long? Sizes { get; set; }
        public int Depth { get; set; }

        public bool isSelected { get; set; }
        public List<FileItem> Children { get; set; }
    }
}
