using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Nitin Start update this class.
namespace LBFVideoLib.Common
{
    public class ConfigHelper
    {
        public static string SourceVideoFolderPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings.Get("sourcevideofolderpath");
            }

        }
        public static string ClientDistributionTargetRootPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings.Get("clientdistributiontargetrootpath");
            }

        }


        //public static string AdminInfoFileName
        //{
        //    get
        //    {
        //        return System.Configuration.ConfigurationManager.AppSettings.Get("admininfofilename");
        //    }

        //}

        public static string ClientInfoFileName
        {
            get
            {
                // return System.Configuration.ConfigurationManager.AppSettings.Get("clientinfofilename");
                return "clientinfo.txt";
            }

        }

        //public static string SessionYears
        //{
        //    get
        //    {
        //        return System.Configuration.ConfigurationManager.AppSettings.Get("sessionYears");
        //    }
        //}

        public static string ClientDistributionPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings.Get("clientdistributionpath");
            }

        }

        // Nitin:+
        public static string GetClientThumbnailImageFileName
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings.Get("thumbnailfilename");
            }
        }
    }
}
