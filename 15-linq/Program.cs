/**
 * Playing with Linq in different scenarios.
 * https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/working-with-linq
 *
 * Andre Zunino <neyzunino@gmail.com>
 * 5 September 2019
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace _15_linq
{
    class Program
    {
        // Iterator method
        static IEnumerable<string> Names()
        {
            yield return "Pacheco";
            yield return "Anderson";
        }

        // Iterator method
        static IEnumerable<string> Adjectives()
        {
            yield return "dumb";
            yield return "retarded";
            yield return "gay";
        }

        static void PlayWithIteratorMethods()
        {
            var combos =
                from name in Names()
                from adjective in Adjectives()
                select new { Name = name, Adjective = adjective };

            foreach (var combo in combos)
            {
                Console.WriteLine($"{combo.Name} is {combo.Adjective}");
            }
        }

        struct Game {
            internal string Title;
            internal int Year;
            internal int MinAge;
        }

        static void PlayWithCollections()
        {
            IEnumerable<Game> games = new List<Game>
            {
                new Game { Title = "Red Dead Redemption", Year = 2010, MinAge = 18 },
                new Game { Title = "The Last of Us", Year = 2013, MinAge = 18 },
                new Game { Title = "Ratchet and Clank", Year = 2009, MinAge = 10 },
                new Game { Title = "Uncharted: Drake's Fortune", Year = 2008, MinAge = 14 }
            };

            var kidsGames = from game in games where game.MinAge <= 10 select game;
            var teenGames = from game in games where game.MinAge <= 16 select game;
            var adultGames = from game in games where game.MinAge > 16 select game;

            Print(kidsGames, "Kids Games");
            Print(teenGames, "Teen Games");
            Print(adultGames, "Adult Games");
        }

        static void Print(IEnumerable<Game> games, string description)
        {
            Console.WriteLine($"== {description}");
            foreach (var game in games)
            {
                Console.WriteLine($"  - {game.Title} ({game.Year})");
            }
        }

        static void Main(string[] args)
        {
            //PlayWithIteratorMethods();
            PlayWithCollections();
        }
    }
}
