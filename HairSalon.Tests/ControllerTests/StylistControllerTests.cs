using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            //Arrange
           StylistController controller = new StylistController();

            //Act
            ActionResult indexView = controller.Index();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            //Arrange
           StylistController controller = new StylistController();

            //Act
            ActionResult newView = controller.New();

            //Assert
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Show_ReturnsCorrectView_True()
        {
            //Arrange
           StylistController controller = new StylistController();

            //Act
            ActionResult newView = controller.Show(1);

            //Assert
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void CreateStylist_ReturnsCorrectView_True()
        {
            //Arrange
            StylistController controller = new StylistController();

            //Act
            ActionResult newView = controller.Create("dog");

            //Assert
            Assert.IsInstanceOfType(newView, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void DeleteStylistAndStylistClients_ReturnsCorrectView_True()
        {
            //Arrange
            StylistController controller = new StylistController();

            //Act
            ActionResult newView = controller.Delete(0);

            //Assert
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void DeleteAllStylists_ReturnsCorrectView_True()
        {
            //Arrange
            StylistController controller = new StylistController();

            //Act
            ActionResult newView = controller.DeleteAll();

            //Assert
            Assert.IsInstanceOfType(newView, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Edit_ReturnsCorrectView_True()
        {
            //Arrange
            StylistController controller = new StylistController();

            //Act
            ActionResult newView = controller.Edit(1);

            //Assert
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Update_ReturnsCorrectView_True()
        {
            //Arrange
            StylistController controller = new StylistController();

            //Act
            ActionResult newView = controller.Update(1, "dog");

            //Assert
            Assert.IsInstanceOfType(newView, typeof(RedirectToActionResult));
        }
    }
}