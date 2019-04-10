using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieCore.Helpers
{
    public class JsonMovieHelper
    {
        public static T DeserializeJson<T>(string jsonString)
        {
            if (!String.IsNullOrEmpty(jsonString))
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
                catch
                {
                    return default(T);
                }
            }

            return default(T);

        }
    }
}
