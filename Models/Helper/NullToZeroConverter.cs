using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Models.Helper
{
    public class NullToZeroConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // This converter will be applied to all numeric types
            return typeof(int).IsAssignableFrom(objectType) ||
                   typeof(double).IsAssignableFrom(objectType) ||
                   typeof(float).IsAssignableFrom(objectType) ||
                   typeof(decimal).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load the JSON value and check if it's null
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Null)
            {
                // If it's null, return zero
                return 0;
            }

            // If it's not null, let Newtonsoft.Json handle the deserialization
            return token.ToObject(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Writing JSON is not necessary for this converter, so the implementation is omitted.
        }
    }
}