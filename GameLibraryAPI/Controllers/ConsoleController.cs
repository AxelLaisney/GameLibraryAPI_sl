using GameLibraryAPI.Data;
using GameLibraryAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsoleController : Controller
    {
        private readonly DataContext _context;
        public ConsoleController(DataContext context)
        {
            _context = context;
        }

        #region Get method
        [HttpGet]
        public async Task<ActionResult<List<ConsoleResult>>> GetConsole()
        {
            List<Console> Consolelist = await _context.Consoles.ToListAsync();
            List<ConsoleResult> result = new List<ConsoleResult>();
            foreach (Console Console in Consolelist)
            {
                ConsoleResult consoleResult = new ConsoleResult()
                {
                    ConsoleId = Console.ConsoleId,
                    Name = Console.Name,
                    Brand = Console.Brand,
                    ReleaseDate = Console.ReleaseDate
                };
                result.Add(consoleResult);
            }
            return Ok(result);
        }
        #endregion

        #region Post method
        [HttpPost("console")]
        public async Task<ActionResult> AddConsole(ConsoleRequest request)
        {
            Console console = new Console()
            {
                Name = request.Name,
                Brand = request.Brand,
                ReleaseDate = request.ReleaseDate,
            };
            _context.Consoles.Add(console);
            await _context.SaveChangesAsync();
            return Ok("Console has been added");
        }
        #endregion

        #region Put/Update Method
        [HttpPut]
        public async Task<ActionResult> UpdateConsole(ConsoleRequest request)
        {
            ConsoleRequest ConsoleRequest = request;
            Console console = await _context.Consoles.Include(c => c.Games).FirstOrDefaultAsync(c => c.ConsoleId == ConsoleRequest.ConsoleId);
            if( console == null)
            {
                return BadRequest("Console not found");
            }

            console.Name = request.Name;
            console.Brand = request.Brand;
            console.ReleaseDate = request.ReleaseDate;
            
            await _context.SaveChangesAsync();
            return Ok("Console has been updated");
        }
        #endregion

        #region Delete method
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteConsole(int id)
        {
            var console = await _context.Consoles.Include(c => c.Games).FirstOrDefaultAsync(c => c.ConsoleId == id);
            if (console == null)
            {
                return BadRequest("Game not found");
            }
            _context.Consoles.Remove(console);
            await _context.SaveChangesAsync();
            return Ok("Console has been deleted");
        }
        #endregion
    }


}
