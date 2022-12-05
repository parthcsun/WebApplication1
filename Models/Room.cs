using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace hotel_management
{
    [BsonIgnoreExtraElements]
    public class Room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("type")]
        public string Type { get; set; } = String.Empty;

        [BsonElement("roomDescription")]
        public string RoomDescription { get; set; } = String.Empty;

        [BsonElement("roomNumber")]
        public int RoomNumber { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }
            
        [BsonElement("isActive")]
        public Boolean IsActive { get; set; }

    }

    [BsonIgnoreExtraElements]
    public class RoomNumber
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public int Number { get; set; }
        public Boolean IsAvailable { get; set; }
    }
}