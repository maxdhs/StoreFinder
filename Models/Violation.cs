using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Weed;

namespace Weed.Models
{
    public class Violation
    {
        private int _license;
        private string _violationType;
        private string _caseNumber;
    
    public Violation(int license, string violationType, string caseNumber)
    {
        _license = license;
        _violationType = violationType;
        _caseNumber = caseNumber;
    }

    public static int ViolationCount(int license)
         {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM violations WHERE license = (@searchlicense);";
            MySqlParameter searchlicense = new MySqlParameter();
            searchlicense.ParameterName = "@searchlicense";
            searchlicense.Value = license;
            cmd.Parameters.Add(searchlicense);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int licenseNumber = 0;
            string ViolationType = "";
            string caseNumber = "";

            while(rdr.Read())
            {
                licenseNumber = rdr.GetInt32(0);
                ViolationType = rdr.GetString(5);
                caseNumber =rdr.GetString(3);
            }

            List<Violation> foundViolations = new List<Violation> ();
            Violation newViolation = new Violation(licenseNumber, ViolationType, caseNumber);
            foundViolations.Add(newViolation);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundViolations.Count;
        }
    }
}
    