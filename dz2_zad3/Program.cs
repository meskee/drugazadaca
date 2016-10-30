using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2_zad3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var integers = new[] { 1, 2, 2, 2, 3, 3, 4, 5 };
            var data = integers.GroupBy(x => x).Distinct().ToArray();
            var strings = new string[data.Length];
            foreach(var n in data)
            {
                strings[n.Key - 1] = $"Broj {n.Key} ponavlja se {n.Count()} puta.";
                Console.Out.WriteLine(strings[n.Key - 1]);
            }
            Console.In.Read();
        }
    }
}
