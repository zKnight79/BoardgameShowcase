using BoardgameShowcase.Common.Utility;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace BoardgameShowcase.Common.Extensions
{
    public static partial class LoggerExtensions
    {
        private const int BASE_EVENT_ID = 42000000;

        [LoggerMessage(
            EventId = BASE_EVENT_ID + 1,
            Message = "{methodName}({args})"
        )]
        private static partial void LogMethodCall(this ILogger logger, LogLevel logLevel, string methodName, string? args);
        public static void LogMethodCall(this ILogger logger, IEnumerable<object> args, LogLevel logLevel = LogLevel.Debug, [CallerMemberName] string callerMemberName = "")
        {
            logger.LogMethodCall(logLevel, callerMemberName, args?.JoinAsString(", "));
        }
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
