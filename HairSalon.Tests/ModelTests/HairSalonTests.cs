using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;
using System.IO;
 
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
        public void FindById_ReturnsStylistList_Stylist()
        {
            //Arrange
            string name = "Jimmy";

            //Act
            StylistClass.Save(name);
            StylistClass temp = StylistClass.FindById(1);

            StylistClass jimmy = new StylistClass("dog");
            jimmy = temp;

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
        public void GetClientsById_ReturnsClientList_Client()
        {
            //Arrange
            string name = "Jimmy";

            //Act
            StylistClass.Save(name);
            StylistClass jimbo = StylistClass.FindById(1);
            int id = 0;
            id = jimbo.GetId();
            ClientClass wanda = new ClientClass(name, id);
            wanda.Save();
            int idTwo = wanda.GetId();
            var tempList = ClientClass.GetClientById(idTwo);

            var jimmy = tempList;

            //Assert
           Assert.IsInstanceOfType(jimmy, typeof(ClientClass));
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

        [TestMethod]
        public void Update_EditsStylistName_String()
        {
            //Arrange
            string name = "Jimmy";
            string nameTwo = "Jimbo";

            //Act
            StylistClass.Save(name);
            StylistClass jimmy = StylistClass.FindByName(name);
            int id = jimmy.GetId();
            StylistClass.UpdateName(id, nameTwo);
            StylistClass jimbo = StylistClass.FindById(id);
            string nameThree = jimbo.GetName();
            //Assert
           Assert.AreEqual(nameTwo, nameThree);
        }

        [TestMethod]
        public void Update_EditsClientName_String()
        {
            //Arrange
            string name = "Jimmy";
            string nameTwo = "Jimbo";
            StylistClass.Save(name);
            StylistClass stylist = StylistClass.FindByName("Jimmy");
            int stylistId = stylist.GetId();
            ClientClass jimbo = new ClientClass(nameTwo, stylistId);
            jimbo.Save();
            string newClientName = "Harold";

            //Act
            List<ClientClass> newJimbo = ClientClass.GetAllClientsByStylistId(stylistId);
            int clientId = newJimbo[0].GetId();
            ClientClass.UpdateName(clientId, newClientName);
            List<ClientClass> newJimboAgain = ClientClass.GetAllClientsByStylistId(stylistId);
            //Assert
           Assert.AreEqual(newJimboAgain[0].GetName(), newClientName);
        }

        [TestMethod]
        public void Update_EditsClientStylist_String()
        {
            //Arrange
            string name = "Jimmy";
            string nameOne = "Sarah";
            string nameTwo = "Jimbo";

            StylistClass.Save(name);
            StylistClass.Save(nameOne);
            
            StylistClass stylist = StylistClass.FindByName("Jimmy");
            int stylistId = stylist.GetId();
            ClientClass jimbo = new ClientClass(nameTwo, stylistId);
            jimbo.Save();
            StylistClass sarah = StylistClass.FindByName("Sarah");
            int stylistTwoId = sarah.GetId();

            //Act
            List<ClientClass> newJimbo = ClientClass.GetAllClientsByStylistId(stylistId);
            int clientId = newJimbo[0].GetId();
            ClientClass.UpdateStylist(clientId, stylistTwoId);
            List<ClientClass> newJimboAgain = ClientClass.GetAllClientsByStylistId(stylistTwoId);
            //Assert
           Assert.AreEqual(newJimboAgain[0].GetStylistId(), stylistTwoId);
        }

        [TestMethod]
        public void SaveAndGetAll_Speciality_Speciality()
        {
            //Arrange
            string speciality = "50s Style";
            SpecialityClass.Save(speciality);

            //Act
            List<SpecialityClass> specialities = SpecialityClass.GetAll();

            //Assert
           Assert.AreEqual(speciality, specialities[0].GetSpeciality());
        }
    }
}
