FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY entrepreneur_tc_auth.csproj ./
RUN dotnet restore ./entrepreneur_tc_auth.csproj
COPY . .
WORKDIR /src/.
RUN dotnet build entrepreneur_tc_auth.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish entrepreneur_tc_auth.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "entrepreneur_tc_auth.dll"]
