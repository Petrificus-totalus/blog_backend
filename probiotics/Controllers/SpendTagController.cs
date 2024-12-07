using probiotics.Data;
using probiotics.Interfaces;
using probiotics.Query;
using Microsoft.AspNetCore.Mvc;

namespace probiotics.Controllers;

[Route("api/tags")]
[ApiController]
public class SpendTagController: ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly ISpendTagRepository _spendTagRepo;
    public SpendTagController(ApplicationDBContext context, ISpendTagRepository spendTagRepo)
    {
        _context = context;
        _spendTagRepo = spendTagRepo;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var tags = await _spendTagRepo.GetAllAsync();
        return Ok(tags);
    }
    
}