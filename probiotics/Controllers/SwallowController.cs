using probiotics.Data;
using probiotics.Dtos.Swallow;
using probiotics.Interfaces;
using probiotics.Mappers;
using probiotics.Models;
using probiotics.Query;
using Microsoft.AspNetCore.Mvc;

namespace probiotics.Controllers;

[Route("api/swallow")]
[ApiController]
public class SwallowController: ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly ISwallowRepository _swallRepo;
    public SwallowController(ApplicationDBContext context, ISwallowRepository swallRepo)
    {
        _context = context;
        _swallRepo = swallRepo;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationParams paginationParams)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var swallows = await _swallRepo.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);
        return Ok(swallows);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var swallow = await _swallRepo.GetByIdAsync(id);
        if(swallow == null) return NotFound();
        return Ok(swallow.ToSwallowDetailDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSwallowDto swallowModel)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var swallow = swallowModel.ToSwallowFromCreateSwallowDto();
        await _swallRepo.CreateAsync(swallow);
        return CreatedAtAction(nameof(GetById), new { id = swallow.Id }, swallow.ToSwallowDto());
    }

}