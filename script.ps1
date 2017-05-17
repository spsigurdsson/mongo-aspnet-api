[Console]::OutputEncoding = [System.Text.Encoding]::Default
dotnet restore
dotnet build
dotnet publish
docker-compose up -d