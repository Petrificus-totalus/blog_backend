using probiotics.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace probiotics.Controllers;

[ApiController]
[Route("api/upload")]
public class UploadController : ControllerBase
{
    private readonly IS3ServiceRepository _s3Service;

    public UploadController(IS3ServiceRepository s3Service)
    {
        _s3Service = s3Service;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        var url = await _s3Service.UploadFileAsync(file);
        return Ok(new { url });
    }
}
