using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;

namespace NewtonsoftJsonHelper
{
    // reference: https://stackoverflow.com/questions/15510742/newtonsoft-json-deserializing-base64-image-fails
    public class JsonImageConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Bitmap);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string value = reader.Value as string;

            if (value == null)
            {
                return null;
            }

            var m = new MemoryStream(Convert.FromBase64String(value));
            return (Bitmap)Bitmap.FromStream(m);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Bitmap bmp = (Bitmap)value;
            MemoryStream m = new MemoryStream();
            bmp.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);

            writer.WriteValue(Convert.ToBase64String(m.ToArray()));
        }
    }
}
