# A collection of Valheim mods

This is a monorepo with simple/small mods that I use on Valheim. Some were made by me, some are forks from other people's code that I intend to maintain.

### Downloading

Right now the only way is to download the code and build it yourself, though it's not hard. Give it a try!

You need:
- Valheim installed
- any version of .NET SDK 7 (https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

Steps:

1. Download the code using the <kbd>Code ▼</kbd> button at the top of the page and unzip it.
2. Inside the project folder, create a file named `ValheimModBase.csproj.user` with the following contents:

```xml
<Project>
    <PropertyGroup>
        <ValheimInstallDir>YOUR VALHEIM INSTALLATION FOLDER</ValheimInstallDir>
    </PropertyGroup>
</Project>
```
As an example, my installation folder is `D:\Games\SteamLibrary\steamapps\common\Valheim`

3. Open a Command Prompt inside the project folder and type `dotnet build --configuration Release <PLUGIN_FOLDER>` to build the mod you want. If everything goes ok, a folder named `bin\Release` will be created inside `<PLUGIN_FOLDER>`, containing `<PLUGIN_NAME>.dll`