namespace GameLibraryAPI.DTO
{
    public class GameRequest
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Completion { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public List<ConsoleRequest> ConsolesList { get; set; }
    }
}
