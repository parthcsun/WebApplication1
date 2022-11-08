using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management
{
    public interface IHotelStoreDatabaseSettings
    {
        string EmployeeCollectionName { get; set; }
        string CustomerCollectionName { get; set; }

        string RoomCollectionName { get; set; }

        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
