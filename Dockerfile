#default configuration. Override with --build-arc CONFIGURATION=<configuration>
# understand more at https://docs.docker.com/engine/reference/builder/#understand-how-arg-and-from-interact
ARG CONFIGURATION=Release

# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG CONFIGURATION
WORKDIR /source

# copy csproj and restore as distinct layers
COPY src/WeatherDemo/*.csproj ./src/WeatherDemo/
RUN dotnet restore src/WeatherDemo/WeatherDemo.csproj

# copy and build app and libraries
COPY src/WeatherDemo/. ./src/WeatherDemo/

# test stage -- exposes optional entrypoint
# target entrypoint with: docker build --target test
FROM build AS tests
ARG CONFIGURATION
ENV CONFIGURATION=${CONFIGURATION}

COPY tests/WeatherDemoTests/*.csproj ./tests/WeatherDemoTests/
RUN dotnet restore tests/WeatherDemoTests/WeatherDemoTests.csproj

COPY tests/WeatherDemoTests/. ./tests/WeatherDemoTests/
RUN dotnet build --configuration ${CONFIGURATION} tests/WeatherDemoTests/WeatherDemoTests.csproj

WORKDIR /source/tests/WeatherDemoTests
# optional: added an entry point for when we run the container on this stage, so that we do not have to specify it on the command line
# if not, we can do it using docker run. Example:
# docker run --rm -v ${pwd}:/testsresults -w /source/tests/WeatherDemoTests <image_name> dotnet test --configuration <configuration> --logger:trx --results-directory /testsresults --collect:"XPlat Code Coverage" --no-build -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format=cobertura
# note: this is using the Shell form of entrypoint, so that ENV vars are interpreted
ENTRYPOINT dotnet test --configuration $CONFIGURATION --filter Category!=Integration --logger:trx --results-directory /testsresults --collect:"XPlat Code Coverage" --no-build -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format=cobertura

FROM build AS publish
ARG CONFIGURATION

RUN dotnet publish src/WeatherDemo/WeatherDemo.csproj --configuration ${CONFIGURATION} -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WeatherDemo.dll"]