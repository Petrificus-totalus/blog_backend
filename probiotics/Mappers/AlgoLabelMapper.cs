using probiotics.Dtos.AlgoTag;
using probiotics.Models;

namespace probiotics.Mappers;

public  static class AlgoLabelMapper
{
    public static AlgoLabelDto ToAlgoLabelDto(this Label labelModel)
    {
        return new AlgoLabelDto
        {
            Id = labelModel.Id,
            Name = labelModel.Name,
            
        };
    }
}