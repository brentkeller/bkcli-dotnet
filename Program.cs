using Bkcli.Commands;
using Spectre.Console.Cli;

var app = new CommandApp();
app.Configure(config =>
{
  config.AddBranch("go", go =>
  {
    go.AddCommand<GoListCommand>("list");
  });
  config.AddCommand<ImportCommand>("import");
});

return app.Run(args);
