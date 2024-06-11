
# Run a publish build

dotnet publish -c Release


# Copy publish files to target directory
$src = ".\bin\Release\net8.0\publish\*"
$dest = "C:\files\tools\bkcli"

$ValidPath = Test-Path -Path $dest

If ($ValidPath -eq $False){
    New-Item -Path $dest -ItemType directory
}

Write-Host "Copying publish files to: $dest"

Copy-Item -Path $src -Recurse -Destination $dest -Force

Write-Host "Finished!"

