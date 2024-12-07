namespace probiotics.Models;

public class AlgoLabel
{
    public int AlgorithmId { get; set; } // 外键
    public Algorithm Algorithm { get; set; } = null!;

    public int LabelId { get; set; } // 外键
    public Label Label { get; set; } = null!;
}