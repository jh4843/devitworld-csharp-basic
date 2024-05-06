using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FunctionMethod
{
    public class Calculator
    {
        // Define Add() method with two parameters (b has a default value 10)
        public int Add(int a, int b = 10)
        {
            return a + b;
        }

        // Overloading: Multiply() method with different parameters
        public int Multiply(int x, int y)
        {
            Console.WriteLine("Multiply(int x, int y)");
            return x * y;
        }
        public double Multiply(double x, double y)
        {
            Console.WriteLine("Multiply(double x, double y)");
            return x * y;
        }

        // recursive method example
        public int Factorial(int n)
        {
            if (n <= 1) return 1; // finish condition
            return n * Factorial(n - 1); // call recursive method again
        }
    }


    public class Person
    {
        private string name;
        public Person(string name) => this.name = name; // Constructor with Expression-bodied member

        // Property with Expression-bodied member
        public string Name
        {
            get => name; // Property
            set => name = value;
        }

        public void Print() => Console.WriteLine(name); // Method with Expression-bodied member
    }

    public class Program
    {
        public static async Task<string> DownloadDataAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                else
                {
                    throw new Exception("Failed to download data.");
                }
            }
        }

        public static async Task Main(string[] args)
        {
            Calculator calc = new Calculator();
            // call Add() method
            int result = calc.Add(5, 3);
            Console.WriteLine("5 + 3 = " + result);

            // call Add() method with default value (b = 10)
            int resultDefault = calc.Add(5);
            Console.WriteLine("5 + 10 = " + resultDefault);

            // call Multiply() method (overloading)
            int result1 = calc.Multiply(5, 3);
            Console.WriteLine("5 * 3 = " + result1);

            double result2 = calc.Multiply(5.5, 3.5);
            Console.WriteLine("5.5 * 3.5 = " + result2);

            // Anonymous Method
            Func<int, int, int> add = delegate (int x, int y) { return x + y; }; // Define an anonymous method
            Console.WriteLine(add(3, 4)); // Use the anonymous method

            // call Factorial() method
            int n = 5;
            int resultFactorial = calc.Factorial(n);
            Console.WriteLine("Factorial of " + n + " is " + resultFactorial);

            // Recent C# version (C# 7.0) allows to define local function
            // 1. Local Function
            Console.WriteLine("1. Local Function");
            int AddLocal(int x, int y) => x + y; // Define a local function
            Console.WriteLine(AddLocal(3, 4)); // Call the local function

            // 2. Lambda Expression
            Console.WriteLine("2. Lambda Expression");
            Func<int, int, int> multiply = (x, y) => x * y; // Define a lambda expression
            Console.WriteLine(multiply(5, 2)); // Use the lambda expression

            // 3. Expression-bodied member
            Console.WriteLine("3. Expression-bodied member");
            Person person = new Person("Tom");
            person.Print(); // Call the Print() method

            // 4. Async Method
            try
            {
                string url = "https://www.google.com";
                string resDownload = await DownloadDataAsync(url);
                Console.WriteLine("Downloaded data:");
                Console.WriteLine(resDownload);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}