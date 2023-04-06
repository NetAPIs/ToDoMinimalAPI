# ToDoMinimalAPI
A simple REST API built with C# and ASP.NET Core, using the minimal API approach.
This API allows you to manage a list of ToDo items, including creating, reading, updating and deleting them.

# Requirements

.NET 6 SDK <br>
Microsoft SQL Server <br>

# Installation

Clone this repository: git clone https://github.com/Argones/ToDoMinimalAPI.git <br>
Navigate to the project folder: cd ToDoMinimalAPI <br>
Restore dependencies: dotnet restore <br>
Create a SQL Server database (e.g. TodoDb) and update the DefaultConnection string in appsettings.json with your connection details. <br>
Run the database migrations: dotnet ef database update <br>
Run the API: dotnet run <br>
The API will be available at https://localhost:5001/todos. <br>

# Usage

The following endpoints are available: <br>

GET /todos - Returns a list of all ToDo items <br>
GET /todos/{id} - Returns a specific ToDo item by ID <br>
POST /todos - Creates a new ToDo item <br>
PUT /todos/{id} - Updates an existing ToDo item by ID <br>
PATCH /todos/{id} - Updates an existing ToDo item by ID <br>
DELETE /todos/{id} - Deletes a ToDo item by ID <br>

# License
This project is licensed under the MIT License.
