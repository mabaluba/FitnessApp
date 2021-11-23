using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class WorkoutController : Repository
    {
        //private const string ExercisesFileName = "exercises.json";
        //private readonly List<Exercise> _exercises;
        //public string ExerciseName { get; private set; }
        //public double WorkoutDuration { get; private set; } = 0;
        //public double CaloriesBurned { get; private set; } = 0;
        //private string UserName { get; }
        //private IEnumerable<string> Exercises { get; private set; }
        //private readonly List<Workout> _workouts;
        private const string WorkoutsFileName = "workouts.json";
        private List<Workout> Workouts { get; set; }
        public Workout CurrentWorkout { get; }

        public WorkoutController() { }

        public WorkoutController(string userName)
        {
            CurrentWorkout = new Workout(ExceptionHelper.NullOrWhiteSpaceCheck(userName));
            //CurrentWorkout.Exercises = new List<string>();
            Workouts = GetData<Workout>(WorkoutsFileName).ToList();
        }

        public void AddExercise(string exercise, double exerciseTime, double caloriesBurnedPerMinute)
        {
            CurrentWorkout.Exercises.Add(ExceptionHelper.NullOrWhiteSpaceCheck(exercise));
            CurrentWorkout.WorkoutDuration += ExceptionHelper.NegativeDoubleNumberCheck(exerciseTime);
            CurrentWorkout.CaloriesBurned += exerciseTime * caloriesBurnedPerMinute;
        }
        public void SaveWorkout()
        {
            Workouts.Add(CurrentWorkout);
            SaveData(Workouts, WorkoutsFileName);
        }


    }
}
