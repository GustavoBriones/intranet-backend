# Intranet BackEnd
Este proyecto fue realizado con .NET CORE 5
Se recomienda montar un contenedor con base de datos SQL SERVER.
Los datos datos de conexion a la base de datos estan en el archivo appsetting.json del proyecto WebApi

## DOTNET EF
Esta proyecto hace uso de Entity framework. Para crear una migracion ejecutar el comando `dotnet-ef migrations add nombreMigracion -p BusinessLogic -s WebApi -o carpetaSalida -c contextDb`

Para actualizar la base de datos ejecutar el siguiente comando `dotnet-ef database update nombreMigracion -p WebApi/WebApi.csproj`

## ASPNET
Para crear un nuevo controlador se debe ejecutar el siguiente comando `dotnet-aspnet-codegenerator controller -name nombreControlador -p WebApi.csproj -outDir carpetaControlador -api`

## PROYECTO
Para compilar el proyecto ejecutar el siguiente comando `dotnet build WebApi/WebApi.csproj`

Para ejecutar el proyecto ejecutar el siguiente comando `dotnet run --project WebApi/WebApi.csproj`