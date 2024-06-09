using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class RoomDao : BaseDao
    {
        public List<Room> GetAllRooms()
        {
            string query = @"
                            SELECT RoomNumber, RoomType, NumberOfBeds, FloorLevel
                            FROM ROOM;
            ";           
            SqlParameter[] sqlParameters = new SqlParameter[0];

            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters); 

            return ReadTablesRoom(dataTable);
        }


        private List<Room> ReadTablesRoom(DataTable dataTable)
        {
            List<Room> roomsList = new List<Room>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Room room = new Room(
                   dr["RoomNumber"].ToString(),
                   dr["RoomType"].ToString(),
                  (int) dr["NumberOfBeds"],
                  (int) dr["FloorLevel"]
               );
                roomsList.Add(room);
            }
            return roomsList;
        }
    }
}