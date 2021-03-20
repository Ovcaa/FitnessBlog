using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessBlog.BaseLogic.Model;
using System;

namespace FitnessBlog.BaseLogic.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SaveUsersTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();

            //Act
            var controller = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }

        [TestMethod()]
        public void SetNewUserDateTest()
        {
            //Arrange
            var rnd = new Random();
            var userName = Guid.NewGuid().ToString();
            var id = rnd.Next(1, 3);
            var gender = new Gender(id);
            var birthDate = DateTime.Parse("01.01.1999");
            var weight = rnd.Next(40, 100);
            var height = rnd.Next(150, 190);

            //Act
            var controller = new UserController(userName);
            controller.SetNewUserDate(id, birthDate, weight, height);

            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
            Assert.AreEqual(gender.Name, controller.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDate, controller.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller.CurrentUser.Weight);
            Assert.AreEqual(height, controller.CurrentUser.Height);
        }
    }
}