using AguiarGames.Api.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AguiarGames.Api.Repository.Interface
{
    public interface IGameRepository
    {
        Task<IList<Game>> GetAllAsync();
        Task<Game> GetByIdAsync(string id);
        Task CreateAsync(Game customer);
        Task UpdateAsync(string id, Game customer);
        Task DeleteAsync(string id);
    }
}