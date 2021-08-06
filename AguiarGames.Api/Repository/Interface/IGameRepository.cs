using AguiarGames.Api.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AguiarGames.Api.Repository.Interface
{
    public interface IGameRepository
    {
        Task<IList<Game>> GetAll();
        Task<Game> GetById(int id);
        Task Create(Game customer);
        Task Update(int id, Game customer);
        Task Delete(int id);
    }
}