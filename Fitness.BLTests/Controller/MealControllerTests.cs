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
        public void AddProductToMealAndToProductsTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var productName = Guid.NewGuid().ToString();
            var userController = new UserController(userName);
            var mealController = new MealController(userController.CurrentUser);
            //Act
            mealController.AddProductToMeal(productName, 100);
            mealController.AddProductToFoods(200, 300, 400, 500);
            //Assert
            Assert.AreEqual(productName, mealController.CurrentMeal.Foods.First().Key);
            Assert.AreEqual(productName, mealController.Products.First().FoodName);
        }

        //[TestMethod()]
        //public void AddProductToFoodsTest()
        //{
        //    //Arrange
        //    var userName = Guid.NewGuid().ToString();
        //    var productName = Guid.NewGuid().ToString();
        //    var userController = new UserController(userName);
        //    var mealController = new MealController(userController.CurrentUser);
        //    var rnd = new Random();
        //    var product = new Food(productName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

        //    mealController.CurrentProduct.FoodName = productName;
            
        //    //Act
        //    mealController.AddProductToFoods(rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));
        //    //Assert
        //    Assert.AreEqual(product.FoodName, )
        //}
    }
}