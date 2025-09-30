# Student Management API
A minimal ASP.NET Core API for managing student records using JSON file storage. This project demonstrates CRUD (Create, Read, Update, Delete) operations with a simple file-based data store.

## Features
* GET /Student - Retrieve all students
* GET /Student/{id} - Retrieve a specific student by ID
* POST /Student - Create a new student
* PUT /Student/{id} - Update an existing student
* DELETE /Student/{id} - Delete a student

## Project Structure
        text
        StudentAPI/
        ├── Program.cs                 # Main application file with API endpoints
        ├── Data/
        │   └── students.json         # JSON data store for student records
        └── StudentModel.cs           # Student data model definitions
## Data Model
The StudentModel class contains the following properties:

        csharp
        public class StudentModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Grade { get; set; }
            public string School { get; set; }
            public string Major { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
        }
## API Endpoints
### Get All Students
        http
        GET /Student
Returns a list of all students in the system.

### Get Student by ID
        http
        GET /Student/{id}
Returns a specific student by their ID.

### Create Student
        http
        POST /Student
Creates a new student. The ID is automatically generated.

### Update Student
        http
        PUT /Student/{id}
Updates an existing student by ID.

Request Body: Same as POST, but with all fields.

### Delete Student
        http
        DELETE /Student/{id}
Deletes a student by ID.

## Prerequisites
* .NET 8.0 
* Newtonsoft.Json package

## Installation
1. Clone the repository

2. Restore NuGet packages:

        bash
        dotnet restore
3. Ensure the Data directory exists with a students.json file

## Running the Application
1. Run the application:

        bash
        dotnet run
2. Navigate to https://localhost:7000/swagger for the Swagger UI

3. Or use http://localhost:5000 for HTTP requests

## Development
The application includes Swagger documentation in development mode, making it easy to test all endpoints through the Swagger UI.

## Error Handling
* Returns 200 OK for successful operations
* Returns appropriate student data or confirmation messages
* Handles missing students gracefully (returns null for non-existent IDs)

## Dependencies
* Newtonsoft.Json - For JSON serialization/deserialization
* Swashbuckle.AspNetCore - For API documentation (Swagger)

## Notes
* The application uses in-memory operations with file persistence
* No database required - perfect for simple demonstrations and small datasets
* Auto-incrementing IDs are handled by the application
* Data is persisted to JSON file after each modification
