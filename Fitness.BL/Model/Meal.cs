using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// TODO Save meals info for each user
    
    /// <summary>
    /// Current meal keeper. Shows current meal of current user. Not keeps every meal.
    /// </summary>
    public class Meal
    {
        public string UserName { get; }
        /// <summary>
        /// Time of meal taking
        /// </summary>
        public DateTime MealTime { get; private set; }
        /// <summary>
        /// Keeps products and its weight from current meal
        /// </summary>
        public Dictionary<string ,double> Foods{ get; set; }
        /// <summary>
        /// Set Date and Time of the meal
        /// </summary>
        public Meal(){}
        public Meal(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName), $"'{nameof(userName)}' cannot be null"); ;
            MealTime = DateTime.Now;
            Foods = new ();
        }
        
        public override string ToString()
        {
            string result=string.Empty;
            foreach (var item in Foods)
            {
                result+= $"\n{item.Key} - {item.Value}g.\n";
            }
            return result;
        }
    }
}
