$VERSION = Get-Date -UFormat "%Y.%m.%d"
$TRAVIS_NO = $env:TRAVIS_BUILD_NUMBER
$NUGET = $env:NUGET_KEY

dotnet restore ".\DragonFruit.Six.Locale.sln"
dotnet pack ".\DragonFruit.Six.Locale\DragonFruit.Six.Locale.csproj" -o .\ -c Release -p:PackageVersion="$VERSION.$TRAVIS_NO"
dotnet push .\*.nupkg -k $NUGET -s "https://api.nuget.org/v3/index.json"