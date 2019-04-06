using LBFVideoLib.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LBFVideoLib.Common
{
   public class TemplateInfo
    {
        public TemplateInfo()
        {
            VideoInfoList = new List<VideoInfo>();
        }

        public string TemplateName { get; set; }

        public string TemplatePath { get; set; }
        
        public DateTime TemplateCreationDate { get; set; }

        public string MemoNumber { get; set; } = "";

        public List<ClassFB> SelectedVideoDetails { get; set; }

        public List<VideoInfo> VideoInfoList { get; set; }
    }
}
