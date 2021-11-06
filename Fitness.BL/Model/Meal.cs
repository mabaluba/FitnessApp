using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Each meal
    /// </summary>
    public class Meal
    {
        public DateTime MealTime { get;}
        public Dictionary<Food,double> Foods{ get;}
        public User User { get;}
        public Meal(User user)
        {
            User = user?? throw new ArgumentNullException(nameof(user),"User cannot be null.");
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
