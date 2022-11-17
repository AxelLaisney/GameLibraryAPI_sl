namespace GameLibraryAPI.DTO
{
    public class GameResult : GameRequest
    {
        public GameResult(Game game) {
            this.GameId = game.GameId; 
            this.Name = game.Name;
            this.Publisher = game.Publisher;
            this.Completion = game.Completion;
            this.ReleaseDate = game.ReleaseDate;
            this.GenreId = game.GenreId;
            this.GenreName = game.Genre.Name;
            this.ConsolesList = new List<ConsoleRequest>();
            foreach(Console console in game.Consoles)
            {
                ConsoleRequest consoleRequest = new ConsoleRequest()
                {
                    ConsoleId = console.ConsoleId,
                    Name = console.Name,
                    Brand = console.Brand,
                    ReleaseDate = console.ReleaseDate,
                };
                ConsolesList.Add(consoleRequest);
                
            }
        }
        public string GenreName { get; set; }
    
    }
}
