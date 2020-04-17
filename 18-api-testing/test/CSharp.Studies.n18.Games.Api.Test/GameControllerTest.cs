using System.Collections.Generic;
using System.Linq; // IEnumerable.Count extension method
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

using Xunit;
using FluentAssertions;

using CSharp.Studies.n18.Games.Models;

namespace CSharp.Studies.n18.Games.Api.Test
{
    public class GameControllerTest
    {
        // This client and its setup could be in an abstract base class for
        // integration test classes.
        private readonly HttpClient _httpClient;

        public GameControllerTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _httpClient = appFactory.CreateClient();
        }

        [Fact]
        public async Task Test()
        {
            var response = await _httpClient.GetAsync("http://localhost:5000/game");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync();
            var games = JsonSerializer.Deserialize<IEnumerable<Game>>(content);
            games.Count().Should().Be(3);
        }
    }
}
