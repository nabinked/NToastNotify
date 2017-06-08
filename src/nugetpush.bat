echo off
echo "%*"
IF "%1"=="Debug" (
    nuget push "%2" %mygetApiKey% -source "mero-feed"
)
IF "%1"=="Release" (
    nuget push "%2" %nugetApiKey% -source "nuget.org"
)