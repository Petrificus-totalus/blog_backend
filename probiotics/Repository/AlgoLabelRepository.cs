using probiotics.Data;
using probiotics.Interfaces;
using probiotics.Models;
using Microsoft.EntityFrameworkCore;

namespace probiotics.Repository;

public class AlgoLabelRepository: IAlgoLabelRepository
{
    private readonly ApplicationDBContext _context;
    public AlgoLabelRepository(ApplicationDBContext DBContext)
    {
        _context = DBContext;
    }
    public async Task<List<Label>> GetAllAsync()
    {
        return await _context.Labels.ToListAsync();
    }
}