using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AutoMapper;

namespace _17_automapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IMapper _mapper;

        static IEnumerable<Game> games;

        static GameController()
        {
            var rockstar = new Publisher { Id = 1, Name = "Rockstar Games" };
            var naughtyDogg = new Publisher { Id = 2, Name = "Naughty Dogg" };
            games = new List<Game>
            {
                new Game { Id = 1, Title = "Red Dead Redemption", Publisher = rockstar },
                new Game { Id = 2, Title = "The Last of Us", Publisher = naughtyDogg },
                new Game { Id = 3, Title = "Red Dead Redemption II", Publisher = rockstar }
            };
        }

        public GameController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("single")]
        public GameViewModel GetSingle()
        {
            var game = _mapper.Map<GameViewModel>(games.First());
            return game;
        }

        [HttpGet("all")]
        public IEnumerable<GameViewModel> GetAll()
        {
            var rockstar = new Publisher { Id = 1, Name = "Rockstar Games" };
            var naughtyDogg = new Publisher { Id = 2, Name = "Naughty Dogg" };
            var games = new List<Game>
            {
                new Game { Id = 1, Title = "Red Dead Redemption", Publisher = rockstar },
                    new Game { Id = 2, Title = "The Last of Us", Publisher = naughtyDogg },
                    new Game { Id = 3, Title = "Red Dead Redemption II", Publisher = rockstar }
            };

            var gameList = _mapper.Map<IEnumerable<GameViewModel>>(games);
            return gameList;
        }
    }
}
