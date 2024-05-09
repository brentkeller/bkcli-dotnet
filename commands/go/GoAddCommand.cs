using System.ComponentModel;
using Bkcli.Services;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Bkcli.Commands
{
  public class GoAddCommand : Command<GoAddCommand.Settings>
  {
    public class Settings : CommandSettings
    {
      [CommandArgument(0, "<Name>")]
      [Description("Name of the shortcut")]
      public string Name { get; set; } = "";

      [CommandArgument(1, "[Path]")]
      [Description("Path to the directory")]
      public string Path { get; set; } = "";
    }

    readonly ShortcutService ShortcutService = new();

    public override int Execute(CommandContext context, Settings settings)
    {
      // default to current working directory if no path is provided
      var path = string.IsNullOrWhiteSpace(settings.Path)
        ? Directory.GetCurrentDirectory()
        : settings.Path;
      AnsiConsole.WriteLine(ShortcutService.AddShortcut(settings.Name, path));
      return 0;
    }
  }
}
