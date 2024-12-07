using probiotics.Data;
using probiotics.Dtos.Spend;
using probiotics.Interfaces;
using probiotics.Mappers;
using probiotics.Models;
using probiotics.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace probiotics.Controllers;
[Route("api/spend")]
[ApiController]
public class SpendController: ControllerBase
{
    
    private readonly ApplicationDBContext _context;
    private readonly ISpendRepository  _spendRepo;
    public SpendController(ApplicationDBContext context, ISpendRepository spendRepo)
    {
        _context = context;
        _spendRepo = spendRepo;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationParams paginationParams)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var spends = await  _spendRepo.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);
        return Ok(spends);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var spendDetailDto = await _spendRepo.GetByIdAsync(id);
        if(spendDetailDto == null) return NotFound();
        return Ok(spendDetailDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSpendDto createSpendDto)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var spend = await  _spendRepo.CreateAsync(createSpendDto);
        return Ok(spend.ToSpendDto());
    }
}