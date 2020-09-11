using MongoDB.Bson.Serialization.Attributes;
using NutritionManager.DataStore.Mongo.Common;

namespace NutritionManager.DataStore.Mongo.Nutrients
{
    public class NutrientModel : DbObjectBase
    {
        [BsonElement] public string NutrientId { get; set; }  = string.Empty;

        [BsonElement] public string Title { get; set; } = string.Empty;

        [BsonElement] public bool IsDeleted { get; set; }
    }
}