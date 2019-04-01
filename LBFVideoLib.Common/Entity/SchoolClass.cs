using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LBFVideoLib.Common
{
    // This will be serialized into a JSON Address object
    public class SchoolClass
    {
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public List<Series> SeriesList { get; set; }
        public bool Selected { get; set; }

        public SchoolClass()
        {
            this.SeriesList = new List<Series>();
            this.Selected = false;
        }
    }
}
