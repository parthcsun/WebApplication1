using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace hotel_management
{
    [BsonIgnoreExtraElements]
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; } = String.Empty;

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("employeeId")]

        public string EmployeeId { get; set; } = String.Empty;

        [BsonElement("password")] 
        public string Password { get; set;}

        
        [BsonElement("salary")]
        public double Salary { get; set; }

        [BsonElement("phone")]

        public string Phone { get; set; } = String.Empty;

        [BsonElement("email")]

        public string Email { get; set; } = String.Empty;

        [BsonElement("address")]

        public string Address { get; set; } = String.Empty;

        [BsonElement("isActive")]

        public Boolean IsActive { get; set; }

        [BsonElement("isAdmin")]

        public Boolean IsAdmin { get; set; }



    }
}