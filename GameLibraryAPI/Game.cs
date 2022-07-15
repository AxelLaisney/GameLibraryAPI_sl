using System.Text.Json.Serialization;

namespace GameLibraryAPI
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public enum _Genre { All, Platformer, Horror, Rpg, Survival, Vr, Roguelike, Adventure, Exploration}
        public enum _Completion { All, NotStarted, OnGoing, Finished, Todo}

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public _Genre Genre { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public _Completion Completion { get; set; }
        public string Cover { get; set; }
        public string Console { get; set; }

 
    }
}
