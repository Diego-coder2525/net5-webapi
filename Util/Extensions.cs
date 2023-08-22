using SurvivorShop.Dtos;
using SurvivorShop.models;

namespace SurvivorShop.Util{
    public static class Extensions{
        public static ArmourDto asArmourDto(this ArmourModel armourModel){
            return new ArmourDto(){
                Id = armourModel.Id,
                Name = armourModel.Name,
                Attribute = armourModel.Attribute,
                BuffedAttribute = armourModel.BuffedAttribute,
                ProtectionValue = armourModel.ProtectionValue,
                Price = armourModel.Price
            };
        }
        public static PotionDto asPotionDto(this PotionModel potionModel){
            return new PotionDto(){
                Id = potionModel.Id,
                Name = potionModel.Name,
                Price = potionModel.Price,
                Type = potionModel.Type
            };
        }
    }
}