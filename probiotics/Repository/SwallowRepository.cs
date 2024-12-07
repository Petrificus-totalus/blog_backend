using probiotics.Data;
using probiotics.Dtos;
using probiotics.Dtos.Algorithm;
using probiotics.Dtos.Swallow;
using probiotics.Interfaces;
using probiotics.Mappers;
using probiotics.Models;
using Microsoft.EntityFrameworkCore;

namespace probiotics.Repository;

public class SwallowRepository: ISwallowRepository
{

    private readonly ApplicationDBContext _context;
    public SwallowRepository(ApplicationDBContext dbContext)
    {
        _context = dbContext;
    }
    public async Task<PagedResultDto<SwallowDto>> GetAllAsync(int pageNumber, int pageSize)
    {
        int totalRecords = await _context.Swallow.CountAsync();
        // 计算总页数
        int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

        var data =  await _context.Swallow.OrderByDescending(c => c.Id)
            .Skip((pageNumber - 1) * pageSize) // 跳过前面的记录
            .Take(pageSize).Select(c=>c.ToSwallowDto()).ToListAsync();
        return new PagedResultDto<SwallowDto>
        {
            TotalPages = totalPages,
            Data = data
        };
    }

    public async Task<Swallow> GetByIdAsync(int id) 
    {
        return await _context.Swallow.Include(c=>c.Links).FirstOrDefaultAsync(x=>x.Id == id);
    }

    public async Task<Swallow> CreateAsync(Swallow swallowModel)
    {
        await _context.Swallow.AddAsync(swallowModel);
        await _context.SaveChangesAsync();
        return swallowModel;
    }

    public Task<bool> SwallowExist(int id)
    {
       return _context.Swallow.AnyAsync(s=>s.Id == id);
    }
}