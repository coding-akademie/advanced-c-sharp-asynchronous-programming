using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {

        async static Task<int> DoAsync()
        {
            int n = 0;

            await Task.Run(async () =>
            {
                await Task.Delay(2000);

                n = (new Random()).Next(9999);
                Console.WriteLine("DoAsync(): " + n);
            });

            return n;
        }


        async static Task Main(string[] args)
        {
            _ = DoAsync();

            Console.WriteLine("Hello!");

            int result = await DoAsync();

            Console.WriteLine("Result: " + result);

            result = await Task.Run(() =>
            {
                Console.WriteLine("Anonymous: " + 3);
                return 3;
            });

            Console.WriteLine("Result: " + result);


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int result1 = await DoAsync();
            int result2 = await DoAsync();

            stopwatch.Stop();

            Console.WriteLine("Results: " + result1 + " & " + result2 + ". Time: " + stopwatch.ElapsedMilliseconds);


            stopwatch.Restart();

            Task<int> task1 = DoAsync();
            Task<int> task2 = DoAsync();

            result1 = await task1;
            result2 = await task2;

            stopwatch.Stop();

            Console.WriteLine("Results: " + result1 + " & " + result2 + ". Time: " + stopwatch.ElapsedMilliseconds);


            Console.WriteLine("Bye!");

        }  

    }
}
