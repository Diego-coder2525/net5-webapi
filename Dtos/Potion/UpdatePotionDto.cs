using System;
namespace SurvivorShop.Dtos{
    public record UpdatePotionDto{
        public string Name {get;init;}
        public string Type {get;init;}
        public int Price {get;init;}
    }
}