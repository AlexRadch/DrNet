﻿SET nupkgVERSION=6.0.0-preview.VERSION
SET nugetAPIKEY=APIKEY
dotnet nuget push src\bin\Release\DrNet.Extensions.Hosting.Abstractions.%nupkgVERSION%.nupkg  --api-key %nugetAPIKEY% --source https://api.nuget.org/v3/index.json