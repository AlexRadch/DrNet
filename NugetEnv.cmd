
powershell "$Env:nugetAPIKEY = '"APIKEY'"
powershell "$Env:DrNetCommit = 'COMMIT'"

powershell "[Environment]::SetEnvironmentVariable('nugetAPIKEY', 'APIKEY', 'User')"
powershell "[Environment]::SetEnvironmentVariable('DrNetCommit', 'COMMIT', 'User')"

SET NugetPackage=PACKAGE
dotnet nuget push "%NugetPackage%" --api-key %nugetAPIKEY% --source https://api.nuget.org/v3/index.json
