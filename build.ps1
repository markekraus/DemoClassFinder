Push-Location ./src
if ($IsWindows) {
    dotnet publish --runtime win-x64 --output ../publish
}
if ($IsLinux) {
    dotnet publish --runtime linux-x64 --output ../publish
}
if ($IsMacOS) {
    dotnet publish --runtime osx-x64 --output ../publish
}
Pop-Location