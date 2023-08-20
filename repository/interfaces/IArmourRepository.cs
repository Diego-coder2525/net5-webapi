using System;
using System.Collections;
using System.Collections.Generic;
using SurvivorShop.models;

namespace SurvivorShop.repository.interfaces{
    public interface IArmourRepository{
        // devuelve las armaduras
        IEnumerable<ArmourModel> getArmours();
        // devuelve una armadura en especifico
        ArmourModel getArmour(Guid id);
        // agrega una armadura
        void addArmour(ArmourModel armourModel);
        // actualiza los detalles de una armadura
        void updateArmour(ArmourModel armourModel);
        // elimina una armadura
        void deleteArmour(Guid id);
    }
}