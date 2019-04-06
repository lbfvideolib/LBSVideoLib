using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LBFVideoLib.Common
{
    public static class CommonHelper
    {
        public static int GetClassSortOrder(string className)
        {
            switch (className)
            {
                case "Class PG":
                    return 1;
                case "Class Nur":
                    return 2;
                case "Class KG1":
                    return 3;
                case "Class KG2":
                    return 4;
                case "Class 1":
                    return 5;
                case "Class 2":
                    return 6;
                case "Class 3":
                    return 7;
                case "Class 4":
                    return 8;
                case "Class 5":
                    return 9;
                default:
                    return 0;
            }
        }
    }
}
