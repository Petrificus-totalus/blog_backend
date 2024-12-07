
using probiotics.Models;

namespace probiotics.Interfaces;

public interface IAlgoLabelRepository
{
    Task<List<Label>> GetAllAsync();
}