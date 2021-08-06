namespace AguiarGames.Api.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string GamesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string GamesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}