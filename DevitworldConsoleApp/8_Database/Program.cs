using System;
using UseDatabase.Repositories;

namespace UseDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start the Database Tutorial !!");

            //MySqlAdoNet mySqlAdoNet = new MySqlAdoNet("devitworld_db", "root", "Devitworld!!!!");

            //mySqlAdoNet.TestConnection();
            //mySqlAdoNet.CreateUserTable();

            //mySqlAdoNet.InsertUser("devitworld", 36, "insfamworld@naver.com");
            //mySqlAdoNet.InsertUser("creamboy", 32, "creamboy1@naver.com");

            //mySqlAdoNet.ReadAllUsers();

            //mySqlAdoNet.UpdateUser(1, "devitworld", 37, "devitworld@google.com");

            //mySqlAdoNet.DeleteUser(mySqlAdoNet.GetUserId("creamboy"));

            //Console.WriteLine("Finish AdoNet Examples !!");

            using (var mySqlEntityFramework = new MySqlEntityFramework("devitworld_db", "root", "Devitworld!!!!"))
            {
                mySqlEntityFramework.Database.EnsureCreated();

                mySqlEntityFramework.CreateUser("devitworld", 36, "insfamworld@naver.com");
                mySqlEntityFramework.CreateUser("creamboy", 32, "creamboy1@naver.com");

                var users = mySqlEntityFramework.GetUsers();
                foreach (var user in users)
                {
                    Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Age: {user.Age}, Email: {user.Email}");
                }

                mySqlEntityFramework.UpdateUser(1, "devitworld", 37, "devitworld@google.com");

                mySqlEntityFramework.DeleteUser(mySqlEntityFramework.GetUserId("creamboy"));
            }

            Console.WriteLine("Finish Entity Framework Examples !!");




            Console.WriteLine("Finish the Database Tutorial !!");
        }
    }
}