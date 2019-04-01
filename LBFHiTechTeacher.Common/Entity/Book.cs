using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LBFVideoLib.Common
{
    // This will be serialized into a JSON array of Contact objects
    public class Book
    {
        public Book()
        {
            this.Selected = false;
        }

        public string BookId { get; set; }
        public string BookName { get; set; }

        public string SubjectName { get; set; }
        public string SeriesName { get; set; }
        public string ClassName { get; set; }

        public string[] VideoList { get; set; }

        public bool Selected { get; set; }

    }
}
