using GameLibraryAPI.Data;
using GameLibraryAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly DataContext _context;
        public GenreController(DataContext context)
        {
            _context = context;
        }

        #region Get method
        [HttpGet]
        public async Task<ActionResult<List<GenreRequest>>> GetGenre()
        {
            List<Genre> Genrelist = await _context.Genres.ToListAsync();
            List<GenreRequest> result = new List<GenreRequest>();
            foreach (Genre genre in Genrelist)
            {
                GenreRequest genreRequest = new GenreRequest()
                {
                    GenreName = genre.Name,
                    GenreId = genre.GenreId,
                };
                result.Add(genreRequest);
            }
            return Ok(result);
        }
        #endregion

        #region Post method
        [HttpPost("genre")]
        public async Task<ActionResult> AddGenre(GenreRequest request)
        {
            var genreRequest = request;
            Genre genre = new Genre()
            {
                Name = genreRequest.GenreName
            };
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return Ok("Genre has been added");
        }
        #endregion

        #region Put/Update method
        [HttpPut]
        public async Task<ActionResult> UpdateGenre(GenreRequest request)
        {
            GenreRequest genreRequest = request;
            Genre genre = await _context.Genres.FindAsync(genreRequest.GenreId);
            if(genre == null)
            {
                return BadRequest("Genre was not found");
            }
            genre.Name = genreRequest.GenreName;

            await _context.SaveChangesAsync();
            return Ok("Genre has been updated");
        }
        #endregion

        #region Delete method
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return BadRequest("Genre not found");
            }
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return Ok("Genre has been deleted");
        }
        #endregion
    }
}
