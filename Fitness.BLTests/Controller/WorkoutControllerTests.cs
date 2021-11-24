using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
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
            Assert.AreEqual((exercise,exerciseTime, calories*exerciseTime),
                (cW.Exercises[0], cW.WorkoutDuration, cW.CaloriesBurned));
        }
    }
}