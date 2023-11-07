using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Models.Helper
{
    public class JsonHelper
    {
        public static string ToJSON(object obj)
        {
            return JsonConvert.SerializeObject(obj, new JavaScriptDateTimeConverter());
        }

        public static string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string SerializeObjectCamelCase(object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }


        public static T DeserializeObject<T>(string value)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            catch
            {
                return default(T);
            }

        }


        public static T DeserializeCamelCase<T>(string value)
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            return JsonConvert.DeserializeObject<T>(value, jsonSerializerSettings);
        }

        public static object DeserializeObject(string value, string type)
        {
            return JsonConvert.DeserializeObject(value, Type.GetType(type));
        }

        public static object DeserializeObject(string value, Type type)
        {
            return JsonConvert.DeserializeObject(value, type);
        }

        public static T DeserializeObjectWithNull<T>(string value)
        {
            try
            {
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new NullToZeroConverter());
                return JsonConvert.DeserializeObject<T>(value, settings);
            }
            catch
            {
                return default(T);
            }

        }
    }
}
