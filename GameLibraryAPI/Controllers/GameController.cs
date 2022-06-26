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

        [HttpGet("{genre?}/{completion?}")]
        public async Task<ActionResult<List<Game>>> Get(int genre, int completion)
        {
            //(int)Enum to cast enum as a readable int
            var games = await _context.Games.Where(x => genre == (int)x.Genre && completion == (int)x.Completion).ToListAsync();
            List<int> Truc = new List<int> { genre, completion };
            return Ok(games);
        }

        [HttpGet("name")]
        public async Task<ActionResult<List<Game>>> Get(string name)
        {
            var games = await _context.Games.Where(x => x.Name.Contains(name)).ToListAsync();
            return Ok(games);
        }

        #endregion

        #region Delete method
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
        #endregion

        #region Put/Update method
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
        #endregion

        #region Post method
        [HttpPost]
        public async Task<ActionResult> AddGame(Game request)
        {
            var game = request;
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return Ok("Game has been added");
        }
        #endregion
    }
}
