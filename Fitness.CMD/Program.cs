using Fitness.BL.Controller;
using System;
using System.Globalization;

namespace Fitness.CMD
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Fitness App!\nPlease, enter your Name");
            var name = IsNullOrWhitespaceCheck(Console.ReadLine().ToLower());
            var userController = new UserController(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name));
            AddNewUser(userController);
            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine();

            var mealController = new MealController(userController.CurrentUser.Name);
            var workoutController = new WorkoutController(userController.CurrentUser.Name);
            while (true)
            {
                Console.WriteLine("What would you like to do next:");
                Console.WriteLine("  M - enter meal products\n");
                Console.WriteLine("  P - show your meal products\n");
                Console.WriteLine("  W - enter workout exercise\n");
                Console.WriteLine("  Q - quit\n");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.M:
                        EnterNewMeal(mealController);
                        
                        break;
                    case ConsoleKey.P:
                        ShowMealProducts(mealController);
                        break;
                    case ConsoleKey.W:
                        EnterNewWorkout(workoutController);
                        break;
                    case ConsoleKey.Q:
                        mealController.SaveProductsMeals();//проверить как сохраняются продукты и приемы пищи
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nWrong command, please, try again");
                        break;
                }
            }
        }

        private static void EnterNewWorkout(WorkoutController workoutController)
        {

            Console.WriteLine("\nEnter exercise name:");
            var exerciseName = IsNullOrWhitespaceCheck(Console.ReadLine().ToLower());
            Console.WriteLine("\nEnter exercise time in minutes:");
            var exerciseTime = ParseToDouble();
            Console.WriteLine("\nEnter calories burned per minute:");
            var caloriesBurnedPerMinute = ParseToDouble();
            workoutController.AddExercise(exerciseName, exerciseTime, caloriesBurnedPerMinute);

        }

        private static string IsNullOrWhitespaceCheck(string userInput)
        {
            while (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("This value cannot be null or whitespace, please try again.");
                userInput = Console.ReadLine();
            }
            return userInput;
            //return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(userInput);
        }

        private static void ShowMealProducts(MealController mealController)
        {
            if (mealController.CurrentMeal.Foods.Count == 0)
            {
                Console.WriteLine("\nThere is no foods in your meal, please, choose \"Enter meal products\" first.");
            }
            else
            {
                Console.WriteLine($"\nFoods in your meal: {mealController.CurrentMeal}");
            }
        }

        private static void AddNewUser(UserController userController)
        {
            if (userController.IsNewUser)
            {
                Console.WriteLine("Please, enter your gender");
                var gender = Console.ReadLine();
                Console.WriteLine("Please, enter your birdth date (dd.mm.yyyy)");
                var birthDate = ParseToDate();
                Console.WriteLine("Please, enter your weight");
                var weight = ParseToDouble();
                Console.WriteLine("Please, enter your height");
                var height = ParseToDouble();
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
        }

        private static void EnterNewMeal(MealController mealController)
        {
            Console.WriteLine("\nEnter product name:");
            string productName = IsNullOrWhitespaceCheck(Console.ReadLine().ToLower());
            Console.WriteLine("Enter product weight:");
            double productWeight = ParseToDouble();
            mealController.AddProductToMeal(productName, productWeight);
            if (mealController.HasNewProduct)
            #region Adds new product and its nutrition information to the products information storage
            {
                Console.WriteLine("There is no nutrition information of this product, please, enter some:");
                Console.WriteLine("Calories:");
                var calories = ParseToDouble();
                Console.WriteLine("Proteins:");
                var proteins = ParseToDouble();
                Console.WriteLine("Fats:");
                var fats = ParseToDouble();
                Console.WriteLine("Carbohydrates:");
                var carbohydrates = ParseToDouble();
                mealController.AddProductToFoods(calories, proteins, fats, carbohydrates);
            }
            #endregion
            //mealController.SaveProductsMeals();
        }

        private static DateTime ParseToDate()
        {
            DateTime birthDate;
            while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                Console.WriteLine("Enter your birdthday correct format as follow (dd.mm.yyyy)");
            }
            return birthDate;
        }

        private static double ParseToDouble()
        {
            double doubleNumber;
            while (!double.TryParse(Console.ReadLine(), out doubleNumber) || doubleNumber < 0)
            {
                Console.WriteLine("This value should be a number and cannot be less than 0, please enter again.");
            }
            return doubleNumber;
        }
    }
}
