# mongo-aspnet-api

A simple web api implementing a counter. Output is current count and time of last count update. The Api uses dotnet core, mongo and docker.

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

## Test
Test of if the Api is working without mongo
```
curl http://localhost:5000/api/data
```
should return a simple "Hello World". 

And with mongo on docker 
```
curl http://localhost:5000/api/values
```
should return a json with "Time" and "Count", e.g.
```javascript
{
  "Time": "2017-05-17T11:33:32.770782+00:00",
  "Count":  24
}
```
