using System;
using System.Collections.Generic;
using System.Linq;
using SurvivorShop.models;
using SurvivorShop.repository.interfaces;

namespace SurvivorShop.repository{
    public class ArmourRepository : IArmourRepository
    {
        private readonly List<ArmourModel> armours = new(){
            new ArmourModel(){Id = Guid.NewGuid(), Name = "Helmet I",Attribute="Strength",BuffedAttribute=1,ProtectionValue=1,Price=3},
            new ArmourModel(){Id = Guid.NewGuid(), Name = "Chestplate I",Attribute="Agility",BuffedAttribute=1,ProtectionValue=3,Price=5},
            new ArmourModel(){Id = Guid.NewGuid(), Name = "Pants I",Attribute="Intelligence",BuffedAttribute=1,ProtectionValue=2,Price=4},
            new ArmourModel(){Id = Guid.NewGuid(), Name = "Boots I",Attribute="Luck",BuffedAttribute=1,ProtectionValue=1,Price=2},
        };

        public void addArmour(ArmourModel armourModel)
        {
            armours.Add(armourModel);
        }

        public void deleteArmour(Guid id)
        {
            int i = armours.FindIndex(armour => armour.Id == id);
            armours.RemoveAt(i);
        }

        public ArmourModel getArmour(Guid id)
        {
            // devuelve una secuencia de valores con un unico valor
            // singleordefault devuelve el item si solo hay un valor y null si hay ninguno, excepcion si hay mas de uno
            ArmourModel armour = armours.Where(armour => armour.Id == id).SingleOrDefault();
            
            return armour;
        }

        public IEnumerable<ArmourModel> getArmours()
        {
            return armours;
        }

        public void updateArmour(ArmourModel armourModel)
        {
            int i = armours.FindIndex(armour => armour.Id == armourModel.Id);
            armours[i] = armourModel;
        }
    }
}