﻿using Bkcli.Commands;
using Spectre.Console.Cli;

var app = new CommandApp();
app.Configure(config =>
{
  config.AddBranch("go", go =>
  {
    go.AddCommand<GoAddCommand>("add");
    go.AddCommand<GoListCommand>("list");
    go.AddCommand<GoToCommand>("to");
  });
  config.AddCommand<ImportCommand>("import");
});

return app.Run(args);
