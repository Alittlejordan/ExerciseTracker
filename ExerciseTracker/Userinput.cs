using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker
{
    internal class Userinput
    {

        private readonly ExerciseService _exerciseService;

        public Userinput(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        //this function will create the menu for the user to interact with
        public void CreateMenu()
        {
            Console.WriteLine("Welcome to the Exercise Tracker");
            Console.WriteLine("Please select an option from the menu below");
            Console.WriteLine("1. Add an exercise");
            Console.WriteLine("2. Update an exercise");
            Console.WriteLine("3. Delete an exercise");
            Console.WriteLine("4. View all exercises");
            Console.WriteLine("5. Exit");

            Console.WriteLine();

            Console.Write("Enter your choice: ");

            //this switch statement will allow the user to select an option from the menu
            while (true)
            {
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddExercise();
                        break;
                    case "2":
                        UpdateExercise();
                        break;
                    case "3":
                        DeleteExercuse();
                        break;
                    case "4":
                        ViewExercise();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }

        }

        //this function will allow the user to add an exercise
        private void AddExercise()
        {
            DateTime startDate, endDate, startTime, endTime;
            int durationMinutes;
            string comments;
            TimeSpan duration;
            // Start with a flag indicating whether the input is valid
            bool isValid = false;

            do
            {
                Console.Write("Enter start date (Format: dd-MM-yy): ");
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
                {
                    Console.WriteLine("Invalid start date format. Please try again.");
                    Console.Write("Enter start date (Format: dd-MM-yy): ");
                }

                Console.Write("Enter end date (Format: dd-MM-yy): ");
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
                {
                    Console.WriteLine("Invalid end date format. Please try again.");
                    Console.Write("Enter end date (Format: dd-MM-yy): ");
                }

                Console.Write("Enter start time (Format: hh:mm tt): ");
                while (!DateTime.TryParseExact(Console.ReadLine(), "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out startTime))
                {
                    Console.WriteLine("Invalid start time format. Please try again.");
                    Console.Write("Enter start time (Format: hh:mm tt): ");
                }

                Console.Write("Enter end time (Format: hh:mm tt): ");
                while (!DateTime.TryParseExact(Console.ReadLine(), "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out endTime))
                {
                    Console.WriteLine("Invalid end time format. Please try again.");
                    Console.Write("Enter end time (Format: hh:mm tt): ");
                }

                // Combine date and time components
                startDate = startDate.Add(startTime.TimeOfDay);
                endDate = endDate.Add(endTime.TimeOfDay);



                //  validating comments
                Console.Write("Enter comments: ");
                comments = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(comments))
                {
                    Console.WriteLine("Comments cannot be empty. Please enter comments.");
                    Console.Write("Enter comments: ");
                }

                isValid = true; // All inputs are valid
            } while (!isValid);

            duration = endTime - startTime;
            // Get total minutes as an integer
            int totalMinutes = (int)duration.TotalMinutes;
            // Create the exercise and add it to the service
            var newExercise = new Exercise
            {
                DateStart = startDate,
                DateEnd = endDate,
                Duration = TimeSpan.FromMinutes(totalMinutes),
                Comments = comments
            };

            _exerciseService.AddExercise(newExercise);
            Console.WriteLine("Exercise added successfully!");

            CreateMenu();
        }

        //this function will allow the user to update an exercise
        private void UpdateExercise()
        {
            Console.Write("Enter the ID of the exercise you want to update: ");
            if (int.TryParse(Console.ReadLine(), out int exerciseId))
            {
                var existingExercise = _exerciseService.GetExerciseById(exerciseId);

                // Check if the exercise exists
                if (existingExercise == null)
                {
                    Console.WriteLine($"Exercise with ID {exerciseId} not found.");
                    return;
                }

                Console.WriteLine("Choose an element to update:");
                Console.WriteLine("1. Start Date");
                Console.WriteLine("2. End Date");
                Console.WriteLine("3. Start Time");
                Console.WriteLine("4. End Time");
                Console.WriteLine("5. Duration");
                Console.WriteLine("6. Comments");
                Console.WriteLine("7. Cancel");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                // Update the exercise based on the user's choice
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter new start date (Format: dd-MM-yy): ");
                        if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newStartDate))
                        {
                            existingExercise.DateStart = newStartDate;
                            Console.WriteLine("Start date updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid start date format. Update canceled.");
                        }
                        break;
                    case "2":
                        Console.Write("Enter new end date (Format: dd-MM-yy): ");
                        if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newEndDate))
                        {
                            existingExercise.DateEnd = newEndDate;
                            Console.WriteLine("End date updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid end date format. Update canceled.");
                        }
                        break;
                    case "3":
                        Console.Write("Enter new start time (Format: hh:mm tt): ");
                        if (DateTime.TryParseExact(Console.ReadLine(), "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newStartTime))
                        {
                            // Update only the time component
                            existingExercise.DateStart = existingExercise.DateStart.Date.Add(newStartTime.TimeOfDay);
                            Console.WriteLine("Start time updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid start time format. Update canceled.");
                        }
                        break;
                    case "4":
                        Console.Write("Enter new end time (Format: hh:mm tt): ");
                        if (DateTime.TryParseExact(Console.ReadLine(), "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newEndTime))
                        {
                            // Update only the time component
                            existingExercise.DateEnd = existingExercise.DateEnd.Date.Add(newEndTime.TimeOfDay);
                            Console.WriteLine("End time updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid end time format. Update canceled.");
                        }
                        break;
                    case "5":
                        Console.Write("Enter new duration in minutes: ");
                        if (int.TryParse(Console.ReadLine(), out int newDurationMinutes))
                        {
                            existingExercise.Duration = TimeSpan.FromMinutes(newDurationMinutes);
                            Console.WriteLine("Duration updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid duration format. Update canceled.");
                        }
                        break;
                    case "6":
                        Console.Write("Enter new comments: ");
                        existingExercise.Comments = Console.ReadLine();
                        Console.WriteLine("Comments updated successfully!");
                        break;
                    case "7":
                        Console.WriteLine("Update canceled.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Update canceled.");
                        CreateMenu();
                        break;
                }

                _exerciseService.UpdateExercise(existingExercise);
            }
            else
            {
                Console.WriteLine("Invalid exercise ID format.");
            }
            CreateMenu();
        }

        //this function will allow the user to delete an exercise
        private void DeleteExercuse()
        {
            // Prompt the user for the ID of the exercise to delete
            Console.Write("Enter the ID of the exercise you want to delete: ");
            if (int.TryParse(Console.ReadLine(), out int exerciseId))
            {
                var existingExercise = _exerciseService.GetExerciseById(exerciseId);

                if (existingExercise == null)
                {
                    Console.WriteLine($"Exercise with ID {exerciseId} not found.");
                    return;
                }

                // Confirm the deletion
                Console.WriteLine("Are you sure you want to delete this exercise? (Y/N)");

                if (Console.ReadLine()?.ToUpper() == "Y")
                {
                    _exerciseService.RemoveExercise(exerciseId);
                    Console.WriteLine("Exercise deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Delete canceled.");
                }
            }
            else
            {
                Console.WriteLine("Invalid exercise ID format.");
            }

            CreateMenu();
        }

        //this function will allow the user to view all exercises
        private void ViewExercise()
        {

            List<Exercise> tableData = new List<Exercise>();

            // Retrieve contacts from the database
            var exercises = _exerciseService.GetAllExercises();

            // Add each contact to the table data
            foreach (var exercise in exercises)
            {

                tableData.Add(new Exercise
                {
                    Id = exercise.Id,
                    DateStart = exercise.DateStart,
                    DateEnd = exercise.DateEnd,
                    Duration = exercise.Duration,
                    Comments = exercise.Comments

                });

            }

            // Display the table
            TableVisualisation.ShowTable(tableData);


            CreateMenu();


        }
    }
}
    

