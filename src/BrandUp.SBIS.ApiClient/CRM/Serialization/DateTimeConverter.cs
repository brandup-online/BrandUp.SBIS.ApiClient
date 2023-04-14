using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.CRM.Serialization
{
    internal class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (!reader.TryGetDateTime(out var dateTime))
            {
                var str = Encoding.UTF8.GetString(reader.ValueSpan);
                str = str.Replace("\\u002B", "+");
                if (!DateTime.TryParseExact(str, "yyyy-MM-dd hh:mm:ss.ffffffzz", null, DateTimeStyles.AdjustToUniversal, out dateTime))
                {
                    throw new NotSupportedException();
                }
            }
            return dateTime;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteRawValue(value.ToShortTimeString());
        }
    }
}
