using System;

namespace ClassOOP
{
    public class Animal
    {
        // 필드 (Field)
        public string Name;
        private int _age;

        // 생성자 (Constructor)
        public Animal(string name, int age)
        {
            Name = name;
            _age = age;
        }

        // 속성 (Property)
        public int Age
        {
            get { return _age; }
            set { _age = value > 0 ? value : 0; } // Age is set to 0 if value is lower than 0
        }

        // 메서드 (Method)
        public virtual void Speak()
        {
            Console.WriteLine("This animal makes a sound.");
        }

        // Pattern matching example
        public void DescribeAnimal(Animal animal)
        {
            if (animal is { Name: "Lion", Age: >= 5 })
            {
                Console.WriteLine("This is an adult lion.");
            }
            else if (animal is { Name: "Lion", Age: < 5 })
            {
                Console.WriteLine("This is a young lion.");
            }
            else
            {
                Console.WriteLine("This is not a lion.");
            }
        }
    }

    // inheritance example
    public class Dog : Animal
    {
        public string Breed;  // 개의 품종

        public Dog(string name, int age, string breed) : base(name, age)
        {
            Breed = breed;
        }

        public override void Speak()
        {
            Console.WriteLine("Woof!");
        }
    }

    // record example
    public record AnimalRecord(string Name, int Age)
    {
        public int Age { get; init; } = Age > 0 ? Age : 0;

        public virtual void Speak()
        {
            Console.WriteLine("This animal makes a sound.");
        }
    }

    // null coalescing assignment example
    public class Zoo
    {
        private Animal _defaultAnimal = new Animal("Elephant", 10);

        public void ShowAnimal(Animal animal)
        {
            // Null 병합 연산자를 사용하여 null 체크
            animal ??= _defaultAnimal;
            Console.WriteLine($"This is a {animal.Name}, and it is {animal.Age} years old.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // example for basic class usage
            Console.WriteLine("\r\n## Basic class usage example ##");
            Animal cat = new Animal("Kitty", 3);
            cat.Age = -2; // Age is lower than 0, so it will be set to 0
            cat.Speak();
            Console.WriteLine($"Name: {cat.Name}, Age: {cat.Age}");

            // example for inheritance
            Console.WriteLine("\r\n## Inheritance example ##");
            Dog dog = new Dog("Puppy", 2, "Golden Retriever");
            dog.Speak();
            Console.WriteLine($"Name: {dog.Name}, Age: {dog.Age}, Breed: {dog.Breed}");

            // example for record
            Console.WriteLine("\r\n## Record example ##");
            AnimalRecord bird = new AnimalRecord("Tweety", 1);
            bird.Speak();
            Console.WriteLine($"Name: {bird.Name}, Age: {bird.Age}");
            Console.WriteLine($"Hash: {bird.GetHashCode()}, Equal: {bird.Equals(dog)}, toString(): {bird.ToString()}");

            // example for pattern matching
            Console.WriteLine("\r\n## Pattern matching example ##");
            Animal oldLion = new Animal("Lion", 10);
            Animal youngLion = new Animal("Lion", 3);
            Animal elephant = new Animal("Elephant", 15);

            oldLion.DescribeAnimal(oldLion);
            youngLion.DescribeAnimal(youngLion);
            elephant.DescribeAnimal(elephant);

            // example for null coalescing assignment
            Console.WriteLine("\r\n## Null coalescing assignment example ##");
            Zoo zoo = new Zoo();
            zoo.ShowAnimal(null);
        }
    }
}