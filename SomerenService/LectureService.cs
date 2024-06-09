using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class LectureService
    {
        private LectureDao lecturedb;

        public LectureService()
        {
            lecturedb = new LectureDao();
        }

        public List<Lecture> GetLectures()
        {
            List<Lecture> lectures = lecturedb.GetAllLectures();
            return lectures;
        }

        public void UpdateLecture(Lecture selectedLecture, Lecture updatedLecture)
        {
            lecturedb.UpdateLectureData(selectedLecture, updatedLecture);
        }

        public void DeleteLecture(Lecture selectedLecture)
        {
            lecturedb.DeleteLectureData(selectedLecture);
        }

        public void AddNewLecture(Lecture LectureNewData)
        {
            lecturedb.AddNewLecture(LectureNewData);
        }
    }
}
