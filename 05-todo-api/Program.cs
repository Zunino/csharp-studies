/**
 * https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.2&tabs=visual-studio-code
 *
 * Andre Zunino <ney.zunino@softplan.com.br>
 * Created 11 June 2019
 * Updated 16 August 2021 (dotnet2.2 -> dotnet5)
 */

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DotnetStudies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
