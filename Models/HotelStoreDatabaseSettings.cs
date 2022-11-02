using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management
{
    public class HotelStoreDatabaseSettings : IHotelStoreDatabaseSettings
    {
        public string EmployeeCollectionName { get; set; } = String.Empty;
        public string CustomerCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
        
    }
}
