using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var gender = "none";
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