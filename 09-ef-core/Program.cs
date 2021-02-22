/**
 * Based on https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite
 *
 * Check if dotnet-ef is already installed
 * dotnet tool list --global
 *
 * Install it, if needed
 * dotnet tool install --global dotnet-ef
 *
 * Setup migrations
 * dotnet ef migrations add InitialCreate
 *
 * Create database and apply migrations
 * dotnet ef database update
 *
 * Drop database
 * dotnet ef database drop
 *
 * Andre Zunino <neyzunino@gmail.com>
 * 10 July 2019
 * Modified 21 February 2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace _09_ef_core
{
    internal static class Program
    {
        static void InsertData()
        {
            using (var db = new GamesDbContext())
            {
                var rockstar = new Publisher {
                    Name = "Rockstar Games",
                    Country = "USA"
                };

                var twok = new Publisher {
                    Name = "2K Games",
                    Country = "USA"
                };

                var bully = new Game {
                    Title = "Bully",
                    Year = 2005
                };

                var rdr = new Game {
                    Title = "Red Dead Redemption",
                    Year = 2010
                };

                var gtav = new Game {
                    Title = "Grand Theft Auto V",
                    Year = 2013
                };

                var rdr2 = new Game {
                    Title = "Red Dead Redemption 2",
                    Year = 2018
                };

                var bioshock = new Game {
                    Title = "Bioshock",
                    Year = 2007
                };

                var bioshock2 = new Game {
                    Title = "Bioshock 2",
                    Year = 2010
                };

                var bioshockInfinite = new Game {
                    Title = "Bioshock Infinite",
                    Year = 2013
                };

                rockstar.Games.Add(bully);
                rockstar.Games.Add(rdr);
                rockstar.Games.Add(gtav);
                rockstar.Games.Add(rdr2);

                twok.Games.Add(bioshock);
                twok.Games.Add(bioshock2);
                twok.Games.Add(bioshockInfinite);

                db.Publishers.Add(rockstar);
                db.Publishers.Add(twok);

                var count = db.SaveChanges();
                Console.WriteLine("{0} records(s) saved to the database", count);
            }
        }

        private static void Main(string[] args)
        {
            using (var db = new GamesDbContext())
            {
                if (db.Publishers.Count() == 0)
                {
                    Console.WriteLine("The database looks empty; inserting sample data...");
                    InsertData();
                }
                Console.WriteLine("Listing games from 2010 on, by publisher:");
                var publishers = db.Publishers
                    .Select(p => new
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Country = p.Country,
                        Games = p.Games.Where(g => g.Year >= 2010).ToList()
                    })
                    .ToList();
                
                foreach (var publisher in publishers)
                {
                    Console.WriteLine($"Publisher [ID: {publisher.Id}]: {publisher.Name} ({publisher.Country})");
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
