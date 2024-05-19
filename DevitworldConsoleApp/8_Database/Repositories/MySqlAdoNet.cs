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
            // _connectionString = $"server=localhost;database={dbName};user={dbUserName};password={dbPassword};";
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

        // Get USER ID
        public int GetUserId(string name)
        {
            string query = $"SELECT ID FROM USER WHERE NAME = '{name}';";

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32(0);
                        }
                    }
                }
            }

            return -1;
        }

        // Create USER table
        public void CreateUserTable()
        {
            string query = $"CREATE TABLE IF NOT EXISTS USER (ID INT PRIMARY KEY AUTO_INCREMENT, NAME VARCHAR(50), AGE INT, EMAIL VARCHAR(50));";

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("USER table created successfully.");
        }

        // Create(Insert) USER
        public void InsertUser(string name, int age, string email)
        {
            string query = $"INSERT INTO USER (NAME, AGE, EMAIL) VALUES ('{name}', {age}, '{email}');";

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("USER inserted successfully.");
        }

        // Read(SELECT) USER
        public void ReadAllUsers()
        {
            string query = $"SELECT * FROM USER;";

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader.GetInt32(0)}, NAME: {reader.GetString(1)}, AGE: {reader.GetInt32(2)}, EMAIL: {reader.GetString(3)}");
                        }
                    }
                }
            }
        }

        // Update USER
        public void UpdateUser(int id, string name, int age, string email)
        {
            string query = $"UPDATE"
                + $" USER"
                + $" SET"
                + $" NAME = '{name}',"
                + $" AGE = {age},"
                + $" EMAIL = '{email}'"
                + $" WHERE"
                + $" ID = {id};";

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("USER updated successfully.");

        }

        // Delete USER
        public void DeleteUser(int id)
        {
            string query = $"DELETE FROM USER WHERE ID = {id};";

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("USER deleted successfully.");
        }




        //public void ExecuteNonQuery(string query)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(_connectionString))
        //    {
        //        connection.Open();

        //        using (MySqlCommand command = new MySqlCommand(query, connection))
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public List<string> ExecuteQuery(string query)
        //{
        //    List<string> result = new List<string>();

        //    using (MySqlConnection connection = new MySqlConnection(_connectionString))
        //    {
        //        connection.Open();

        //        using (MySqlCommand command = new MySqlCommand(query, connection))
        //        {
        //            using (MySqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    result.Add(reader.GetString(0));
        //                }
        //            }
        //        }
        //    }

        //    return result;
        //}

    }
}
