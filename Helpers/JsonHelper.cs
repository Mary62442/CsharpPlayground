using BlMusic.Classes;
using Newtonsoft.Json;
using System;


namespace Helpers
{
    public static class JsonHelper
    {
        public static string ConvertToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static object ConvertToObjectFromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject(jsonData, typeof(Musician), new JsonSerializerSettings(){TypeNameHandling = TypeNameHandling.Objects});
        }

    }
}
