using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class ClientClass
    {
        private int _id;
        private string _name;
        private int _stylist_id;

        public ClientClass(int id, string name, int stylist_id)
        {
            _id = id;
            _name = name;
            _stylist_id = stylist_id;
        }

        public ClientClass(string name, int stylist_id)
        {
            _name = name;
            _stylist_id = stylist_id;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetStylistId()
        {
            return _stylist_id;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients (name, stylist_id) VALUES (@ClientName , @ClientStylistId);";
            cmd.Parameters.AddWithValue("@ClientName" , this._name);
            cmd.Parameters.AddWithValue("@ClientStylistId" , this._stylist_id);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<ClientClass> GetAll()
        {
            List<ClientClass> allClients = new List<ClientClass> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                int stylist_id = rdr.GetInt32(2);
                ClientClass newClient = new ClientClass(id, name, stylist_id);
                allClients.Add(newClient);
                
            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return allClients;
        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is ClientClass))
            {
                return false;
            }
            else
            {
                ClientClass newClient = (ClientClass) otherClient;
                bool nameEquality = (this.GetName() == newClient.GetName());
                return (nameEquality);
            }
        }

        public static List<ClientClass> GetAllClientsByStylistId(int id)
        {
            List<ClientClass> allClients = new List<ClientClass> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = " + id + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int idz = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                int stylist_id = rdr.GetInt32(2);
                ClientClass newClient = new ClientClass(idz, name, stylist_id);
                allClients.Add(newClient);
                
            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return allClients;
        }

        public static ClientClass GetClientById(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE id = " + id + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            int idz = 0;
            string name = "Client Does Not Exist";
            int stylist_id = 0;
            while(rdr.Read())
            {
                idz = rdr.GetInt32(0);
                name = rdr.GetString(1);
                stylist_id = rdr.GetInt32(2);
            }
            conn.Close();
            ClientClass newClient = new ClientClass(idz, name, stylist_id);
            if (conn !=null)
            {
                conn.Dispose();
            }
            return newClient;
        }

        public static void DeleteClientsByStylistId(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients WHERE stylist_id = " + id + ";";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void Delete(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients WHERE id = " + id + ";";

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
            cmd.CommandText = @"UPDATE clients SET name = '" + name + "' WHERE id = " + id + ";";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void UpdateStylist(int id, int stylistId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE clients SET stylist_id = " + stylistId + " WHERE id = " + id + ";";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}