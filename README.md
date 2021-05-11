# ShippingEcommerceApi
 Shipping Api Example 


# Commerce API

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

docker-compose --build
docker-compose up
```

The swagger interface can then be found at http://localhost:3005/swagger/index.html

![image](https://user-images.githubusercontent.com/5769233/117893479-59a48400-b26f-11eb-8036-417b7dfbf0f1.png)

![image](https://user-images.githubusercontent.com/5769233/117893564-7fca2400-b26f-11eb-8e8a-f744167b7ab6.png)

![image](https://user-images.githubusercontent.com/5769233/117893639-a4be9700-b26f-11eb-8853-a5fb9beb6add.png)

![image](https://user-images.githubusercontent.com/5769233/117893656-ae47ff00-b26f-11eb-9cdb-36d8ac44f7f7.png)

http://localhost:3005/swagger/index.html
![image](https://user-images.githubusercontent.com/5769233/117893867-1860a400-b270-11eb-9eee-e742daeaa873.png)

![image](https://user-images.githubusercontent.com/5769233/117893895-231b3900-b270-11eb-9e23-cc9baa29a627.png)




## Debugging

If trying to debug from the IDE, the Postgres container can be run independently using the following command
```
docker-compose up db
```
