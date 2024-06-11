
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

# Publishing the app

The app can be built for publication using `dotnet publish -c Release`. A helper script `publish.ps1` has been written to streamline creating a publish build and copying it to a directory registered on the `PATH` environment variable.

# Prior Art

I ran into some hangups with the `go` feature and the idea for outputting the shortcut path for use via shell scripts was inspired by [golumbus](https://github.com/jverhoelen/golumbus) by [Jonas Verhoelen](https://github.com/jverhoelen).
