using System;
using System.Threading.Tasks;

/**
 * INSTRUCTIONS:
 *  1. Modify the codes below and make it asynchronous
 *  2. After your modification, explain what makes it asynchronous
**/


namespace asynchronous_assessment_lm
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var coffee = PrepareCoffee();
            var juice = PrepareOrangeJuice();
            var eggs = PrepareEgg(2);
            var bacons = PrepareBacon(3);
            var toasts = PrepareToast(2);
            await Task.WhenAll( eggs, bacons, toasts, coffee, juice);
            Console.WriteLine("Breakfast is ready!");
        }

        private static Task<Coffee> PrepareCoffee()
        {
            var coffee = PourCoffee();
            Console.WriteLine("Coffee is ready");
            return Task.FromResult(coffee);

        }

        private static Task<Juice> PrepareOrangeJuice() 
        {
            var juice = PourOJ();
            Console.WriteLine("Orange juice is ready");
            return Task.FromResult(juice);
        }

        private static async Task PrepareEgg(int count)
        {
            await FryEggs(count);
            Console.WriteLine("Eggs are ready");
        }
        private static async Task PrepareBacon(int slices)
        {
            await FryBacon(slices);
            Console.WriteLine("Bacon is ready");
        }

        private static async Task PrepareToast(int slices)
        {
            var toast = await ToastBread(slices);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");
        }
        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> ToastBread(int slices)
        {
            for (var slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (var slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);


            return new Bacon();
        }

        private static async Task<Egg> FryEggs(int count)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {count} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        private class Coffee
        {
        }

        private class Egg
        {
        }

        private class Bacon
        {
        }

        private class Toast
        {
        }

        private class Juice
        {
        }
    }
}
