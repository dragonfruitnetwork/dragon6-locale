$VERSION = Get-Date -UFormat "%Y.%m.%d"
$NUGET_KEY = $env:NUGET_KEY
$WORKINGDIR = Get-Location
$SOURCE = "NuGet"

nuget sources add -Name NuGet -Source "https://api.nuget.org/v3/index.json" -UserName "xxx" -Password $NUGET_KEY

dotnet restore ".\DragonFruit.Six.Locale.sln"
dotnet pack ".\DragonFruit.Six.Locale\DragonFruit.Six.Locale.csproj" -o $WORKINGDIR -c Release -p:PackageVersion="$VERSION.$env:TRAVIS_BUILD_NUMBER"

Get-ChildItem -Path $WORKINGDIR -Filter *.nupkg -Recurse -File -Name | ForEach-Object {
    nuget push $_ -ApiKey $NUGET_KEY -Source $NUGET_SOURCE -Verbosity detailed 
}
