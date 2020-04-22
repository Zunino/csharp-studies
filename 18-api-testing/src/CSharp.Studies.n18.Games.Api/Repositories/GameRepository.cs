using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Game>> FindAll()
        {
            return await Task.FromResult(_data);
        }

        public async Task<Game> FindById(int id)
        {
            return await Task.FromResult(_data.SingleOrDefault(g => g.Id == id));
        }
    }
}