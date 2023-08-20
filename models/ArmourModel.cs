using System;
using SurvivorShop.Dtos;

namespace SurvivorShop.models{
    public record ArmourModel{
        public Guid Id {get;init;}
        public string Name {get;init;}
        public string Attribute {get;set;}
        public int ProtectionValue {get;init;}
        public int BuffedAttribute {get;init;}
        public int Price{get;init;}

        internal ArmourDto Select()
        {
            throw new NotImplementedException();
        }
    }
}