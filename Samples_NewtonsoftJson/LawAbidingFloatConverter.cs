using Newtonsoft.Json;
using System;

namespace NewtonsoftJsonHelper
{
    // reference: https://stackoverflow.com/questions/13274625/how-to-set-custom-jsonserializersettings-for-json-net-in-mvc-4-web-api

    // Sample:
    //LawAbidingFloatConverter floatConverter = new LawAbidingFloatConverter();
    //JsonSerializerSettings settings = new JsonSerializerSettings();
    //settings.Converters.Add(floatConverter);
    //Newtonsoft.Json.JsonConvert.SerializeObject(data, settings);
    public class LawAbidingFloatConverter : JsonConverter
    {
        public override bool CanRead
        {
            get
            {
                return false;
            }
        }
        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var val = value as double? ?? value as float?;
            if (val == null || double.IsNaN((double)val) || double.IsInfinity((double)val))
            {
                writer.WriteNull();
                return;
            }
            writer.WriteValue((double)val);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(double) || objectType == typeof(float);
        }
    }
}
