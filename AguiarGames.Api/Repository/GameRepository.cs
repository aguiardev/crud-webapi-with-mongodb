using AguiarGames.Api.Entity;
using AguiarGames.Api.Models;
using AguiarGames.Api.Repository.Interface;
using MongoDB.Driver;
using System;
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

        public async Task<IList<Game>> GetAllAsync()
            => await _collection.Find(c => true).ToListAsync();
        
        public async Task<Game> GetByIdAsync(string id)
            => await _collection.Find(document => document.Id == id).FirstOrDefaultAsync();

        public async Task<IList<Game>> GetByFiltersAsync(string title, DateTime? release, bool? offer, decimal? price)
        {
            var mainFilter = new List<FilterDefinition<Game>>();

            if(!string.IsNullOrEmpty(title))
                mainFilter.Add(Builders<Game>.Filter.Eq(x => x.Title, title));

            if(release.HasValue)
                mainFilter.Add(Builders<Game>.Filter.Eq(x => x.Release, release));

            if(offer.HasValue)
                mainFilter.Add(Builders<Game>.Filter.Eq(x => x.Offer, offer));

            if(price.HasValue)
                mainFilter.Add(Builders<Game>.Filter.Eq(x => x.Price, price));
            
            var combinedFilters = Builders<Game>.Filter.And(mainFilter);
            
            return await _collection.Find(combinedFilters).ToListAsync();
        }

        public async Task CreateAsync(Game game)
            => await _collection.InsertOneAsync(game);

        public async Task DeleteAsync(string id)
            => await _collection.DeleteOneAsync(c => c.Id == id);

        public async Task UpdateAsync(string id, Game game)
            => await _collection.ReplaceOneAsync(c => c.Id == id, game);
    }
}