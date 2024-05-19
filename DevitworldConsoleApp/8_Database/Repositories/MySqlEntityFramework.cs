using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UseDatabase.Model;
using Microsoft.EntityFrameworkCore;

namespace UseDatabase.Repositories
{
    // Example class for Entity Framework with MySQL
    public class MySqlEntityFramework : DbContext
    {
        public DbSet<User> User { get; set; }

        private readonly string _connectionString;

        public MySqlEntityFramework(string dbName, string dbUserName, string dbPassword)
        {
            _connectionString = $"server=localhost;database={dbName};user={dbUserName};password={dbPassword};";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectionString, new MySqlServerVersion(new Version(8, 0, 36)));
        }

        // Get User ID with Name
        public int GetUserId(string name)
        {
            User user = User.FirstOrDefault(u => u.Name == name);
            return user != null ? user.Id : -1;
        }

        // Create Table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User"); // 테이블 이름 설정

                entity.HasKey(e => e.Id); // 기본 키 설정

                entity.Property(e => e.Name)
                      .IsRequired() // 필수 필드
                      .HasMaxLength(50); // 최대 길이

                entity.Property(e => e.Email)
                      .HasMaxLength(100); // 최대 길이

                entity.Property(e => e.Age)
                      .IsRequired();
            });

            Console.WriteLine("Table Created !!");
        }

        // Exmaples of CRUD operations
        // 1. Create
        public void CreateUser(string name, int age, string email)
        {
            User user = new User
            {
                Name = name,
                Age = age,
                Email = email
            };

            User.Add(user);
            SaveChanges();
        }

        // 2. Read
        public List<User> GetUsers()
        {
            return User.ToList();
        }

        // 3. Update
        public void UpdateUser(int id, string name, int age, string email)
        {
            User user = User.Find(id);
            if (user != null)
            {
                user.Name = name;
                user.Age = age;
                user.Email = email;
                SaveChanges();
            }
        }

        // 4. Delete
        public void DeleteUser(int id)
        {
            User user = User.Find(id);
            if (user != null)
            {
                User.Remove(user);
                SaveChanges();
            }
        }
    }
}
