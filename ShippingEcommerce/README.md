# ShippingEcommerceApi
 Shipping Api Example


# Arrive Outdoors Commerce API

The ASP.NET Core 5 based API for E-Commerce Shipping interview question

## Prerequisites

* [dotnet CLI](https://dotnet.microsoft.com/download)
* [Docker](https://docs.docker.com/get-docker/)

## Getting Started

The following commands will generate a self-signed dev certificate, build the API, start a PostgreSQL container, and finally start the API and apply migrations.

```text
dotnet dev-certs https --clean
dotnet dev-certs https -ep $HOME/.aspnet/https/aspnetapp.pfx -p SuperSecretPassword
dotnet dev-certs https --trust

docker-compose up --build
```

The swagger interface can then be found at https://localhost:3001/swagger

## Debugging

If trying to debug from the IDE, the Postgres container can be run independently using the following command
```
docker-compose up db
```