using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Current meal keeper. Not save all meals info for each user, but only for showing current meal of current user.
    /// TODO Save meals info for each user
    /// </summary>
    public class Meal
    {
        public DateTime MealTime { get;}
        public Dictionary<Food,double> Foods{ get;}
        public Meal()
        {
            MealTime = DateTime.UtcNow;
            Foods = new();
        }
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.FoodName.Equals(food.FoodName));
            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
