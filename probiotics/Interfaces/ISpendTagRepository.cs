using probiotics.Dtos.Tag;

namespace probiotics.Interfaces;

public interface ISpendTagRepository
{
    Task<List<TagDto>> GetAllAsync();
}