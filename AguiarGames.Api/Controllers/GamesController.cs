using AguiarGames.Api.Entity;
using AguiarGames.Api.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AguiarGames.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Description("Games")]
    public class GamesController : ControllerBase
    {
        private readonly ILogger<GamesController> _logger;
        private readonly IGameRepository _gameRepository;

        public GamesController(
            ILogger<GamesController> logger,
            IGameRepository gameRepository)
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var games = await _gameRepository.GetAll();
            
            return games == null || !games.Any()
                ? NotFound()
                : Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if(string.IsNullOrEmpty(id))
                return BadRequest("Invalid game id");

            var game = await _gameRepository.GetById(id);
            
            return game == null
                ? NotFound()
                : Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Game game)
        {
            await _gameRepository.Create(game);

            return CreatedAtAction(
                nameof(GetById),
                new { id = game.Id },
                game
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Game game)
        {
            if(string.IsNullOrEmpty(id))
                return BadRequest("Invalid game id");

            var currentGame = await _gameRepository.GetById(id);
            if(currentGame == null)
                return NotFound();

            await _gameRepository.Update(id, game);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if(string.IsNullOrEmpty(id))
                return BadRequest("Invalid game id");

            var currentGame = await _gameRepository.GetById(id);
            if(currentGame == null)
                return NotFound();

            await _gameRepository.Delete(id);

            return NoContent();
        }
    }
}
