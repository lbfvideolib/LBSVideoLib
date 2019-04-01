using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LBFVideoLib.Common
{  // This will be serialized into a JSON Contact object
    public class Series
    {
        public string SeriesId { get; set; }
        public string SeriesName { get; set; }
        public string ClassName { get; set; }
        public List<Book> BookList { get; set; }
        public bool Selected { get; set; }

        public Series()
        {
            this.BookList = new List<Book>();
            this.Selected = false;
        }
    }
}
