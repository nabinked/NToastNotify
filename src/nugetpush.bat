echo off
echo "%*"
npm install
npm build
dotnet pack -o temp-pack
IF NOT "%nugetApiKey"=="" (
	nuget push "%2" %nugetApiKey% -source "nuget.org"    
)
rd temp-pack /s
exit 0;