using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LBFVideoLib.Common
{
    [Serializable()]
    public class VideoInfo
    {
        public string VideoFullUrl { get; set; }

        public string VideoRelativeUrl { get; set; }

        public string VideoName { get; set; }

        public int WatchCount { get; set; }

        public string ClassName { get; set; }

        public string SeriesName { get; set; }

        public string Subject { get; set; }

        public string Book { get; set; }

        //public string FileName { get; set; }

        public string ThumbnailFilePath { get; set; }

    }
}
