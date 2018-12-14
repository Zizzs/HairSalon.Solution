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
            ClientClass.ClearAll();
        }

        

        public HairSalonTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8890;database=alex_williams_test;";
        }

        [TestMethod]
        public void GetName_ReturnsName_StylistString()
        {
            //Arrange
            StylistClass jimmy = new StylistClass("dog");

            //Act
            var newName = jimmy.GetName();

            //Assert
            Assert.IsInstanceOfType(newName, typeof(string));
        }

        [TestMethod]
        public void GetId_ReturnsName_Int()
        {
            //Arrange
            StylistClass jimmy = new StylistClass("dog");

            //Act
            var newName = jimmy.GetId();

            //Assert
            Assert.IsInstanceOfType(newName, typeof(int));
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
            string name = "Jimmy";
            StylistClass stylist = new StylistClass(name);

            //Act
            StylistClass.Save(name);
            List<StylistClass> result = StylistClass.GetAll();
            List<StylistClass> testList = new List<StylistClass>{stylist};

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Clear_ClearsFromDatabase_StylistList()
        {
            //Arrange
            List<StylistClass> newList = new List<StylistClass> { };
            string name = "Jimmy";

            //Act
            StylistClass.Save(name);
            StylistClass.ClearAll();
            List<StylistClass> testList = StylistClass.GetAll();

            //Assert
            CollectionAssert.AreEqual(newList, testList);
        }

        [TestMethod]
        public void FindById_ReturnsStylistList_StylistList()
        {
            //Arrange
            string name = "Jimmy";

            //Act
            StylistClass.Save(name);
            List<StylistClass> tempList = StylistClass.FindById(1);

            StylistClass jimmy = new StylistClass("dog");
            foreach(StylistClass stylist in tempList)
            {
                jimmy = stylist;
            }

            //Assert
           Assert.IsInstanceOfType(jimmy, typeof(StylistClass));
        }

        [TestMethod]
        public void Delete_DeletesStylistById_StylistList()
        {
            //Arrange
            string name = "Jimmy";
            List<StylistClass> tempList = new List<StylistClass> {};

            //Act
            StylistClass.Save(name);
            List<StylistClass> tempListTwo = StylistClass.GetAll();
            int id = tempListTwo[0].GetId();
            StylistClass.Delete(id);
            List<StylistClass> tempListThree = StylistClass.GetAll();

            //Assert
           CollectionAssert.AreEqual(tempList, tempListThree);
        }

        [TestMethod]
        public void GetName_ReturnsName_String()
        {
            //Arrange
            ClientClass jimmy = new ClientClass("dog", 1);

            //Act
            var newName = jimmy.GetName();

            //Assert
            Assert.IsInstanceOfType(newName, typeof(string));
        }

        [TestMethod]
        public void GetId_ReturnsName_ClientInt()
        {
            //Arrange
            ClientClass jimmy = new ClientClass("dog", 1);

            //Act
            var newName = jimmy.GetId();

            //Assert
            Assert.IsInstanceOfType(newName, typeof(int));
        }

        [TestMethod]
        public void GetStylistId_ReturnsName_ClientInt()
        {
            //Arrange
            ClientClass jimmy = new ClientClass("dog", 1);

            //Act
            var newName = jimmy.GetStylistId();

            //Assert
            Assert.IsInstanceOfType(newName, typeof(int));
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

        [TestMethod]
        public void Clear_ClearsFromDatabase_ClientList()
        {
            //Arrange
            List<ClientClass> newList = new List<ClientClass> { };
            string name = "Jimmy";
            int id = 1;
            ClientClass jimmy = new ClientClass(name, id);

            //Act
            jimmy.Save();
            ClientClass.ClearAll();
            List<ClientClass> testList = ClientClass.GetAll();

            //Assert
            CollectionAssert.AreEqual(newList, testList);
        }

        [TestMethod]
        public void GetAllClientsByStylistId_ReturnsClientList_ClientClass()
        {
            //Arrange
            string name = "Jimmy";
            ClientClass wanda = new ClientClass(name, 1);

            //Act
            StylistClass.Save(name);
            wanda.Save();
            List<ClientClass> tempList = ClientClass.GetAllClientsByStylistId(1);

            var jimmy = tempList[0];

            //Assert
           Assert.IsInstanceOfType(jimmy, typeof(ClientClass));
        }

        [TestMethod]
        public void GetClientsById_ReturnsClientList_ClientList()
        {
            //Arrange
            string name = "Jimmy";

            //Act
            StylistClass.Save(name);
            List<StylistClass> jimbo = StylistClass.FindById(1);
            int id = 0;
            foreach(StylistClass stylist in jimbo)
            {
                id = stylist.GetId();
            }
            ClientClass wanda = new ClientClass(name, id);
            wanda.Save();
            int idTwo = wanda.GetId();
            var tempList = ClientClass.GetClientsById(idTwo);

            var jimmy = tempList;

            //Assert
           Assert.IsInstanceOfType(jimmy, typeof(List<ClientClass>));
        }

        [TestMethod]
        public void DeleteClientsByStylistId_DeletesClientsByStylistId_ClientList()
        {
            //Arrange
            List<ClientClass> tempList = new List<ClientClass> {};
            string name = "Jimmy";
            int id = 1;
            ClientClass wanda = new ClientClass(name, id);

            //Act
            StylistClass.Save(name);
            wanda.Save();
            ClientClass.DeleteClientsByStylistId(1);
            List<ClientClass> tempListThree = ClientClass.GetAll();

            //Assert
           CollectionAssert.AreEqual(tempList, tempListThree);
        }
    }
}
