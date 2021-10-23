using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Welcome to Fitness App!");
            //Console.WriteLine("Please, enter your Name");
            //var name = Console.ReadLine();
            //Console.WriteLine("Please, enter your gender");
            //var gender = Console.ReadLine();
            //Console.WriteLine("Please, enter your Birdth date");
            //var birthDate =DateTime.Parse( Console.ReadLine());// TODO заменить на TryParse
            //Console.WriteLine("Please, enter your weight");
            //var weight =double.Parse( Console.ReadLine());
            //Console.WriteLine("Please, enter your height");
            //var height = double.Parse(Console.ReadLine());

            //var userController = new UserController(name, gender, birthDate, weight, height);
            //userController.Save();

            Console.WriteLine("Welcome to Fitness App!");
            Console.WriteLine("Please, enter your Name");
            var name = Console.ReadLine();
            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Please, enter your gender");
                var gender = Console.ReadLine();

                userController.SetNewUserData();
            }
            Console.WriteLine(userController.CurrentUser);


        }
    }
}
