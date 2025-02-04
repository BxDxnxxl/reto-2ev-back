using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Service
{
    public interface ITipoAlimentoService
    {
        Task<List<TipoAlimento>> GetAllAsync();
        Task<TipoAlimento?> GetByIdAsync(int id);
        Task AddAsync(TipoAlimento tipoAlimento);
        Task UpdateAsync(TipoAlimento tipoAlimento);
        Task DeleteAsync(int id);
    }
}
