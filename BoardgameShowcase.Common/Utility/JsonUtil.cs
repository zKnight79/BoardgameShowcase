using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Common.Utility
{
    public static class JsonUtil
    {
        public static T DeserialiseWithStringEnum<T>(string filename, ILogger? logger = null) where T : new()
        {
            T? result = default;

            try
            {
                logger?.LogDebug($"Try deserializing `{filename}` ...");
                
                using FileStream stream = File.OpenRead(filename);

                JsonSerializerOptions options = new();
                options.Converters.Add(new JsonStringEnumConverter());

                result = JsonSerializer.Deserialize<T>(stream, options);
                if (result is null)
                {
                    logger?.LogWarning($"`{filename}` deserialization returned nothing");
                }
                else
                {
                    logger?.LogDebug($"`{filename}` deserialization done successfully");
                }
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, $"An error occured during deserialization of `{filename}`");
            }

            return result ?? new();
        }
    }
}
