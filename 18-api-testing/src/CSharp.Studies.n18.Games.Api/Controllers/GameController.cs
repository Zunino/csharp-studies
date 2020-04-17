using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CSharp.Studies.n18.Games.Repositories;
using CSharp.Studies.n18.Games.Models;

namespace CSharp.Studies.n18.Games.Controllers
{
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GameRepository _gameRepository;

        public GameController(GameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public IEnumerable<Game> GetGames()
        {
            return _gameRepository.FindAll();
        }
    }
}