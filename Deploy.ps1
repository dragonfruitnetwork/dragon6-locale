$VERSION = Get-Date -UFormat "%Y.%m.%d"
$NUGET_SOURCE = "https://api.nuget.org/v3/index.json"
$WORKINGDIR = Get-Location

dotnet restore ".\DragonFruit.Six.Locale.sln"
dotnet pack ".\DragonFruit.Six.Locale\DragonFruit.Six.Locale.csproj" -o $WORKINGDIR -c Release -p:PackageVersion="$VERSION.$env:TRAVIS_BUILD_NUMBER"

nuget setApiKey $env:NUGET_KEY -Source "api.nuget.org"
nuget setApiKey $env:NUGET_KEY -Source "www.nuget.org"
nuget setApiKey $env:NUGET_KEY -Source "nuget.org"

Get-ChildItem -Path $WORKINGDIR -Filter *.nupkg -Recurse -File -Name | ForEach-Object {
    nuget push $_ -Source $NUGET_SOURCE -SkipDuplicate -NoSymbols
}
