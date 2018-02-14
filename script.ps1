[Console]::OutputEncoding = [System.Text.Encoding]::Default


dotnet restore
dotnet build
dotnet publish -c release
docker-compose up -d

docker-compose down --rmi local