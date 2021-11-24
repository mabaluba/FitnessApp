using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class MealController : Repository
    {
        /// <summary>
        /// Filename for storing all products
        /// </summary>
        private const string FoodsFileName = "foods.json";
        private const string MealsFileName = "meals.json";
        private string ProductName { get; set; }
        /// <summary>
        /// Keeps all products collection
        /// </summary>
        public List<Food> Products { get; }
        public bool HasNewProduct { get; private set; } = false;
        public Food CurrentProduct { get; private set; }
        /// <summary>
        /// Keeps all meals collection
        /// </summary>
        public List<Meal> Meals { get; }
        public Meal CurrentMeal { get; }

        public MealController(string userName)
        {
            userName = ExceptionHelper.NullOrWhiteSpaceCheck(userName);
            Products = GetData<Food>(FoodsFileName).ToList();
            Meals = GetData<Meal>(MealsFileName).ToList();
            CurrentMeal = new Meal(userName);
        }

        /// <summary>
        /// Adds product to the current meal 
        /// </summary>
        /// <param name="food"></param>
        /// <param name="weight"></param>
        public void AddProductToMeal(string productName, double weight)
        {
            ProductName = productName;
            if (CurrentMeal.Foods.Keys.Contains(productName))
            {
                CurrentMeal.Foods[productName] += weight;
            }
            else
            {
                CurrentMeal.Foods.Add(productName, weight);
            }
            HasNewProduct = !Products.Any(p => p.FoodName == productName);
        }

        /// <summary>
        /// Adds product to Foods collection
        /// </summary>
        /// <param name="calories"></param>
        /// <param name="proteins"></param>
        /// <param name="fats"></param>
        /// <param name="carbohydrates"></param>
        public void AddProductToFoods(double calories, double proteins, double fats, double carbohydrates)
        {
            if (HasNewProduct)
            {
                CurrentProduct = new Food(ProductName, calories, proteins, fats, carbohydrates);
                Products.Add(CurrentProduct);
            }
        }

        /// <summary>
        /// Saves current meal to current user meals, saves all meals and products
        /// </summary>
        public void SaveProductsMeals()
        {
            if (CurrentMeal.Foods.Count != 0)
            {
                Meals.Add(CurrentMeal);
                SaveData(Meals, MealsFileName);
                SaveData(Products, FoodsFileName);
            }

        }
    }
}
