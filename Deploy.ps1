$VERSION = Get-Date -UFormat "%Y.%m.%d"
$NUGET_KEY = $env:NUGET_KEY
$WORKINGDIR = Get-Location

dotnet restore ".\DragonFruit.Six.Locale.sln"
dotnet pack ".\DragonFruit.Six.Locale\DragonFruit.Six.Locale.csproj" -o $WORKINGDIR -c Release -p:PackageVersion="$VERSION.$env:TRAVIS_BUILD_NUMBER"

Get-ChildItem -Path $WORKINGDIR -Filter *.nupkg -Recurse -File -Name | ForEach-Object {
    dotnet nuget push $_ --api-key $NUGET_KEY --source https://api.nuget.org/v3/index.json --force-english-output
}
