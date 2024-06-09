using System;
using System.Security.Claims;

namespace SomerenModel
{
    public class Lecture
    {
        private int lectureID;
        public int LectureID { get { return lectureID; } set { lectureID = value; } }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string RoomNumber { get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public Lecture(int lectureID, string firstName, string lastName, int age, string phoneNumber, string roomNumber)
        {
            LectureID = lectureID;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PhoneNumber = phoneNumber;
            RoomNumber = roomNumber;
        }

        public override string ToString()
        {
            return $"{LectureID} {FullName} ";
        }
    }
}