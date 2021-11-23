using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{
    public sealed class Workout
    {
        public string UserName { get; }
        public string ExerciseName { get;}
        public double WorkoutTime { get;}
        public DateTime WorkoutDate { get; private set; }
        public Workout() { }
        public Workout(string userName)
        {
            UserName = ExceptionHelper.NullOrWhiteSpaceCheck(userName);
            WorkoutDate = DateTime.Now;
        }
    }
}
