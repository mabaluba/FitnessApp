using Fitness.BL.Model;
using Fitness.BL.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class MealController
    {
        private const string FoodsFileName = "foods.json";
        private readonly User _user;
        public List<Food> Foods { get; }
        public List<Meal> Meals { get; }//TODO finish getting Meals

        public MealController(User user)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user),"User cannot be null.");
            Foods = GetAllFoods();
        }

        private List<Food> GetAllFoods()
        {
            ISerialization serialization = new JsonSerialization();
            return serialization.GetData<Food>(FoodsFileName);
        }
        private void SaveFoods()
        {
            ISerialization a = new JsonSerialization();
            a.SaveData(Foods, FoodsFileName);
        }
    }
}
