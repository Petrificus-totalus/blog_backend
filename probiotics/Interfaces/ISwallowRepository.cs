using probiotics.Models;
using probiotics.Dtos;
using probiotics.Dtos.Swallow;
using probiotics.Models;

namespace probiotics.Interfaces;

public interface ISwallowRepository
{
    Task<PagedResultDto<SwallowDto>> GetAllAsync(int pageNumber, int pageSize);
    Task<Swallow> GetByIdAsync(int id);
    Task<Swallow> CreateAsync(Swallow swallowModel);

    Task<bool> SwallowExist(int id);
}