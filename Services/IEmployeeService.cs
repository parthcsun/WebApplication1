using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management
{
    public interface IEmployeeService
    {
        List<Employee> Get();
        Employee Get(string id);
        Employee Create(Employee employee);
        void Update(string id, Employee employee);
        void Remove(string id);
        Employee GetByEmployeeId(string employeeId);

       



    }
}
