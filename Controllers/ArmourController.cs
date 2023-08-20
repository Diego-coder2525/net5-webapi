using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SurvivorShop.Dtos;
using SurvivorShop.models;
using SurvivorShop.repository;
using SurvivorShop.repository.interfaces;
using SurvivorShop.Util;

namespace SurvivorShop.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class ArmourController : ControllerBase{
        // se puede leer porque no tiene datos dentro ( interfaz )
        private readonly IArmourRepository armourRepository;

        public ArmourController(IArmourRepository armourRepository){
            this.armourRepository = armourRepository;
        }

        [HttpGet]
        public IEnumerable<ArmourDto> GetArmours(){
            var armours = armourRepository.getArmours().Select(armour => armour.asArmourDto());
            return armours;
        }
        [HttpGet("{id}")]
        public ActionResult<ArmourDto> GetArmour(Guid id){
            var armour = armourRepository.getArmour(id);
            if(armour is null){
                return NotFound();
            }
            var armourAsDto = armour.asArmourDto();
            return armourAsDto;
        }
        [HttpPost]
        public ActionResult<ArmourDto> AddArmour(CreateArmourDto armourDto){
            ArmourModel armourModel = new(){
                Id = Guid.NewGuid(),
                Name = armourDto.Name,
                Attribute = armourDto.Attribute,
                BuffedAttribute = armourDto.BuffedAttribute,
                Price = armourDto.Price,
                ProtectionValue = armourDto.ProtectionValue
            };
            armourRepository.addArmour(armourModel);
            return CreatedAtAction(nameof(GetArmour), new { id = armourModel.Id }, armourModel.asArmourDto());
        }
        [HttpPut("{id}")]
        public ActionResult UpdateArmour(Guid id, UpdateArmourDto armourDto){
            var OriginalArmour = armourRepository.getArmour(id);
            if(OriginalArmour is null){
                return NotFound();
            }
            ArmourModel UpdatedArmour = OriginalArmour with {
                Attribute = armourDto.Attribute,
                BuffedAttribute = armourDto.BuffedAttribute,
                Name = armourDto.Name,
                Price = armourDto.Price,
                ProtectionValue = armourDto.ProtectionValue
            };
            armourRepository.updateArmour(UpdatedArmour);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteArmour(Guid id){
            if(armourRepository.getArmour(id) is null){
                return NotFound();
            }
            armourRepository.deleteArmour(id);
            return NoContent();
        }
        
    }
}