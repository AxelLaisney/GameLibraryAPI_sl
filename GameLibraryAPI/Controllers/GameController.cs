using GameLibraryAPI.Data;
using GameLibraryAPI.DTO;
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
        public async Task<ActionResult<List<Game>>> GetGame()
        {
            var Initialresults = await _context.Games.Include(g => g.Genre).Include(g => g.Consoles).ToListAsync();
            //var Initialresults = await _context.Games.ToListAsync();
            List<GameResult> Results = new List<GameResult>();
            foreach (Game InitialResult in Initialresults)
            {
                GameResult GameResult= new GameResult(InitialResult);
                Results.Add(GameResult);
            }
            return Ok(Results);
        }

        #endregion

        #region Delete method
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGame(int id)
        {
            var game = await _context.Games.Include(g => g.Genre).Include(g => g.Consoles).FirstOrDefaultAsync(g => g.GameId == id);
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
        public async Task<ActionResult> UpdateGame(GameRequest request)
        {
            GameRequest gameRequest = request;
            List<Console> GameConsoles = new List<Console>();
            foreach(ConsoleRequest requestConsole in request.ConsolesList)
            {
                Console console = await _context.Consoles.FindAsync(requestConsole.ConsoleId);
                GameConsoles.Add(console);
            }
            Game game = await _context.Games.Include(g => g.Genre).Include(g => g.Consoles).FirstOrDefaultAsync(g => g.GameId == gameRequest.GameId);
            if (game == null)
            {
                return BadRequest("Game not found");
            }

            game.Name = gameRequest.Name;
            game.Publisher = gameRequest.Publisher;
            game.ReleaseDate = gameRequest.ReleaseDate;
            game.GenreId = gameRequest.GenreId;
            game.Completion = gameRequest.Completion;
            game.Consoles = GameConsoles;
                
            
            await _context.SaveChangesAsync();
            return Ok("Game has been updated");
        }
        #endregion

        #region Post method
        [HttpPost]
        public async Task<ActionResult> AddGame(GameRequest request)
        {
            List<Console> Consoles = new List<Console>();
            foreach(ConsoleRequest consoleRequest in request.ConsolesList)
            {
                Console console = await _context.Consoles.FindAsync(consoleRequest.ConsoleId);
                Consoles.Add(console);
            }

            Game game = new Game()
            {
                Name = request.Name,
                Publisher = request.Publisher,
                Completion = request.Completion,
                GenreId = request.GenreId,
                Consoles = Consoles,
                ReleaseDate = request.ReleaseDate
            };
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return Ok("Game has been added");
        }
        #endregion
    }
}
