using Bkcli.Commands;
using Spectre.Console.Cli;

var app = new CommandApp();
app.Configure(config =>
{
  config.AddCommand<ImportCommand>("import");
});

return app.Run(args);
