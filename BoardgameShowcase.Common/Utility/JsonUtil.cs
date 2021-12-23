using System.Text.Json.Serialization;
using System.Text.Json;

namespace BoardgameShowcase.Common.Utility
{
    public static class JsonUtil
    {
        public static T DeserialiseWithStringEnum<T>(string filename) where T : new()
        {
            using FileStream stream = File.OpenRead(filename);
            
            JsonSerializerOptions options = new();
            options.Converters.Add(new JsonStringEnumConverter());
            
            return JsonSerializer.Deserialize<T>(stream, options) ?? new();
        }
    }
}
