using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GameLibraryAPI
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Completion { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual Genre Genre { get; set; }
        [ForeignKey("GenreId")]
        public int GenreId { get; set; }
        public List<Console> Consoles { get; set; }

 
    }
}
