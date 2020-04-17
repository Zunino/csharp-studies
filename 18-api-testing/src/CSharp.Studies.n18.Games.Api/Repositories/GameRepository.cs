using System.Collections.Generic;
using System.Linq;
using CSharp.Studies.n18.Games.Models;

namespace CSharp.Studies.n18.Games.Repositories
{
    public class GameRepository
    {
        private readonly IEnumerable<Game> _data = new List<Game>
            {
                new Game {
                    Id = 1,
                    Title = "Leisure Suit Larry",
                    Year = 1987
                },
                new Game {
                    Id = 2,
                    Title = "Grand Theft Auto V",
                    Year = 2013
                },
                new Game {
                    Id = 3,
                    Title = "Red Dead Redemption II",
                    Year = 2018
                }
            };

        public IEnumerable<Game> FindAll()
        {
            return _data;
        }

        public Game FindById(int id)
        {
            return _data.SingleOrDefault(g => g.Id == id);
        }
    }
}