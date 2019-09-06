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

        struct Studio {
            internal int Id;
            internal string Name;
        }

        struct Game {
            internal int StudioId;
            internal string Title;
            internal int Year;
            internal int MinAge;
        }

        struct GameInfo {
            internal string Title;
            internal string StudioName;
            internal int Year;
        }

        static void PlayWithCollections()
        {
            IEnumerable<Studio> studios = new List<Studio>
            {
                new Studio { Id = 1, Name = "Rockstar Games" },
                new Studio { Id = 2, Name = "CD Projekt Red" },
                new Studio { Id = 3, Name = "Naughty Dog" },
                new Studio { Id = 4, Name = "Insomniac Games" },
                new Studio { Id = 5, Name = "Mojang" },
                new Studio { Id = 6, Name = "Bethesda Softworks" },
                new Studio { Id = 7, Name = "Infinity Ward" }
            };

            IEnumerable<Game> games = new List<Game>
            {
                new Game { StudioId = 1, Title = "Red Dead Redemption", Year = 2010, MinAge = 18 },
                new Game { StudioId = 2, Title = "Witcher 3", Year = 2015, MinAge = 18 },
                new Game { StudioId = 3, Title = "The Last of Us", Year = 2013, MinAge = 18 },
                new Game { StudioId = 4, Title = "Ratchet and Clank", Year = 2009, MinAge = 10 },
                new Game { StudioId = 3, Title = "Uncharted: Drake's Fortune", Year = 2008, MinAge = 14 },
                new Game { StudioId = 7, Title = "Call of Duty: Modern Warfare", Year = 2009, MinAge = 16 },
                new Game { StudioId = 5, Title = "Minecraft", Year = 2016, MinAge = 10 },
                new Game { StudioId = 6, Title = "Fallout 4", Year = 2015, MinAge = 18 },
                new Game { StudioId = 6, Title = "Skyrim", Year = 2014, MinAge = 18 },
                new Game { StudioId = 1, Title = "Grand Theft Auto V", Year = 2013, MinAge = 18 }
            };

            var kidsGames =
                from game in games
                where game.MinAge <= 10
                join studio in studios on game.StudioId equals studio.Id
                orderby game.Year
                select new GameInfo {
                    Title = game.Title,
                    StudioName = studio.Name,
                    Year = game.Year
                };

            var teenGames =
                from game in games
                where game.MinAge > 10 && game.MinAge <= 16
                join studio in studios on game.StudioId equals studio.Id
                orderby game.Year
                select new GameInfo {
                    Title = game.Title,
                    StudioName = studio.Name,
                    Year = game.Year
                };

            // Using method syntax
            var adultGames = games
                .Where(game => game.MinAge > 16)
                .Join(
                    studios,
                    game => game.StudioId,
                    studio => studio.Id,
                    (game, studio) => new GameInfo {
                        Title = game.Title,
                        StudioName = studio.Name,
                        Year = game.Year
                    })
                .OrderBy(game => game.Year);

            Print(kidsGames, "Kids Games");
            Print(teenGames, "Teen Games");
            Print(adultGames, "Adult Games");
        }

        static void Print(IEnumerable<GameInfo> gameInfos, string description)
        {
            Console.WriteLine($"== {description}");
            foreach (var gameInfo in gameInfos)
            {
                Console.WriteLine($"  - {gameInfo.Title} ({gameInfo.StudioName}, {gameInfo.Year})");
            }
        }

        static void Main(string[] args)
        {
            //PlayWithIteratorMethods();
            PlayWithCollections();
        }
    }
}
