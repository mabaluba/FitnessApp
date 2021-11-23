using System;

namespace Fitness.BL.Model
{
    public sealed class Exercise
    {
        public string ExerciseName { get;}
        public double CaloriesPerMinute { get;}
        public Exercise(string exerciseName, double caloriesPerMinute)
        {
            ExerciseName = ExceptionHelper.NullOrWhiteSpaceCheck(exerciseName);
            CaloriesPerMinute = ExceptionHelper.NegativeDoubleNumberCheck(caloriesPerMinute);
        }
        public override string ToString()
        {
            return ExerciseName;
        }
    }
}
