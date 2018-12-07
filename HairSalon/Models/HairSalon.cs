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

        public static List<StylistClass> FindById(int id)
        {
            List<StylistClass> stylistList = new List<StylistClass> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE id = " + id + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int idz = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                StylistClass newStylist = new StylistClass(idz, name);
                stylistList.Add(newStylist);
                
            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return stylistList;
        }
    }

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
    }
}
