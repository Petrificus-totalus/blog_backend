using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace probiotics.Dtos.Swallow;

public class CreateSwallowDto
{
    [Required]
    [MaxLength(255, ErrorMessage = "Cannot be longer than 255 characters.")]
    public string Restaurant { get; set; } = string.Empty; 
    [Required]
    [Range(0.0,5.0)]
    public decimal Rating { get; set; } 
    [MaxLength(500)]
    public string? Summary { get; set; } 
    public string? Review { get; set; } 
    public string? CoverImage { get; set; } 
    public DateTime CreateTime { get; set; } = DateTime.Now; 
}