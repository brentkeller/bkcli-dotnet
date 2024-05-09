using System.Text.Json;
using Bkcli.Models;
using Bkcli.Services;
using Spectre.Console;
using Spectre.Console.Cli;
using Spectre.Console.Json;

namespace Bkcli.Commands
{
  public class ImportCommand : Command<ImportCommand.Settings>
  {
    public class Settings : CommandSettings
    {
      [CommandArgument(0, "<FilePath>")]
      public string FilePath { get; set; } = "";
    }

    public override int Execute(CommandContext context, Settings settings)
    {
      if (!File.Exists(settings.FilePath))
        throw new ApplicationException($"Import file not found: {settings.FilePath}");

      var json = File.ReadAllText(settings.FilePath);
      AnsiConsole.Write(
        new Panel(new JsonText(json))
            .Header("Import data")
            .Collapse()
            .RoundedBorder()
            .BorderColor(Color.Yellow));

      var data = JsonSerializer.Deserialize<AppData>(json) ?? new AppData();

      DataService.SaveData(data);

      AnsiConsole.MarkupLine($"[green]App data imported![/]");
      return 0;
    }
  }
}
