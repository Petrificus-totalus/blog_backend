using probiotics.Dtos;
using probiotics.Dtos.Spend;
using probiotics.Models;

namespace probiotics.Interfaces;

public interface ISpendRepository
{
    public Task<PagedResultDto<GroupedSpendDto>> GetAllAsync(int pageNumber, int pageSize);
    public Task<Spend> CreateAsync(CreateSpendDto createSpendDto);
    public Task<SpendDetailDto> GetByIdAsync(int id);
}