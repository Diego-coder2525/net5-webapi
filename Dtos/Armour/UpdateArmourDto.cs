using System;

namespace SurvivorShop.Dtos
{
    public record UpdateArmourDto{
        public string Name {get;init;}
        public string Attribute {get;set;}
        public int ProtectionValue {get;init;}
        public int BuffedAttribute {get;init;}
        public int Price{get;init;}
    }
}