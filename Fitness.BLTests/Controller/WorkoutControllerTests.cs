using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Linq;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class WorkoutControllerTests
    {
        [TestMethod()]
        public void AddExerciseTest()
        {
            //Arrange
            var userName = new Guid().ToString();
            var exercise = "jump";
            var workoutController = new WorkoutController(userName);
            double exerciseTime = 30;
            double calories = 10;
            //Act
            workoutController.AddExercise(exercise, exerciseTime, calories);
            //Assert
            var cW = workoutController.CurrentWorkout;
            Assert.AreEqual((exercise, exerciseTime, calories * exerciseTime),
                (cW.Exercises[0], cW.WorkoutDuration, cW.CaloriesBurned));
        }

        [TestMethod()]
        public void SaveWorkoutTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var exercise = Guid.NewGuid().ToString();
            var workoutController = new WorkoutController(userName);
            double exerciseTime = 30;
            double calories = 10;
            workoutController.AddExercise(exercise, exerciseTime, calories);
            //Act
            workoutController.SaveWorkout();
            //Assert
            var cW = new WorkoutController(userName);
            //cW.Workouts.Last().Exercises[0]= "jjm";
            Assert.AreEqual(exercise, cW.Workouts.Last().Exercises[0]);
        }
    }
}