npm install
npm run build
dotnet build -c Release
Push-Location ..
dotnet test
Pop-Location 
dotnet pack -c Release --no-build -o .\temp-nuget-pack-folder
if ([string]::IsNullOrEmpty($Env:nugetApiKey)) {
    throw "Nuget api key not found"
}
dotnet nuget push .\temp-nuget-pack-folder\*.nupkg -k $Env:nugetApiKey -s "nuget.org"
Remove-Item .\temp-nuget-pack-folder -r