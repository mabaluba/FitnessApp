using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Globalization;
using System.Linq;

namespace Fitness.CMD
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Fitness App!");
            Console.WriteLine("Please, enter your Name");
            var nameRaw = Console.ReadLine();
            var name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nameRaw);
            var userController = new UserController(name);
            AddNewUser(userController);
            var currentUser = userController.CurrentUser;
            Console.WriteLine(currentUser);
            Console.WriteLine();
            var mealController = new MealController(currentUser.Name);

            while (true)
            {
                Console.WriteLine("What would you like to do next:");
                Console.WriteLine("\tM - enter meal products\n");
                Console.WriteLine("\tP - show your meal products\n");
                //Console.WriteLine("\tE - enter exercise\n");//пока нет
                Console.WriteLine("\tQ - quit\n");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.M:
                        EnterNewMeal(mealController);
                        break;
                    case ConsoleKey.P:
                        ShowMealProducts(mealController);
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nWrong command, please, try again");
                        break;
                }
            }
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
            #region Adds new user
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
            #endregion
        }

        private static void EnterNewMeal(MealController mealController)
        {
            Console.WriteLine("\nEnter product name:");
            string productName = Console.ReadLine().ToLower();
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
            mealController.SaveProductsMeals();
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
            while (!double.TryParse(Console.ReadLine(), out doubleNumber))
            {
                Console.WriteLine("Wrong format, enter again");
            }
            return doubleNumber;
        }
    }
}
