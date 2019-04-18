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
            switch (className.ToLower())
            {
                case "class pg":
                    return 1;
                case "class nur":
                    return 2;
                case "class kg1":
                    return 3;
                case "class kg2":
                    return 4;
                case "class 1":
                    return 5;
                case "class 2":
                    return 6;
                case "class 3":
                    return 7;
                case "class 4":
                    return 8;
                case "class 5":
                    return 9;
                default:
                    return -1;
            }
        }

        public static string GetVersionNo()
        {
            return "Version 2.0";
        }
    }
}
