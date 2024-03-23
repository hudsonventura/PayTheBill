using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace ClickUp.Utils;

internal class UnixTimeConverter : DateTimeConverterBase
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (!(value is DateTime))
        {
            throw new ArgumentException("Expect DateTime as input parameter");
        }


        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        long value2 = (long)((((DateTime)value).ToUniversalTime() - dateTime).TotalSeconds) * 1000;
        writer.WriteValue(value2);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        long result;
        switch (reader.TokenType)
        {
            case JsonToken.Integer:
                result = Convert.ToInt64(reader.Value);
                break;
            case JsonToken.String:
                if (!long.TryParse(reader.Value!.ToString().Substring(0, 10).ToString(), out result))
                {
                    throw new ArgumentException($"{reader.Value} isn't a number");
                }

                break;
            case JsonToken.Null:
                return null;
            default:
                throw new ArgumentException($"Unexpected token. Integer or String was expected, got {reader.TokenType}");
        }

        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(result);
        return dateTime;
    }
}
