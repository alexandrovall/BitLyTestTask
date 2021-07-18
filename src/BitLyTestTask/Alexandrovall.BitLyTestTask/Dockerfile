#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Alexandrovall.BitLyTestTask/Alexandrovall.BitLyTestTask.csproj", "Alexandrovall.BitLyTestTask/"]
COPY ["Alexandrovall.BitLyTestTask.MediatR.Behaviors/Alexandrovall.BitLyTestTask.MediatR.Behaviors.csproj", "Alexandrovall.BitLyTestTask.MediatR.Behaviors/"]
COPY ["Alexandrovall.BitLyTestTask.MediatR.Contracts/Alexandrovall.BitLyTestTask.MediatR.Contracts.csproj", "Alexandrovall.BitLyTestTask.MediatR.Contracts/"]
COPY ["Alexandrovall.BitLyTestTask.BL/Alexandrovall.BitLyTestTask.BL.csproj", "Alexandrovall.BitLyTestTask.BL/"]
COPY ["Alexandrovall.BitLyTestTask.DataAccess.MongoDb/Alexandrovall.BitLyTestTask.DataAccess.MongoDb.csproj", "Alexandrovall.BitLyTestTask.DataAccess.MongoDb/"]
COPY ["Alexandrovall.BitLyTestTask.Exceptions/Alexandrovall.BitLyTestTask.Exceptions.csproj", "Alexandrovall.BitLyTestTask.Exceptions/"]
RUN dotnet restore "Alexandrovall.BitLyTestTask/Alexandrovall.BitLyTestTask.csproj"
COPY . .
WORKDIR "/src/Alexandrovall.BitLyTestTask"
RUN dotnet build "Alexandrovall.BitLyTestTask.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Alexandrovall.BitLyTestTask.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Alexandrovall.BitLyTestTask.dll"]
