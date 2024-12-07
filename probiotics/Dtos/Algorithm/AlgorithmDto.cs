using probiotics.Dtos.AlgoTag;
using probiotics.Dtos.Tag;

namespace probiotics.Dtos.Algorithm;

public class AlgorithmDto
{
    public int Id { get; set; }
    public string Desc { get; set; } = string.Empty;
    public List<AlgoLabelDto> Labels { get; set; } = new List<AlgoLabelDto>();
}