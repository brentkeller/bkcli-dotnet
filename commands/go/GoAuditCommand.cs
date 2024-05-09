using System.ComponentModel;
using Bkcli.Services;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Bkcli.Commands
{
  public class GoAuditCommand : Command<GoAuditCommand.Settings>
  {
    public class Settings : CommandSettings
    {
      [CommandOption("-c")]
      [Description("Remove shortcuts whose path does not exist")]
      public bool? Clean { get; set; }
    }

    readonly ShortcutService ShortcutService = new();

    public override int Execute(CommandContext context, Settings settings)
    {
      var badShortcuts = ShortcutService.Shortcuts
        .Where(x => !Directory.Exists(x.Value))
        .ToList();

      if (badShortcuts.Count == 0)
      {
        AnsiConsole.WriteLine("All shortcuts are valid!");
      }
      else
      {
        AnsiConsole.WriteLine("Found these invalid shortcuts:");
        var grid = new Grid();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddRow(new string[] { "Name", "Path" });
        foreach (var item in badShortcuts.OrderBy(x => x.Key))
        {
          grid.AddRow(new string[] { item.Key, item.Value });
        }
        AnsiConsole.Write(grid);
        if (settings.Clean.GetValueOrDefault())
        {
          foreach (var shortcut in badShortcuts)
          {
            AnsiConsole.WriteLine(ShortcutService.RemoveShortcut(shortcut.Key));
          }
        }
      }
      return 0;
    }
  }
}
