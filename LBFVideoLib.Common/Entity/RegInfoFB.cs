using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LBFVideoLib.Common.Entity
{

    public class RegInfoFB
    {
                
        public RegInfoFB()
        {
            Classes = new List<ClassFB>();
            MacAddresses = new List<string>();

        }

        public string RegDate
        {
            get; set;
        }

        public string LoginEmail
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }

        public string SchoolName
        {
            get; set;
        }

        public string City
        {
            get; set;
        }

        public string SchoolCode
        {
            get; set;
        }

        public string Session
        {
            get; set;
        }

        public string MemoNumber
        {
            get; set;
        }

        public List<ClassFB> Classes
        {
            get; set;
        }

        public int NoOfPcs { get; set; }

        public DateTime ExpiryDate { get; set; }

        public List<string> MacAddresses { get; set; }
    }

    [Serializable()]
    public class ClassFB
    {
        public ClassFB()
        {
            Series = new List<SeriesFB>();
        }

        public string Name
        {
            get; set;
        }

        public List<SeriesFB> Series
        {
            get; set;
        }
    }
    [Serializable()]
    public class SeriesFB
    {

        public SeriesFB()
        {
            Subjects = new List<SubjectFB>();
        }

        public string Name
        {
            get; set;
        }
        public List<SubjectFB> Subjects;
    }

    [Serializable()]
    public class SubjectFB
    {

        public SubjectFB()
        {
            Books = new List<BookFB>();
        }
        public string Name
        {
            get; set;
        }
        public List<BookFB> Books;
    }

    [Serializable()]
    public class BookFB
    {
        public string Name
        {
            get; set;
        }

        public int WatchCount
        {
            get; set;
        }

    }


    public class WatchCountInfoFB
    {
        public string machinename { get; set; }
        public string videoname { get; set; }
        public int videowatchcount { get; set; }
    }

    public class SessionInfoFB
    {
        //public string machineName { get; set; }
        public DateTime sessionstarttime { get; set; }
        public DateTime sessionendtime { get; set; }
    }
}
