using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Common
{
    public abstract class Loggable<T>
    {
        protected ILogger<T> Logger { get; }

        protected Loggable(ILogger<T> logger)
        {
            Logger = logger;
        }
    }
}
