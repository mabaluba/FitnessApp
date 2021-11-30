using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fitness.BL.Model
{
    public sealed class Workout
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [JsonInclude] [NotMapped]
        public List<string> Exercises { get; private set; }
        public double WorkoutDuration { get; set; }
        public double CaloriesBurned { get; set; }
        [JsonInclude]
        public DateTime WorkoutDate { get; private set; }
        public Workout() { }
        public Workout(string userName)
        {
            UserName = ExceptionHelper.NullOrWhiteSpaceCheck(userName);
            WorkoutDate = DateTime.Now;
            Exercises = new List<string>();
        }
        public override string ToString()
        {
            return $"\n\t{UserName}, your total training was {((int)WorkoutDuration) / 60}h(s), {((int)WorkoutDuration) % 60}min(s).\n\t\tAnd total calories burned - {CaloriesBurned / 1000}Kcal.\n";
        }
    }
}
