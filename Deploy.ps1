$VERSION = Get-Date -UFormat "%Y.%m.%d"
$TRAVIS_NO = $env:TRAVIS_BUILD_NUMBER
$NUGET = $env:NUGET_KEY
$NUGET_SOURCE = "https://api.nuget.org/v3/index.json"

dotnet restore ".\DragonFruit.Six.Locale.sln"
dotnet pack ".\DragonFruit.Six.Locale\DragonFruit.Six.Locale.csproj" -o .\ -c Release -p:PackageVersion="$VERSION.$TRAVIS_NO"

nuget setApiKey $NUGET -Source $NUGET_SOURCE -Verbosity quiet

Get-ChildItem -Path .\ -Filter *.nupkg -Recurse -File -Name | ForEach-Object {
    nuget push $_ -Source $NUGET_SOURCE -SkipDuplicate -NoSymbols
}
