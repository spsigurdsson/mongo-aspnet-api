# mongo-aspnet-api

Using dotnet core, mongo and docker. This is simple counter web api, which via. a GET increments a counter and shows last time updated.
In the `Dockerfile` we target the smaller  `microsoft/dotnet:1.0-runtime` which means that a `dotnet publish` must be run before building the Dockerfile.

```
dotnet restore
dotnet build
dotnet publish
docker-compose up
```