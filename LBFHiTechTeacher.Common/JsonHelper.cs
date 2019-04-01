using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LBFVideoLib.Common
{
   public  class JsonHelper
    {
        public static Object ParseJsonToObject<T>(string jsonString)
        {
           return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static string ParseObjectToJSON<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

    }
}
