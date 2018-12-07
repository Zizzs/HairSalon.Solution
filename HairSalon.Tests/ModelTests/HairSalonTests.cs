using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;
 
namespace HairSalon.Tests
{
    [TestClass]
    public class HairSalonTest : IDisposable
    {

        public void Dispose()
        {
            StylistClass.ClearAll();
        }

        public HairSalonTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8890;database=alex_williams_test;";
        }

        [TestMethod]
        public void GetAll_ReturnsEmptyListFromDatabase_StylistClassList()
        {
            //Arrange
            List<StylistClass> newList = new List<StylistClass> { };

            //Act
            List<StylistClass> result = StylistClass.GetAll();

            //Assert
            CollectionAssert.AreEqual(newList, result);
        }
        
        [TestMethod]
        public void Save_SavesToDatabase_StylistList()
        {
            //Arrange
            StylistClass testStylist = new StylistClass("Jimmy");

            //Act
            testStylist.Save();
            List<StylistClass> result = StylistClass.GetAll();
            List<StylistClass> testList = new List<StylistClass>{testStylist};

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void GetAll_ReturnsEmptyListFromDatabase_ClientClassList()
        {
            //Arrange
            List<ClientClass> newList = new List<ClientClass> { };

            //Act
            List<ClientClass> result = ClientClass.GetAll();

            //Assert
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Save_SavesToDatabase_ClientList()
        {
            //Arrange
            ClientClass testStylist = new ClientClass("Jimmy", 2);

            //Act
            testStylist.Save();
            List<ClientClass> result = ClientClass.GetAll();
            List<ClientClass> testList = new List<ClientClass>{testStylist};

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }

    }
}
