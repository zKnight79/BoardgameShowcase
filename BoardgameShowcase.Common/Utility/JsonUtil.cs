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
        public static T? DeserializeWithStringEnum<T>(string filename, ILogger? logger = null)
        {
            logger?.LogDebug($"Deserializing `{filename}` ...");

            T? result = default;

            try
            {
                using FileStream stream = File.OpenRead(filename);
                result = DeserializeWithStringEnum<T>(stream, logger);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, $"An error occured during `{filename}` deserialization");
            }

            return result;
        }

        public static T? DeserializeWithStringEnum<T>(Stream? stream, ILogger? logger)
        {
            logger?.LogDebug($"Try deserializing stream ...");

            T? result = default;

            try
            {
                if (stream is null)
                {
                    throw new ArgumentNullException(nameof(stream));
                }
                JsonSerializerOptions options = new();
                options.Converters.Add(new JsonStringEnumConverter());

                result = JsonSerializer.Deserialize<T>(stream, options);
                if (result is null)
                {
                    logger?.LogWarning($"Stream deserialization returned nothing");
                }
                else
                {
                    logger?.LogDebug($"Stream deserialization done successfully");
                }
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "An error occured during stream deserialization");
            }

            return result;
        }
    }
}
