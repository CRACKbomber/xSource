
#region Setup Logger
using CommandLine;
using NLog;
using NLog.Config;
using NLog.Targets;
using vxzip;

var config = new LoggingConfiguration();

var consoleTarget = new ColoredConsoleTarget
{
    Name = "console",
    Layout = "${date:format=HH\\:mm\\:ss} ${level:uppercase=true} ${message}",
    UseDefaultRowHighlightingRules = false,
};

// colored outputs
consoleTarget.RowHighlightingRules.Add(
    new ConsoleRowHighlightingRule
    {
        Condition = "level == LogLevel.Trace",
        ForegroundColor = ConsoleOutputColor.DarkGray,
        BackgroundColor = ConsoleOutputColor.Black
    });
consoleTarget.RowHighlightingRules.Add(
    new ConsoleRowHighlightingRule
    {
        Condition = "level == LogLevel.Info",
        ForegroundColor = ConsoleOutputColor.Green
    });
consoleTarget.RowHighlightingRules.Add(
    new ConsoleRowHighlightingRule
    {
        Condition = "level == LogLevel.Warn",
        ForegroundColor = ConsoleOutputColor.Yellow
    }
    );
consoleTarget.RowHighlightingRules.Add(
    new ConsoleRowHighlightingRule
    {
        Condition = "level == LogLevel.Error",
        ForegroundColor = ConsoleOutputColor.Red
    });
consoleTarget.RowHighlightingRules.Add(
    new ConsoleRowHighlightingRule
    {
        Condition = "level == LogLevel.Fatal",
        ForegroundColor = ConsoleOutputColor.White,
        BackgroundColor = ConsoleOutputColor.Red
    });
config.AddTarget(consoleTarget);
config.AddRuleForAllLevels(consoleTarget);

LogManager.Configuration = config;
#endregion

#region Argument Parsing
var parsedArgs = Parser.Default.ParseArguments<ExtractOptions, CreateOptions>(args);

parsedArgs.WithParsed(options =>
{
    if (options is ExtractOptions)
        ZipApp.ExtractZip(options as ExtractOptions);
    else if (options is CreateOptions)
        ZipApp.CreateZip(options as CreateOptions);
});
//.WithNotParsed(errs => Console.WriteLine(HelpText.AutoBuild(parsedArgs)));

#endregion
