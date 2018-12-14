using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class StylistClass
    {
        private int _id;
        public string _name;

        public StylistClass(string name)
        {
            _name = name;
        }

        public StylistClass(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
        }

        public static void Save(string _name)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (name) VALUES (@StylistName);";
            cmd.Parameters.AddWithValue("@StylistName" , _name);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<StylistClass> GetAll()
        {
            List<StylistClass> allStylists = new List<StylistClass> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                StylistClass newStylist = new StylistClass(id, name);
                allStylists.Add(newStylist);
                
            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return allStylists;
        }

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is StylistClass))
            {
                return false;
            }
            else
            {
                StylistClass newStylist = (StylistClass) otherStylist;
                bool nameEquality = (this.GetName() == newStylist.GetName());
                return (nameEquality);
            }
        }

        public static StylistClass FindById(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE id = " + id + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            int idz = 0;
            string name = "Stylist Does Not Exist";
            while(rdr.Read())
            {
                idz = rdr.GetInt32(0);
                name = rdr.GetString(1);
            }
            StylistClass newStylist = new StylistClass(idz, name);
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return newStylist;
        }

        //Something is wrong with this Search Method. Can't figure it out. Abandoning it for now, will ask about it later.
        public static StylistClass FindByName(string name)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE name = @thisName;";
            MySqlParameter thisName = new MySqlParameter();
            thisName.ParameterName = "@thisName";
            thisName.Value = name;
            cmd.Parameters.Add(thisName);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            int idz = 0;
            string namez = "";
            while(rdr.Read())
            {
                idz = rdr.GetInt32(0);
                namez = rdr.GetString(1);
            }
            StylistClass foundItem = new StylistClass(idz, namez);
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return foundItem;
        }

        public static void Delete(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists WHERE id = " + id + ";";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void UpdateName(int id, string name)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE stylists SET name = '" + name + "' WHERE id = " + id + ";";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}