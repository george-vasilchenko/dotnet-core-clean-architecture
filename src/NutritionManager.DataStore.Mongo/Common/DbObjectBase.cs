using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NutritionManager.DataStore.Mongo.Common
{
    [BsonIgnoreExtraElements]
    public abstract class DbObjectBase
    {
        [BsonId] [BsonIgnoreIfDefault] public ObjectId DbObjectId { get; set; }
    }
}