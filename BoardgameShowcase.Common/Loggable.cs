using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Common
{
    /// <summary>
    /// An abstract class that contains an <see cref="ILogger{TCategoryName}"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The type inheriting <see cref="Loggable{T}"/>.
    /// <code>
    /// class SomeLoggableType : Loggable&lt;SomeLoggableType&gt;
    /// </code>
    /// </typeparam>
    public abstract class Loggable<T> where T : Loggable<T>
    {
        /// <summary>
        /// An <see cref="ILogger"/> of the current type instance.
        /// </summary>
        protected ILogger<T> Logger { get; }

        /// <summary>
        /// Initializes the <seealso cref="Logger"/> property.
        /// </summary>
        /// <param name="logger">An <see cref="ILogger"/> instance to set in the <seealso cref="Logger"/> property.</param>
        protected Loggable(ILogger<T> logger)
        {
            Logger = logger;
        }
    }
}
