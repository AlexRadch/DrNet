
powershell "$Env:nugetAPIKEY = '"APIKEY'"

powershell "$Env:DrNetVersion = '6.0.0-preview.7.'+(Get-Date).ToString('yyMMdd.HHmm')"
powershell "$Env:DrNetCommit = 'COMMIT'"

powershell "[Environment]::SetEnvironmentVariable('nugetAPIKEY', 'APIKEY', 'User')"

powershell "[Environment]::SetEnvironmentVariable('DrNetVersion', '6.0.0-preview.7.'+(Get-Date).ToString('yyMMdd.HHmm'), 'User')"
powershell "[Environment]::SetEnvironmentVariable('DrNetCommit', 'COMMIT', 'User')"

dotnet nuget push NUPKG --api-key %nugetAPIKEY% --source https://api.nuget.org/v3/index.json
