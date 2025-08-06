FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /app
EXPOSE 80
COPY Shared/OnlineCourse.Shared/*.csproj Shared/OnlineCourse.Shared/
COPY Services/Catalog/OnlineCourse.Services.Catalog/*.csproj Services/Catalog/OnlineCourse.Services.Catalog/
RUN dotnet restore Services/Catalog/OnlineCourse.Services.Catalog/*.csproj
COPY . .
RUN dotnet publish Services/Catalog/OnlineCourse.Services.Catalog/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","OnlineCourse.Services.Catalog.dll" ]