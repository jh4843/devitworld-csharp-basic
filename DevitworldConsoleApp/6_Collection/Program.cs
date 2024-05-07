using System;

namespace Collection
{
    enum Day { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };

    struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Array Example
            Console.WriteLine("\r\n## Array Example ##");
            int[] numbers = new int[3];
            numbers[0] = 2;
            numbers[1] = 4;
            numbers[2] = 6;
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            // List Example
            Console.WriteLine("\r\n## List Example ##");
            List<string> fruits = new List<string>();
            fruits.Add("Apple");
            fruits.Add("Banana");
            fruits.Add("Cherry");
            foreach (string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }

            // Queue Example
            Console.WriteLine("\r\n## Queue Example ##");
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            // Stack Example
            Console.WriteLine("\r\n## Stack Example ##");
            Stack<string> stack = new Stack<string>();
            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");
            
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            // Set Example
            Console.WriteLine("\r\n## Set Example ##");
            HashSet<int> numbersSet = new HashSet<int>();
            numbersSet.Add(1);
            numbersSet.Add(1); // Ignore duplicate value
            numbersSet.Add(2);
            foreach (int number in numbersSet)
            {
                Console.WriteLine(number);
            }

            // Dictionary Example (=Hash Table)
            Console.WriteLine("\r\n## Dictionary Example ##");
            Dictionary<string, string> capitals = new Dictionary<string, string>();
            capitals.Add("France", "Paris");
            capitals.Add("Italy", "Rome");
            capitals.Add("Japan", "Tokyo");
            foreach (KeyValuePair<string, string> item in capitals)
            {
                Console.WriteLine($"The capital of {item.Key} is {item.Value}");
            }

            // Enum Example
            Console.WriteLine("\r\n## Enum Example ##");
            Day today = Day.Wednesday;
            Console.WriteLine($"Today is {today} {((int)today)}");

            // Structure Example
            Console.WriteLine("\r\n## Structure Example ##");
            Point point = new Point(10, 20);
            Console.WriteLine($"Point Coordinates X: {point.X}, Y: {point.Y}");

            // LINQ Example
            // LINQ (Query Syntax) Example
            Console.WriteLine("\r\n## LINQ Example (Query Syntax) ##");
            int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var evenNumbers = from num in nums
                              where num % 2 == 0
                              select num;

            foreach (var num in evenNumbers)
            {
                Console.WriteLine(num); // Outputs even numbers: 0, 2, 4, 6, 8
            }

            // LINQ (Method Syntax) Example
            Console.WriteLine("\r\n## LINQ Example (Method Syntax) ##");
            var oddNumbers = nums.Where(n => n % 2 == 1);
            foreach (var num in oddNumbers)
            {
                Console.WriteLine(num); // Outputs odd numbers: 1, 3, 5, 7, 9
            }
        }
    }
}