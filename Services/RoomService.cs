using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management
{
	public class RoomService : IRoomService
	{
		private readonly IMongoCollection<Room> _rooms;

		public RoomService(IHotelStoreDatabaseSettings settings, IMongoClient mongoClient)
		{
			var database = mongoClient.GetDatabase(settings.DatabaseName);
			_rooms = database.GetCollection<Room>(settings.RoomCollectionName);
		}
		
		public Room Create(Room room)
		{
			_rooms.InsertOne(room);
			return room;
		}
		
		public List<Room> Get()
		{
			return _rooms.Find(room => true).ToList();
		}

		public Room Get(string id)
		{
			return _rooms.Find(room => room.Id == id).FirstOrDefault();
		}

		public void Remove(string id)
		{
			_rooms.DeleteOne(room => room.Id == id);
		}

		public Room Update(string id, Room room)
		{
			 _rooms.ReplaceOne(room => room.Id == id, room);

            return _rooms.Find(room => room.Id == id).FirstOrDefault();


        }

     }
}
