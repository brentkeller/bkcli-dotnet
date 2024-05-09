# `Go` commands

Used to provide shortcuts to working directories in a terminal

## Commands

`bk go add <name> [path]`: Adds a new shortcut with the given `name`. If `path` is empty the current working directory will be used.

`bk go audit`: Checks the shortcuts for invalid directory paths. Passing the `-c` flag will automatically remove any invalid shortcuts.

`bk go list`: Prints a listing of registered shortcut names and paths

`bk go remove <name>`: Removes the shortcut with the given `name`.

`bk go to <name>`: Prints the path for the shortcut with the given `name`. If not found the current directory will be printed (e.g. `.`)  
