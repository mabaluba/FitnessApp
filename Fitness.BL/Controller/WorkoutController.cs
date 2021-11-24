using Fitness.BL.Model;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class WorkoutController : Repository
    {
        private const string WorkoutsFileName = "workouts.json";
        private List<Workout> Workouts { get; set; }
        public Workout CurrentWorkout { get; }
        public WorkoutController() { }

        public WorkoutController(string userName)
        {
            CurrentWorkout = new Workout(ExceptionHelper.NullOrWhiteSpaceCheck(userName));
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
            if (CurrentWorkout.Exercises.Count != 0)
            {
                Workouts.Add(CurrentWorkout);
                SaveData(Workouts, WorkoutsFileName);
            }
        }


    }
}
