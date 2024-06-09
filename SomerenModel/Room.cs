using System.Security.Claims;

namespace SomerenModel
{
    public class Room
    {
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public int NumberOfBeds { get; set; }
        public int FloorLevel { get; set; }

        public Room(string roomNumber, string roomType, int numberOfBeds, int floorLevel)
        {
            RoomNumber = roomNumber;
            RoomType = roomType;
            NumberOfBeds = numberOfBeds;
            FloorLevel = floorLevel;
        }

        public override string ToString()
        {
            return $"{RoomNumber} {RoomType} {NumberOfBeds} {FloorLevel}";
        }
    }
}