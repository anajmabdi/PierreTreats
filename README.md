# <div align="center"> **Pierre's Sweet and Savory Treats**</div>

#### <div align="center"> By Najma Abdi </div>  
<p>&nbsp;</p>

# <div align="center"> Technologies Used
- <div align="center">C#
- <div align="center">HTML
- <div align="center">ASP.NET Core MVC
- <div align="center">Identity
- <div align="center">EF Core
- <div align="center">Markdown
- <div align="center">Razor
- <div align="center">MySQL

<p>&nbsp;</p>

# <div align="center"> Description </div>
<div align="center"> 

- User authentication will be a feature of the application using Identity. A user will have the option to log in and out. Users who are logged in will be able to create, update, and delete content. There will be read functionality available to all users.
- Treats and flavors will have a many-to-many relationship.
- A user can get a splash page that contains a list of all the desserts and flavors. Also, users will be able to click on a certain treat or flavor to view all the treats and flavors that are associated with it.


<p>&nbsp;</p>


# <div align="center">Installation Requirements 
You must make sure the following software packages are locally installed in order to use this application:
- A preferred code editor (my case: VS Code)
- .NET6
- MySQL and MySQL workbench


<p>&nbsp;</p>

## <div align="center"> Setup

- Clone the repository.
- Launch the terminal and go to the "PierreTreats" production directory for this project.
- Create a new appsettings.json file in the "PierreTreats" production directory.
- Launch a code editor, then go to appsettings.json.
- Insert the following code in appsettings.json, substituting the values in the brackets with your personal MySQL username and password.

        {
         "ConnectionStrings": {
            "DefaultConnection": "Server=localhost;Port=3306;database=[DATABASE_NAME];uid=[uid];pwd=[pwd];"
         }
        }
- Add this file in your .gitignore, along with obj and bin files.


<p>&nbsp;</p>

## Import the Database

- Locate the Navigator pane in MySQL Workbench by opening it on the left-hand side of the program window. Selecting this option will bring up the Data Import page, where you can import data.
- Choose the "Import from Self Contained File" option. Locate the files you downloaded from this repository's top directory ("PierreTreats").
- From "PierreTreats," choose the najma_abdi.sql file.
- Click the "New" box next to "Default Schema to be Imported To", type "najma_abdi.sql" as the database name, and then click "OK".
- Locate the "Start Import" button in the Data Import Pane's lower right corner.
- The "Schemas" tab can be found on the Navigator panel. The database should appear if you click the "refresh" icon, which is represented by two arrows in a circle in the top right corner of the pane.

- To update the database, run "dotnet ef update database" .


<p>&nbsp;</p>

## To run the server:
- Navigate to this project's production directory and run 'dotnet restore' if you haven't already. This will establish project-specific tools and dependencies that are listed in the project file
- Run 'dotnet watch' to start the server.

<p>&nbsp;</p>
<p>&nbsp;</p>


# <div align="center"> Known bugs </div>
Log off is broken
<p>&nbsp;</p>

#### License

MIT License

Copyright (c) [2022] [Najma Abdi]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions: