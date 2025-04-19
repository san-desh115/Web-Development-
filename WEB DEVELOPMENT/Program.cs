using System;
using System.Collections.Generic;
using System.Linq;
using Internal;

class Program
{
    static void Main()
    {
        List<int> numbers = GetUserInput();

        if (numbers.Count > 0)
        {
            Console.WriteLine($"Total Count: {numbers.Count}");
            Console.WriteLine($"Minimum: {numbers.Min()}");
            Console.WriteLine($"Maximum: {numbers.Max()}");
            Console.WriteLine($"Average: {numbers.Average():F2}");
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }

    static List<int> GetUserInput()
    {
        List<int> numbers = new List<int>();
        while (true)
        {
            Console.WriteLine("Enter a number (or 'x' to exit):");
            string input = Console.ReadLine();
            if (input.ToLower() == "x") break;
            if (int.TryParse(input, out int number))
                numbers.Add(number);
            else
                Console.WriteLine("Invalid input.");
        }
        return numbers;
    }
}
