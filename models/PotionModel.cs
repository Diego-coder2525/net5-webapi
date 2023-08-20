using System;

namespace SurvivorShop.models
{
    public record PotionModel
    {
        private Guid Id { get; init; }
        private string Name { get; init; }
        private string Type { get; init; }
        private int Price { get; init; }
    }
}