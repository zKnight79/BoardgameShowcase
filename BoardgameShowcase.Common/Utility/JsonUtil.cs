using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Common.Utility
{
    /// <summary>
    /// Provides utility methods for Json.
    /// </summary>
    public static class JsonUtil
    {
        /// <summary>
        /// Deserialize a json file where enums are stored as string.
        /// </summary>
        /// <typeparam name="T">The type of the resulting object instance.</typeparam>
        /// <param name="filename">The name (path included) of the json file to deserialize.</param>
        /// <param name="logger">An optional <see cref="ILogger"/> used to write message logs.</param>
        /// <returns>The result of the Json deserialization, or <see cref="null"/> if something went wrong.</returns>
        public static T? DeserialiseWithStringEnum<T>(string filename, ILogger? logger = null)
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

            return result;
        }
    }
}
