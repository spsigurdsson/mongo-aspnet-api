# mongo-aspnet-api

A simple counter web api. With at GET we implement a counter. Output is current count and time of last count update. The Api uses dotnet core, mongo and docker.

## Docker-compose
In the `Dockerfile` we target the smaller  `microsoft/dotnet:1.0-runtime` which means that a `dotnet publish` must be run before building the Dockerfile.

```
dotnet restore
dotnet build
dotnet publish
docker-compose up
```
## Debug
If it is run in debug a `mongod` must be run locally or in Docker 
```
docker run -d -p 27017:27017 --name some-mongo -d mongo
```
