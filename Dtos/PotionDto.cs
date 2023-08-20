using System;
namespace SurvivorShop.Dtos{
    public record PotionDto{
        public Guid Id{get;init;}
        public string Name {get;init;}
        public string Type {get;init;}
        public int Price {get;init;}
    }
}