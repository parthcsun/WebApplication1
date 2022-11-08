using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace hotel_management
{
    [BsonIgnoreExtraElements]
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("gender")]
        public string Gender { get; set; } = String.Empty;

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("identityProof")]

        public string IdentityProof { get; set; } = String.Empty;


        [BsonElement("phone")]

        public string Phone { get; set; } = String.Empty;

        [BsonElement("paymentDetails")]

        public PaymentDetails PaymentDetails { get; set; }

        [BsonElement("isActive")]

        public Boolean IsActive { get; set; }

        internal class InsertOne
        {
            private Customer customer;

            public InsertOne(Customer customer)
            {
                this.customer = customer;
            }
        }
    }

    [BsonIgnoreExtraElements]
    public class PaymentDetails
    {

        public string PaymentMethod { get; set; }

        public string Amount { get; set; }
    }
}