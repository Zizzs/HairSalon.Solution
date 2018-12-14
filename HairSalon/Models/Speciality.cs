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

        public static void SaveSpecialtyToStylist(int stylistId, int specialityId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialities_stylists (stylist_id, speciality_id) VALUES (@Stylist_id, @Speciality_id);";
            cmd.Parameters.AddWithValue("@Stylist_id" , stylistId);
            cmd.Parameters.AddWithValue("@Speciality_id" , specialityId);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<SpecialityClass> GetAllSpecialitysByStylistId(int stylistId)
        {
            List<SpecialityClass> allSpecialities = new List<SpecialityClass> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT specialities.* FROM specialities
            JOIN specialities_stylists ON (specialities.id = specialities_stylists.speciality_id)
            JOIN stylists ON (specialities_stylists.stylist_id = stylists.id)
            WHERE stylists.id = " + stylistId + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string speciality = rdr.GetString(1);
                SpecialityClass newSpeciality = new SpecialityClass(speciality, id);
                allSpecialities.Add(newSpeciality);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allSpecialities;
        }

        public static SpecialityClass FindBySpeciality(string speciality)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialities WHERE speciality = '" + speciality + "';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            int idz = 0;
            string namez = "";
            while(rdr.Read())
            {
                idz = rdr.GetInt32(0);
                namez = rdr.GetString(1);
            }
            SpecialityClass foundItem = new SpecialityClass(namez, idz);
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return foundItem;
        }

        public static SpecialityClass FindBySpecialityId(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialities WHERE id = " + id + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            int idz = 0;
            string namez = "";
            while(rdr.Read())
            {
                idz = rdr.GetInt32(0);
                namez = rdr.GetString(1);
            }
            SpecialityClass foundItem = new SpecialityClass(namez, idz);
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return foundItem;
        }

        public static void DeleteSpecialitysByStylistId(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialities_stylists WHERE stylist_id = " + id + ";";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}