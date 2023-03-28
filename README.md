### important

These files need to stay unchanged in the repo for the Github Action (Docker Image Build) to work properly (at least temporary).

1. `./View/Program.cs`
2. `./View/appsettings.json`

If you want to contribute to this repo, make sure to run these commands **once** _before_ adding, commiting, or pushing:

> on Windows:
```powershell
git update-index --assume-unchanged .\View\Program.cs
git update-index --assume-unchanged .\View\appsettings.json
```
> on other OS:
```powershell
git update-index --assume-unchanged ./View/Program.cs
git update-index --assume-unchanged ./View/appsettings.json
```
