using BoardgameShowcase.Common.Utility;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace BoardgameShowcase.Common.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="ILogger"/>
    /// </summary>
    public static partial class LoggerExtensions
    {
        private const int BASE_EVENT_ID = 42000000;

        [LoggerMessage(
            EventId = BASE_EVENT_ID + 1,
            Message = "{methodName}({args})"
        )]
        private static partial void LogMethodCall(this ILogger logger, LogLevel logLevel, string methodName, string? args);

        /// <summary>
        /// Log the caller method name, with optionnaly provided argument values.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> used to write the log message.</param>
        /// <param name="args">The arguments to write in the method call log message.</param>
        /// <param name="logLevel">The <see cref="LogLevel"/> of the message, <see cref="LogLevel.Debug"/> if not set.</param>
        /// <param name="callerMemberName">The name of the caller method, automatically provided if not set.</param>
        public static void LogMethodCall(this ILogger logger, IEnumerable<object> args, LogLevel logLevel = LogLevel.Debug, [CallerMemberName] string callerMemberName = "")
        {
            logger.LogMethodCall(logLevel, callerMemberName, args?.JoinAsString(", "));
        }

        /// <summary>
        /// Log the caller method name, with optionnaly provided argument values.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> used to write the log message.</param>
        /// <param name="arg0">The 1st argument to write in the method call log message.</param>
        /// <param name="arg1">The 2nd argument to write in the method call log message.</param>
        /// <param name="arg2">The 3rd argument to write in the method call log message.</param>
        /// <param name="arg3">The 4th argument to write in the method call log message.</param>
        /// <param name="arg4">The 5th argument to write in the method call log message.</param>
        /// <param name="arg5">The 6th argument to write in the method call log message.</param>
        /// <param name="arg6">The 7th argument to write in the method call log message.</param>
        /// <param name="arg7">The 8th argument to write in the method call log message.</param>
        /// <param name="arg8">The 9th argument to write in the method call log message.</param>
        /// <param name="arg9">The 10th argument to write in the method call log message.</param>
        /// <param name="logLevel">The <see cref="LogLevel"/> of the message, <see cref="LogLevel.Debug"/> if not set.</param>
        /// <param name="callerMemberName">The name of the caller method, automatically provided if not set.</param>
        public static void LogMethodCall(this ILogger logger,
                                                 object? arg0 = null,
                                                 object? arg1 = null,
                                                 object? arg2 = null,
                                                 object? arg3 = null,
                                                 object? arg4 = null,
                                                 object? arg5 = null,
                                                 object? arg6 = null,
                                                 object? arg7 = null,
                                                 object? arg8 = null,
                                                 object? arg9 = null,
                                                 LogLevel logLevel = LogLevel.Debug,
                                                 [CallerMemberName] string callerMemberName = "")
        {
            
            IEnumerable<object> args = EnumerableUtil.From(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            logger.LogMethodCall(args, logLevel, callerMemberName);
        }
    }
}
