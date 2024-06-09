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
    public class LectureDao : BaseDao
    {
        public List<Lecture> GetAllLectures()
        {
            string query = "SELECT LectureID, FirstName, LastName, Age, PhoneNumber, RoomNumber FROM LECTURE;";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters); 

            return ReadTablesLecture(dataTable);
        }

        public void UpdateLectureData(Lecture selectedLecture, Lecture lectureToUpdate)
        {
            string query = @"
                UPDATE LECTURE 
                SET 
                    LectureID = @LectureIDNew,
                    FirstName = @FirstName,
                    LastName = @LastName,
                    PhoneNumber = @PhoneNumber,
                    Age = @Age,
                    RoomNumber = @RoomNumber
                WHERE 
                    LectureID = @LectureIDOld;

                UPDATE SUPERVISES 
                SET 
                    LectureID = @LectureIDNew
                WHERE 
                    LectureID = @LectureIDOld;
            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@LectureIDOld", selectedLecture.LectureID),
                new SqlParameter("@LectureIDNew", lectureToUpdate.LectureID),
                new SqlParameter("@FirstName", lectureToUpdate.FirstName),
                new SqlParameter("@LastName", lectureToUpdate.LastName),
                new SqlParameter("@PhoneNumber", lectureToUpdate.PhoneNumber),
                new SqlParameter("@Age", lectureToUpdate.Age),
                new SqlParameter("@RoomNumber", lectureToUpdate.RoomNumber)
            };

            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }

        public void AddNewLecture(Lecture LectureNewData)
        {
            string query = @"INSERT INTO LECTURE (LectureID, FirstName, LastName, Age, PhoneNumber, RoomNumber)
                        VALUES
                        (@LectureID, @FirstName, @LastName, @Age, @PhoneNumber, @RoomNumber);

            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@LectureID", LectureNewData.LectureID),
                new SqlParameter("@FirstName", LectureNewData.FirstName),
                new SqlParameter("@LastName", LectureNewData.LastName),
                new SqlParameter("@Age", LectureNewData.Age),
                new SqlParameter("@PhoneNumber", LectureNewData.PhoneNumber),
                new SqlParameter("@RoomNumber", LectureNewData.RoomNumber)
            };

            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }


        public void DeleteLectureData(Lecture selectedLecture)
        {
           
            string query = @"
                DELETE FROM SUPERVISES 
                WHERE LectureID = @SelectedLectureID;

                DELETE FROM LECTURE 
                WHERE LectureID = @SelectedLectureID;
            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@SelectedLectureID", selectedLecture.LectureID)
            };

            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }


        private List<Lecture> ReadTablesLecture(DataTable dataTable)
        {
            List<Lecture> lecturesList = new List<Lecture>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Lecture lecture = new Lecture(
                   (int)dr["LectureID"],
                   dr["FirstName"].ToString(),
                   dr["LastName"].ToString(),
                  (int) dr["Age"],
                   dr["PhoneNumber"].ToString(),
                   dr["RoomNumber"].ToString()
               );
                lecturesList.Add(lecture);
            }
            return lecturesList;
        }
    }
}