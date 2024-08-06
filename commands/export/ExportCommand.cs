using Bkcli.Services;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Bkcli.Commands
{
  public class ExportCommand : Command<ExportCommand.Settings>
  {
    public class Settings : CommandSettings
    {
      [CommandArgument(0, "<FilePath>")]
      public string FilePath { get; set; } = "";
    }

    public override int Execute(CommandContext context, Settings settings)
    {
      var data = DataService.GetData();

      DataService.SaveData(data, settings.FilePath);

      AnsiConsole.MarkupLine($"[green]App data exported![/]");
      return 0;
    }
  }
}
