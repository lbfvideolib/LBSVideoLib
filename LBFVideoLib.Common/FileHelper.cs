using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LBFVideoLib.Common
{
    public class FileHelper
    {
        // Delete file
        public static void DeleteFile(string filePath)
        {
            System.IO.File.Delete(filePath);
        }

        public static void CreateFile(string filePath, string content)
        {
            //write string to file
            System.IO.File.WriteAllText(@filePath, content);
        }
    }
}
