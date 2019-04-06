using LBFVideoLib.Common.Entity;
using System;
using System.Collections.Generic;
using System.IO;

namespace LBFVideoLib.Common
{
    [Serializable()]
    public class ClientInfo
    {
        public ClientInfo()
        {
            SessionList = new List<SessionInfo>();
            VideoInfoList = new List<VideoInfo>();
        }

        public string EmailId { get; set; }

        public string Password { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime SessionStartDate { get; set; }

        public DateTime SessionEndDate { get; set; }

        public DateTime LastAccessStartTime { get; set; }

        public DateTime LastAccessEndTime { get; set; }

        public string SchoolName { get; set; }

        public string SchoolId { get; set; }

        public string SchoolCity { get; set; }

        public string SessionString { get; set; }

        public bool Expired { get; set; } = false;

        public string MemoNumber { get; set; } = "";

        public string MacAddress { get; set; } = "";

        public int MaxNumberOfPCs { get; set; } = 0;

        public List<ClassFB> SelectedVideoDetails { get; set; }

        public List<SessionInfo> SessionList { get; set; }

        public List<VideoInfo> VideoInfoList { get; set; }

        // Added this property to transfer object from template to new registration.
        public RegInfoFB RegistrationInfo { get; set; }
        
    }
}
