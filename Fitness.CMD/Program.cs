using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Linq;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Fitness App!");
            Console.WriteLine("Please, enter your Name");
            var name = Console.ReadLine();
            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Please, enter your gender");
                var gender = Console.ReadLine();
                Console.WriteLine("Please, enter your birdth date (dd.mm.yyyy)");
                DateTime birthDate;
                while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    Console.WriteLine("Enter your birdthday correct format as follow (dd.mm.yyyy)");
                }
                //var birthDate = DateTime.Parse(Console.ReadLine());// TODO заменить на TryParse?
                Console.WriteLine("Please, enter your weight");
                var weight = ParseToDouble();
                //var weight = double.Parse(Console.ReadLine());
                Console.WriteLine("Please, enter your height");
                var height = ParseToDouble();
                //var height = double.Parse(Console.ReadLine());
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
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
