FROM mcr.microsoft.com/dotnet/core/runtime:3.1

COPY bin/Release/netcoreapp2.2/publish app/

ENTRYPOINT ["dotnet", "app/Application.dll"]
