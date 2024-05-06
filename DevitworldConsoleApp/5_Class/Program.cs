using System;

namespace ClassOOP
{
    public class Animal
    {
        // 필드
        public string Name;
        private int _age;

        // 생성자
        public Animal(string name, int age)
        {
            Name = name;
            _age = age;
        }

        public int Age
        {
            get { return _age; }
            set { _age = value > 0 ? value : 0; } // 나이는 0 이상만 가능
        }

        // 메서드
        public void Speak()
        {
            Console.WriteLine("This animal makes a sound.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // example for basic class usage
            Animal cat = new Animal("Kitty", 3);

            cat.Age = -2; // Age is lower than 0, so it will be set to 0

            cat.Speak();
            Console.WriteLine($"Name: {cat.Name}, Age: {cat.Age}");
        }
    }
}