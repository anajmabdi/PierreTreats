# Template that includes configuration for Entity Framework Core and ASP.Net Core MVC

- Run "dotnet restore" to establish project-specific tools and dependencies that are listed in the project file.
- Set up database and update the connection string in the appsettings with the correct info related to the database. 
    #### Since this file contains sensitive data, be sure to add this to your.gitignore file.
- Make sure the config for database context in the project file is updated with the correct project name.
- For testing, update the  project reference in the project file with the correct project name.
