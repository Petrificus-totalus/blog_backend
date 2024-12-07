using probiotics.Data;
using probiotics.Dtos.Tag;
using probiotics.Interfaces;
using probiotics.Mappers;
using Microsoft.EntityFrameworkCore;

namespace probiotics.Repository;

public class SpendTagRepository: ISpendTagRepository
{
    private readonly ApplicationDBContext _context;

    public SpendTagRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<List<TagDto>> GetAllAsync()
    {
        return await _context.Tag.Select(c=>c.ToTagDto()).ToListAsync();
    }
}