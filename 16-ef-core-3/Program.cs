using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using FluentMigrator.Runner;

namespace _16_ef_core_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //UpdateMigrations();
            QueryVideos();
        }

        private static void UpdateMigrations()
        {
            var serviceProvider = CreateServices();
            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        private static void QueryVideos()
        {
            using (var db = new VideoContext())
            {
                var videos = db.Videos.ToList();
                foreach (var v in videos)
                {
                    Console.WriteLine($"{v.Description} [{v.Id}]");
                    if (v.Transcription != null) {
                        Console.WriteLine($"\tTranscription: \"{v.Transcription.Text}\"");
                    } else {
                        Console.WriteLine("\tTranscription: N/A");
                    }
                }
            }
        }

        private static void SetUpServices()
        {
            // var services = new ServiceCollection()
            //     .AddDb
        }
        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLite support to FluentMigrator
                    //.AddSQLite()
                    // Set the connection string
                    // .WithGlobalConnectionString("Data Source=videos.db")
                    .AddPostgres()
                    .WithGlobalConnectionString("User ID=user;Password=pass;Host=localhost;Port=5432;Database=postgres;")
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(AddVideoTable).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }
    }
}
