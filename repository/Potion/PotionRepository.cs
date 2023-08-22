using System;
using System.Collections.Generic;
using SurvivorShop.models;
using SurvivorShop.repository.interfaces;

namespace SurvivorShop.repository.Potion{
    public class PotionRepository : IPotionRepository
    {
        
        public void addPotion(PotionModel potionModel)
        {
            throw new NotImplementedException();
        }

        public void deletePotion(Guid id)
        {
            throw new NotImplementedException();
        }

        public PotionModel getPotion(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PotionModel> getPotions()
        {
            throw new NotImplementedException();
        }

        public void updatePotion(PotionModel potionModel)
        {
            throw new NotImplementedException();
        }
    }
}