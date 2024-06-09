using SomerenDAL;
using SomerenModel;
using System.Collections.Generic;

namespace SomerenService
{
    public class StudentService
    {
        private StudentDao studentdb;

        public StudentService()
        {
            studentdb = new StudentDao();
        }

        public List<Student> GetStudents()
        {
            List<Student> students = studentdb.GetAllStudents();
            return students;
        }

        public void UpdateStudent(Student selectedStudent, Student updatedStudent)
        {
            studentdb.UpdateStudentData(selectedStudent, updatedStudent);
        }

        public void DeleteStudent(Student selectedStudent)
        {
            studentdb.DeleteStudentData(selectedStudent);
        }

        public void AddNewStudent(Student studentNewData)
        {
            studentdb.AddNewStudent(studentNewData);
        }
    }
}