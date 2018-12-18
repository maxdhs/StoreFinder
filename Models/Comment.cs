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
        private int _dispensaryLicense;

        public Comment(string description, int dispensaryLicense, int id = 0)
        {
            _description = description;
            _dispensaryLicense = dispensaryLicense;
            _id = id;
        }

        
    }
}
