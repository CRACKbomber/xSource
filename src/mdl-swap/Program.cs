

using mdl_swap;
using NLog;
using NLog.Config;
using NLog.Targets;

#region Setup Logger
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

if (args.Length != 2)
{
    Console.WriteLine("Usage: Xbox2PC <source_folder> <destination_folder>");
    return;
}
string sourceFolder = args[0];
string destinationFolder = args[1];
// Check if the source folder exists
if (!Directory.Exists(sourceFolder))
{
    Console.WriteLine($"Source folder '{sourceFolder}' does not exist.");
    return;
}

// Create the destination folder if it doesn't exist
if (!Directory.Exists(destinationFolder))
    Directory.CreateDirectory(destinationFolder);

foreach (string file in Directory.EnumerateFiles(sourceFolder))
{
    var fileExt = Path.GetExtension(file).ToLower();

    switch (fileExt)
    {
        case ".mdl":
            SwapApp.SwapMDL(file, file + ".conv");
            break;
    }
}

