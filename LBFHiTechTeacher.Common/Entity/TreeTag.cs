using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LBFVideoLib.Common.Entity
{
    public class TreeTag
    {
        public TreeTag()
        {
            BookVideoList = new List<string>();
        }
        public string CurrentDirectoryPath { get; set; }

        public List<string> BookVideoList { get; set; }
    }
}
