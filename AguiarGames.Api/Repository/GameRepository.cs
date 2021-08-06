using AguiarGames.Api.Entity;
using AguiarGames.Api.Models;
using AguiarGames.Api.Repository.Interface;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AguiarGames.Api.Repository
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(IDatabaseSettings settings)
            : base(settings.ConnectionString, settings.DatabaseName, settings.GamesCollectionName)
        {
            
        }

        public async Task<IList<Game>> GetAll()
            => await _collection.Find(c => true).ToListAsync();
        
        public async Task<Game> GetById(string id)
            => await _collection.Find(document => document.Id == id).FirstOrDefaultAsync();

        public async Task Create(Game game)
            => await _collection.InsertOneAsync(game);

        public async Task Delete(string id)
            => await _collection.DeleteOneAsync(c => c.Id == id);

        public async Task Update(string id, Game game)
            => await _collection.ReplaceOneAsync(c => c.Id == id, game);
    }
}