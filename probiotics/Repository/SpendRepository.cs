using probiotics.Data;
using probiotics.Dtos;
using probiotics.Dtos.Picture;
using probiotics.Dtos.Spend;
using probiotics.Interfaces;
using probiotics.Mappers;
using probiotics.Models;
using Microsoft.EntityFrameworkCore;

namespace probiotics.Repository;

public class SpendRepository: ISpendRepository
{
    private readonly ApplicationDBContext _context;

    public SpendRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<PagedResultDto<GroupedSpendDto>> GetAllAsync(int pageNumber, int pageSize)
    {
        int totalRecords = await _context.Spend
            .GroupBy(s => s.CreateTime.Date) // 按 CreateTime 日期分组
            .CountAsync(); // 获取分组后的总记录数

        // 计算总页数
        int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
        var spend =  await _context.Spend
            .Include(s => s.SpendTags) // 包含 SpendTags
            .ThenInclude(st => st.Tag).OrderBy(s => s.Id) // 按主键排序，确保一致性
            .GroupBy(s => s.CreateTime.Date) // 按 CreateTime 的日期部分分组
            .OrderByDescending(g => g.Key).Skip((pageNumber - 1) * pageSize) // 跳过前面的记录
            .Take(pageSize).Select(g=> new GroupedSpendDto
            {
                CreateTime = g.Key,
                Total = g.Sum(s => s.Price), // 计算总价
                Items = g.Select(c=>c.ToSpendDto()).ToList()
            }).ToListAsync(); // 取指定数量的记录
        return new PagedResultDto<GroupedSpendDto>
        {
            TotalPages = totalPages,
            Data = spend,
        };

    }

    public async Task<Spend> CreateAsync(CreateSpendDto createSpendDto)
    {
        var spendModel = createSpendDto.ToSpendFromCreateSpendDto();
        await _context.Spend.AddAsync(spendModel);
        await _context.SaveChangesAsync();
        
        if (createSpendDto.Tags.Any())
        {
            // 获取现有的 Tag 实体
            var tags = await _context.Tag
                .Where(t => createSpendDto.Tags.Contains(t.Id))
                .ToListAsync();

            // 创建 SpendTag 实体并指定 SpendId 和 TagId
            var spendTags = tags.Select(tag => new SpendTag
            {
                SpendId = spendModel.Id,
                TagId = tag.Id
            }).ToList();

            // 添加 SpendTag 实体到数据库
            await _context.SpendTag.AddRangeAsync(spendTags);
        }
        
        // 处理 Pictures
        if (createSpendDto.PictureLinks.Any())
        {
            var pictures = createSpendDto.PictureLinks.Select(link => new Picture
            {
                Link = link,
                SpendId = spendModel.Id // 指定外键
            }).ToList();

            // 添加 Pictures 到数据库
            await _context.Picture.AddRangeAsync(pictures);
        }

        // 保存所有关联实体
        await _context.SaveChangesAsync();
        
        return spendModel;
    }

    public async Task<SpendDetailDto> GetByIdAsync(int id)
    {
        var spend = await _context.Spend.Include(c => c.Pictures).FirstOrDefaultAsync(c=>c.Id==id);
        if (spend == null)
        {
            return null; // 或者 throw new KeyNotFoundException("Spend not found");
        }

        // 映射为 SpendDetailDto
        return new SpendDetailDto
        {
            Id = spend.Id,
            Description = spend.Description,
            Pictures = spend.Pictures.Select(p => new PictureDto
            {
                Id = p.Id,
                Link = p.Link
            }).ToList()
        };
    }
}