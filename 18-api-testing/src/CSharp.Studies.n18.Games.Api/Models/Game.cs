using System.Text.Json.Serialization;

namespace CSharp.Studies.n18.Games.Models
{
    public class Game
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("year")]
        public int Year { get; set; }
    }
}