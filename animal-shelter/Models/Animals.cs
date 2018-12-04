using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using csharpanimalshelter;

namespace csharpanimalshelter.Models
{
    public class Animals
    {

        // private int _id;
        private string _type;
        private string _name;
        private string _breed;
        private string _date;

        public Animals(string type, string name, string breed, string date)
        {
            _type = type;
            _name = name;
            _breed = breed;
            _date = date;
        }

        public string GetAnimalType()
        {
            return _type;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetBreed()
        {
            return _breed;
        }

        public string GetDate()
        {
            return _date;
        }
    

          public static List<Animals> GetAll()
          { 
            //  Animals dummyAnimal = new Animals("dog","fluffy","malamute","2007-03-03"); 
             List<Animals> allAnimals = new List<Animals>{};
             MySqlConnection conn = DB.Connection();
             conn.Open();
             var cmd = conn.CreateCommand() as MySqlCommand;
             cmd.CommandText = @"SELECT * FROM animal_shelter;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int animalId = rdr.GetInt32(0);
                string animalType = rdr.GetString(1);
                string animalName = rdr.GetString(2);
                string animalBreed = rdr.GetString(3);
                string animalDate = rdr.GetString(4);

                Animals newAnimal = new Animals(animalType, animalName, animalBreed, animalDate);
                allAnimals.Add(newAnimal);
            }
             conn.Close();
             if (conn != null)
              {
                conn.Dispose();
              }
              return allAnimals;
          }   
          
        public static List<Animals> GetByType(string type)
          { 
            //  Animals dummyAnimal = new Animals("dog","fluffy","malamute","2007-03-03"); 
             List<Animals> allAnimalsByType = new List<Animals>{};
                // allAnimalsByType = allAnimalsByType.Sort();

             MySqlConnection conn = DB.Connection();
             conn.Open();
             var cmd = conn.CreateCommand() as MySqlCommand;
             cmd.CommandText = @"SELECT * FROM animal_shelter WHERE type = '" + type + "';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int animalId = rdr.GetInt32(0);
                string animalType = rdr.GetString(1);
                string animalName = rdr.GetString(2);
                string animalBreed = rdr.GetString(3);
                string animalDate = rdr.GetString(4);

                Animals newAnimal = new Animals(animalType, animalName, animalBreed, animalDate);
                allAnimalsByType.Add(newAnimal);  
            }
             List<Animals> sortedList = allAnimalsByType.OrderBy(x => x._name).ToList();

             conn.Close();
             if (conn != null)
              {
                conn.Dispose();
              }
              return sortedList;
          }   
         public static Animals GetAnimal(string name)
         {
            //  Animals dummyAnimal = new Animals("dog","fluffy","malamute","2007-03-03"); 
             List<Animals> allAnimals = new List<Animals>{};
             MySqlConnection conn = DB.Connection();
             conn.Open();
             var cmd = conn.CreateCommand() as MySqlCommand;
             cmd.CommandText = @"SELECT * FROM animal_shelter WHERE name = '" + name + "';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            string animalType="";
            string animalName="";
            string animalBreed="";
            string animalDate="";

            Animals tempAnimal = new Animals(animalType, animalName, animalBreed, animalDate);
            while(rdr.Read())
            {
               
                animalType = rdr.GetString(1);
                animalName = rdr.GetString(2);
                animalBreed = rdr.GetString(3);
                animalDate = rdr.GetString(4);
                
                
                // allAnimals.Add(newAnimal);
            }
            Animals newAnimal = new Animals(animalType, animalName, animalBreed, animalDate);
            return newAnimal;
             conn.Close();
             if (conn != null)
              {
                conn.Dispose();
              }
              return newAnimal;
         }


    
         public static Animals Find(int searchId)
        {
               // Temporarily returning dummy item to get beyond compiler errors, until we refactor to work with database.
               Animals dummyAnimal = new Animals("dog","fluffy","malamute","2007-03-03");
               return dummyAnimal;
        }

          public int GetId()
        {
    // Temporarily returning dummy id to get beyond compiler errors, until we refactor to work with database.
       return 0;
        }            


         public static void ClearAll()
          {
             MySqlConnection conn = DB.Connection();
             conn.Open();
             var cmd = conn.CreateCommand() as MySqlCommand;
             cmd.CommandText = @"DELETE FROM animal_shelter;";
             cmd.ExecuteNonQuery();
             conn.Close();
             if (conn != null)
              {
                conn.Dispose();
              }
          }

          public override bool Equals(System.Object otherItem)
            {
                if (!(otherItem is Animals))
                {
                    return false;
                }
                else
                {
                    Animals newItem = (Animals) otherItem;
                    bool descriptionEquality = (this.GetName() == newItem.GetName());
                    return (descriptionEquality);
                }
            }

        public void Save()
            {
                MySqlConnection conn = DB.Connection();
                conn.Open();
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"INSERT INTO animal_shelter (type, name, breed, date) VALUES (@animaltype, @animalname, @animalbreed, @animaldate);";
                
                MySqlParameter type = new MySqlParameter();
                type.ParameterName = "@animaltype";
                type.Value = this._type;
                cmd.Parameters.Add(type);

                MySqlParameter name = new MySqlParameter();
                name.ParameterName = "@animalname";
                name.Value = this._name;
                cmd.Parameters.Add(name);

                MySqlParameter breed = new MySqlParameter();
                breed.ParameterName = "@animalbreed";
                breed.Value = this._breed;
                cmd.Parameters.Add(breed);

                MySqlParameter date = new MySqlParameter();
                date.ParameterName = "@animaldate";
                date.Value = this._date;
                cmd.Parameters.Add(date);

                
                cmd.ExecuteNonQuery();
                // more logic will go here in a moment

                conn.Close();
                if (conn != null)
                {
                    conn.Dispose();
                }
            }

        //   public override bool Equals(System.Object otherKitten)
        //     {
        //         if (!(otherKitten is Animals))
        //         {
        //         return false;
        //         }
        //         else
        //         {
        //         Animals newKitten = (Animals) otherKitten;
        //         return this.GetName().Equals(newKitten.GetName());
        //         }
        //     }

        //     public override int GetHashCode()
        //     {
        //         return this.GetName().GetHashCode();
        //     }
    }
}
