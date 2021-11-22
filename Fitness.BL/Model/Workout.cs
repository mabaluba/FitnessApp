using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{
    internal sealed class Workout
    {
        public string UserName { get; }
        public Exercise CurrentExercise { get; set; }
        public DateTime Start { get;}
        public DateTime Stop { get;}
        public Workout() { }
        public Workout(string userName, Exercise currentExercise, DateTime start, DateTime stop)
        {
            UserName = ExceptionHelper.NullOrWhiteSpaceCheck(userName);
            CurrentExercise = currentExercise ?? throw new ArgumentNullException(nameof(currentExercise));
            Start = start;
            Stop = stop;
        }
    }
}
