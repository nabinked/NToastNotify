echo off
echo "%*"
IF "%1"=="Debug" (
    IF NOT "%mygetApiKey"=="" (
        nuget push "%2" %mygetApiKey% -source "myget-nabin"
    )
)
IF "%1"=="Release" (
    IF NOT "%mygetApiKey"=="" (
    nuget push "%2" %nugetApiKey% -source "nuget.org"    
    )    
)
exit 0;