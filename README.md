# Student Assessment Tracker

Student Assessment Tracker is a beginner-friendly **ASP.NET Core MVC** web application to manage and track student assessments. It allows teachers to add, edit, delete, and view student scores, calculate totals, averages, percentages, and performance levels.

## Architecture

This system is built using the **MVC (Model-View-Controller) architecture**:

**Model** – Represents the data (Student model with assessments, totals, average, percentage, performance level).
**View** – Razor views that handle the user interface (HTML, CSS, JS).
**Controller** – Handles user input and application logic (StudentsController manages CRUD operations).

**Why MVC:**

* Separates concerns, making the application easier to maintain and extend.
* Beginner-friendly: easy to follow how data flows from the database to the UI.
* Supports clear structure for CRUD operations and sorting/filtering students.

## Database

Currently, the application uses an **In-Memory Database** provided by **Entity Framework Core**.

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("StudentDb"));

Why In-Memory Database:

* Simple to set up for beginners; no need to install SQL Server or SQLite.
* Perfect for testing and learning CRUD operations.
* Stores all data temporarily during the app session; resets when the application stops.

## Features

* Add, Edit, Delete Students with assessments
* Sort Students by First Name, Last Name, Total Score, or Percentage
* Automatic calculations: Total, Average, Percentage, Performance Level

  * `<50` → Needs Support
  * `50-55` → Satisfactory
  * `56-75` → Good
  * `>75` → Excellent
* Styled tables and forms using CSS
* Delete confirmation via JavaScript
* Beginner-friendly code with proper MVC structure

## Project Structure

StudentAssessmentTracker/
│
├── Controllers/
│   └── StudentsController.cs
├── Models/
│   └── Student.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Views/
│   └── Students/ 
│       ├── Index.cshtml
│       ├── Create.cshtml
│       └── Edit.cshtml
├── wwwroot/                   
│   ├── css/site.css
│   ├── js/site.js
│   └── images/logo.png
├── Program.cs                 
├── StudentAssessmentTracker.csproj
└── README.md

## Setup Instructions

1. Clone or Download Project in github repository
2. Open in VS Code
3. Install Dependencies

   ```bash
   dotnet restore
   
4. **Run the Application**

   ```bash
   dotnet run

5. **Open in Browser**

   http://localhost:5000/Students
  
## Usage

1. View Students – homepage table
2. Add Student – click “Add Student”
3. Edit Student – click “Edit”
4. Delete Student – click “Delete” (confirmation appears)
5. Sort Students – click table headers

## Notes

* In-memory database clears data on application stop
* Static files (CSS, JS, Images) are in `wwwroot/`
* Logo image is resizable via CSS

Future Improvements

* Persistent database using SQL Server or SQLite
* Search/filter students
* Export table to Excel or PDF
* Responsive layout with Bootstrap
* User authentication
