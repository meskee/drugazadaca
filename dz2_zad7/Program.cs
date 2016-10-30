using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Zad7
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var task = Task.Run(() => MainAsync());
            Task.WaitAll(task);

            Console.Read();
        }

        private static async void MainAsync()
        {
            Console.WriteLine(await FactorialDigitSum(1));
            Console.WriteLine(await FactorialDigitSum(2));
            Console.WriteLine(await FactorialDigitSum(4));
            Console.WriteLine(await FactorialDigitSum(8));
            Console.WriteLine(await FactorialDigitSum(16));
        }

        public static async Task<long> FactorialDigitSum(int num)
        {
            Task<int> task = Task.Run(() => (GetFactorial(num).ToString().Sum(c => c - '0')));
            await task;
            return task.Result;
        }

        static long GetFactorial(int num)
        {
            long result = num;
            for (var i = 1; i < num; i++)
                result = result * i;
            return result;
        }
    }
}
