FROM ubuntu:latest
WORKDIR /app
COPY ./ ./

RUN apt-get update 
RUN apt-get install -y dotnet-sdk-6.0
RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https --trust
RUN dotnet add package MongoDB.Driver

RUN dotnet run

