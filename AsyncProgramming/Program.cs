using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //Asynchronous example
            var tasks = new List<Task> { MakeCoffeeAsync(), MakeBreakfastAsync() };
            await Task.WhenAll(tasks);

            //Synchronous example
            //MakeCoffee();
            //MakeBreakfast();

            Console.WriteLine("Everything is ready!");
            stopwatch.Stop();
            Console.WriteLine($"Time spent: {stopwatch.Elapsed.TotalSeconds}");
        }

        private static async Task MakeCoffeeAsync()
        {
            Console.WriteLine("Starting making coffee");
            Console.WriteLine("Get cups");
            Console.WriteLine($"Pour {await BoilWaterAsync()} in cups.");
            Console.WriteLine("Coffee is ready!");
        }

        private static async Task<string> BoilWaterAsync()
        {
            Console.WriteLine("Start the kettle");
            await Task.Delay(3000);
            Console.WriteLine("Water has boiled");
            return "boiled water";
        }

        private static async Task MakeBreakfastAsync()
        {
            Console.WriteLine("Starting making breakfast");
            await Task.Delay(7000);
            Console.WriteLine("Breakfast is ready!");
        }

        public static void MakeCoffee()
        {
            Console.WriteLine("Starting making coffee");
            Console.WriteLine("Get cups");
            Console.WriteLine($"Pour {BoilWater()} in cups.");
            Console.WriteLine("Coffee is ready!");
        }

        private static string BoilWater()
        {
            Console.WriteLine("Start the kettle");
            Thread.Sleep(3000);
            Console.WriteLine("Water has boiled");
            return "boiled water";
        }

        private static void MakeBreakfast()
        {
            Console.WriteLine("Make breakfast");
            Thread.Sleep(7000);
            Console.WriteLine("Breakfast is ready!");
        }
    }
}