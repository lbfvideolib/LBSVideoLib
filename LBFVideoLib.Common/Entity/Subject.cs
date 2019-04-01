 

namespace LBFVideoLib.Common.Entity
{
   public class Subject
    {
        // This will be serialized into a JSON array of Contact objects

        public Subject()
        {
            this.Selected = false;
        }

        public string SubjectId { get; set; }
        public string SubjectName { get; set; }

        public string SeriesName { get; set; }
        public string ClassName { get; set; }

        public bool Selected { get; set; }


    }
}
