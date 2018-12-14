using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class SpecialityClass
    {
        private int _id;
        private string _speciality;

        public SpecialityClass(string speciality, int id=0)
        {
            _speciality = speciality;
            _id = id;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetSpeciality()
        {
            return _speciality;
        }

        public static void Save(string speciality)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialities (speciality) VALUES (@Speciality);";
            cmd.Parameters.AddWithValue("@Speciality" , speciality);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<SpecialityClass> GetAll()
        {
            List<SpecialityClass> allSpecialities = new List<SpecialityClass> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialities;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                SpecialityClass newSpeciality = new SpecialityClass(name, id);
                allSpecialities.Add(newSpeciality);
                
            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return allSpecialities;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialities;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
        }
    }
}