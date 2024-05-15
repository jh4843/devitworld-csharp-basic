using System;
using UseDatabase.Repositories;

namespace UseDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlAdoNet mySqlAdoNet = new MySqlAdoNet("devitworld_db", "root", "Devitworld!!!!");

            mySqlAdoNet.TestConnection();


            Console.WriteLine("Finish the Database Tutorial !!");
        }
    }
}