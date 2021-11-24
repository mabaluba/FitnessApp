using Fitness.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Serialization.Tests
{
    [TestClass()]
    public class JsonSerializationTests : JsonSerialization
    {
        [TestMethod()]
        public void Save_Get_DataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            IEnumerable<User> itemsCollection = new List<User>
            {
                new User { Name = userName }
            };
            var fileName = "test.json";
            //Act
            SaveData(itemsCollection, fileName);
            var resultUserName = GetData<User>(fileName).ToList().First().Name;
            //Assert
            Assert.AreEqual(userName, resultUserName);
        }
    }
}