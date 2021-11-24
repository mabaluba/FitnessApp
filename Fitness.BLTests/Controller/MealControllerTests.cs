using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class MealControllerTests
    {

        [TestMethod()]
        public void AddProductToMealAndToProductsTest()
        {
            //Arrange
            //var fileName = "testMealController.json";
            var userName = Guid.NewGuid().ToString();
            var productName = Guid.NewGuid().ToString();
            var userController = new UserController(userName);
            var mealController = new MealController(userController.CurrentUser.Name);

            //Act
            mealController.AddProductToMeal(productName, 100);
            mealController.AddProductToFoods(200, 300, 400, 500);
            mealController.Meals.Add(mealController.CurrentMeal);

            //Assert
            Assert.AreEqual(productName, mealController.CurrentProduct.FoodName);
            Assert.AreEqual(productName, mealController.CurrentMeal.Foods.First().Key);
            Assert.AreEqual(productName, mealController.Meals.First().Foods.First().Key);
            Assert.AreEqual(productName, mealController.Products.First().FoodName);
        }
    }
}