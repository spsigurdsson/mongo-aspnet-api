# Use the standard Microsoft ASP.NET Core container
FROM microsoft/dotnet:1.0-runtime
 
# Copy our code from the "/src/MyWebApi/bin/Debug/netcoreapp1.1/publish" folder to the "/app" folder in our container
WORKDIR /app
COPY ./bin/Debug/netcoreapp1.0/publish .
 
# Expose port 5000 for the Web API traffic
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000
 
# Run the dotnet application against a DLL from within the container
# Don't forget to publish your application or this won't work
ENTRYPOINT ["dotnet", "mongo-aspnet-api.dll"]