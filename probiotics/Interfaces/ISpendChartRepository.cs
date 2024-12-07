using probiotics.Dtos.SpendChart;

namespace probiotics.Interfaces;

public interface ISpendChartRepository
{
    Task<List<SpendChartDto>> GetAllAsync(string item);
}