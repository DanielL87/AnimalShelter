using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using csharpanimalshelter.Models;
using System.Collections.Generic;
using System;
 
namespace csharpanimalshelter.Tests
{
  [TestClass]
  public class AnimalsTest : IDisposable
  {

    public void Dispose()
    {
      Animals.ClearAll();
    }

    public AnimalsTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=animals_test;";
    }
  

  [TestMethod]
    public void AnimalsConstructor_CreatesInstanceOfAnimal_Animal()
    {
      Animals newAnimal = new Animals("dog","fluffy","malamute","2007-03-03");
      Assert.AreEqual(typeof(Animals), newAnimal.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "fluffy";
      Animals newAnimal = new Animals("dog", name ,"malamute","2007-03-03");

      //Act
      string result = newAnimal.GetName();

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_AnimalsList()
    {
      //Arrange
      List<Animals> newList = new List<Animals> {};

      //Act
      List<Animals> result = Animals.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

  //   [TestMethod]
  //   public void GetAll_ReturnsAnimals_AnimalsList()
  // {
  //   //Arrange
  //   // string description01 = "Walk the dog";
  //   // string description02 = "Wash the dishes";
  //   Animals newAnimal1 = new Animals("dog","fluffy","malamute","2007-03-03");
  //   newAnimal1.Save();
  //   Animals newAnimal2 = new Animals("dog","fluffy","malamute","2007-03-03");
  //   newAnimal2.Save();
  //   List<Animals> newList = new List<Animals> { newAnimal1, newAnimal2 };

  //   //Act
  //   List<Animals> result = Animals.GetAll();

  //   //Assert
  //   CollectionAssert.AreEqual(newList, result);
  // }

  //   [TestMethod]
  //   public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Animals()
  //   {
  //     // Arrange, Act
  //     Animals firstAnimal = new Animals("dog","fluffy","malamute","2007-03-03");
  //     Animals secondAnimal = new Animals("dog","fluffy","malamute","2007-03-03");

  //     // Assert
  //     Assert.AreEqual(firstAnimal, secondAnimal);
  //   }

  //    [TestMethod]
  //   public void Save_SavesToDatabase_AnimalsList()
  //   {
  //     //Arrange
  //     Animals testAnimal = new Animals("dog","fluffy","malamute","2007-03-03");

  //     //Act
  //     testAnimal.Save();
  //     List<Animals> result = Animals.GetAll();
  //     List<Animals> testList = new List<Animals>{testAnimal};

  //     //Assert
  //     CollectionAssert.AreEqual(testList, result);
  //   }




    // [TestMethod]
    // public void SetDescription_SetDescription_String()
    // {
    //   //Arrange
    //   string description = "Walk the dog.";
    //   Item newItem = new Item(description);

    //   //Act
    //   string updatedDescription = "Do the dishes";
    //   newItem.SetDescription(updatedDescription);
    //   string result = newItem.GetDescription();

    //   //Assert
    //   Assert.AreEqual(updatedDescription, result);
    // }
  }
}