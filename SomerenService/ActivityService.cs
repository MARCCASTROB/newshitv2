using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class ActivityService
    {
        private ActivityEventDao activitydb;

        public ActivityService()
        {
            activitydb = new ActivityEventDao();
        }

        public List<Activity> GetActivities()
        {
            List<Activity> activityList = activitydb.GetAllActivities();
            return activityList;

        }

        public List<ActivityParticipants> GetActivityParticipatants(string activityID, DateTime activityDate)
        {
            List<ActivityParticipants> activityParticipantsList = activitydb.GetAllActivityParticipants(activityID, activityDate);
            return activityParticipantsList;
        }

        public List<ActivitySupervisors> GetActivitySupervisors(string activityID, DateTime activityDate)
        {
            List<ActivitySupervisors> activitySupervisorsList = activitydb.GetAllActivitySupervisors(activityID, activityDate);
            return activitySupervisorsList;
        }

       

        public void AddActivitySupervisor(Lecture newLectureSupervisor, string activityID, DateTime activityDate)
        {
            activitydb.AddActivitySupervisor(newLectureSupervisor, activityID, activityDate);
        }

        public void AddActivityParticipator(Student newStudentParticipant, string activityID, DateTime activityDate)
        {
            activitydb.AddActivityParticipator(newStudentParticipant, activityID, activityDate);
        }

        public void DeleteActivitySupervisor(int selectedSupervisorLectureID, string activityID, DateTime activityDate)
        {
            activitydb.DeleteActivitySupervisor(selectedSupervisorLectureID, activityID, activityDate);
        }

        public void DeleteActivityParticipator(int selectedParticipantStudentID, string activityID, DateTime activityDate)
        {
            activitydb.DeleteActivityParticipator(selectedParticipantStudentID, activityID, activityDate);
        }
    }
}