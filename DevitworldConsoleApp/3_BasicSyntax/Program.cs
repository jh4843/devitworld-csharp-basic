using System;

namespace BasicSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////////////////////////////
            // Variables
            ///////////////////////////////////////////////
            // Variable Types
            int age = 30;
            Console.WriteLine(age);

            double temperature = 36.6;
            Console.WriteLine(temperature);

            string name = "Alice";
            Console.WriteLine(name);

            bool isCSharpFun = true;
            Console.WriteLine(isCSharpFun);

            // var keyword examples
            var vNumber = 10; // 정수
            var vName = "John Doe"; // 문자열
            var vIsCSharpFun = true; // 불리언
            var vSalary = 30000.50; // 실수

            Console.WriteLine($"Value: {vNumber}, Type: {vNumber.GetType()}");
            Console.WriteLine($"Value: {vName}, Type: {vName.GetType()}");
            Console.WriteLine($"Value: {vIsCSharpFun}, Type: {vIsCSharpFun.GetType()}");
            Console.WriteLine($"Value: {vSalary}, Type: {vSalary.GetType()}");

            // string interpolstaion examples
            var user = "Alice";
            var day = "Wednesday";
            var temp = 23.4;
            // using string interpolation
            var message = $"Hello, {user}! Today is {day}, and the temperature is {temp} degrees.";
            Console.WriteLine(message);

            ///////////////////////////////////////////////
            // Operators, Expressions, and Statements
            ///////////////////////////////////////////////
            int a = 10;
            int b = 20;
            int sum = a + b; // 
            bool isEqual = (a == b); // 비교 연산자 사용
            Console.WriteLine($"Sum: {sum}, IsEqual: {isEqual}");

            int length = 10;
            int width = 20;
            int area = length * width; // length & width variable, * is operator
            Console.WriteLine($"Area: {area}");

            ///////////////////////////////////////////////
            // Conditional Statements and Loops
            ///////////////////////////////////////////////
            ///
            // if statement
            Console.WriteLine("if statement");
            if (temperature > 30)
            {
                Console.WriteLine("It's hot outside!");
            }

            // if-else statement
            Console.WriteLine("if-else statement");
            if (temperature > 30)
            {
                Console.WriteLine("It's hot outside!");
            }
            else if (temperature < 10)
            {
                Console.WriteLine("It's cold outside!");
            }
            else
            {
                Console.WriteLine("It's a nice day!");
            }

            // switch statement
            Console.WriteLine("switch statement");
            DayOfWeek dayOfWeek = DayOfWeek.Monday;
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    Console.WriteLine("Start of a new week!");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("Weekend is near!");
                    break;
                default:
                    Console.WriteLine("It's a regular day.");
                    break;
            }

            // for loop
            Console.WriteLine("for loop");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Hello, World!");
            }

            // foreach loop
            Console.WriteLine("foreach loop");
            string[] names = { "Alice", "Bob", "Charlie" };
            foreach (string tName in names)
            {
                Console.WriteLine($"Hello, {tName}!");
            }

            // while loop
            Console.WriteLine("while loop");
            int count = 1;
            while (count <= 5)
            {
                Console.WriteLine($"Count: {count}");
                count++;
            }

            // do-while loop
            Console.WriteLine("do-while loop");
            do
            {
                Console.WriteLine($"Count: {count}");
                count++;
            } while (count <= 5);

        }
    }
}