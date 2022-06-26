using GameLibraryAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly DataContext _context;
        public GameController(DataContext context)
        {
            _context = context;
        }

        #region Get methods
        [HttpGet]
        public async Task<ActionResult<List<Game>>> Get()
        {
            return Ok(await _context.Games.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> Get(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return BadRequest("Game not found");
            }
            return Ok(game);
            
        }

        [HttpGet("name")]
        public async Task<ActionResult<List<Game>>> Get(string name)
        {
            var games = await _context.Games.Where(x => x.Name.Contains(name)).ToListAsync();
            return Ok(games);
        }

        #endregion

        [HttpDelete("{id}")]
        public async  Task<ActionResult> Delete(int id)
        {
            var game = _context.Games.Find(id);
            if (game == null)
            {
                return BadRequest("Game not found");
            }
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return Ok("Game has been deleted");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateGame(Game request)
        {
            var game = await _context.Games.FindAsync(request.Id);
            if(game == null)
            {
                return BadRequest("Game not found");
            }
            game.Id = request.Id;
            game.Name = request.Name;
            game.Publisher = request.Publisher;
            game.Genre = request.Genre;
            game.Completion = request.Completion;
            
            await _context.SaveChangesAsync();
            return Ok("Game has been updated");
        }

        [HttpPost]
        public async Task<ActionResult> AddGame(Game request)
        {
            var game = request;
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return Ok("Game has been added");
        }
    }
}
