# Shopping Cart

A Blazor Shopping Cart Demo

Here's how you can run this application.

## 1. Install SQL Server & Entity Framework

Since I'm using SQL Server Express and Entity Framework Core in this application, you have to install these first.

`dotnet tool install --global dotnet-ef`

## 2. Update the ConnectionString

In the `appsettings.json` file of the Server project, you will find the connection string to connect to your database.

## 3. Update the Database

To create the database with all the seeded data, make sure to change to the Server directory of this solution.

`cd .\Shop.Api`

Then you can run all the migrations of EF Core or update the database, respectively.

`dotnet ef database update`

## 4. Run the Application

And finally, you can run the app.

`dotnet watch run`

Or, if you prefere use the Visual Studio 2022 just click on the Start button.

Enjoy!

Flávio

![Home](https://user-images.githubusercontent.com/9452793/208445528-7c8ddf95-43d8-42af-a7df-7e05261cacc1.PNG)
![Home - Responsive](https://user-images.githubusercontent.com/9452793/208445550-08cf4a28-dea9-46dd-b685-904fe60def84.PNG)
![Catalogo](https://user-images.githubusercontent.com/9452793/208445581-2e435d5a-2901-42ef-ad38-956ba0207dee.PNG)
![Product Detail](https://user-images.githubusercontent.com/9452793/208445600-89caca5e-5654-4c39-a529-13177f964660.PNG)
![Cart](https://user-images.githubusercontent.com/9452793/208445613-a27e0f9a-328b-4f12-8ca0-7d8511c56bca.PNG)
