using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GameLibraryAPI
{
    public class Console
    {
        [Key]
        public int ConsoleId { get; set; }

        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Brand { get; set; }

        public List<Game> Games { get; set; }

    }
}
