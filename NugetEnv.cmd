
powershell "$Env:nugetAPIKEY = '"APIKEY'"
powershell "$Env:DrNetCommit = 'COMMIT'"

powershell "[Environment]::SetEnvironmentVariable('nugetAPIKEY', 'APIKEY', 'User')"
powershell "[Environment]::SetEnvironmentVariable('DrNetCommit', 'COMMIT', 'User')"

dotnet nuget push NUPKG --api-key %nugetAPIKEY% --source https://api.nuget.org/v3/index.json
