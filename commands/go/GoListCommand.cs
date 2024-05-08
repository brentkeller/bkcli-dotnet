using System.ComponentModel;
using Bkcli.Services;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Bkcli.Commands
{
  public class GoListCommand : Command<GoListCommand.Settings>
  {
    public class Settings : CommandSettings
    {
      [CommandOption("-n|--name")]
      [Description("Shortcut name contains <NAME>")]
      public string Name { get; set; } = "";

      [CommandOption("-p|--path")]
      [Description("Shortcut path contains <PATH>")]
      public string Path { get; set; } = "";

    }

    readonly ShortcutService ShortcutService = new();

    public override int Execute(CommandContext context, Settings settings)
    {
      var shortcuts = ShortcutService.Shortcuts.ToList();
      if (!string.IsNullOrWhiteSpace(settings.Name))
        shortcuts = shortcuts.Where(x => x.Key.Contains(settings.Name)).ToList();

      if (!string.IsNullOrWhiteSpace(settings.Path))
        shortcuts = shortcuts.Where(x => x.Value.Contains(settings.Path)).ToList();

      AnsiConsole.WriteLine("Available shortcuts:");
      var grid = new Grid();
      grid.AddColumn();
      grid.AddColumn();
      grid.AddRow(new string[] { "Name", "Path" });
      foreach (var item in shortcuts.OrderBy(x => x.Key))
      {
        grid.AddRow(new string[] { item.Key, item.Value });
      }
      AnsiConsole.Write(grid);
      return 0;
    }
  }
}
