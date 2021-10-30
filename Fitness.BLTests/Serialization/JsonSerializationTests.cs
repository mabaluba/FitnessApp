using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL.Controller;

namespace Fitness.BL.Serialization.Tests
{
    [TestClass()]
    public class JsonSerializationTests
    {
        [TestMethod()]
        public void SaveDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            //Act
            var controller = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }

       /* [TestMethod()]
        public void GetDataTest()
        {
            Assert.Fail();
        }*/
    }
}