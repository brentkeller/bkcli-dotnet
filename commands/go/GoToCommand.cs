using System.ComponentModel;
using Bkcli.Services;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Bkcli.Commands
{
  public class GoToCommand : Command<GoToCommand.Settings>
  {
    public class Settings : CommandSettings
    {
      [CommandArgument(0, "<Name>")]
      [Description("Name of the shortcut")]
      public string Name { get; set; } = "";
    }

    readonly ShortcutService ShortcutService = new();

    public override int Execute(CommandContext context, Settings settings)
    {
      var shortcuts = ShortcutService.Shortcuts;
      var path = shortcuts.TryGetValue(settings.Name, out string? value) ? value : ".";
      AnsiConsole.Write(path);
      return 0;
    }
  }
}
