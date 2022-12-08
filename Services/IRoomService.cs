using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management
{
    public interface IRoomService
    {
        List<Room> Get();
        Room Get(string id);
        Room Create(Room room);
        Room Update(string id, Room room);
        void Remove(string id);

    }
}
