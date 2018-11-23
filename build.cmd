@echo off
set config=%1
if "%config%" == "" (
   set config=Debug
)
 
set version=1.0.0
if not "%PackageVersion%" == "" (
   set version=%PackageVersion%
)

set nuget=
if "%nuget%" == "" (
        set nuget=nuget.exe
)

%nuget% pack "ReSharper.WixToolset\ReSharper.WixToolset.nuspec" -NoPackageAnalysis -Version %version% -Properties "Configuration=%config%"