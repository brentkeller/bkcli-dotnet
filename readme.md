
# Personal tools CLI

## `Go`
A shortcut system for storing bookmarks to specific directories. See the [Go readme](/commands/go/readme.md)


# Running the app

Development

`dotnet run [command] [args]`

If you need to pass command switches that conflict with `dotnet run` you can call the arguments after `--`

examples:
`dotnet run go`
`dotnet run import "C:\dev\data.json"`
`dotnet run -- go audit -c`

