using System;
using System.Collections.Generic;

namespace _08_iterator_methods
{
    class Program
    {
        static IEnumerable<string> Colors()
        {
            yield return "RED";
            yield return "GREEN";
            yield return "BLUE";
        }
        static void Main(string[] args)
        {
            foreach (var color in Colors())
            {
                Console.WriteLine(color);
            }
        }
    }
}
