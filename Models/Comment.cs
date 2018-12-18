using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Weed;

namespace Weed.Models
{
    public class Comment
    {
        private int _id;
        private string _description;
        private int _stars;
        private int _dispensaryLicense;

        public Comment(string description, int stars, int dispensaryLicense, int id = 0)
        {
            _description = description;
            _stars = stars;
            _dispensaryLicense = dispensaryLicense;
            _id = id;
        }

        public string GetDescription()
        {
          return _description;  
        }

        public int GetId()
        {
          return _id;  
        }

        public int GetStars()
        {
          return _stars;  
        }


        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO comments (description, stars, dispensaryLicense) VALUES (@description, @stars, @dispensaryLicense);";

            MySqlParameter description = new MySqlParameter();
            description.ParameterName = "@description";
            description.Value = this._description;
            cmd.Parameters.Add(description);

            MySqlParameter stars = new MySqlParameter();
            stars.ParameterName = "@stars";
            stars.Value = this._stars;
            cmd.Parameters.Add(stars);

            MySqlParameter dispensaryLicense = new MySqlParameter();
            dispensaryLicense.ParameterName = "@dispensaryLicense";
            dispensaryLicense.Value = this._dispensaryLicense;
            cmd.Parameters.Add(dispensaryLicense);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Comment> GetAll()
        {
            List<Comment> allComments = new List<Comment> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM comments;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string description = rdr.GetString(1);
                int stars = rdr.GetInt32(2);
                int dispensaryLicense = rdr.GetInt32(3);
                
                Comment newComment = new Comment(description, stars, dispensaryLicense, id);
                allComments.Add(newComment);
            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return allComments;
        }

        public static List<Comment> GetCommentsByLicense(int license)
        {
            List<Comment> allComments = new List<Comment> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM comments WHERE dispensaryLicense = " + license + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string description = rdr.GetString(1);
                int stars = rdr.GetInt32(2);
                int dispensaryLicense = rdr.GetInt32(3);
                
                Comment newComment = new Comment(description, stars, dispensaryLicense, id);
                allComments.Add(newComment);
            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return allComments;
        }
    }
}