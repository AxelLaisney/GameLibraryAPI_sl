using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GameLibraryAPI
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        public string Name { get; set; }
        public List<Game> Games { get; set; }
    }
}
