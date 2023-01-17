using Crack.xSource.Zip;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace vxzip
{
    internal static class ZipApp
    {
        internal static void ConfigureLogger()
        {
            var config = new LoggingConfiguration();

            // Console target
            var consoleTarget = new ColoredConsoleTarget();
            consoleTarget.Layout = "${longdate}|${level:uppercase=true}|${message}${onexception:${newline}${exception:maxInnerExceptionLevel=10:format=shortType,message}}";

            consoleTarget.UseDefaultRowHighlightingRules = false;

            // Define row highlighting rules for different log levels
            var highlightRuleTrace = new ConsoleRowHighlightingRule("level == LogLevel.Trace", ConsoleOutputColor.DarkGray, ConsoleOutputColor.NoChange);
            var highlightRuleDebug = new ConsoleRowHighlightingRule("level == LogLevel.Debug", ConsoleOutputColor.Gray, ConsoleOutputColor.NoChange);
            var highlightRuleInfo = new ConsoleRowHighlightingRule("level == LogLevel.Info", ConsoleOutputColor.White, ConsoleOutputColor.NoChange);
            var highlightRuleWarn = new ConsoleRowHighlightingRule("level == LogLevel.Warn", ConsoleOutputColor.Yellow, ConsoleOutputColor.NoChange);
            var highlightRuleError = new ConsoleRowHighlightingRule("level == LogLevel.Error", ConsoleOutputColor.Red, ConsoleOutputColor.NoChange);
            var highlightRuleFatal = new ConsoleRowHighlightingRule("level == LogLevel.Fatal", ConsoleOutputColor.Red, ConsoleOutputColor.Yellow);

            consoleTarget.RowHighlightingRules.Add(highlightRuleTrace);
            consoleTarget.RowHighlightingRules.Add(highlightRuleDebug);
            consoleTarget.RowHighlightingRules.Add(highlightRuleInfo);
            consoleTarget.RowHighlightingRules.Add(highlightRuleWarn);
            consoleTarget.RowHighlightingRules.Add(highlightRuleError);
            consoleTarget.RowHighlightingRules.Add(highlightRuleFatal);

            // Add console target to the configuration
            config.AddTarget("console", consoleTarget);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, consoleTarget));

            // Apply the configuration
            LogManager.Configuration = config;
        }
        internal static void CreateZip(CreateOptions? ops)
        {
            ConfigureLogger();

            try
            {
                XZP2File.Create(ops.ZipPath, ops.WorkingDirectory);
            }
            catch (Exception e)
            {
                LogManager.GetCurrentClassLogger().Error(e);
            }
        }

        internal static void ExtractZip(ExtractOptions? ops)
        {
            ConfigureLogger();
            try
            {
                new XZP2File(ops.ZipPath).ExtractWildCard(ops.WorkingDirectory, ops.SearchPattern);
            }
            catch (Exception e)
            {
                LogManager.GetCurrentClassLogger().Error(e);
            }
        }
    }
}
