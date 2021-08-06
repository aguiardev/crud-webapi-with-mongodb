using AguiarGames.Api.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AguiarGames.Api.Repository.Interface
{
    public interface IGameRepository
    {
        Task<IList<Game>> GetAll();
        Task<Game> GetById(string id);
        Task Create(Game customer);
        Task Update(string id, Game customer);
        Task Delete(string id);
    }
}