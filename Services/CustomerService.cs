using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerService(IHotelStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _customers = database.GetCollection<Customer>(settings.CustomerCollectionName);
        }

        public Customer Create(Customer customer)
        {
            _customers.InsertOne(customer);
            return customer;
        }

        public List<Customer> Get()
        {
            return _customers.Find(customer => true).ToList();
        }

        public Customer Get(string id)
        {
            return _customers.Find(customer => customer.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _customers.DeleteOne(customer => customer.Id == id);
        }

        public void Update(string id, Customer customer)
        {
            _customers.ReplaceOne(customer => customer.Id == id, customer);
        }
        
        


    }
}
