using System;
namespace SurvivorShop.Dtos{
    public record CreatePotionDto{
        public string Name {get;init;}
        public string Type {get;init;}
        public int Price {get;init;}
    }
}