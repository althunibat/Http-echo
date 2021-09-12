FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /app

# Copy and restore as distinct layers
COPY . ./
RUN dotnet restore -r linux-musl-x64 

RUN dotnet publish -c release -o /app -r linux-musl-x64 --self-contained false --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["./HttpEcho.Web"]