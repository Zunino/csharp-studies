/**
 * Based on https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite
 *
 * Andre Zunino <neyzunino@gmail.com>
 * 10 July 2019
 */

using System;

namespace _09_ef_core
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new GamesDbContext())
            {
                var rockstar = new Publisher {
                    Name = "Rockstar Games",
                    Country = "USA"
                };

                var gtav = new Game {
                    Title = "Grand Theft Auto V",
                    Year = 2013
                };

                var rdr2 = new Game {
                    Title = "Red Dead Redemption 2",
                    Year = 2018
                };

                rockstar.Games.Add(gtav);
                rockstar.Games.Add(rdr2);

                db.Publishers.Add(rockstar);
                var count = db.SaveChanges();
                Console.WriteLine("{0} records(s) saved to the database", count);

                foreach (var publisher in db.Publishers)
                {
                    Console.WriteLine("Publisher [ID: {0}]: {1} ({2})", publisher.PublisherId, publisher.Name, publisher.Country);
                    var games = publisher.Games;
                    if (games.Count == 0)
                    {
                        Console.WriteLine("  <No games>");
                        continue;
                    }
                    foreach (var game in games)
                    {
                        Console.WriteLine("  * {0} ({1})", game.Title, game.Year);
                    }
                }
            }
        }
    }
}
