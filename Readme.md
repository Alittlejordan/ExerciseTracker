# Exercise Tracker

## Overview

Exercise Tracker is a simple console application for tracking exercise sessions. It allows users to log their exercise sessions, including start date, end date, duration, and comments.

## Features

- Add a new exercise session
- View details of a specific exercise session
- Update information for an existing exercise session
- Delete an exercise session
- View a list of all exercise sessions

## Project Structure

The project follows the Repository Pattern for data persistence and uses a simple console interface for user interaction. Key components include:

- `Exercise`: Model class representing an exercise session with properties like Id, DateStart, DateEnd, Duration, and Comments.
- `ExerciseDbContext`: Database context class for Entity Framework or raw SQL, responsible for interacting with the underlying database.
- `IExerciseRepository`: Interface defining CRUD operations for exercises.
- `ExerciseRepository`: Repository class implementing `IExerciseRepository` and handling CRUD operations for exercises.
- `ExerciseService`: Service class containing business logic for exercise-related operations.
- `ExerciseController`: Controller class responsible for handling user input and interacting with the service and repository.
- `UserInput`: Class handling user input for adding and updating exercises.
- `TableVisualization`: Class responsible for visualizing data in tabular format.

## Getting Started

### Prerequisites

- .NET Core SDK installed

### Setup

1. Clone the repository:

   git clone https://github.com/Alittlejordan/exercise-tracker.git
   cd exercise-tracker

2. Open the ExerciseTracker/app.config file and update the connection string

3. Apply migrations to create the database:
	dotnet ef migrations add InitialCreate
	dotnet ef database update

4. Build the project:

5. Run the application:

### Usage
Follow the on-screen prompts to perform various actions such as adding, updating, and deleting exercise sessions.

### Dependencies
Dependencies
Entity Framework (or your chosen data persistence library)
SQLite (or your chosen database)

### Contributing
Contributions are welcome! If you find a bug or have an enhancement in mind, feel free to open an issue or submit a pull request.