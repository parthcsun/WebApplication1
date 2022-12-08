using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hotel_management
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        public IRoomService roomService;

        public RoomsController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        // GET: api/<RoomsController>
        [HttpGet]

        public ActionResult<List<Room>> Get()
        {
            return roomService.Get();
        }

        // GET api/<RoomsController>/5
        [HttpGet("{id}")]
        public ActionResult<Room> Get(string id)
        {
            var room = roomService.Get(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // POST api/<RoomsController>
        [HttpPost]
        public ActionResult<Room> Create(Room room)
        {
            Room tempRoom = new Room()
            {
                Name = room.Name,
                Type = room.Type,
                RoomDescription = room.RoomDescription,
                RoomImage = room.RoomImage,
                RoomNumber = room.RoomNumber,
                Price = room.Price,
                IsActive = room.IsActive
            };

            var savedRoom = roomService.Create(tempRoom);
            return CreatedAtAction(nameof(Get), new { id = savedRoom.Id }, savedRoom);
        }

        // PUT api/<RoomsController>/5
        [HttpPut]
        public ActionResult<Room> Put(string id,Room roomIn)
        {
            var room = roomService.Get(id);

            if (room == null)
            {
                return NotFound($"Room with Id = {id} not found");
            }

            roomService.Update(id, roomIn);
            var roomm = roomService.Get(id);

            return roomm;
        }

        // DELETE api/<RoomsController>/5

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var room = roomService.Get(id);

            if (room == null)
            {
                return NotFound($"Room with Id = {id} not found");
            }

            roomService.Remove(room.Id);

            return NoContent();
        }
        
        


    }
}
