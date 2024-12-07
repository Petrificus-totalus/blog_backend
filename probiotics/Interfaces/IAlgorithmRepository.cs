using probiotics.Dtos;
using probiotics.Dtos.Algorithm;
using probiotics.Models;

namespace probiotics.Interfaces;

public interface IAlgorithmRepository
{
    Task<PagedResultDto<AlgorithmDto>> GetAllAsync(int pageNumber, int pageSize);
    Task<Algorithm?> GetByIdAsync(int id);  // FirstOrDefault can be NULL
    Task<AlgorithmDto> CreateAsync(CreateAlgorithmDto algorithmDto);
    Task<Algorithm?> UpdateAsync(int id, UpdateAlgorithmDto algorithmDto);
    Task<Algorithm?> DeleteAsync(int id);
  
    
}