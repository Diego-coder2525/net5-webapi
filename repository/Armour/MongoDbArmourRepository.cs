using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SurvivorShop.models;
using SurvivorShop.repository.interfaces;

namespace SurvivorShop.repository
{
    public class MongoDbArmourRepository : IArmourRepository
    {
        //
        private const string databaseName = "survivorshop";
        private const string collectionName = "armours";
        //
        private readonly IMongoCollection<ArmourModel> armourCollection;
        private readonly FilterDefinitionBuilder<ArmourModel> filterBuilder = Builders<ArmourModel>.Filter;
        //
        public MongoDbArmourRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            armourCollection = database.GetCollection<ArmourModel>(collectionName);
        }
        public void addArmour(ArmourModel armourModel)
        {
            armourCollection.InsertOne(armourModel);
        }

        public void deleteArmour(Guid id)
        {
            var filter = filterBuilder.Eq(armour => armour.Id, id);
            armourCollection.DeleteOne(filter);
        }

        public ArmourModel getArmour(Guid id)
        {
            var filter = filterBuilder.Eq(armour => armour.Id, id);
            return armourCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<ArmourModel> getArmours()
        {
            return armourCollection.Find(new BsonDocument()).ToList();
        }

        public void updateArmour(ArmourModel armourModel)
        {
            var filter = filterBuilder.Eq(armour => armour.Id, armourModel.Id);
            armourCollection.ReplaceOne(filter, armourModel);
        }
    }
}