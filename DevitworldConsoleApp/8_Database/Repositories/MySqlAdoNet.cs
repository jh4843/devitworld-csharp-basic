using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace UseDatabase.Repositories
{
    public class MySqlAdoNet
    {
        private string _connectionString;

        // dbName: devitworld_db, dbUserName: root, dbPassword: devitworld!!
        public MySqlAdoNet(string dbName, string dbUserName, string dbPassword)
        {
            // Initial connection string without specifying a database
            string initialConnectionString = $"server=localhost;user={dbUserName};password={dbPassword};";

            // Check if the database exists, if not, create it
            using (var connection = new MySqlConnection(initialConnectionString))
            {
                try
                {
                    connection.Open();
                    var createDbCommand = new MySqlCommand($"CREATE DATABASE IF NOT EXISTS `{dbName}`;", connection);
                    createDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while creating the database.", ex);
                }
            }

            _connectionString = $"server=localhost;database={dbName};user={dbUserName};password={dbPassword};";
        }

        // connection test
        public void TestConnection()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    Console.WriteLine("Connection is successful.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection is failed.");
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public void ExecuteNonQuery(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<string> ExecuteQuery(string query)
        {
            List<string> result = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return result;
        }

    }
}
