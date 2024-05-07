using System;

namespace Collection
{
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

            // 스택 요소 출력 및 제거
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

        }
    }
}