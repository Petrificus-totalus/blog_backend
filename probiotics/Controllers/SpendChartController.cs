using probiotics.Data;
using probiotics.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace probiotics.Controllers;
[Route("api/spendchart")]
[ApiController]
public class SpendChartController: ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly ISpendChartRepository _spendChartRepo;

    public SpendChartController(ApplicationDBContext context, ISpendChartRepository spendChartRepo)
    {
        _context = context;
        _spendChartRepo = spendChartRepo;
    }
    
    [HttpGet("{item}")]
    public async Task<IActionResult> GetSpendChart(string item)
    {
        var spendCharts = await _spendChartRepo.GetAllAsync(item);
        return Ok(spendCharts);
    }

}