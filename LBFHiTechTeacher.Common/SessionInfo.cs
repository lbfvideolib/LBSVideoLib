using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LBFVideoLib.Common
{
    [Serializable()]
    public class SessionInfo
    {
        public DateTime StartTime
        {
            get; set;
        }
        public DateTime EndTime
        {
            get; set;
        }
    }
}
