# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebApplication3/WebApplication3.csproj", "WebApplication3/"]

RUN dotnet restore "WebApplication3/WebApplication3.csproj"



COPY . .
WORKDIR "/src/WebApplication3"
RUN dotnet build "WebApplication3.csproj" -c Release -o /app/build

# Install dotnet-ef tool
RUN dotnet tool install --global dotnet-ef --version 7.0.0
ENV PATH="${PATH}:/root/.dotnet/tools"

# Publish stage
FROM build AS publish
RUN dotnet publish "WebApplication3.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Copy dotnet-ef from build stage to final stage
COPY --from=build /root/.dotnet/tools /root/.dotnet/tools

# Set the PATH environment variable
ENV PATH="${PATH}:/root/.dotnet/tools"


ENTRYPOINT ["dotnet", "WebApplication3.dll"]
