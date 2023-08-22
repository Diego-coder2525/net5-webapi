using System;

namespace SurvivorShop.models
{
    public record PotionModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Type { get; init; }
        public int Price { get; init; }
    }
}