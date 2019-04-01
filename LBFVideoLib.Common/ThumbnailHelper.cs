using System.IO;

namespace LBFVideoLib.Common
{
    public class ThumbnailHelper
    {
        const string Class1String = "class 1";
        const string Class2String = "class 2";
        const string Class3String = "class 3";
        const string Class4String = "class 4";
        const string Class5String = "class 5";

        const string EnglishSubjectString = "english";
        const string HindiSubjectString = "hindi";
        const string EVSSubjectString = "evs";
        const string MathsSubjectString = "maths";
        const string GKSubjectString = "gk";

        public static string GetThumbnailFileName(string thumbnailDirectoryPath, string classString, string subjectString)
        {
            string subject = "", onlySubjectThumbnail = "";
            if (subjectString.ToLower().Contains(EnglishSubjectString))
            {
                subject = EnglishSubjectString;
                onlySubjectThumbnail = "Subjects_English.png";
            }
            else if (subjectString.ToLower().Contains(HindiSubjectString))
            {
                //return "Subjects_Hindi.png";
                subject = HindiSubjectString;
                onlySubjectThumbnail = "Subjects_Hindi.png";
            }
            else if (subjectString.ToLower().Contains(EVSSubjectString))
            {
                subject = EVSSubjectString;
                onlySubjectThumbnail = "Subjects_EVS.png";
                //return "Subjects_EVS.png";
            }
            else if (subjectString.ToLower().Contains(MathsSubjectString))
            {
                subject = MathsSubjectString;
                onlySubjectThumbnail = "Subjects_Maths";  //return "Subjects_Maths.png";
            }
            else if (subjectString.ToLower().Contains(GKSubjectString))
            {
                subject = GKSubjectString;
                onlySubjectThumbnail = "default.jpg";
            }
            else
            {
                return "default.jpg";
            }
            string expectedThumbnailName = string.Format("{0}_{1}.jpg", classString.ToLower(), subject);

            if (File.Exists(Path.Combine(thumbnailDirectoryPath, expectedThumbnailName)))
            {
                return expectedThumbnailName;
            }
            else
            {
                return onlySubjectThumbnail;
            }

            //if (Class1String.ToLower().Contains(classString) && EnglishSubjectString.ToLower().Contains(subjectString))
            //{
            //    return "English Cover Class 1st.jpg";
            //}
            //if (Class2String.ToLower().Contains(classString) && EnglishSubjectString.ToLower().Contains(subjectString))
            //{
            //    return "English Cover Class 2nd.jpg";
            //}
            //if (Class3String.ToLower().Contains(classString) && EnglishSubjectString.ToLower().Contains(subjectString))
            //{
            //    return "English Cover Class 3rd.jpg";
            //}
            //if (Class4String.ToLower().Contains(classString) && EnglishSubjectString.ToLower().Contains(subjectString))
            //{
            //    return "English Cover Class 4th.jpg";
            //}
            //else if (Class5String.ToLower().Contains(classString) && EnglishSubjectString.ToLower().Contains(subjectString))
            //{
            //    return "English Cover Class 5th.jpg";
            //}

            //else if (Class1String.ToLower().Contains(classString) && HindiSubjectString.ToLower().Contains(subjectString))
            //{
            //    return "Hindi Cover Class 1st.jpg";
            //}
            //if (Class2String.ToLower().Contains(classString) && HindiSubjectString.ToLower().Contains(subjectString))
            //{
            //    return "Hindi Cover Class 2nd.jpg";
            //}
            //if (Class3String.ToLower().Contains(classString) && HindiSubjectString.ToLower().Contains(subjectString))
            //{
            //    return "Hindi Cover Class 3rd.jpg";
            //}
            //if (Class4String.ToLower().Contains(classString) && HindiSubjectString.ToLower().Contains(subjectString))
            //{
            //    return "Hindi Cover Class 4th.jpg";
            //}
            //else if (Class5String.ToLower().Contains(classString) && HindiSubjectString.ToLower().Contains(subjectString))
            //{
            //    return "Hindi Cover Class 5th.jpg";
            //}

            //  if (subjectString.ToLower().Contains(EnglishSubjectString))
            //{
            //    return "Subjects_English.png";
            //}
            //else if (subjectString.ToLower().Contains(HindiSubjectString))
            //{
            //    return "Subjects_Hindi.png";
            //}
            //else if (subjectString.ToLower().Contains(EVSSubjectString))
            //{
            //    return "Subjects_EVS.png";
            //}
            //else if (subjectString.ToLower().Contains(MathsSubjectString))
            //{
            //    return "Subjects_Maths.png";
            //}
            //return "Subjects_English.png";
        }

        // Nitin Start 03-Sep

        public static string GetThumbnailDirectoryPathByVideoPath(string videoFilePath)
        {
            return Path.Combine(Path.GetDirectoryName(videoFilePath), "Thumbnail");
        }

        public static string GetThumbnailFilePathByVideoPath(string videoFilePath)
        {
            string thumbnailDirectoryPath = GetThumbnailDirectoryPathByVideoPath(videoFilePath);
            return Path.Combine(thumbnailDirectoryPath, Directory.GetFiles(thumbnailDirectoryPath)[0]);
        }

        public static string GetThumbnailFileNameByVideoPath(string videoFilePath)
        {
            string thumbnailDirectoryPath = GetThumbnailDirectoryPathByVideoPath(videoFilePath);
            return Path.GetFileName(Directory.GetFiles(thumbnailDirectoryPath)[0]);
        }
        // Nitin End 03-Sep
    }
}
