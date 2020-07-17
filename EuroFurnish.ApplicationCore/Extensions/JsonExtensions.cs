using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EuroFurnish.ApplicationCore.Extensions
{
    public static class JsonExtensions
    {
        private static JsonSerializerSettings SetJsonOptions()
        {
            return new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-ddTHH:mm:ssZ",
                Formatting = Formatting.Indented,
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };
          
        }
       

        public static JsonSerializerSettings SettJsonSerializerSettings(this JsonSerializerSettings jsonSerializer)
        {
            jsonSerializer = SetJsonOptions();
            return jsonSerializer;
        }

        public static T FromJson<T>(this string json) => JsonConvert.DeserializeObject<T>(json, SetJsonOptions());


        public static string ToJson<T>(this T obj) => JsonConvert.SerializeObject(obj, SetJsonOptions());
    }
}
