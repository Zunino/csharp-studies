using System.Collections.Generic;
using System.Threading.Tasks;
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

        [HttpGet("/games")]
        public async Task<IEnumerable<Game>> GetGames()
        {
            return await _gameRepository.FindAll();
        }

        [HttpGet("/game/{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            var game = await _gameRepository.FindById(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }
    }
}