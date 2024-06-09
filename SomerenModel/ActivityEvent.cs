using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public abstract class ActivityEvent
    {
        public string ActivityID { get; set; }
        public DateTime ActivityDate { get; set; }

        protected ActivityEvent(string activityID, DateTime activityDate)
        {
            ActivityID = activityID;
            ActivityDate = activityDate;
        }
    }

    public class Activity : ActivityEvent
    {
        public string ActivityName { get; set; }
        public string Location { get; set; }
        public DateTime ActivityDateTime { get; set; }      

        public Activity(string activityID, string activityName, string location, DateTime activityDateTime)
            : base(activityID, activityDateTime)
        {
            ActivityName = activityName;
            Location = location;
            ActivityDateTime = activityDateTime;   
        }
    }

    public class ActivitySupervisors : ActivityEvent
    {
        public int LectureID;
        public string LectureFullName;

        public ActivitySupervisors(string activityID, int lectureid, string lecturefullname, DateTime activityDateTime)
           : base(activityID, activityDateTime)
        {
            LectureID = lectureid;
            LectureFullName = lecturefullname;
        }

        public override string ToString()
        {
            return $"{LectureID} - {LectureFullName}";
        }
    }

    public class ActivityParticipants : ActivityEvent
    {
        public int StudentID;
        public string StudentFullName;

        public ActivityParticipants(string activityID, int studentID, string studentFullName, DateTime activityDateTime)
          : base(activityID, activityDateTime)
        {
            StudentID = studentID;
            StudentFullName = studentFullName;
        }

        public override string ToString()
        {
            return $"{StudentID} - {StudentFullName}";
        }
    }
}


