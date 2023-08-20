using System;
using System.Collections;
using System.Collections.Generic;
using SurvivorShop.models;

namespace SurvivorShop.repository.interfaces{
    public interface IPotionRepository{
        // devuelve las potis
        IEnumerable<PotionModel> getPotions();
        // devuelve una poti
        PotionModel getPotion(Guid id);
        // agregar una poti
        void addPotion(PotionModel potionModel);
        // actualizar una poti
        void updatePotion(PotionModel potionModel);
        // eliminar una poti
        void deletePotion(Guid id);
        
    }
}