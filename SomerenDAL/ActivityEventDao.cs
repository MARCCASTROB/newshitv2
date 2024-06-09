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
    public class ActivityEventDao : BaseDao
    {
        public List<Activity> GetAllActivities()
        {
            string query = @"
                            SELECT ActivityID, ActivityName, Location_, Time_ 
                            FROM ACTIVITY;
            ";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);

            return ReadTablesActivity(dataTable);
        }

        private List<Activity> ReadTablesActivity(DataTable dataTable)
        {
            List<Activity> activityList = new List<Activity>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Activity activity = new Activity(
                   dr["ActivityID"].ToString(),
                   dr["ActivityName"].ToString(),
                   dr["Location_"].ToString(),
                  (DateTime) dr["Time_"]
               );
                activityList.Add(activity);
            }
            return activityList;
        }

        public List<ActivitySupervisors> GetAllActivitySupervisors(string activityID, DateTime activityDate)
        {
            DateTime activityDatePlus1 = activityDate.AddDays(1);

            string query = @"
                            SELECT S.ActivityID, S.LectureID, CONCAT(L.FirstName, ' ', L.LastName) AS FullName, S._DateTime As ActivityDate
                             FROM SUPERVISES AS S
                             JOIN Lecture AS L ON S.LectureID = L.LectureID
                             WHERE S._DateTime >= @activityDate
                             AND S._DateTime < @activityDatePlus1
                             AND S.ActivityID = @activityID;

            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@activityDate", activityDate),
                new SqlParameter("@activityDatePlus1", activityDatePlus1),
                new SqlParameter("@activityID", activityID),
            };

            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);

            return ReadTablesActivitySupervisors(dataTable);
        }

        private List<ActivitySupervisors> ReadTablesActivitySupervisors(DataTable dataTable)
        {
            List<ActivitySupervisors> activitySupervisorsList = new List<ActivitySupervisors>();

            foreach (DataRow dr in dataTable.Rows)
            {
                ActivitySupervisors activitySpervisor = new ActivitySupervisors(
                    dr["ActivityID"].ToString(),
                   (int)dr["LectureID"],
                    dr["FullName"].ToString(),
                    (DateTime)dr["ActivityDate"]
               );
                activitySupervisorsList.Add(activitySpervisor);
            }
            return activitySupervisorsList;
        }

        public List<ActivityParticipants> GetAllActivityParticipants(string activityID, DateTime activityDate)
        {
            DateTime activityDatePlus1 = activityDate.AddDays(1);

            string query = @"
                         SELECT P.ActivityID, S.StudentNumber, CONCAT(S.FirstName, ' ', S.LastName) AS FullName, P._DateTime As ActivityDate
                         FROM PARTICIPATES AS P
                         JOIN STUDENT AS S ON S.StudentNumber = P.StudentNumber
                         WHERE P._DateTime >= @activityDate 
                         AND P._DateTime < @activityDatePlus1
                         AND P.ActivityID = @activityID;
                 ";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@activityDate", activityDate),
                new SqlParameter("@activityDatePlus1", activityDatePlus1),
                new SqlParameter("@activityID", activityID),
            };

            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);

            return ReadTablesActivityParticipants(dataTable);
        }

        public void AddActivitySupervisor(Lecture LectureSupervisor, string activityID, DateTime activityDate)
        {
            string query = @"
				INSERT INTO SUPERVISES (ActivityID, LectureID, _DateTime)
				VALUES
				(@activityID, @LectureID, @activityDate );
            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@LectureID", LectureSupervisor.LectureID),
                new SqlParameter("@activityDate", activityDate),
                new SqlParameter("@activityID", activityID)
            };

            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }

        public void DeleteActivitySupervisor(int selectedSupervisorLectureID, string activityID, DateTime activityDate)
        {
            DateTime activityDatePlus1 = activityDate.AddDays(1);

            string query = @"
				DELETE FROM SUPERVISES
				WHERE LectureID = @LectureID
				AND _DateTime >= @activityDate
				AND _DateTime < @activityDatePlus1
				AND ActivityID = @activityID;
            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@LectureID", selectedSupervisorLectureID),
                new SqlParameter("@activityDate", activityDate),
                new SqlParameter("@activityDatePlus1", activityDatePlus1),
                new SqlParameter("@activityID", activityID),
            };

            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }

        public void AddActivityParticipator(Student newStudentParticipant, string activityID, DateTime activityDate)
        {
            string query = @"
				INSERT INTO PARTICIPATES (ActivityID, StudentNumber, _DateTime)
				VALUES
				(@activityID, @StudentID, @activityDate );
            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@StudentID", newStudentParticipant.StudentId),
                new SqlParameter("@activityDate", activityDate),
                new SqlParameter("@activityID", activityID)
            };

            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }

        public void DeleteActivityParticipator(int selectedParticipantStudentID, string activityID, DateTime activityDate)
        {
            DateTime activityDatePlus1 = activityDate.AddDays(1);

            string query = @"
				DELETE FROM PARTICIPATES
				WHERE StudentNumber = @StudentID
				AND _DateTime >= @activityDate
				AND _DateTime < @activityDatePlus1
				AND ActivityID = @activityID;
            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@StudentID", selectedParticipantStudentID),
                new SqlParameter("@activityDate", activityDate),
                new SqlParameter("@activityDatePlus1", activityDatePlus1),
                new SqlParameter("@activityID", activityID),
            };

            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }

        private List<ActivityParticipants> ReadTablesActivityParticipants(DataTable dataTable)
        {
            List<ActivityParticipants> activityParticipantsList = new List<ActivityParticipants>();

            foreach (DataRow dr in dataTable.Rows)
            {
                ActivityParticipants activityParticipant = new ActivityParticipants(               
                     dr["ActivityID"].ToString(),
                      (int)dr["StudentNumber"],
                    dr["FullName"].ToString(),
                    (DateTime)dr["ActivityDate"]
               );
                activityParticipantsList.Add(activityParticipant);
            }
            return activityParticipantsList;
        }
    }
}