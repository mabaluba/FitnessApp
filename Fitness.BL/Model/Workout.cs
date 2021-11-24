using System;
using System.Collections.Generic;

namespace Fitness.BL.Model
{
    public sealed class Workout
    {
        public string UserName { get; set; }
        public List<string> Exercises { get; set; }
        public double WorkoutDuration { get; set; }
        public double CaloriesBurned { get; set; }

        public DateTime WorkoutDate { get; set; }
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
