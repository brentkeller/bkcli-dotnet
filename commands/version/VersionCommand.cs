using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics;
using System.Reflection;

namespace Bkcli.Commands
{
    public class VersionCommand : Command<VersionCommand.Settings>
    {
        public class Settings : CommandSettings { }

        public override int Execute(CommandContext context, Settings settings)
        {
            var version = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "unknown";
            var targetFramework = Assembly.GetEntryAssembly()?
                .GetCustomAttributes(typeof(System.Runtime.Versioning.TargetFrameworkAttribute), false)
                .OfType<System.Runtime.Versioning.TargetFrameworkAttribute>()
                .FirstOrDefault()?.FrameworkName ?? "unknown";

            string gitHash = "unknown";
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "git",
                    Arguments = "rev-parse --short HEAD",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using var process = Process.Start(psi);
                gitHash = process?.StandardOutput.ReadLine()?.Trim() ?? "unknown";
            }
            catch { }

            AnsiConsole.MarkupLine($"[yellow]bkcli version:[/] [green]{version}[/]");
            AnsiConsole.MarkupLine($"[yellow]Target .NET:[/] [green]{targetFramework}[/]");
            AnsiConsole.MarkupLine($"[yellow]Git commit:[/] [green]{gitHash}[/]");
            return 0;
        }
    }
}
