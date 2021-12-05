using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        /*[TestMethod()]
        public void UserControllerTest()
        {
            Assert.Fail();
        }*/

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var gender = "MaleTest";
            var birthDate = DateTime.Now;
            var weight = 60;
            var height = 170;
            var controllerNew = new UserController(userName);
            //Act
            controllerNew.SetNewUserData(gender, birthDate, weight, height);
            var controllerCheck = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controllerCheck.CurrentUser.Name);
            Assert.AreEqual(gender, controllerCheck.CurrentUser.Gender.GenderType);
            Assert.AreEqual(birthDate, controllerCheck.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controllerCheck.CurrentUser.Weight);
            Assert.AreEqual(height, controllerCheck.CurrentUser.Height);
        }
    }
}