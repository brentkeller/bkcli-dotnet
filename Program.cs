using Bkcli.Commands;
using Spectre.Console.Cli;

// Check for --version or -v flag before running the app
if (args.Contains("--version") || args.Contains("-v"))
{
    var versionCmd = new Bkcli.Commands.VersionCommand();
    versionCmd.Execute(null!, new Bkcli.Commands.VersionCommand.Settings());
    return 0;
}

var app = new CommandApp();
app.Configure(config =>
{
  config.AddBranch("go", go =>
  {
    go.AddCommand<GoAddCommand>("add");
    go.AddCommand<GoAuditCommand>("audit");
    go.AddCommand<GoListCommand>("list");
    go.AddCommand<GoRemoveCommand>("remove");
    go.AddCommand<GoToCommand>("to");
  });
  config.AddCommand<ExportCommand>("export");
  config.AddCommand<ImportCommand>("import");
});

return app.Run(args);
