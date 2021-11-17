using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    public class Food
    {
        public string FoodName { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Calories in 100g
        /// </summary>
        public double Calories { get; set; }
        //public double CaloriesOneGramm{ get { return Calories / 100.0; } }
        //public double ProteinsOneGramm { get { return Proteins / 100.0; } }
        //public double FatsOneGramm { get { return Fats / 100.0; } }
        //public double CarbohydratesOneGramm { get => Carbohydrates / 100.0; }
        public Food(){ }
        //public Food(string foodName):this(foodName,0,0,0,0)
        //{
        //    if (string.IsNullOrWhiteSpace(foodName))
        //    {
        //        throw new ArgumentNullException(nameof(foodName), $"'{nameof(foodName)}' cannot be null or whitespace.");
        //    }
        //}
        public Food(string foodName, double calories, double proteins, double fats, double carbohydrates)
        {
            FoodName = foodName;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }
        public override string ToString()
        {
            return FoodName+" "+ Calories+"cal.";
        }
    }
}
