using System.ComponentModel;
using Bkcli.Services;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Bkcli.Commands
{
  public class GoRemoveCommand : Command<GoRemoveCommand.Settings>
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
      AnsiConsole.WriteLine(ShortcutService.RemoveShortcut(settings.Name));
      return 0;
    }
  }
}
