using System;
using System.Collections.Generic;
using System.Linq;

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
        static IEnumerable<string> Tones()
        {
            yield return "LIGHT";
            yield return "DARK";
        }
        static void Main(string[] args)
        {
            foreach (var color in Colors())
            {
                Console.WriteLine(color);
            }

            var allTones =
                from c in Colors()
                from t in Tones()
                select new { Color = c, Tone = t };
            foreach(var t in allTones)
            {
                Console.WriteLine(t);
            }
        }
    }
}
