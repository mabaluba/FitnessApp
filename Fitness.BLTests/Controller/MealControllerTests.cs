using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL.Model;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class MealControllerTests
    {

        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            //var userController = new UserController(userName);
            //var mealController = new MealController(userController.CurrentUser);
            var mealController = new MealController();
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));
            //Act
            mealController.Add(food, 100);
            //Assert
            Assert.AreEqual(food.FoodName, mealController.Meal.Foods.First().Key.FoodName);
        }
    }
}