using Fitness.BL.Model;
using Fitness.BL.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class MealController
    {
        private const string FoodsFileName = "foods.json";

        public List<Food> Foods { get; }
        public Meal Meal { get; }

        public MealController()
        { 
            Foods = GetAllFoods();
            Meal = new();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.FoodName == food.FoodName);
            if (product == null)
            {
                Foods.Add(food);
                Meal.Add(food, weight);
                SaveAllFoods();
            }
            else
            {
                Meal.Add(product, weight);
            }
        }

        private List<Food> GetAllFoods()
        {
            return JsonSerialization.GetData<Food>(FoodsFileName);
        }
        private void SaveAllFoods()
        {
            JsonSerialization.SaveData(Foods, FoodsFileName);
        }
    }
}
