# EF Core 6 Relationship Sample
Entity Framework Relationship sample with PostgreSQL

#### NuGet Packages
```shell

dotnet add package Microsoft.EntityFrameworkCore --version 6.0.13

dotnet add package  Microsoft.EntityFrameworkCore.Design --version 6.0.13

dotnet add package  Npgsql.EntityFrameworkCore.PostgreSQL --version 6.0.8

```

#### User Secrets in ASP.NET Core With Jetbrains Rider

user secret location
```
Mac/Linux: ~/.microsoft/usersecrets

Windows: %APPDATA%\Microsoft\UserSecrets
```

#### ASP.NET Core 3.0 and Above
If you have the .NET Core SDK 3.0.100 or later you can use the .NET Core CLI from the ASP.NET Core project directory.

```
dotnet user-secrets init

```

#### Manage User secret in Rider
In Rider’s Solution Explorer, 
right-click on the ASP.NET Core project -> Tools -> Open project user secrets.