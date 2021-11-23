using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class WorkoutController : Repository
    {
        private const string WorkoutsFileName = "workouts.json";
        //private const string ExercisesFileName = "exercises.json";
        //private readonly List<Exercise> _exercises;
        private readonly List<Workout> _workouts;
        public string ExerciseName { get; private set; }
        public double WorkoutTime { get; private set; } = 0;
        public double CaloriesBurned { get; private set; } = 0;
        private string UserName { get; }
        public List<string> Exercises { get; private set; }
        public IEnumerable<Workout> Workouts => _workouts;
        public Workout CurrentWorkout { get; }

        public WorkoutController() { }

        public WorkoutController(string userName)
        {
            UserName = ExceptionHelper.NullOrWhiteSpaceCheck(userName);
            CurrentWorkout = new Workout(UserName);
            //_exercises = GetData<Exercise>(ExercisesFileName).ToList();
            _workouts = GetData<Workout>(WorkoutsFileName).ToList();

        }

        public void AddExercise(string exerciseName, double exerciseTime, double caloriesBurnedPerMinute)
        {
            ExerciseName = ExceptionHelper.NullOrWhiteSpaceCheck(exerciseName);
            Exercises.Add(exerciseName);
            CaloriesBurned += exerciseTime * caloriesBurnedPerMinute;
            WorkoutTime += exerciseTime;
        }
    }
}
