using System.Globalization;
using probiotics.Data;
using probiotics.Dtos.SpendChart;
using probiotics.Interfaces;
using probiotics.Utils;
using Microsoft.EntityFrameworkCore;

namespace probiotics.Repository;

public class SpendChartRepository: ISpendChartRepository
{
    private readonly ApplicationDBContext _context;

    public SpendChartRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<List<SpendChartDto>> GetAllAsync(string item)
    {
        DateTime startDate = item switch
        {
            "week" => DateTime.Now.AddDays(-7 * 20), // 20 周以内
            "month" => DateTime.Now.AddMonths(-12), // 12 个月以内
            _ => DateTime.Now.AddDays(-30) // 默认 30 天以内
        };

        // if (item == "week")
        // {
        //     // 按周分组
        //     var filtered = await _context.Spend
        //         .Where(s => s.CreateTime >= startDate).Select(c=> new
        //         {
        //             creatTime = c.CreateTime,
        //             week = ISOWeek.GetWeekOfYear(c.CreateTime),
        //             price = c.Price,
        //         }).ToListAsync();
        //     
        //     return await filtered.AsQueryable()// 过滤 20 周以内的数据
        //         .GroupBy(s => new
        //         {
        //             Year = s.creatTime.Year,
        //             Week = s.week // 获取 ISO 周
        //         })
        //         .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Week) // 按年和周排序
        //         .Select(g => new SpendChartDto
        //         {
        //             CreateTime = DateUtils.FirstDateOfWeekISO8601(g.Key.Year, g.Key.Week).ToString("yyyy-MM-dd"), // 该周的第一天
        //             Price = g.Sum(s => s.price) // 计算该周的总价
        //         })
        //         .ToListAsync();
        // }
        if (item == "month")
        {
            // 按月分组
            return await _context.Spend
                .Where(s => s.CreateTime >= startDate) // 过滤 12 个月以内的数据
                .GroupBy(s => new
                {
                    Year = s.CreateTime.Year,
                    Month = s.CreateTime.Month // 获取月份
                })
                .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month) // 按年和月排序
                .Select(g => new SpendChartDto
                {
                    CreateTime = $"{CultureInfo.GetCultureInfo("en-US").DateTimeFormat.GetMonthName(g.Key.Month)} {g.Key.Year}", // 月份的英文名 + 年份
                    Price = g.Sum(s => s.Price) // 计算该月的总价
                })
                .ToListAsync();
        }

        // 默认返回按天分组
        return await _context.Spend
            .Where(s => s.CreateTime >= startDate) // 根据时间范围过滤
            .GroupBy(s => s.CreateTime.Date) // 按日期分组
            .OrderBy(g => g.Key) // 按日期排序
            .Select(g => new SpendChartDto
            {
                CreateTime = g.Key.ToString("yyyy-MM-dd"), // 分组的日期
                Price = g.Sum(s => s.Price) // 分组内的价格总和
            })
            .ToListAsync();
    }

}