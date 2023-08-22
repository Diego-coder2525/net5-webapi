using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SurvivorShop.Dtos;
using SurvivorShop.models;
using SurvivorShop.repository.interfaces;
using SurvivorShop.Util;

namespace SurvivorShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PotionController : ControllerBase
    {
        //
        private readonly IPotionRepository potionRepository;
        //
        public PotionController(IPotionRepository potionRepository)
        {
            this.potionRepository = potionRepository;
        }
        [HttpGet]
        public IEnumerable<PotionDto> GetPotions()
        {
            var potions = potionRepository.getPotions().Select(potion => potion.asPotionDto());

            return potions;
        }
        [HttpGet("{id}")]
        public ActionResult<PotionDto> GetPotion(Guid id)
        {
            var potion = potionRepository.getPotion(id);
            //
            return potion != null ? potion.asPotionDto() : NotFound();
        }
        [HttpPost]
        public ActionResult<PotionDto> AddPotion(CreatePotionDto potionDto){
            PotionModel potionModel = new(){
                Id = Guid.NewGuid(),
                Name = potionDto.Name,
                Price = potionDto.Price,
                Type = potionDto.Type
            };
            potionRepository.addPotion(potionModel);
            return CreatedAtAction(nameof(GetPotion),new {id = potionModel.Id},potionModel.asPotionDto());
        }
        [HttpPut("{id}")]
        public ActionResult UpdatePotion(Guid id, UpdatePotionDto potionDto)
        {
            var originalPotion = potionRepository.getPotion(id);
            if (originalPotion is null)
            {
                return NotFound();
            }
            PotionModel updatedPotion = originalPotion with
            {
                Name = potionDto.Name,
                Price = potionDto.Price,
                Type = potionDto.Type
            };
            potionRepository.updatePotion(updatedPotion);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeletePotion(Guid id){
            var existingPotion = potionRepository.getPotion(id);
            if(existingPotion is null){
                return NotFound();
            }
            potionRepository.deletePotion(id);
            return NoContent();
        }
    }
}