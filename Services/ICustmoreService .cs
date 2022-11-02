using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management
{
    public interface ICustomerService
    {
        List<Customer> Get();
        Customer Get(string id);
        Customer Create(Customer customer);
        void Update(string id, Customer customer);
        void Remove(string id);
        
    }
}
