using probiotics.Data;
using probiotics.Interfaces;
using probiotics.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace probiotics.Controllers;


[Route("api/algolabel")]
[ApiController]
public class AlgoLabelController: ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly IAlgoLabelRepository _algoLabelRepo;

    public AlgoLabelController(ApplicationDBContext context, IAlgoLabelRepository algoLabelRepo)
    {
        _context = context;
        _algoLabelRepo = algoLabelRepo;
    }
    [HttpGet]  
    public async Task<IActionResult> GetAll()
    {
        var tags = await _algoLabelRepo.GetAllAsync();
        var tagDto = tags.Select(s=>s.ToAlgoLabelDto());
        return Ok(tagDto);
    }

    
}