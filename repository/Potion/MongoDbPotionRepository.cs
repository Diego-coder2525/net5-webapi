using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SurvivorShop.models;
using SurvivorShop.repository.interfaces;

namespace SurvivorShop.repository.Potion
{
    public class MongoDbPotionRepository : IPotionRepository
    {
        //
        private const string databaseName = "survivorshop";
        private const string collectionName = "potions";
        //
        private readonly IMongoCollection<PotionModel> potionCollection;
        private readonly FilterDefinitionBuilder<PotionModel> filterBuilder = Builders<PotionModel>.Filter;
        //
        public MongoDbPotionRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            potionCollection = database.GetCollection<PotionModel>(collectionName);
        }

        public void addPotion(PotionModel potionModel)
        {
            potionCollection.InsertOne(potionModel);
        }

        public void deletePotion(Guid id)
        {
            var filter = filterBuilder.Eq(potion => potion.Id, id);
            potionCollection.DeleteOne(filter);
        }

        public PotionModel getPotion(Guid id)
        {
            var filter = filterBuilder.Eq(potion => potion.Id, id);
            return potionCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<PotionModel> getPotions()
        {
            return potionCollection.Find(new BsonDocument()).ToList();
        }

        public void updatePotion(PotionModel potionModel)
        {
            var filter = filterBuilder.Eq(potion => potion.Id, potionModel.Id);
            potionCollection.ReplaceOne(filter, potionModel);
        }
    }
}