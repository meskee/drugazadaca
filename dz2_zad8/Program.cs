using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2_zad8
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main method is the only method that
            // can’t be marked with async.
            // What we are doing here is just a way for us to simulate
            // async-friendly environment you usually have with
            // other .NET application types (like web apps, win apps etc.) // Ignore main method, you can just focus on
            //LetsSayUserClickedAButtonOnGuiMethod() as a
            // first method in call hierarchy.
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }

        private static void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = GetTheMagicNumber();
            Console.WriteLine(result);
        }

        private static long GetTheMagicNumber()
        {
            return IKnowIGuyWhoKnowsAGuy().Result;

        }

        private static async Task<long> IKnowIGuyWhoKnowsAGuy()
        {
            var t1 = IKnowWhoKnowsThis(10);
            var t2 = IKnowWhoKnowsThis(5);
            await Task.WhenAll(t1, t2);
            return t1.Result + t2.Result;
        }

        private static async Task<long> IKnowWhoKnowsThis(int n)
        {
            return await dz2_zad7.Program.FactorialDigitSum(n);
        }
    }
}
