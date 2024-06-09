using System;

namespace SomerenModel
{
    public class Student
    {
        private int studentId;
        public int StudentId { get { return studentId; } set { studentId = value; } }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Class { get; set; }
        public string RoomNumber { get; set; }
        
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public Student(int studentId, string firstName, string lastName, string phoneNumber, string studentClass, string roomNumber)
        {
            this.StudentId = studentId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Class = studentClass;
            this.RoomNumber = roomNumber;
        }

        public override string ToString()
        {
            return $"{StudentId} {FullName}";
        }
    }
}