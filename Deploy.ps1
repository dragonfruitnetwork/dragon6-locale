$VERSION = Get-Date -UFormat "%Y.%m.%d"
$NUGET_SOURCE = "https://api.nuget.org/v3/index.json"
$WORKINGDIR = Get-Location

dotnet restore ".\DragonFruit.Six.Locale.sln"
dotnet pack ".\DragonFruit.Six.Locale\DragonFruit.Six.Locale.csproj" -o $WORKINGDIR -c Release -p:PackageVersion="$VERSION.$env:TRAVIS_BUILD_NUMBER"

Get-ChildItem -Path $WORKINGDIR -Filter *.nupkg -Recurse -File -Name | ForEach-Object {
    nuget push $_ $env:NUGET_KEY -Source $NUGET_SOURCE -Verbosity detailed 
}
