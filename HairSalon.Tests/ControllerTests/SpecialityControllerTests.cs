using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialityControllerTest
    {
        [TestMethod]
        public void ShowAll_ReturnsCorrectView_True()
        {
            //Arrange
            SpecialityController controller = new SpecialityController();

            //Act
            ActionResult indexView = controller.ShowAll();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            //Arrange
            SpecialityController controller = new SpecialityController();

            //Act
            ActionResult indexView = controller.New();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Create_ReturnsCorrectView_True()
        {
            //Arrange
            SpecialityController controller = new SpecialityController();

            //Act
            ActionResult indexView = controller.Create("dog");

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Search_ReturnsCorrectView_True()
        {
            //Arrange
            SpecialityController controller = new SpecialityController();

            //Act
            ActionResult newView = controller.Search("dog");

            //Assert
            Assert.IsInstanceOfType(newView, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Join_ReturnsCorrectView_True()
        {
            //Arrange
            SpecialityController controller = new SpecialityController();

            //Act
            ActionResult newView = controller.Join();

            //Assert
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void JoinCreate_ReturnsCorrectView_True()
        {
            //Arrange
            SpecialityController controller = new SpecialityController();

            //Act
            ActionResult newView = controller.JoinCreate(1, 1);

            //Assert
            Assert.IsInstanceOfType(newView, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Show_ReturnsCorrectView_True()
        {
            //Arrange
            SpecialityController controller = new SpecialityController();

            //Act
            ActionResult newView = controller.Show(1);

            //Assert
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void DeleteAll_ReturnsCorrectView_True()
        {
            //Arrange
            SpecialityController controller = new SpecialityController();

            //Act
            ActionResult newView = controller.DeleteAll();

            //Assert
            Assert.IsInstanceOfType(newView, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Delete_ReturnsCorrectView_True()
        {
            //Arrange
            SpecialityController controller = new SpecialityController();

            //Act
            ActionResult newView = controller.Delete(1);

            //Assert
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }
    }
}