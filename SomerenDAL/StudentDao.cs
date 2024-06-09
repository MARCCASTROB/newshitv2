using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class StudentDao : BaseDao
    {
        public List<Student> GetAllStudents()
        {
            string query = @"
                SELECT StudentNumber, FirstName,LastName, PhoneNumber, Class, RoomNumber 
                FROM STUDENT;
            ";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters); 

            return ReadTablesStudent(dataTable );
        }
        

        public void DeleteStudentData(Student studentToDelete)
        {
            string query = @"
                DELETE FROM PARTICIPATES 
                WHERE StudentNumber = @SelectedStudentID;

                UPDATE ORDERS 
                SET StudentNumber = NULL 
                WHERE StudentNumber = @SelectedStudentID;

                DELETE FROM STUDENT 
                WHERE StudentNumber = @SelectedStudentID;
            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@SelectedStudentID", studentToDelete.StudentId)
            };

            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }

        public void AddNewStudent(Student studentNewData)
        {
            string query = @"
                             INSERT INTO STUDENT(StudentNumber, FirstName, LastName, PhoneNumber, class, RoomNumber) 
                             VALUES
                             (@StudentNumber, @FirstName, @LastName, @PhoneNumber, @class, @RoomNumber);

            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@StudentNumber", studentNewData.StudentId),
                new SqlParameter("@FirstName", studentNewData.FirstName),
                new SqlParameter("@LastName", studentNewData.LastName),
                new SqlParameter("@PhoneNumber", studentNewData.PhoneNumber),
                new SqlParameter("@class", studentNewData.Class),
                new SqlParameter("@RoomNumber", studentNewData.RoomNumber)
            };

            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }


        public void UpdateStudentData(Student selectedStudent, Student studentToUpdate)
        {
            string query = @"
                UPDATE STUDENT 
                SET 
                    StudentNumber = @StudentNumberNew,
                    FirstName = @FirstName,
                    LastName = @LastName,
                    PhoneNumber = @PhoneNumber,
                    Class = @Class,
                    RoomNumber = @RoomNumber
                WHERE 
                    StudentNumber = @StudentNumberOld;

                UPDATE PARTICIPATES 
                SET 
                    StudentNumber = @StudentNumberNew
                WHERE 
                    StudentNumber = @StudentNumberOld;

                UPDATE ORDERS 
                SET 
                    StudentNumber = @StudentNumberNew
                WHERE 
                    StudentNumber = @StudentNumberOld;
        ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@StudentNumberOld", selectedStudent.StudentId),
                new SqlParameter("@StudentNumberNew", studentToUpdate.StudentId),
                new SqlParameter("@FirstName", studentToUpdate.FirstName),
                new SqlParameter("@LastName", studentToUpdate.LastName),
                new SqlParameter("@PhoneNumber", studentToUpdate.PhoneNumber),
                new SqlParameter("@Class", studentToUpdate.Class),
                new SqlParameter("@RoomNumber", studentToUpdate.RoomNumber)
            };

            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }

        private List<Student> ReadTablesStudent(DataTable dataTable)
        {
            List<Student> studentsList = new List<Student>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Student student = new Student(
                   (int)dr["StudentNumber"],
                   dr["FirstName"].ToString(),
                   dr["LastName"].ToString(),
                   dr["PhoneNumber"].ToString(),
                   dr["Class"].ToString(),
                   dr["RoomNumber"].ToString()
               );
                studentsList.Add(student);
            }
            return studentsList;
        }
    }
}