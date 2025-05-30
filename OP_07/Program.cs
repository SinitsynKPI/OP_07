using System;
using OP_07;

namespace MyDoubleLinkedListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyDoubleLinkedList<double>();
            var random = new Random();
            Console.Write("Enter the number of elements: ");
            if (!int.TryParse(Console.ReadLine(), out int numElements) || numElements <= 0)
            {
                Console.WriteLine("Invalid number.");
                return;
            }
            Console.Write("Choose fill method (1 - random, 2 - manual): ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                for (int i = 0; i < numElements; i++)
                {
                    double value = random.NextDouble() * 100;
                    list.AddLast(value);
                }
            }
            else if (choice == "2")
            {
                for (int i = 0; i < numElements; i++)
                {
                    Console.Write($"Enter element {i + 1}: ");
                    if (double.TryParse(Console.ReadLine(), out double value))
                    {
                        list.AddLast(value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, adding 0.");
                        list.AddLast(0);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                return;
            }
            Console.WriteLine("Generated list:");
            foreach (var item in list)
            {
                Console.Write($"{item:F2} ");
            }
            Console.WriteLine();
            Console.WriteLine($"First below average: {list.FindFirstBelowAverage():F2}");
            Console.WriteLine($"Sum after max: {list.SumAfterMax():F2}");
            double threshold = 50.0;
            var aboveList = list.GetListAboveValue(threshold);
            Console.WriteLine($"New list (elements > {threshold}):");
            foreach (var item in aboveList)
            {
                Console.Write($"{item:F2} ");
            }
            Console.WriteLine();
            list.RemoveBeforeMax();
            Console.WriteLine("List after removing elements before max:");
            foreach (var item in list)
            {
                Console.Write($"{item:F2} ");
            }
            Console.WriteLine();
            Console.WriteLine("Removing element at index 0...");
            list.RemoveAt(0);
            Console.WriteLine("List after removal:");
            foreach (var item in list)
            {
                Console.Write($"{item:F2} ");
            }
            Console.WriteLine();
            Console.WriteLine("Done! Press any key to exit...");
            Console.ReadKey();
        }
    }
}
