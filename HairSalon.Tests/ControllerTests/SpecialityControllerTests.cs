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
    }
}