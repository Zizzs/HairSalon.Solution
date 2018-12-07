using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class HairSalonControllerTest
    {

        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            //Arrange
            HairSalonController controller = new HairSalonController();

            //Act
            ActionResult indexView = controller.Index();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            //Arrange
            HairSalonController controller = new HairSalonController();

            //Act
            ActionResult newView = controller.New();

            //Assert
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Show_ReturnsCorrectView_True()
        {
            //Arrange
            HairSalonController controller = new HairSalonController();

            //Act
            ActionResult newView = controller.Show();

            //Assert
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void ShowStylist_ReturnsCorrectView_True()
        {
            //Arrange
            HairSalonController controller = new HairSalonController();

            //Act
            ActionResult newView = controller.ShowStylist(1);

            //Assert
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void CreateStylist_ReturnsCorrectView_True()
        {
            //Arrange
            HairSalonController controller = new HairSalonController();

            //Act
            ActionResult newView = controller.ShowStylist(0);

            //Assert
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void CreateClient_ReturnsCorrectView_True()
        {
            //Arrange
            HairSalonController controller = new HairSalonController();

            //Act
            ActionResult newView = controller.CreateClient("Hippo", 0);

            //Assert
            Assert.IsInstanceOfType(newView, typeof(RedirectToActionResult));
        }
        //Had this test to test if the Index returned a Dictionary, but I couldn't figure out the correct syntax for the Dictionary Object within the IsInstanceOfType method. So I'm commenting this out and will ask about it later.
        // [TestMethod]
        // public void Index_HasCorrectModelType_Dictionary()
        // {
        //     //Arrange
        //     ViewResult indexView = new HomeController().Index() as ViewResult;

        //     //Act
        //     var result = indexView.ViewData.Model;

        //     //Assert
        //     Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        // }
    }
}
