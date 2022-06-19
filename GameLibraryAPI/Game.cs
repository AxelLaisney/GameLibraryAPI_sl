using System.Text.Json.Serialization;

namespace GameLibraryAPI
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public enum _Genre { Platformer, Horror, Ppg, Survival, Vr, Roguelike, Adventure, Exploration}
        public enum _Completion { NotStarted, OnGoing, Finished}

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public _Genre Genre { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public _Completion Completion { get; set; }
    }
}
