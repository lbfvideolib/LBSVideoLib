using System;
using System.IO;

namespace LBFVideoLib.Common
{
    public class ClientHelper
    {

        #region Client Path Helper Methods
        public static string GetClientRootPath()
        {
            return Directory.GetCurrentDirectory();
            // return @"D:\School\Error";
           // return @"D:\School\ClientPackages\a";
        }

        public static string GetClientInfoFilePath()
        {
            return Path.Combine(GetClientRootPath(), ConfigHelper.ClientInfoFileName);
        }

        public static string GetClientVideoFilePath(string schoolCode, string schoolCity)
        {
            string parentPath = Directory.GetParent(GetClientRootPath()).FullName;

            //return Path.Combine(parentPath, string.Format("{ 0}_{1}_{2}", schoolCode, schoolCity, "LBFVideos"));
            return Path.Combine(GetClientRootPath(), string.Format("{0}_{1}_{2}", schoolCode, schoolCity, "LBFVideos"));
        }

        public static string GetClientThumbanailPath()
        {
            return Path.Combine(GetClientRootPath(), "Thumbnails");
        }

        public static string GetClassNameFromFullPath(string fullBookDirectoryPath)
        {
            return Directory.GetParent(fullBookDirectoryPath).Parent.Parent.Name;
        }
        #region BkupFileCode

        public static string GetClientInfoBackupRootPath()
        {
            return Path.Combine(GetClientRootPath(), "Bkup");
        }

        public static string GetClientInfoBackupFilePath()
        {
            return Path.Combine(GetClientInfoBackupRootPath(), ConfigHelper.ClientInfoFileName);
        }

        public static void CopyClientInfoFile(string sourcePath, string destinationPath, bool overwrite)
        {
            File.Copy(sourcePath, destinationPath, overwrite);
        } 

        #endregion
        #endregion

        #region Admin Path Helper Methods

        public static string GetTemplateTargetFolderPath(string templateTargetRootFolderPath, string templateName)
        {
            return  Path.Combine(templateTargetRootFolderPath, templateName.Trim());
        }

        public static string GetTemplateTargetVideoFolderPath(string templateTargetFolderPath, string templateName)
        {
            return Path.Combine(templateTargetFolderPath, GetTemplateVideoFolderName(templateName));
        }

        public static string GetTemplateVideoFolderName(string templateName)
        {
            return string.Format("{0}_LBFVideos", templateName);
        }

        public static string GetRegisteredSchoolPackageTargetRootPath()
        {
            return ConfigHelper.ClientDistributionTargetRootPath;
        }

        public static string GetRegisteredSchoolPackagePath(string schoolCode)
        {
            //return Path.Combine(ConfigHelper.ClientDistributionTargetRootPath, Path.Combine(schoolCode, "Package"));
            return Path.Combine(GetRegisteredSchoolPackageTargetRootPath(), schoolCode);
        }

        public static string GetRegisteredSchoolPackageThumbnailPath(string schoolCode)
        {
            return Path.Combine(GetRegisteredSchoolPackagePath(schoolCode), "Thumbnails");
        }

        public static string GetRegisteredSchoolPackageVideoPath(string schoolCode, string schoolCity)
        {
            return Path.Combine(GetRegisteredSchoolPackagePath(schoolCode), GetClientVideoFolderName(schoolCode, schoolCity));
        }

        public static string NewRegisteredSchoolInfoFilePath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "ClientRegistrationData");
        }

        public static string GetMemoNumberFilePath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), MemoNumberFileName());
        }

        public static string MemoNumberFileName()
        {
            return "LBFVideoLibMemoNumber.txt";
        }

        public static string GetClientVideoFolderName(string schoolCode, string schoolCity)
        {
            return string.Format("{0}_{1}_{2}", schoolCode, schoolCity, "LBFVideos");
        }



        //// This path is use to create client package during registration from admin form.
        //public static string GetRegisteredClientDistributionRootPath(string schoolCode)
        //{

        //    //  return Directory.GetCurrentDirectory();
        //    Path.Combine(ConfigHelper.ClientDistributionTargetRootPath 
        //    return @"C:\LBFSetup\Registration\ClientPackages\786\Package";
        //}

        #endregion

        #region Message String Helper

        public static string GetContactMessageString()
        {
            return "In case of any query, feedback or if you forgot your password Please Contact info@lbf.in or call 91091 38808";
        }

        public static string GetSessionString(string sessionString)
        {
            return string.Format("Session : {0}", sessionString);
        }

        public static string GetWelcomeString(string schoolName, string schoolCity, string schoolCode)
        {
            string registeredSchoolTitle = GetRegisteredSchoolTitleString(schoolName, schoolCity, schoolCode);
            return string.Format("Welcome, {0}", registeredSchoolTitle);
        }

        public static string GetRegisteredSchoolTitleString(string schoolName, string schoolCity, string schoolCode)
        {
            return string.Format("{0}, {1}, [{2}]", schoolName, schoolCity, schoolCode);
        }

        public static string GetExpiryDateString(DateTime expiryDate)
        {
            return string.Format("Expires on {0}", expiryDate.ToString("dd MMMM yyyy"));
        }

        public static string GetSubjectThumbnailSourcePath()
        {
            return Path.Combine(ConfigHelper.ClientDistributionPath, "Thumbnails");
        }

        public static string GetDemoVideoSourcePath()
        {
            return Path.Combine(ConfigHelper.ClientDistributionPath, "DemoVideos");
        }


        #endregion
    }
}
